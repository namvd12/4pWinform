using _4P_PROJECT.DataBase;
using LiveCharts.Maps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GiamSat.model.Machine;

namespace SabanWi.Model.user
{
    public class User
    {
        public class UserData
        {
            public uint userKey;            //tula_key
            public string userID;           //tula_1
            public string position;         //tula_2
            public string userName;         //tula_3
            public string password;         //tula_4
            public string fullName;         //tula_5
            public string phone;            //tula_6
            public string email;            //tula_7
            public string avatar;           //tula_8
            public string groupID;          //tula_9
            public string topicNoti;        //tula_10
        }

        private static UserData userCurrent = new UserData();

        private Group group = new Group();
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
                group.database = value;
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
                    data.position = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    data.groupID = Convert.ToString(row["tula9"]);
                    ls.Add(data);
                }
            }
            return ls;
        }

        public UserData getByUserID(string userID)
        {
            UserData data = new UserData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table8, userID);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.userKey = Convert.ToUInt32(row["tula_key"]);
                    data.userID = Convert.ToString(row["tula1"]);
                    data.position = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    data.groupID = Convert.ToString(row["tula9"]);
                }
            }
            return data;
        }

        public List<UserData> getByPositionName(string value1, string value2 = "")
        {
            List<UserData> ls = new List<UserData>();

            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table8, "",value1, value2);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    UserData data = new UserData();
                    data.userKey = Convert.ToUInt32(row["tula_key"]);
                    data.userID = Convert.ToString(row["tula1"]);
                    data.position = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    data.groupID = Convert.ToString(row["tula9"]);
                    ls.Add(data);
                }
            }
            return ls;
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
                    data.position = Convert.ToString(row["tula2"]);
                    data.userName = Convert.ToString(row["tula3"]);
                    data.password = Convert.ToString(row["tula4"]);
                    data.fullName = Convert.ToString(row["tula5"]);
                    data.phone = Convert.ToString(row["tula6"]);
                    data.email = Convert.ToString(row["tula7"]);
                    data.avatar = Convert.ToString(row["tula8"]);
                    data.groupID = Convert.ToString(row["tula9"]);
                    ls.Add(data);
                }
            }
            return ls;
        }
        public bool add(string userID, string position, string userName, string password, string fullName = "", string phone = "", string email = "")
        {
            bool res;

            /*Check UserID or UserName exits*/
            DataTable data = mMydatabase.GetData(DataBase.TABLE_DB.tula_table8, userID, userName);
            if (data.Rows.Count != 0)
            {
                return false;
            }
            // get groupID by position
            var groupID = group.getGroupKeyByName(position);
            string topPicNoti = position;
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table8, userID, position, userName,
                                        password, fullName, phone, email, "", groupID.ToString(), topPicNoti);
            return res;
        }

        public bool delete(int userKey)
        {
            bool res;
            res = mMydatabase.DeleteData(DataBase.TABLE_DB.tula_table8, userKey);
            return res;
        }

        public bool update(uint userKey, string userID, string position, string userName, string password = null, string fullName = null, string phone = null, string email = null)
        {
            bool res;
            var groupID = group.getGroupKeyByName(position);
            string topPicNoti = position;
            res = mMydatabase.EditData(DataBase.TABLE_DB.tula_table8, userKey, userID, position, userName, password, fullName, phone, email, null, groupID.ToString(), topPicNoti);
            return res;
        }
        public UserData login(string userName, string password, string permission)
        {
            List<UserData> listUser = SearchValue(userName);
            foreach (var user in listUser)
            {
                if (user.userName == userName && mMydatabase.checkPermission(userName, permission))
                {                
                    try
                    {
                        var checkPass = BCrypt.Net.BCrypt.Verify(password, user.password);
                        if (checkPass == true)
                        {
                            return user;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    catch (Exception ex)
                    {
                        //return user;
                        //throw;
                    }
                }
            }
            return null;
        }

        public void logout()
        {
            userCurrent = null;
        }

        public string getNameUserLogin()
        {
            if (userCurrent !=null)
            {
                return userCurrent.userName;
            }
            return ""; 
        }
        public void setCurrentUser(UserData user)
        {
            userCurrent = user;
        }
        public bool userHasPermission(string userName, string permissionname)
        {
            return mMydatabase.checkPermission(userName, permissionname);
        }

        public bool checkUserLoginHMI(string userName, string password)
        {
            //userHasPermission(userName, permissionname);
            List<UserData> listUser = SearchValue(userName);
            foreach (var user in listUser)
            {
                if (user.userName == userName)
                {
                    try
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
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
