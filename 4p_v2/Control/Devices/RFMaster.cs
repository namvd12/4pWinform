
using GiamSat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;
using SabanWi.Control.crc16;
using System.Runtime.Intrinsics.Arm;
using System.Windows.Forms;
using WebSocketSharp;
using SabanWi.Control.Devices;
using Org.BouncyCastle.Asn1.Ocsp;
using Org.BouncyCastle.Utilities;
using static SabanWi.Control.Devices.ItemHMI;
using System.Runtime.InteropServices;
using Org.BouncyCastle.Pqc.Crypto.Picnic;
using System.Reflection;
using Microsoft.VisualBasic.Logging;
using MySqlX.XDevAPI.Common;


namespace Giamsat.Control.Devices
{
    internal class RFMaster
    {
        private bool g_isConnect = false;
        public enum SendCommand
        {
           CMD_NONE,
           CMD_READ_ADD,
           CMD_WRITE_ADD,
           CMD_WRITE_RF_CONFIG,
           CMD_WRITE_CLIENT_SETTIN,
           CMD_READ_DEVICE_INFO_1,
           CMD_READ_DEVICE_INFO_2,
           CMD_READ_DEVICE_INFO_3,
           CMD_READ_DEVICE_INFO_4,
           CMD_READ_SYS_STATUS,    // PC send read sys status
           CMD_WRITE_MODBUS_CONFIG,
           CMD_TEST_MODBUS,
           CMD_WRITE_RF_HMI_CMD,
        };
        public class RF_Package_Send
        {
            public byte cmd;
            public byte length;
            public byte[] AddrSlave;
            public byte[] crc = new byte[2];
        }
        public class RF_Package_Receive
        {
            public byte cmd;
            public byte length;
            public byte slaveAddr;
            public byte []slaveStatus = new byte[2];
            public byte []crc = new byte[2];
        }

        public class RF_HMI_Package_Send
        {
            public byte cmd;  // set status HMI
            public byte addr;
            public HMI_data data = new HMI_data();
            public byte[] crc = new byte[2]; // CRC 16
        }
        public class RF_HMI_Receive
        {
            public byte cmd;  // set status HMI
            public byte addr;
            public HMI_data data = new HMI_data();
            public byte[] crc = new byte[2]; // CRC 16
        }

        public class HMI_data  // total 60 byte
        {
            public byte state;  
            public byte cmd;    
            public byte []data = new byte[58];  
        }
        public class client_Status
        {
            public uint addr;
            public uint port;
            public string status;
        }

        private List<client_Status> receive(byte[] data)
        {
            List<client_Status> lsClient = new List<client_Status>();
            RF_Package_Receive pkgRev = new RF_Package_Receive();
            int crcValue = 0;
            Byte[] data_receive = new byte[64];
            Buffer.BlockCopy(data, 1, data_receive, 0, 64);
            if (data_receive.Length > 0)
            { 
                pkgRev.cmd = data_receive[0];

                if (pkgRev.cmd == (byte)SendCommand.CMD_READ_SYS_STATUS)
                {                 
                    crcValue += pkgRev.cmd;

                    pkgRev.length = data_receive[1];
                    crcValue += pkgRev.length;
                    uint i = 0;
                    for (i = 0; i < pkgRev.length; i++)
                    {
                        pkgRev.slaveAddr = data_receive[i*3 + 2];
                        crcValue += pkgRev.slaveAddr;
                        pkgRev.slaveStatus[0] = data_receive[i*3 + 3];
                        crcValue += pkgRev.slaveStatus[0];
                        pkgRev.slaveStatus[1] = data_receive[i*3 + 4];
                        crcValue += pkgRev.slaveStatus[1];

                        // add status to list
                        for (byte j = 1; j <= 8; j++)
                        {
                            client_Status client = new client_Status();
                            client.addr = (uint)(pkgRev.slaveAddr);
                            client.port = j;
  
                            int statusAllPort = (pkgRev.slaveStatus[0] << 8) + pkgRev.slaveStatus[1];
                            int statusPort = (statusAllPort >> ((j - 1) * 2)) & 0x03;

                            if (statusPort == 0)
                            {
                                client.status = "DIS";
                            }
                            else if (statusPort == 1)
                            {
                                client.status = "OK";
                            }
                            else if (statusPort == 2)
                            {
                                client.status = "NG";
                            }
                            else
                            {
                                client.status = "DIS";
                            }
                            lsClient.Add(client);
                        }
                    }
                    pkgRev.crc[0] = data_receive[i * 3 + 2];
                    pkgRev.crc[1] = data_receive[i * 3 + 3];
                    int crc = pkgRev.crc[0] * 256 + pkgRev.crc[1];
                    if (crcValue != (pkgRev.crc[0] * 256 + pkgRev.crc[1]))
                    {
                        lsClient.Clear();
                    }
                }
            }
            return lsClient;
        }
        private ItemHMI receiveHMIStatus(byte[] data)
        {
            RF_HMI_Receive pkgRev = new RF_HMI_Receive();
            ItemHMI itemHMI = new ItemHMI();
            Byte[] data_receive = new byte[64];
            Buffer.BlockCopy(data, 1, data_receive, 0, 64);
            if (data_receive.Length > 0)
            {
                ushort crc16Rev = (ushort)(data_receive[63] << 8);

                crc16Rev += Convert.ToUInt16(data_receive[62]);

                byte[] buffCheckCRC = new byte[62];
                pkgRev.cmd = data_receive[0];
                pkgRev.addr = data_receive[1];
                pkgRev.data.state = data_receive[2];
                pkgRev.data.cmd = data_receive[3];
                Buffer.BlockCopy(data_receive, 4, pkgRev.data.data, 0, pkgRev.data.data.Length);
                Buffer.BlockCopy(data_receive, 0, buffCheckCRC, 0, buffCheckCRC.Length);

                // check crc
                var crcCheck = Crc16.ComputeChecksum(buffCheckCRC);
                if(crcCheck == crc16Rev)
                {
                    itemHMI.addrHMI = pkgRev.addr;
                    itemHMI.state = (hmiState)pkgRev.data.state;
                    itemHMI.cmd = (hmiResponseCmd)pkgRev.data.cmd;
                    itemHMI.dataRev = Encoding.Default.GetString(pkgRev.data.data).Replace('\0', ' ').Trim();
                    if (itemHMI.state == hmiState.START)
                    {
                        // not doing
                    }
                    else if (itemHMI.state == hmiState.LOGOUT)
                    {
                        if(itemHMI.cmd == hmiResponseCmd.LOGIN)
                        {
                            try
                            {
                                itemHMI.user = itemHMI.dataRev.Split((char)29)[0].Trim();
                                itemHMI.password = itemHMI.dataRev.Split((char)29)[1].Trim();
                            }
                            catch (Exception)
                            {
                                //throw;
                                return null;
                            }                           
                        }
                        else if (itemHMI.cmd == hmiResponseCmd.NON)
                        {
                            return null;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else if (itemHMI.state == hmiState.LOGED)
                    {
                        if(itemHMI.cmd == hmiResponseCmd.REQUEST)
                        {
                            try
                            {
                                itemHMI.machineCode = itemHMI.dataRev.Split((char)29)[0].Trim();
                                itemHMI.line = itemHMI.dataRev.Split((char)29)[1].Trim();
                                itemHMI.lane = itemHMI.dataRev.Split((char)29)[2].Trim();
                                itemHMI.partNumber = itemHMI.dataRev.Split((char)29)[3].Trim();
                                itemHMI.slot = itemHMI.dataRev.Split((char)29)[4].Trim();
                                itemHMI.number = itemHMI.dataRev.Split((char)29)[5].Trim();
                                itemHMI.level = itemHMI.dataRev.Split((char)29)[6].Trim();
                                itemHMI.status = itemHMI.dataRev.Split((char)29)[7].Trim();
                                itemHMI.user = itemHMI.dataRev.Split((char)29)[8].Trim();
                                itemHMI.time = DateTime.Now;
                            }
                            catch (Exception)
                            {
                                //throw;
                                return null;    
                            }
                        }
                    }
                    else if (itemHMI.state == hmiState.CHECKSTATUS)
                    {
                        if(itemHMI.cmd == hmiResponseCmd.UPDATE_STATUS)
                        {
                            try
                            {
                                itemHMI.machineCode = itemHMI.dataRev;
                                itemHMI.machineCode = itemHMI.dataRev.Split((char)29)[0];
                                itemHMI.line = itemHMI.dataRev.Split((char)29)[1];
                                itemHMI.lane = itemHMI.dataRev.Split((char)29)[2];
                                itemHMI.partNumber = itemHMI.dataRev.Split((char)29)[3];
                            }
                            catch (Exception)
                            {
                                return null;
                                //throw;
                            }
                        }
                    }
                }   
                else
                {
                    return null;
                }    

            }
            return itemHMI;
        }
        public bool connect()
        {
            try
            {
                HidStream stream;
                var loader = new HidDeviceLoader();
                var device = loader.GetDevices(0x4000, 0x5FFA).First();
                g_isConnect =  device.TryOpen(out stream);
                return g_isConnect;
            }
            catch (Exception)
            {
                g_isConnect = false;
                return g_isConnect;      
            }
        }
        public bool disconnect()
        {
            g_isConnect = false;
            return true;
        }
        public bool isConnect()
        {
            return g_isConnect;
        }
        private byte[] sendAndRead(byte[] message)
        {
            var loader = new HidDeviceLoader();
            var device = loader.GetDevices(0x4000, 0x5FFA).First();
            HidStream stream;
            device.TryOpen(out stream);
            stream.Write(message);
            return stream.Read();
        }
        private List<client_Status> sendAndReceive(RF_Package_Send pkg) 
        {
            int totalByte = pkg.AddrSlave.Length + pkg.crc.Length + 2;

            byte[] message = new byte[totalByte + 1];

            message[0] = 0;
            message[1] = pkg.cmd;
            message[2] = pkg.length;

            Buffer.BlockCopy(pkg.AddrSlave, 0, message, 3, pkg.AddrSlave.Length);
            
            Buffer.BlockCopy(pkg.crc, 0, message, 3 + pkg.AddrSlave.Length, pkg.crc.Length);

            try
            {
                var loader = new HidDeviceLoader();
                var device = loader.GetDevices(0x4000, 0x5FFA).First();
                HidStream stream;
                device.TryOpen(out stream);
                stream.Write(message);
                byte[] receiveData = stream.Read();
                return receive(receiveData);
            }
            catch(Exception)
            {
                return null;
                
            }
        }
        private ItemHMI sendAndReceive(RF_HMI_Package_Send pkg)
        {
            int totalByte = 64; // size of RF_HMI_Package_Send
            //int totalByte = 80; // size of RF_HMI_Package_Send
            byte[] message = new byte[totalByte - 2];   // 2byte for crc
            byte[] sendBuff = new byte[totalByte + 1];  // 1byte index presend

            // get data to message
            message[0] = pkg.cmd;
            message[1] = pkg.addr;
            message[2] = pkg.data.state;
            message[3] = pkg.data.cmd;

            Buffer.BlockCopy(pkg.data.data, 0, message, 4, pkg.data.data.Length);

            // copy message to sendBuff
            Buffer.BlockCopy(message, 0, sendBuff, 1, message.Length);

            // caculate crc16 
            var crc16 = Crc16.ComputeChecksum(message);
            pkg.crc[0] = (byte)((crc16) >> 8);
            pkg.crc[1] = (byte)(crc16 & 0x00FF);

            // copy crc to sendBuff
            Buffer.BlockCopy(pkg.crc, 0, sendBuff, sendBuff.Length - 2, pkg.crc.Length);

            try
            {
                var loader = new HidDeviceLoader();
                var device = loader.GetDevices(0x4000, 0x5FFA).First();
                HidStream stream;
                device.TryOpen(out stream);
                stream.Write(sendBuff);
                byte[] receiveData = stream.Read();
                return receiveHMIStatus(receiveData);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public List<client_Status> GetStatus(uint totalSlave)
        {         
            RF_Package_Send pkg = new RF_Package_Send();

            int crcValue = 0;

            pkg.cmd = (byte)SendCommand.CMD_READ_SYS_STATUS;
            crcValue += pkg.cmd;
            pkg.length = (byte)totalSlave;
            crcValue += pkg.length;
            pkg.AddrSlave = new byte[totalSlave];
            for (int i = 0; i < totalSlave; i++)
            {
                pkg.AddrSlave[i] = (byte)(i + 1);
                crcValue += pkg.AddrSlave[i];
            }
            pkg.crc[0] = (byte)(crcValue / 256); // high byte
            pkg.crc[1] = (byte)(crcValue % 256); // // low byte

            return sendAndReceive(pkg);
        }
        public ItemHMI send_HMI_cmd(uint addrHMI, sendToHmicmd cmd, string strSend)
        {
            RF_HMI_Package_Send pkg = new RF_HMI_Package_Send();
            byte[] bytesData;
            if (strSend != null)
            {
                bytesData = Encoding.ASCII.GetBytes(strSend);
            }
            else
            {
                bytesData = Encoding.ASCII.GetBytes("ERROR get status");
            }    
            pkg.cmd = (byte)SendCommand.CMD_WRITE_RF_HMI_CMD;
            pkg.addr = (byte)addrHMI;
            pkg.data.cmd = (byte)cmd;            
            if(bytesData.Length <= pkg.data.data.Length)
            {
                Buffer.BlockCopy(bytesData, 0, pkg.data.data, 0, bytesData.Length);
            }
            else
            {
                Buffer.BlockCopy(bytesData, 0, pkg.data.data, 0, pkg.data.data.Length);
            }
            return sendAndReceive(pkg);
        }

    }
}
