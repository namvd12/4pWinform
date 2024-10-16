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
    public class ConfigSystem
    {
        public class ConfigData
        {
            public int configID;                // tula_key
            public int configNum;               // tula_1     
            public string timeReportNG;         // tula_2
            public string folderSaveReport;     // tula_3
            public string lineWorking;          // tula_4
            public string modeSystem;           // tula_5
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


        private ConfigData get(int configNum)
        {
            ConfigData data = new ConfigData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table7, (UInt64)configNum);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.configID = Convert.ToInt32(row["tula_key"]);
                    data.configNum = Convert.ToInt32(row["tula1"]);
                    data.timeReportNG = Convert.ToString(row["tula2"]);
                    data.folderSaveReport = Convert.ToString(row["tula3"]);
                    data.lineWorking = Convert.ToString(row["tula4"]);
                    data.modeSystem = Convert.ToString(row["tula5"]);
                }
            }
            else
            {
                data.configID = 0;
                data.timeReportNG = "0";
            }
            return data;
        }

        public bool setTimeNG(int configNum, int timeReportNG)
        {
            bool res;
            ConfigData config = get(configNum);
            if (config.configNum != configNum)
            {
                res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table7, configNum.ToString(), timeReportNG.ToString());
            }
            else
            { 
                res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table7, (UInt64)config.configID, null, timeReportNG.ToString());
            }
            return res;
        }

        public int getTimeReport()
        {
            ConfigData config = new ConfigData();
            config = get(1);
            return Convert.ToUInt16(config.timeReportNG);
        }
        public string getFolderReport()
        {
            ConfigData config = new ConfigData();
            config = get(1);
            return config.folderSaveReport;
        }
        public bool setFolder(string folder, int configNum = 1)
        {
            bool res;
            ConfigData config = get(configNum);
            if (config.configNum != configNum)
            {
                res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table7, configNum.ToString(), config.timeReportNG.ToString(), folder);
            }
            else
            {
                res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table7, (UInt64)config.configID, null, null, folder);
            }
            return res;
        }

        public string getModeSystem()
        {
            ConfigData config = new ConfigData();
            config = get(1);
            return config.modeSystem;
        }
    }
}
