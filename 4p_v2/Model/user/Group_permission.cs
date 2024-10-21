using _4P_PROJECT.DataBase;
using GiamSat;
using Syncfusion.Compression.Zip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SabanWi.Model.user.Group;

namespace SabanWi.Model.user
{
    internal class Group_permission
    {
        public class GroupPermissionData
        {
            public uint GroupPermissionKey;            //tula_key
            public string groupKey;                    //tula_1
            public string permissionKey;               //tula_2
        }

        private Group groupUser = new Group();

        private Permission permission = new Permission();

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
                groupUser.database = value;
                permission.database = value;
            }
        }

        public void setGroup_Permission(string groupname, string []permissionArray)
        {
            foreach (string permissionName in permissionArray) {

                UInt32 groupKey =  groupUser.getGroupKeyByName(groupname);
                UInt32 permissionKey = permission.getPermissionKeyByName(permissionName);
                if (groupKey != 0 && permissionKey !=0) {
                    var key = mMydatabase.GetKey(DataBase.TABLE_DB.tula_table12, groupKey.ToString(), permissionKey.ToString());
                    if (key == 0)
                    {
                        mMydatabase.AddNewData(DataBase.TABLE_DB.tula_table12, groupKey.ToString(), permissionKey.ToString());
                    }
                }
            }
        }

        public void setDefaut_group_permission()
        {
            string []list_permission_admin = { "View_user"       , "Edit_user"       , "Delete_user", 
                                               "View_device"     , "Edit_device"     , "Delete_device", 
                                               "View_devicePlan" , "Edit_devicePlan" , "Delete_devicePlan", 
                                               "View_sparePart"  , "Edit_sparePart"  , "Delete_sparePart",
                                               "View_callMaterial"  , "Edit_callMaterial"  , "Delete_callMaterial",
            };
            setGroup_Permission(groupName.admin, list_permission_admin);

            string[] list_permission_leader = {"View_device"     , "Edit_device"     , "Delete_device",
                                               "View_devicePlan" , "Edit_devicePlan" , "Delete_devicePlan",
                                               "View_sparePart"  , "Edit_sparePart"  , "Delete_sparePart"};
            setGroup_Permission(groupName.teamLeader, list_permission_leader);
            setGroup_Permission(groupName.partLeader, list_permission_leader);

            string[] list_permission_engineer = {"View_device"     , "Edit_device"     , "Delete_device",
                                                 "View_devicePlan" ,  
                                                 "View_sparePart"  ,};
            setGroup_Permission(groupName.engineer, list_permission_engineer);

            string[] list_permission_customer = {"View_device"     ,
                                                 "View_devicePlan" ,
                                                 "View_sparePart"  ,};
            setGroup_Permission(groupName.customer, list_permission_customer);

            string[] list_permission_test = {"View_device"     ,
                                                 "View_devicePlan" ,
                                                 "View_sparePart"  ,};
            setGroup_Permission(groupName.test, list_permission_test);            
            
            string[] list_permission_callMaterial = {"View_callMaterial",
                                                 "Edit_callMaterial" ,
                                                 "Delete_callMaterial"  ,};
            setGroup_Permission(groupName.callMaterial, list_permission_callMaterial);
        }
    }
}
