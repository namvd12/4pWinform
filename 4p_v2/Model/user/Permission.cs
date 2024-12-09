using _4P_PROJECT.DataBase;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Mysqlx.Notice.Warning.Types;
using static SabanWi.Model.user.Group;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SabanWi.Model.user
{
    public class Permission
    {
        public class PermissionData
        {
            public uint permissionKey;           //tula_key
            public string permissionName;        //tula_1
            public string description;           //tula_2
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

        private bool CreatePermission(string permissionName, string decription)
        {
            bool res;
            res = mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, permissionName, decription);
            return res;
        }

        public void Create_Read_Write_Delete()
        {
            CreatePermission("Read", "mode read all system");
            CreatePermission("Write", "mode write to system");
            CreatePermission("Edit", "mode edit system");
        }

        public UInt32 getPermissionKeyByName(string permissionName)
        {
            PermissionData data = new PermissionData();
            DataTable dt = mMydatabase.GetData(DataBase.TABLE_DB.tula_table11, permissionName);
            if (dt != null)
            {
                foreach (DataRow row in dt.Rows)
                {
                    data.permissionKey = Convert.ToUInt32(row["tula_key"]);
                    data.permissionName = Convert.ToString(row["tula1"]);
                    data.description = Convert.ToString(row["tula2"]);
                }
            }
            else
            {
                return 0;
            }
            return data.permissionKey;
        }

        public void setDefaultPermission()
        {
            /* Set default permission */
            /* User*/
            if (getPermissionKeyByName("View_User") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_user", "View user ");
            }
            if (getPermissionKeyByName("Edit_User") == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_user", "Edit user ");
            }
            if (getPermissionKeyByName("Delete_User") == 0) 
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_user", "Delete user ");
            }

            /* Device*/
            if (getPermissionKeyByName("View_device") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_device", "View device");
            }
            if (getPermissionKeyByName("Edit_device") == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_device", "Edit device");
            }
            if (getPermissionKeyByName("Delete_device") == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_device", "Delete device");
            }

            /* Device plan*/
            if (getPermissionKeyByName("View_devicePlan") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_devicePlan", "View devicePlan");
            }
            if (getPermissionKeyByName("Edit_devicePlan") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_devicePlan", "Edit devicePlan");
            }
            if (getPermissionKeyByName("Delete_devicePlan") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_devicePlan", "Delete devicePlan");
            }

            if (getPermissionKeyByName("Delete_history") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_history", "Delete history");
            }

            /* spare part*/
            if (getPermissionKeyByName("View_sparePart") == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_sparePart", "View sparePart");
            }
            if (getPermissionKeyByName("Edit_sparePart") == 0)
            { 
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_sparePart", "Edit system");
            }
            if (getPermissionKeyByName("Delete_sparePart") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_sparePart", "Delete system");
            } 
            
            /*call material*/
            if (getPermissionKeyByName("View_callMaterial") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_callMaterial", "View call material");
            }
            if (getPermissionKeyByName("Edit_callMaterial") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_callMaterial", "Edit call material");
            }
            if (getPermissionKeyByName("Delete_callMaterial") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_callMaterial", "Delete call material");
            }

            /*Setup system*/
            if (getPermissionKeyByName("View_setupSystem") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "View_setupSystem", "View setup system");
            }
            if (getPermissionKeyByName("Edit_setupSystem") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Edit_setupSystem", "Edit setup system");
            }
            if (getPermissionKeyByName("Delete_setupSystem") == 0)
            {
                mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table11, "Delete_setupSystem", "Delete setup system");
            }
        }
    }
}
