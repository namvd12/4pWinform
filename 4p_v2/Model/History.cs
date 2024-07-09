using _4P_PROJECT.DataBase;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace GiamSat.model
{
    public partial class History
    {
        public class HistoryData
        {
            public UInt64 historyID;         //tula_key
            public int machineID;         //tula_1
            public string machineName;    //tula_2
            public string line;           //tula_3
            public string lane;           //tula_4
            public string noTrouble;      //tula_5
            public string troubleName;    //tula_6
            public string time;           //tula_7
            public string status;         //tula_8
            public string picture1;       //tula_9
            public string note1;          //tula_10
            public string picture2;       //tula_11
            public string note2;          //tula_12
            public string picture3;       //tula_13
            public string note3;          //tula_14
            public string picture4;       //tula_15
            public string note4;          //tula_16
            public string picture5;       //tula_17
            public string note5;          //tula_18
            public string picture6;       //tula_19
            public string note6;          //tula_20
            public int ChildMachineID;      //tula_21
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

        public List<HistoryData> get(int machineID)
        {
            List<HistoryData> ls = new List<HistoryData>();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table2, (UInt64)machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryData data = new HistoryData();
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if (row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                    ls.Add(data);
                }
            }
            return ls;
        }

        public HistoryData get(UInt64 historyID, int machineID)
        {
            HistoryData data = new HistoryData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table2, historyID, machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if (row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                }
            }
            else
            {
                return null;
            }
            return data;
        }

        public List<HistoryData> searchValue(string value, string time1, string time2)
        {
            List<HistoryData> ls = new List<HistoryData>();

            Machine mc = new Machine();
            mc.database = mMydatabase;

            DataTable dt;
            int machineID = mc.getMachineID(value);
            string machineCode;
            string machineName;
            string line;
            string lane;

            mc.get_Mc_Line_Land(machineID, out machineCode, out machineName, out line, out lane);

            if (machineName != string.Empty)
            {
                dt = mMydatabase.GetDataLikeValue(DataBase.TABLE_DB.tula_table2, machineName, time1, time2);
            }
            else
            { 
                dt = mMydatabase.GetDataLikeValue(DataBase.TABLE_DB.tula_table2, value, time1, time2);
            }

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryData data = new HistoryData();
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if(row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                    ls.Add(data);
                }
            }
            return ls;
        }

        public HistoryData searchStatusOKNearNG(UInt64 historyID, int machineID)
        {
            HistoryData data = new HistoryData();
            DataTable dt = mMydatabase.GetDataExtend(DataBase.TABLE_DB.tula_table2, historyID, machineID, "OK");

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if (row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                }
            }
            else
            {
                return null;
            }
            return data;
        }

        public List<HistoryData> get(string line, string lane, string time1, string time2)
        {
            
            List<HistoryData> ls = new List<HistoryData>();
            DataTable dt = mMydatabase.GetDataWithLineAndTime(DataBase.TABLE_DB.tula_table2, line, lane, time1, time2);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryData data = new HistoryData();
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if (row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                    ls.Add(data);
                }
            }
            return ls;
        }
        public List<HistoryData> getAll()
        {
            List<HistoryData> ls = new List<HistoryData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table2);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryData data = new HistoryData();
                    data.historyID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.machineName = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.noTrouble = Convert.ToString(row["tula5"]);
                    data.troubleName = Convert.ToString(row["tula6"]);
                    data.time = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.picture1 = Convert.ToString(row["tula9"]);
                    data.note1 = Convert.ToString(row["tula10"]);
                    data.picture2 = Convert.ToString(row["tula11"]);
                    data.note2 = Convert.ToString(row["tula12"]);
                    data.picture3 = Convert.ToString(row["tula13"]);
                    data.note3 = Convert.ToString(row["tula14"]);
                    data.picture4 = Convert.ToString(row["tula15"]);
                    data.note4 = Convert.ToString(row["tula16"]);
                    data.picture5 = Convert.ToString(row["tula17"]);
                    data.note5 = Convert.ToString(row["tula18"]);
                    data.picture6 = Convert.ToString(row["tula19"]);
                    data.note6 = Convert.ToString(row["tula20"]);
                    if (row["tula21"] != System.DBNull.Value)
                    {
                        data.ChildMachineID = Convert.ToInt32(row["tula21"]);
                    }
                    else
                    {
                        data.ChildMachineID = 0;
                    }
                    ls.Add(data);
                }
            }
            return ls;
        }

        public UInt64 add(int machineID, string errorName, string time, string status)
        {
            bool res;
            string machineCode;
            string machineName;
            string line;
            string lane;
            string troubleName = string.Empty;
            UInt64 historyID = 0;
            try
            {
                DateTime date = DateTime.ParseExact(time, "dd-MM-yyyy HH:mm", null);
                uint lastTulaKey = mMydatabase.getLastTula_key(DataBase.TABLE_DB.tula_table2) + 1;
                troubleName = "TR" + date.ToString("yyyy") + date.ToString("MM") + date.ToString("dd") + "_" + lastTulaKey.ToString("D" + 4);
            }
            catch
            {
                //DateTime date = DateTime.Parse(time);
                troubleName = "TR" + time;

            }

            Machine mc = new Machine();
            mc.database = mMydatabase;
            mc.get_Mc_Line_Land(machineID, out machineCode, out machineName, out line, out lane);
            
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table2, machineID.ToString(), machineName, line, lane, troubleName, errorName, time, status, 
                                        "", "", "", "", "", "", "", "", "", "", "", "", machineID.ToString());
            if (res)
            {
                historyID = getHistoryID(troubleName);
            }

            return historyID;
        }

        public bool update(UInt64 historyID, string errorName, string note1, string note2, string note3, string note4, string note5, string note6)
        {
            bool res;
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table2, historyID, null, null, null, null, null, errorName, null, null, null, note1, null, note2, null, note3, null, note4, null, note5, null, note6);
            return res;
        }

        public UInt64 getHistoryID(string noTrouble)
        {
            UInt64 machineID = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table2, noTrouble);
            return machineID;
        }
    }
}
