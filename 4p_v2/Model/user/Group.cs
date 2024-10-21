using _4P_PROJECT.DataBase;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SabanWi.Model.user.User;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SabanWi.Model.user
{
    public class Group
    {
        public static class groupName
        {
            public const string
            admin = "Admin",
            teamLeader = "Team_leader",
            partLeader = "Part_leader",
            engineer = "Engineer",
            customer = "Customer",
            test = "test",
            callMaterial = "CallMaterial";
        }
        public class GroupData
        {
            public uint groupKey;            //tula_key
            public string nameGroup;         //tula1
            public string decription;        //tula2
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

        public List<GroupData> getAll()
        {
            List<GroupData> ls = new List<GroupData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table10);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    GroupData data = new GroupData();
                    data.groupKey = Convert.ToUInt32(row["tula_key"]);
                    data.nameGroup = Convert.ToString(row["tula1"]);
                    data.decription = Convert.ToString(row["tula2"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public UInt32 getGroupKeyByName(string groundName)
        {
            GroupData data = new GroupData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table10, groundName);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.groupKey = Convert.ToUInt32(row["tula_key"]);
                    data.nameGroup = Convert.ToString(row["tula1"]);
                    data.decription = Convert.ToString(row["tula2"]);
                }
            }
            else
            {
                return 0;
            }
            return data.groupKey;
        }

        public void setDefaultGroup()
        {
            /* Set default Group */
            if (getGroupKeyByName(groupName.admin) == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.admin, "admin all permission");
            }
            if (getGroupKeyByName(groupName.teamLeader) == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.teamLeader, "Team leader all permission");
            }
            if (getGroupKeyByName(groupName.partLeader) == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.partLeader, "Part leader all permission");
            }
            if (getGroupKeyByName(groupName.engineer) == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.engineer, "Engineer all permission use phone");
            }
            if (getGroupKeyByName(groupName.customer) == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.customer, "Customer only view");
            }
            if (getGroupKeyByName(groupName.test) == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.test, "test_system only view");
            }
            if (getGroupKeyByName(groupName.callMaterial) == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table10, groupName.callMaterial, "callMaterial only view");
            }
        }
    }
}
