using _4P_PROJECT.DataBase;
using DevComponents.DotNetBar.Controls;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.model.History;

namespace GiamSat.model
{
    public partial class HistoryNG
    {
        public class HistoryNGData
        {
            public UInt64 historyNGID;   //tula_key
            public int machineID;        //tula_1
            public string historyID;     //tula_2
            public string line;          //tula_3
            public string lane;          //tula_4
            public string time;          //tula_5
            public string status;        //tula_6
            public string modeSystem;    //tula_7
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

        public List<HistoryNGData> get(UInt64 machineID)
        {
            List<HistoryNGData> ls = new List<HistoryNGData>();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table6, machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryNGData data = new HistoryNGData();
                    data.historyNGID   = Convert.ToUInt64(row["tula_key"]);
                    data.machineID     = Convert.ToInt32(row["tula1"]);
                    data.historyID     = Convert.ToString(row["tula2"]);
                    data.line          = Convert.ToString(row["tula3"]);
                    data.lane          = Convert.ToString(row["tula4"]);
                    data.time          = Convert.ToString(row["tula5"]);
                    data.status        = Convert.ToString(row["tula6"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public HistoryNGData get(UInt64 historyID, int machineID)
        {
            HistoryNGData data = new HistoryNGData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table6, historyID, machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                }
            }
            return data;
        }

        public List<HistoryNGData> get(string line, string lane, string time1, string time2)
        {

            List<HistoryNGData> ls = new List<HistoryNGData>();
            DataTable dt = mMydatabase.GetDataWithLineAndTime(DataBase.TABLE_DB.tula_table6, line, lane, time1, time2);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryNGData data = new HistoryNGData();
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public List<HistoryData> searchValue(string value, string time1, string time2)
        {
            List<HistoryNGData> lsHistoryNGData = new List<HistoryNGData>();
            List<HistoryData> lsHistoryData = new List<HistoryData>();
            List<HistoryData> lsHistoryNGDataFilter = new List<HistoryData>();
            History history = new History();

            history.database = mMydatabase;

            lsHistoryData = history.searchValue(value, time1, time2);

            lsHistoryNGData = this.get(null, null, time1, time2);

            foreach (var HistoryData in lsHistoryData)
            {
                foreach (var HistoryNGData in lsHistoryNGData)
                {
                    if (HistoryData.historyID.ToString() == HistoryNGData.historyID)
                    {
                        lsHistoryNGDataFilter.Add(HistoryData);
                    }
                }
            }
            return lsHistoryNGDataFilter;
        }

        public List<HistoryNGData> searchWarningNG_OK()
        {
            List<HistoryNGData> ls = new List<HistoryNGData>();

            Machine mc = new Machine();
            mc.database = mMydatabase;

            DataTable dt;
            dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table6, "WarningNG", "OK");

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryNGData data  = new HistoryNGData();
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                    ls.Add(data);
                }
            }
            return ls;
        }
        public List<HistoryNGData> searchNgOnTime(string time1, string time2)
        {
            List<HistoryNGData> ls = new List<HistoryNGData>();

            Machine mc = new Machine();
            mc.database = mMydatabase;

            DataTable dt;
            dt = dt = mMydatabase.GetDataLikeValue(DataBase.TABLE_DB.tula_table6, "NG", time1, time2);

            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryNGData data = new HistoryNGData();
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                    ls.Add(data);
                }
            }
            return ls;
        }
        public HistoryNGData searchStatusOKNearNG(UInt64 historyID, int machineID)
        {
            HistoryNGData data = new HistoryNGData();
            UInt64 historyNG_ID = getHistoryNG_ID(Convert.ToString(historyID));
            DataTable dt = mMydatabase.GetDataExtend(DataBase.TABLE_DB.tula_table6, historyNG_ID, machineID, "OK");

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                }
            }
            else
            {
                return null;
            }
            return data;
        }
        public HistoryNGData searchHistoryNGLast(int machineID)
        {
            HistoryNGData data = new HistoryNGData();
            DataTable dt = mMydatabase.GetDataExtend2(DataBase.TABLE_DB.tula_table6, machineID);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                }
            }
            else
            {
                return null;
            }
            return data;
        }
        public List<HistoryNGData> getAll()
        {
            List<HistoryNGData> ls = new List<HistoryNGData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table6);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    HistoryNGData data = new HistoryNGData();
                    data.historyNGID = Convert.ToUInt64(row["tula_key"]);
                    data.machineID = Convert.ToInt32(row["tula1"]);
                    data.historyID = Convert.ToString(row["tula2"]);
                    data.line = Convert.ToString(row["tula3"]);
                    data.lane = Convert.ToString(row["tula4"]);
                    data.time = Convert.ToString(row["tula5"]);
                    data.status = Convert.ToString(row["tula6"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public bool add(int machineID, string historyID, string line, string lane, string time, string status, string modeSystem)
        {
            bool res;
            if (status == "NG")
            {
                status = "WarningNG";
            }
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table6, machineID.ToString(), historyID, line, lane, time, status, modeSystem);
            return res;
        }

        public bool update(UInt64 historyID, string status)
        {
            bool res;
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table6, historyID, null, null, null, null, null, status);
            return res;
        }

        public bool delete(UInt64 historyID)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table6, historyID);
            return res;
        }

        public UInt64 getHistoryNG_ID(string historyID)
        {
            UInt64 historyNG_ID = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table6, historyID);
            return historyNG_ID;
        }
    }
}
