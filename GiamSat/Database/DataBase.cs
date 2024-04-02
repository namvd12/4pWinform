using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using OfficeOpenXml.Utils;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _4P_PROJECT.DataBase
{
    public partial class DataBase
    {
        public MySqlConnection myConnection;
        const string ipAddr = "localhost";
        const string port = "3306";
        const string user = "root";
        const string pass = "123456a@";
        const string sourceDB = "test2";
        bool isConnected = false;
        public int number_path_image = 100;
        public int number_status_device = 100;
        public enum TABLE_DB
        {
            tb_device,
            tb_image,
            tb_status,
        }
        public bool Connect()
        {
            string myConnectionDataBase;
            string myConnectionWithoutDb;
            //set the correct values for your server, user, password and database name
            myConnectionDataBase = string.Format("server={0}; port={1};uid={2}; pwd={3}; database={4}", ipAddr, port, user, pass, sourceDB);
            try
            {
                myConnection = new MySqlConnection(myConnectionDataBase);
                //open a connection
                myConnection.Open();
                isConnected = true;
                return true;
            }
            catch (global::MySql.Data.MySqlClient.MySqlException ex)
            {
                isConnected = false;
                return false;
            }
        }
        public bool IsConnected()
        {
            return isConnected;
        }
        public bool Disconnect()
        {
            if (myConnection != null && isConnected == true)
            {
                myConnection.Close();
                return true;
            }
            return false;
        }
        private void CreateDatabase()
        {
            string command = "CREATE DATABASE " + sourceDB;
            MySqlCommand cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
        }
        public bool InitDataBase()
        {
            if (!isTableExit(TABLE_DB.tb_device))
            {
                // create table device
                CreateTable(TABLE_DB.tb_device);
            }
            if (!isTableExit(TABLE_DB.tb_status))
            {
                // create table image first!!!
                CreateTable(TABLE_DB.tb_status);
            }
            if (!isTableExit(TABLE_DB.tb_image))
            {
                // create table image first!!!
                CreateTable(TABLE_DB.tb_image);
            }

            return true;
        }

        private bool isDataBaseExit(string name)
        {
            if (isConnected)
            {
                string command = string.Format("Select * from {0}", name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if (Convert.ToInt32(obj) > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        private bool isTableExit(TABLE_DB nameTable)
        {
            string table_name = null;
            if (nameTable == TABLE_DB.tb_device)
            {
                table_name = "device";
            }
            else if (nameTable == TABLE_DB.tb_image)
            {
                table_name = "image";
            }
            else if (nameTable == TABLE_DB.tb_status)
            {
                table_name = "status";
            }
            else
            {
                return false;
            }
            if (isConnected)
            {
                string command = string.Format("SELECT count(*) FROM information_schema.TABLES WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'", sourceDB, table_name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                object obj = cmd.ExecuteScalar();
                if (Convert.ToInt32(obj) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void CreateTable(TABLE_DB tableName)
        {
            string command;
            MySqlCommand cmd;
            switch (tableName)
            {
                case TABLE_DB.tb_device:
                    command = "CREATE TABLE `device` (\r\n\t`DeviceID` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Name` VARCHAR(100) NOT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`SN` VARCHAR(100) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',\r\n\t`Person` VARCHAR(100) NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',\r\n\t`Manufacturer` VARCHAR(100) NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',\r\n\t`Time` CHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Status` VARCHAR(100) NULL DEFAULT '0' COLLATE 'utf8mb4_general_ci',\r\n\t`Note` TEXT NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`DeviceID`) USING BTREE\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tb_image:
                    command = "CREATE TABLE `image` (\r\n\t`ImageID` INT(10) NOT NULL AUTO_INCREMENT,\r\n\t`DeviceID` VARCHAR(100) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',\r\n\t`Image_path` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Time` VARCHAR(50) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`ImageID`) USING BTREE,\r\n\tINDEX `FK_image_status` (`DeviceID`) USING BTREE,\r\n\tCONSTRAINT `FK_image_status` FOREIGN KEY (`DeviceID`) REFERENCES `device` (`DeviceID`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=1\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    //add colum

                    break;
                case TABLE_DB.tb_status:
                    command = "CREATE TABLE `status` (\r\n\t`StatusID` INT(10) NOT NULL AUTO_INCREMENT,\r\n\t`DeviceID` VARCHAR(100) NOT NULL DEFAULT '' COLLATE 'utf8mb4_general_ci',\r\n\t`Status` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Time` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Image_path` VARCHAR(100) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`Note` TEXT NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`StatusID`) USING BTREE,\r\n\tINDEX `FK_status_device` (`DeviceID`) USING BTREE,\r\n\tCONSTRAINT `FK_status_device` FOREIGN KEY (`DeviceID`) REFERENCES `device` (`DeviceID`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=1\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }

        private string SearchDeviceIDFromTable(string SN)
        {    
            string command = string.Format("SELECT DeviceID FROM device WHERE SN = \'{0}\'", SN);
            MySqlCommand cmd = new MySqlCommand(command, myConnection);
            string DeviceID = null;
            using (var cursor = cmd.ExecuteReader())
            {
                while (cursor.Read())
                {
                    DeviceID = Convert.ToString(cursor["DeviceID"]);
                }
            }
            return DeviceID;
        }
        public bool CreateNewDevice(string ID, string Name, string SN = "", string Person = "", string Manufacturer = "", string Time = "", string Status = "")
        {
            string command;
            MySqlCommand cmd;
            if (!isConnected)
            {
                return false;
            }
            try
            {
                // STEP1: insert new data in device table
                command = string.Format("INSERT INTO device (DeviceID, Name, SN, Person, Manufacturer, Time, Status)" +
                    "\r\nVALUES ('{0}', \'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\')", ID, Name, SN, Person, Manufacturer, Time, Status);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool CheckDeviceExist(string DeviceID)
        {
            string command;
            MySqlCommand cmd;
            command = string.Format("SELECT DeviceID FROM device WHERE DeviceID = \'{0}\'", DeviceID);
            cmd = new MySqlCommand(command, myConnection);

            object obj = cmd.ExecuteScalar();
            if (Convert.ToInt32(obj) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateDevice(string Name, string SN, string Person = "", string Manufacturer = "", UInt16 TimeOP = 0, string Status = "")
        {
            string command;
            MySqlCommand cmd;
            if (!isConnected)
            {
                return false;
            }

            // update data in device 
            command = string.Format("UPDATE device SET Name = \'{0}\', SN = \'{1}\', Person = \'{2}\', Manufacturer = \'{3}\', TimeOP = {4}, Status = \'{5}\'" +
                      " WHERE SN = \'{1}\'", Name, SN, Person, Manufacturer, TimeOP, Status);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool UpdateDeviceStatus(string DeviceID, string Status)
        {
            string command;
            MySqlCommand cmd;
            if (!isConnected)
            {
                return false;
            }
            string time_str = DateTime.Now.ToString("MM/dd/yyyy h:mm:s tt");
            // add status in device table 
            command = string.Format("UPDATE device" +
                "\r\nSET Status = \'{0}\', Time = \'{1}\'" +
                "\r\nWHERE DeviceID = \'{2}\';", Status, time_str, DeviceID);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();

            // add new data in status table 
            command = string.Format("INSERT INTO status (DeviceID, Status, Time)" +
                "\r\nVALUES (\'{0}\', \'{1}\', \'{2}\');", DeviceID, Status, time_str);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
            return true;
        }

        public string ReadDeviceStatus(string DeviceID)
        {
            string command;
            MySqlCommand cmd;
            string status = null;
            command = string.Format("SELECT Status FROM device WHERE DeviceID = \'{0}\'", DeviceID);
            cmd = new MySqlCommand(command, myConnection);

            using (var cursor = cmd.ExecuteReader())
            {
                while (cursor.Read())
                {
                    status = Convert.ToString(cursor["Status"]);
                }
            }
            return status;
        }
    }
}
