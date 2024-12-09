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
            public string position;      // tula_4
            public string slot;          // tula_5
            public string urgent;        // tula_6
            public string status;        // tula_7
            public string time;          // tula_8
            public string user;          // tula_9
            public string note;          // tula_10
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
        public UInt64 add(string machineCode, string line, string lane, string position, string slot, string urgent, string status, string time, string userKey)
        {
            UInt64 callID;
            var callInfor = getCallInfor(machineCode, line, lane, position, slot, userKey);
            if (callInfor.callID != 0 && callInfor.status != "OK")
            {
                mMydatabase.EditData(DataBase.TABLE_DB.tula_table14, (UInt64)callInfor.callID, machineCode, line, lane, position, slot, urgent, status, time, userKey);
            }
            else
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, position, slot, urgent, status, time, userKey);
            }    
            callID = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, position, slot, urgent, status, time);
            return callID;
        }

        public callMaterialData getCallInfor(string machineCode, string line, string lane, string position, string slot, string userKey = "")
        {
            callMaterialData data = new callMaterialData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table14, machineCode, line, lane, position, slot, userKey);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.callID = Convert.ToInt32(row["tula_key"]);
                    data.machineCode = Convert.ToString(row["tula1"]);
                    data.line = Convert.ToString(row["tula2"]);
                    data.lane = Convert.ToString(row["tula3"]);
                    data.position = Convert.ToString(row["tula4"]);
                    data.slot = Convert.ToString(row["tula5"]);
                    data.urgent = Convert.ToString(row["tula6"]);
                    data.status = Convert.ToString(row["tula7"]);
                    data.time = Convert.ToString(row["tula8"]);
                    data.user = Convert.ToString(row["tula9"]);
                }
            }
            else
            {
                return null;
            }    
            return data;
        }
    }
}
