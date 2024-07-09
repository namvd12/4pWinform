using _4P_PROJECT.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.model.History;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GiamSat.model
{
    internal class ClientRF
    {
        public class ClientData
        {
            public int clientID;       // tula_key
            public int machineID;      // tula_1
            public string machineName; // tula_2
            public uint clientAddr;    // tula_3
            public uint port;          // tula_4
            public string status;      // tula_5
            public int location_x;     // tula_6
            public int location_y;     // tula_7
            public string region;      // tula_8
        }

        private DataBase mMydatabase;

        public DataBase database
        {
            get
            {
                return mMydatabase;
            }
            set
            {
                mMydatabase = value;
            }
        }

        public List<ClientData> getAll()
        {
            List<ClientData> ls = new List<ClientData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table3);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    ClientData data = new ClientData();
                    data.clientID   = Convert.ToInt32(row["tula_key"]);
                    data.machineID  = Convert.ToInt32(row["tula1"]);
                    data.machineName= Convert.ToString(row["tula2"]);
                    data.clientAddr = Convert.ToUInt16(row["tula3"]);
                    data.port       = Convert.ToUInt16(row["tula4"]);
                    data.status     = Convert.ToString(row["tula5"]);
                    data.location_x = Convert.ToInt16(row["tula6"]);
                    data.location_y = Convert.ToInt16(row["tula7"]);
                    data.region     = Convert.ToString(row["tula8"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public ClientData get(int machineID)
        {
            ClientData data = new ClientData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table3, (UInt64)machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.clientID = Convert.ToInt32(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.clientAddr = Convert.ToUInt16(row["tula3"]);
                    data.port = Convert.ToUInt16(row["tula4"]);
                    data.status = Convert.ToString(row["tula5"]);
                    data.location_x = Convert.ToInt16(row["tula6"]);
                    data.location_y = Convert.ToInt16(row["tula7"]);
                    data.region = Convert.ToString(row["tula8"]);
                }
            }
            return data;
        }

        public bool add(int machineID, uint addr, uint port, string name, string status, int x, int y, string region)
        {
            bool res;
            int clientID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table3, machineID.ToString(), name);
            if (clientID != 0)
            {
                res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table3, (UInt64)clientID, machineID.ToString(), name, addr.ToString(),
                                            port.ToString(), status, x.ToString(), y.ToString(), region);
            }
            else
            {             
                res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table3, machineID.ToString(), name, addr.ToString(), 
                                            port.ToString(), status, x.ToString(), y.ToString(), region);
            }
            return res;
        }

        public bool delete(int machineID)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table3, machineID);
            return res;
        }

        public bool setStatus(int machineID, string machineCode, string status)
        {
            bool res;
            int clientID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table3, machineID.ToString(), machineCode);
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table3, (UInt64)clientID, null, null, null, null, status);
            return res;
        }


        public bool updatePosition(int machineID, string clientAdrr, string port)
        {
            bool res;
            int clientID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table3, machineID.ToString());
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table3, (UInt64)clientID, null, clientAdrr, port, null);
            return res;
        }
    }
}
