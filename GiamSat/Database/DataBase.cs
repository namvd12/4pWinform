using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace _4P_PROJECT.DataBase
{
    public partial class DataBase
    {
        public MySqlConnection myConnection;
        const string ipAddr = "localhost";
        const string port = "3306";
        const string user = "root";
        const string pass = "123456a@";
        const string sourceDB = "test";
        bool isConnected = false;
        public int number_path = 100;
        public enum TABLE_DB
        {
            tb_device,
            tb_image
        }
        public bool Connect()
        {
            string myConnectionString;
            //set the correct values for your server, user, password and database name
            myConnectionString = string.Format("server={0}; port={1};uid={2}; pwd={3}; database={4}", ipAddr, port, user, pass, sourceDB);
            try
            {
                myConnection = new MySqlConnection(myConnectionString);
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

        public bool InitDataBase()
        {
            // Check image exit first !!!
            if (!isTableExit(TABLE_DB.tb_device))
            {
                // create table image first!!!
                CreateTable(TABLE_DB.tb_image);
            }

            if (!isTableExit(TABLE_DB.tb_device))
            {
                // create table device
                CreateTable(TABLE_DB.tb_device);
            }

            return true;
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
            switch (tableName)
            {
                case TABLE_DB.tb_device:
                    command = "CREATE TABLE `device` (" +
                        "\r\n\t`SN` VARCHAR(100) NOT NULL DEFAULT '' COLLATE 'latin1_swedish_ci'," +
                        "\r\n\t`Name` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci'," +
                        "\r\n\t`Model` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci'," +
                        "\r\n\t`Status` VARCHAR(100) NULL DEFAULT NULL COLLATE 'latin1_swedish_ci'," +
                        "\r\n\t`TimeOP` INT(11) NULL DEFAULT NULL," +
                        "\r\n\t`ID_Image` VARCHAR(100) NULL DEFAULT NULL," +
                        "\r\n\tPRIMARY KEY (`SN`) USING BTREE,\r\n\tINDEX `FK_device_information_image` (`ID_Image`) USING BTREE," +
                        "\r\n\tCONSTRAINT `FK_device_information_image` FOREIGN KEY (`ID_Image`) REFERENCES `image` (`ID_Image`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)" +
                        "\r\nCOLLATE='latin1_swedish_ci'" +
                        "\r\nENGINE=InnoDB\r\n";
                    MySqlCommand cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tb_image:
                    command = "CREATE TABLE `image` (" +
                        "\r\n\t`ID_Image` VARCHAR(100) NOT NULL ," +
                        "\r\n\tPRIMARY KEY (`ID_Image`) USING BTREE\r\n)" +
                        "\r\nCOLLATE='latin1_swedish_ci'" +
                        "\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=4\r\n;";
                    MySqlCommand cmd1 = new MySqlCommand(command, myConnection);
                    cmd1.ExecuteNonQuery();
                    //add colum
                    for (int i = 1; i <= number_path; i++)
                    {
                        command = string.Format("ALTER TABLE image ADD `{0}` VARCHAR(50) NULL DEFAULT 'NULL' COLLATE 'latin1_swedish_ci'", "Path" + i);
                        cmd1 = new MySqlCommand(command, myConnection);
                        cmd1.ExecuteNonQuery();
                    }
                    break;
                default:
                    break;
            }
        }

        public bool CreateNewDevice(string SN, string Name, string Model, UInt16 TimeOP = 0, string Status = "NON")
        {
            string command;
            MySqlCommand cmd;
            if (!isConnected)
            {
                return false;
            }
            // STEP1: insert new row in image 
            command = string.Format("INSERT INTO image (ID_Image) VALUES (\'{0}\')", SN);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();

            // STEP2: insert new row in device 
            command = string.Format("INSERT INTO device (SN, Name, Model, Status, TimeOP, ID_Image)" +
                "\r\nVALUES (\'{0}\', \'{1}\', \'{2}\', \'{3}\', {4}, \'{5}\')", SN, Name, Model, Status, TimeOP, SN);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
            return true;
        }

        public bool CheckDeviceExist(string SN)
        {
            string command;
            MySqlCommand cmd;
            command = string.Format("SELECT SN FROM device WHERE SN = \'{0}\'", SN);
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

        public bool UpdateDevice(string SN, string Name, string Model, UInt16 TimeOP = 0, string Status = "NON")
        {
            string command;
            MySqlCommand cmd;
            if (!isConnected)
            {
                return false;
            }

            // update data in device 
            command = string.Format("UPDATE device SET Name = \'{0}\', Model = \'{1}\', Status = \'{2}\', TimeOP = {3}" +
                      " WHERE SN = \'{4}\'", Name, Model, Status, TimeOP, SN);
            cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
            return true;
        }
    }
}
