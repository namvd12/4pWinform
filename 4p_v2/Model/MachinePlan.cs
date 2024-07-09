using _4P_PROJECT.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Giamsat.Model
{
    public class MachinePlan
    {
        public class MachinePlanData
        {
            /* MaintenanceData*/
            public UInt32 MaintenanceID;       //tula_key  
            public UInt32 MachineID;           //tula_1
            public UInt32 Cycles;              //tula_2
            public DateTime TimeLatest;        //tula_3
            public DateTime TimeMaintenace;    //tula_4
            public UInt32 TimeRemaining;       //tula_5
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

        public List<MachinePlanData> getAll()
        {
            List<MachinePlanData> ls = new List<MachinePlanData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table4);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    MachinePlanData data = new MachinePlanData();
                    data.MaintenanceID = Convert.ToUInt32(row["tula_key"]);
                    data.MachineID = Convert.ToUInt32(row["tula1"]);
                    data.Cycles = Convert.ToUInt32(row["tula2"]);
                    data.TimeLatest = Convert.ToDateTime(row["tula3"]);
                    data.TimeMaintenace = Convert.ToDateTime(row["tula4"]);
                    data.TimeRemaining = Convert.ToUInt32(row["tula5"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public MachinePlanData get(int machineID)
        {
            MachinePlanData data = new MachinePlanData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table4, (UInt64)machineID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.MaintenanceID = Convert.ToUInt32(row["tula_key"]);
                    data.MachineID = Convert.ToUInt32(row["tula1"]);
                    data.Cycles = Convert.ToUInt32(row["tula2"]);
                    data.TimeLatest = Convert.ToDateTime(row["tula3"]);
                    data.TimeMaintenace = Convert.ToDateTime(row["tula4"]);
                    data.TimeRemaining = Convert.ToUInt32(row["tula4"]);
                }
            }
            return data;
        }

        public bool add(int machineID, UInt32 Cycles, DateTime TimeLatest, DateTime TimeMaintenace, UInt32 TimeRemaining)
        {
            bool res;
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table4, machineID.ToString(), Cycles.ToString(), TimeLatest.ToString(),
                                        TimeMaintenace.ToString(), TimeRemaining.ToString());
            return res;
        }
        public bool set(int MaintenanceID, int machineID, UInt32 Cycles, DateTime TimeLatest, DateTime TimeMaintenace, UInt32 TimeRemaining)
        {
            bool res = false;

            if (MaintenanceID == 0)
            {
                res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table4, machineID.ToString(), Cycles.ToString(), TimeLatest.ToString(),
                            TimeMaintenace.ToString(), TimeRemaining.ToString());
            }
            else
            {             
                res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table4, (UInt64)MaintenanceID, machineID.ToString(), Cycles.ToString(), TimeLatest.ToString(),
                                            TimeMaintenace.ToString(), TimeRemaining.ToString());
            }
            return res;
        }
        public bool set(uint machineID, UInt32 TimeRemaining)
        {
            bool res;
            int MaintenancePlanID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table4, machineID.ToString());
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table4, (UInt64)MaintenancePlanID, machineID.ToString(), null, null, null, TimeRemaining.ToString());
            return res;
        }
        public bool delete(int machineID)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table4, machineID);
            return res;
        }

        public bool update(int machineID, UInt32 Cycles, DateTime TimeLatest, DateTime TimeMaintenace, UInt32 TimeRemaining)
        {
            bool res;
            int MaintenanceID = (int)mMydatabase.GetKey(DataBase.TABLE_DB.tula_table4, machineID.ToString());
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table4, (UInt64)MaintenanceID, null, Cycles.ToString(), TimeLatest.ToString(), TimeMaintenace.ToString(), TimeRemaining.ToString());
            return res;
        }
    }
}
