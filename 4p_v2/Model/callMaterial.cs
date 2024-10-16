using _4P_PROJECT.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.model.Machine;

namespace SabanWi.Model
{
    internal class CallMaterial
    {
        public class callMaterialData
        {
            public int callID;           // tula_key
            public string machineCode;   // tula_1
            public string line;          // tula_2
            public string lane;          // tula_3
            public string partNumber;    // tula_4
            public string slot;          // tula_5
            public string number;        // tula_6
            public string level;         // tula_7
            public string status;        // tula_8
            public string time;          // tula_9
            public string userCall;      // tula_10
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
        public UInt64 add(string machineCode, string line, string lane, string partNumber, string slot, string number,string level, string status, string time, string userCall)
        {
            bool res;
            UInt64 callID;
            string resStatus =  getStatus(machineCode, line, lane, partNumber);
            if(resStatus != null)
            {
                return 0;
            }    
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, partNumber, slot, number, level, status, time, userCall);
            callID = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, partNumber, slot);
            return callID;
        }

        public string getStatus(string machineCode, string line, string lane, string partNumber)
        {
            callMaterialData data = new callMaterialData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, partNumber);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.callID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.line = Convert.ToString(row["tula2"]);
                    data.lane = Convert.ToString(row["tula3"]);
                    data.partNumber = Convert.ToString(row["tula4"]);
                    data.slot = Convert.ToString(row["tula5"]);
                    data.number = Convert.ToString(row["tula6"]);
                    data.level = Convert.ToString(row["tula7"]);
                    data.status = Convert.ToString(row["tula8"]);
                    data.time = Convert.ToString(row["tula9"]);
                    data.userCall = Convert.ToString(row["tula10"]);
                }
            }
            else
            {
                return string.Empty;
            }    
            return data.status;
        }
    }
}
