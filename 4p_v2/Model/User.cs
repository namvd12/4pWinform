using _4P_PROJECT.DataBase;
using LiveCharts.Maps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.model.Machine;

namespace SabanWi.Model
{
    public class User
    {
        public class UserData
        {
            /* MaintenanceData*/
            public uint userKey;            //tula_key
            public string userID;           //tula_1
            public string level;            //tula_2
            public string userName;         //tula_3
            public string password;         //tula_4
            public string fullName;         //tula_5
            public string phone;            //tula_6
            public string email;            //tula_7
            public string avatar;           //tula_8
        }
        public List<string> levels = new List<string> { "level1", "level2","level3","level4" };

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

        public List<UserData> getAll()
        {
            List<UserData> ls = new List<UserData>();
            DataTable dt = mMydatabase.GetAllData(DataBase.TABLE_DB.tula_table8);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    UserData data = new UserData();
                    data.userKey = Convert.ToUInt32(row["tula_key"]);
                    data.userID = Convert.ToString(row["tula1"]);
                    data.level = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public UserData get(string userID, string userName)
        {
            UserData data = new UserData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table8, userID, userName);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.userKey = Convert.ToUInt32(row["tula_key"]);
                    data.userID = Convert.ToString(row["tula1"]);
                    data.level = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                }
            }
            return data;
        }

        public List<UserData> SearchValue(string value)
        {
            List<UserData> ls = new List<UserData>();

            DataTable dt = mMydatabase.GetDataLikeValue(DataBase.TABLE_DB.tula_table8, value);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    UserData data = new UserData();
                    data.userKey = Convert.ToUInt32(row["tula_key"]);
                    data.userID = Convert.ToString(row["tula1"]);
                    data.level = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    ls.Add(data);
                }
            }
            return ls;
        }
        public bool add(string userID, string level, string userName, string password, string fullName = "", string phone= "", string email="")
        {
            bool res;

            /*Check UserID or UserName exits*/
            DataTable data = mMydatabase.GetData(DataBase.TABLE_DB.tula_table8, userID, userName);
            if (data.Rows.Count != 0)
            {
                return false;
            }
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table8, userID, level, userName,
                                        password, fullName, phone, email);
            return res;
        }

        public bool delete(int userKey)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table8, userKey);
            return res;
        }

        public bool update(uint userKey, string userID, string level, string userName, string password = null, string fullName = null, string phone = null, string email =null)
        {
            bool res;
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table8, (ulong)userKey, userID, level, userName, password, fullName, phone, email);
            return res;
        }
        public bool loginAdmin(string userName, string password)
        {
            List<UserData> listUser = SearchValue(userName);
            foreach (var user in listUser)
            {
                if (user.userName == "admin")
                {
                    var checkPass = BCrypt.Net.BCrypt.Verify(password, user.password);
                    if (checkPass == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
