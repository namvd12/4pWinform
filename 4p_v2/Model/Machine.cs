using _4P_PROJECT.DataBase;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GiamSat.model
{
    public class Machine
    {
        public class machineData
        {
            public int machineID;        //tula_key
            public string machineCode;   //tula_1
            public string machineName;   //tula_2
            public string linePosition;  //tula_3
            public string lane;          //tula_4
            public string status;        //tula_5
            public string time;          //tula_6
            public string picture;       //tula_7
            public string note;          //tula_8
            public string manager;       //tula_9
            public string Model;         //tula_10
            public string Serial;        //tula_11
            public string TopBot;        //tula_12
            public string category;      //tula_13
            public string mode;          //tula_14
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
        public bool add(string machineCode = null, string machineName = null, string linePosition = null, string lane = null, string status = null, string time = null, string picture = null,
                           string note = null, string manager = null, string model = null, string serial = null, string topBot = null)
        {
            bool res;
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table1, machineCode, machineName, linePosition, lane, status, time, picture,
                                        note, manager, model, serial, topBot);
            return res;
        }

        public machineData get(int machineID)
        {
            machineData data = new machineData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table1, (UInt64)machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {    
                    data.machineID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.linePosition = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.status = Convert.ToString(row["tula5"]);
                    data.time = Convert.ToString(row["tula6"]);
                    data.picture = Convert.ToString(row["tula7"]);
                    data.note = Convert.ToString(row["tula8"]);
                    data.manager = Convert.ToString(row["tula9"]);
                    data.Model = Convert.ToString(row["tula10"]);
                    data.Serial = Convert.ToString(row["tula11"]);
                    data.TopBot = Convert.ToString(row["tula12"]);
                }
            }
            return data;
        }
        public List<machineData> get(string line, string lane)
        {
            List<machineData> lsData = new List<machineData>();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table1, line, lane);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    machineData data = new machineData();
                    data.machineID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.linePosition = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.status = Convert.ToString(row["tula5"]);
                    data.time = Convert.ToString(row["tula6"]);
                    data.picture = Convert.ToString(row["tula7"]);
                    data.note = Convert.ToString(row["tula8"]);
                    data.manager = Convert.ToString(row["tula9"]);
                    data.Model = Convert.ToString(row["tula10"]);
                    data.Serial = Convert.ToString(row["tula11"]);
                    data.TopBot = Convert.ToString(row["tula12"]);
                    lsData.Add(data);
                }
            }
            return lsData;
        }
        public List<machineData> getAll()
        {
            List<machineData> ls = new List<machineData>();

            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table1);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    machineData data = new machineData();
                    data.machineID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.linePosition = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.status = Convert.ToString(row["tula5"]);
                    data.time = Convert.ToString(row["tula6"]);
                    data.picture = Convert.ToString(row["tula7"]);
                    data.note = Convert.ToString(row["tula8"]);
                    data.manager = Convert.ToString(row["tula9"]);
                    data.Model = Convert.ToString(row["tula10"]);
                    data.Serial = Convert.ToString(row["tula11"]);
                    data.TopBot = Convert.ToString(row["tula12"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public List<machineData> SearchValue(string value)
        {
            List<machineData> ls = new List<machineData>();

            DataTable dt = mMydatabase.GetDataLikeValue(DataBase.TABLE_DB.tula_table1, value);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    machineData data = new machineData();
                    data.machineID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.linePosition = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.status = Convert.ToString(row["tula5"]);
                    data.time = Convert.ToString(row["tula6"]);
                    data.picture = Convert.ToString(row["tula7"]);
                    data.note = Convert.ToString(row["tula8"]);
                    data.manager = Convert.ToString(row["tula9"]);
                    data.Model = Convert.ToString(row["tula10"]);
                    data.Serial = Convert.ToString(row["tula11"]);
                    data.TopBot = Convert.ToString(row["tula12"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public bool update(int machineID, string machineCode = null, string machineName = null, string linePosition = null, string lane = null, string status = null, string time = null, string picture = null,
                           string note = null, string manager = null, string model = null, string serial = null, string topBot = null)
        {
            bool res;

            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table1, (UInt64)machineID, machineCode, machineName, linePosition, lane, status, time, picture, 
                                        note, manager, model, serial, topBot);
            return res;
        }

        public bool updateStatus(int machineID, string status, string time, string mode)
        {
            bool res;

            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table1, (UInt64)machineID, null, null, null, null, status, time, null, null, null, null, null,null,null, mode);
            return res;
        }

        public bool delete(int machineID)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table1, machineID);
            return res;
        }

        public void get_Mc_Line_Land(int machineID, out string machine_code, out string machine_name, out string line, out string lane)
        {
            machine_name = string.Empty;
            line = string.Empty;
            mMydatabase.GetValue(DataBase.TABLE_DB.tula_table1, machineID, out machine_code, out machine_name, out line, out lane);
        }

        public int getMcID(string machineCodeOld)
        {
            int machineID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table1, machineCodeOld);
            return machineID;
        }
        public int getMachineID(string machineCode)
        {
            int machineID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table1, machineCode);
            return machineID;
        }
    }
}
