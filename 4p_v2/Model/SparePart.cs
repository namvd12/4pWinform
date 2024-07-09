using _4P_PROJECT.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giamsat.Model
{
    public class SparePart
    {
        public class SparePartData
        {
            /* MaintenanceData*/
            public uint SparePartID;        //tula_key
            public uint MachineID;          //tula_1
            public string SpareCode;        //tula_2
            public string SpareName;        //tula_3
            public string SN;               //tula_4
            public DateTime TimeMaintenace; //tula_5
            public uint NumberItem;         //tula_6
            public uint Cycle;              //tula_7
            public uint TimeRemaining;      //tula_8
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

        public List<SparePartData> getAll()
        {
            List<SparePartData> ls = new List<SparePartData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table5);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    SparePartData data  = new SparePartData();
                    data.SparePartID    = Convert.ToUInt32(row["tula_key"]);
                    data.MachineID      = Convert.ToUInt32(row["tula1"]);
                    data.SpareCode      = Convert.ToString(row["tula2"]);
                    data.SpareName      = Convert.ToString(row["tula3"]);
                    data.SN             = Convert.ToString(row["tula4"]);
                    data.TimeMaintenace = Convert.ToDateTime(row["tula5"]);
                    data.NumberItem     = Convert.ToUInt32(row["tula6"]);
                    data.Cycle          = Convert.ToUInt32(row["tula7"]);
                    data.TimeRemaining  = Convert.ToUInt32(row["tula8"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        //public SparePartData get(int machineID)
        //{
        //    SparePartData data = new SparePartData();
        //    DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table4, machineID);
        //    if (dt != null)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            data.SparePartID = Convert.ToUInt32(row["tula_key"]);
        //            data.MachineID = Convert.ToUInt32(row["tula1"]);
        //            data.SpareCode = Convert.ToString(row["tula2"]);
        //            data.SpareName = Convert.ToString(row["tula3"]);
        //            data.SN = Convert.ToString(row["tula4"]);
        //            data.Time = Convert.ToDateTime(row["tula5"]);
        //            data.NumberOfitem = Convert.ToUInt32(row["tula6"]);
        //            data.Time_remaining = Convert.ToUInt32(row["tula7"]);
        //        }
        //    }
        //    return data;
        //}

        //public bool add(int machineID, UInt32 Cycles, DateTime TimeLatest, DateTime TimeMaintenace, UInt32 TimeRemaining)
        //{
        //    bool res;
        //    res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table4, machineID.ToString(), Cycles.ToString(), TimeLatest.ToString(),
        //                                TimeMaintenace.ToString(), TimeRemaining.ToString());
        //    return res;
        //}

        public bool delete(int machineID)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table5, machineID);
            return res;
        }

        //public bool update(int machineID, UInt32 Cycles, DateTime TimeLatest, DateTime TimeMaintenace, UInt32 TimeRemaining)
        //{
        //    bool res;
        //    int MaintenanceID = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table4, machineID.ToString());
        //    res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table4, MaintenanceID, null, Cycles.ToString(), TimeLatest.ToString(), TimeMaintenace.ToString(), TimeRemaining.ToString());
        //    return res;
        //}
        public bool set(int SparePartID, int machineID, string spCode, string spName, string sn, DateTime TimeMaintenace   , uint numberItem, uint cycle, uint TimeRemaining)
        {
            bool res = false;
            if (SparePartID == 0)
            {
                res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table5, machineID.ToString(), spCode, spName, sn, TimeMaintenace.ToString(), 
                                        numberItem.ToString(), cycle.ToString(), TimeRemaining.ToString());
            }
            else
            {
                res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table5, (UInt64)SparePartID, machineID.ToString(), spCode, spName, sn, TimeMaintenace.ToString(),
                                        numberItem.ToString(), cycle.ToString(), TimeRemaining.ToString());
            }
            return res;
        }
    }
}
