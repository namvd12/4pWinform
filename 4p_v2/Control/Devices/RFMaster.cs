
using GiamSat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HidSharp;


namespace Giamsat.Control.Devices
{
    internal class RFMaster
    {
        private bool g_isConnect = false;
        public enum SendCommand
        {
            NONE, READ_ADD, WRITE_ADD, READ_SABAN, WRITE_SABAN, READ_TIME, WRITE_TIME,
            READ_RUNNING_INFO, DELETE_RUNNING_INFO, READ_SYS_STATUS, SCAN_SYS_STATUS
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

                if (pkgRev.cmd == (byte)SendCommand.SCAN_SYS_STATUS)
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

        public List<client_Status> GetStatus(uint totalSlave)
        {         
            RF_Package_Send pkg = new RF_Package_Send();

            int crcValue = 0;

            pkg.cmd = (byte)SendCommand.READ_SYS_STATUS;
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
    }
}
