using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using MySql.Data.MySqlClient;
using Mysqlx;
using System;
using System.Collections.Generic;
using System.Data;
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
        private MySqlConnection myConnection;
        private static Mutex mutexMySql = new Mutex();
        private string ipAddr = "127.0.0.1";
        const string port = "3306";
        const string user = "root";
        const string pass = "123456a@";
        const string sourceDB = "4p_db";
        private string path = "setting.bin";
        bool isConnected = false;

        public enum TABLE_DB
        {
            tula_table1,
            tula_table2,
            tula_table3,
            tula_table4,
            tula_table5,
            tula_table6,
            tula_table7,
            tula_table8,
            tula_table9,
        }
        public bool Connect()
        {
            string myConnectionDataBase;
            if (isConnected == true)
            {
                return true;
            }
            // read Ipadress server
            if (File.Exists(path))
            {           
                ipAddr = File.ReadAllText(path);
            }
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

        private void waitConnectFree()
        {
            mutexMySql.WaitOne();
        }

        private void releaseConnect()
        {
            mutexMySql.ReleaseMutex();
        }
        private void CreateDatabase()
        {
            string command = "CREATE DATABASE " + sourceDB;
            MySqlCommand cmd = new MySqlCommand(command, myConnection);
            cmd.ExecuteNonQuery();
        }
        public bool InitDataBase()
        {
            if (!isTableExit(TABLE_DB.tula_table1))
            {
                CreateTable(TABLE_DB.tula_table1);
            }
            if (!isTableExit(TABLE_DB.tula_table2))
            {
                CreateTable(TABLE_DB.tula_table2);
            }
            else
            {
                int numberColum = numberOfcolum(TABLE_DB.tula_table2);
                if (numberColum == 21)
                {
                    Addcolum(TABLE_DB.tula_table2);
                }
            }
            if (!isTableExit(TABLE_DB.tula_table3))
            {
                CreateTable(TABLE_DB.tula_table3);
            }
            if (!isTableExit(TABLE_DB.tula_table4))
            {
                CreateTable(TABLE_DB.tula_table4);
            }
            if (!isTableExit(TABLE_DB.tula_table5))
            {
                CreateTable(TABLE_DB.tula_table5);
            }
            if (!isTableExit(TABLE_DB.tula_table6))
            {
                CreateTable(TABLE_DB.tula_table6);
            }
            if (!isTableExit(TABLE_DB.tula_table7))
            {
                CreateTable(TABLE_DB.tula_table7);
            }
            if (!isTableExit(TABLE_DB.tula_table8))
            {
                CreateTable(TABLE_DB.tula_table8);
            }
            if (!isTableExit(TABLE_DB.tula_table9))
            {
                CreateTable(TABLE_DB.tula_table9);
            }
            return true;
        }

        private bool isTableExit(TABLE_DB nameTable)
        {
            string table_name = null;
            if (nameTable == TABLE_DB.tula_table1)
            {
                table_name = "tula_table1";
            }
            else if (nameTable == TABLE_DB.tula_table2)
            {
                table_name = "tula_table2";
            }
            else if (nameTable == TABLE_DB.tula_table3)
            {
                table_name = "tula_table3";
            }
            else if (nameTable == TABLE_DB.tula_table4)
            {
                table_name = "tula_table4";
            }
            else if (nameTable == TABLE_DB.tula_table5)
            {
                table_name = "tula_table5";
            }
            else if (nameTable == TABLE_DB.tula_table6)
            {
                table_name = "tula_table6";
            }
            else if (nameTable == TABLE_DB.tula_table7)
            {
                table_name = "tula_table7";
            }
            else if (nameTable == TABLE_DB.tula_table8)
            {
                table_name = "tula_table8";
            }
            else if (nameTable == TABLE_DB.tula_table9)
            {
                table_name = "tula_table9";
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

        private int numberOfcolum(TABLE_DB nameTable)
        {
            string table_name = null;
            if (nameTable == TABLE_DB.tula_table1)
            {
                table_name = "tula_table1";
            }
            else if (nameTable == TABLE_DB.tula_table2)
            {
                table_name = "tula_table2";
            }
            else if (nameTable == TABLE_DB.tula_table3)
            {
                table_name = "tula_table3";
            }
            else if (nameTable == TABLE_DB.tula_table4)
            {
                table_name = "tula_table4";
            }
            else if (nameTable == TABLE_DB.tula_table5)
            {
                table_name = "tula_table5";
            }
            else if (nameTable == TABLE_DB.tula_table6)
            {
                table_name = "tula_table6";
            }
            else if (nameTable == TABLE_DB.tula_table7)
            {
                table_name = "tula_table7";
            }
            else if (nameTable == TABLE_DB.tula_table8)
            {
                table_name = "tula_table8";
            }
            else
            {
                return 0;
            }
            if (isConnected)
            {
                string command = string.Format("SELECT count(*) FROM information_schema.columns WHERE TABLE_SCHEMA = '{0}' AND TABLE_NAME = '{1}'", sourceDB, table_name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                object obj = cmd.ExecuteScalar();
                int numberColums = Convert.ToInt32(obj);
                if (numberColums > 0)
                {
                    return numberColums;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        private bool Addcolum(TABLE_DB nameTable)
        {
            string table_name = null;
            if (nameTable == TABLE_DB.tula_table1)
            {
                table_name = "tula_table1";
            }
            else if (nameTable == TABLE_DB.tula_table2)
            {
                table_name = "tula_table2";
            }
            else if (nameTable == TABLE_DB.tula_table3)
            {
                table_name = "tula_table3";
            }
            else if (nameTable == TABLE_DB.tula_table4)
            {
                table_name = "tula_table4";
            }
            else if (nameTable == TABLE_DB.tula_table5)
            {
                table_name = "tula_table5";
            }
            else if (nameTable == TABLE_DB.tula_table6)
            {
                table_name = "tula_table6";
            }
            else if (nameTable == TABLE_DB.tula_table7)
            {
                table_name = "tula_table7";
            }
            else if (nameTable == TABLE_DB.tula_table8)
            {
                table_name = "tula_table8";
            }
            else
            {
                return false;
            }
            if (isConnected)
            {
                string command = string.Format("ALTER TABLE {0}\r\nADD tula21 varchar(255),ADD tula22 varchar(255), ADD tula23 varchar(255),  ADD tula24 varchar(255)," +
                    " ADD tula25 varchar(255),  ADD tula26 varchar(255),  ADD tula27 varchar(255),  ADD tula28 varchar(255),  ADD tula29 varchar(255),  ADD tula30 varchar(255)", table_name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
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
                case TABLE_DB.tula_table1:
                    command = "CREATE TABLE `tula_table1` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=1\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table2:
                    command = "CREATE TABLE `tula_table2` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table2_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table3:
                    command = "CREATE TABLE `tula_table3` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table3_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table4:
                    command = "CREATE TABLE `tula_table4` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table4_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table5:
                    command = "CREATE TABLE `tula_table5` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table5_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table6:
                    command = "CREATE TABLE `tula_table6` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table6_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table7:
                    command = "CREATE TABLE `tula_table7` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` INT(10) UNSIGNED NOT NULL ,\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE,\r\n\tCONSTRAINT `FK_tula_table7_tula_table1` FOREIGN KEY (`tula1`) REFERENCES `tula_table1` (`tula_Key`) ON UPDATE NO ACTION ON DELETE NO ACTION\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\n;\r\n";
                    cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table8:
                    command = "CREATE TABLE `tula_table8` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=1\r\n;\r\n"; cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                case TABLE_DB.tula_table9:
                    command = "CREATE TABLE `tula_table9` (\r\n\t`tula_Key` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,\r\n\t`tula1` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula2` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula3` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula4` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula5` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula6` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula7` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula8` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula9` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula10` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula11` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula12` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula13` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula14` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula15` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula16` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula17` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula18` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula19` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\t`tula20` VARCHAR(250) NULL DEFAULT NULL COLLATE 'utf8mb4_general_ci',\r\n\tPRIMARY KEY (`tula_Key`) USING BTREE\r\n)\r\nCOLLATE='utf8mb4_general_ci'\r\nENGINE=InnoDB\r\nAUTO_INCREMENT=1\r\n;\r\n"; cmd = new MySqlCommand(command, myConnection);
                    cmd.ExecuteNonQuery();
                    break;
                default:
                    break;
            }
        }

        public bool AddNewData(TABLE_DB tableName, string tula1 = "", string tula2 = "", string tula3 = "", string tula4 = "", string tula5 = "", string tula6 = "", string tula7 = "", string tula8 = "", string tula9 = "",
                                         string tula10 = "", string tula11 = "", string tula12 = "", string tula13 = "", string tula14 = "", string tula15 = "", string tula16 = "", string tula17 = "", string tula18 = "", string tula19 = "", string tula20 = "",
                                         string tula21 = "")
        {
            string command = "";
            MySqlCommand cmd;
            string table_Name = "";
            if (!isConnected)
            {
                return false;
            }
            try
            {
                if (tableName == TABLE_DB.tula_table1)
                {
                    table_Name = "tula_table1";
                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES (\'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if(tableName == TABLE_DB.tula_table2)
                {
                    table_Name = "tula_table2";
                    
                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20, tula21)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20, tula21);
                }
                else if (tableName == TABLE_DB.tula_table3)
                {
                    table_Name = "tula_table3";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if (tableName == TABLE_DB.tula_table4)
                {
                    table_Name = "tula_table4";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if (tableName == TABLE_DB.tula_table5)
                {
                    table_Name = "tula_table5";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if (tableName == TABLE_DB.tula_table6)
                {
                    table_Name = "tula_table6";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if (tableName == TABLE_DB.tula_table7)
                {
                    table_Name = "tula_table7";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES ({1}, \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, Convert.ToInt32(tula1), tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                else if (tableName == TABLE_DB.tula_table8)
                {
                    table_Name = "tula_table8";

                    command = string.Format("INSERT INTO {0} (tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, " +
                                            "tula9, tula10, tula11, tula12, tula13, tula14, tula15, tula16, tula17, tula18, tula19, tula20)" +
                                            "\r\nVALUES (\'{1}\', \'{2}\', \'{3}\', \'{4}\', \'{5}\', \'{6}\', \'{7}\',\'{8}\', \'{9}\', \'{10}\', " +
                                            "\'{11}\', \'{12}\', \'{13}\', \'{14}\', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}')",
                                            table_Name, tula1, tula2, tula3, tula4, tula5, tula6, tula7, tula8, tula9, tula10, tula11, tula12, tula13, tula14, tula15
                                            , tula16, tula17, tula18, tula19, tula20);
                }
                waitConnectFree();
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
                releaseConnect();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool EditData(TABLE_DB tableName, UInt64 tula_key, string tula1 = null, string tula2 = null, string tula3 = null, string tula4 = null, string tula5 = null, string tula6 = null, string tula7 = null, string tula8 = null, string tula9 = null,
                            string tula10 = null, string tula11 = null, string tula12 = null, string tula13 = null, string tula14 = null, string tula15 = null, string tula16 = null, string tula17 = null, string tula18 = null, string tula19 = null, string tula20 = null)
        {
            string command = "";
            MySqlCommand cmd;
            string nameTable = "";
            bool FirstValue = true;
            if (!isConnected)
            {
                return false;
            }

            if (tableName == TABLE_DB.tula_table1)
            {
                nameTable = "tula_table1";
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                nameTable = "tula_table2";
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                nameTable = "tula_table3";
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                nameTable = "tula_table4";
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                nameTable = "tula_table5";
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                nameTable = "tula_table6";
            }
            else if (tableName == TABLE_DB.tula_table7)
            {
                nameTable = "tula_table7";
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                nameTable = "tula_table8";
            }
            if (tula1 != null)
            {
                tula1 = string.Format("tula1 = \"{0}\"", tula1);
                FirstValue = false;
            }
            if (tula2 != null)
            {
                if (FirstValue == true)
                {
                    tula2 = string.Format("tula2 = \"{0}\"", tula2);
                    FirstValue = false;
                }
                else
                { 
                    tula2 = string.Format(", tula2 = \"{0}\"", tula2);
                }
            }
            if (tula3 != null)
            {
                if (FirstValue == true)
                {
                    tula3 = string.Format("tula3 = '{0}'", tula3);
                    FirstValue = false;
                }
                else
                {
                    tula3 = string.Format(", tula3 = '{0}'", tula3);
                }
            }
            if (tula4 != null)
            {
                if (FirstValue == true)
                {
                    tula4 = string.Format("tula4 = \"{0}\"", tula4);
                    FirstValue = false;
                }
                else
                {
                    tula4 = string.Format(", tula4 = \"{0}\"", tula4);
                }
            }
            if (tula5 != null)
            {
                if (FirstValue == true)
                {
                    tula5 = string.Format("tula5 = \"{0}\"", tula5);
                    FirstValue = false;
                }
                else
                {
                    tula5 = string.Format(", tula5 = \"{0}\"", tula5);
                }
            }
            if (tula6 != null)
            {
                if (FirstValue == true)
                {
                    tula6 = string.Format("tula6 = \"{0}\"", tula6);
                    FirstValue = false;
                }
                else
                {
                    tula6 = string.Format(", tula6 = \"{0}\"", tula6);
                }
            }
            if (tula7 != null)
            {
                if (FirstValue == true)
                {
                    tula7 = string.Format("tula7 = \"{0}\"", tula7);
                    FirstValue = false;
                }
                else
                {
                    tula7 = string.Format(", tula7 = \"{0}\"", tula7);
                }
            }
            if (tula8 != null)
            {
                if (FirstValue == true)
                {
                    tula8 = string.Format("tula8 = \"{0}\"", tula8);
                    FirstValue = false;
                }
                else
                {
                    tula8 = string.Format(", tula8 = \"{0}\"", tula8);
                }
            }
            if (tula9 != null)
            {
                if (FirstValue == true)
                {
                    tula9 = string.Format("tula9 = \"{0}\"", tula9);
                    FirstValue = false;
                }
                else
                {
                    tula9 = string.Format(", tula9 = \"{0}\"", tula9);
                }
            }
            if (tula10 != null)
            {
                if (FirstValue == true)
                {
                    tula10 = string.Format("tula10 = \"{0}\"", tula10);
                    FirstValue = false;
                }
                else
                {
                    tula10 = string.Format(", tula10 = \"{0}\"", tula10);
                }
            }
            if (tula11 != null)
            {
                if (FirstValue == true)
                {
                    tula11 = string.Format("tula11 = \"{0}\"", tula11);
                    FirstValue = false;
                }
                else
                {
                    tula11 = string.Format(", tula11 = \"{0}\"", tula11);
                }
            }
            if (tula12 != null)
            {
                if (FirstValue == true)
                {
                    tula12 = string.Format("tula12 = \"{0}\"", tula12);
                    FirstValue = false;
                }
                else
                {
                    tula12 = string.Format(", tula12 = \"{0}\"", tula12);
                }
            }
            if (tula13 != null)
            {
                if (FirstValue == true)
                {
                    tula13 = string.Format("tula13 = \"{0}\"", tula13);
                    FirstValue = false;
                }
                else
                {
                    tula13 = string.Format(", tula13 = \"{0}\"", tula13);
                }
            }
            if (tula14 != null)
            {
                if (FirstValue == true)
                {
                    tula14 = string.Format("tula14 = \"{0}\"", tula14);
                    FirstValue = false;
                }
                else
                {
                    tula14 = string.Format(", tula14 = \"{0}\"", tula14);
                }
            }
            if (tula15 != null)
            {
                if (FirstValue == true)
                {
                    tula15 = string.Format("tula15 = \"{0}\"", tula15);
                    FirstValue = false;
                }
                else
                {
                    tula15 = string.Format(", tula15 = \"{0}\"", tula15);
                }
            }
            if (tula16 != null)
            {
                if (FirstValue == true)
                {
                    tula16 = string.Format("tula16 = \"{0}\"", tula16);
                    FirstValue = false;
                }
                else
                {
                    tula16 = string.Format(", tula16 = \"{0}\"", tula16);
                }
            }
            if (tula17 != null)
            {
                if (FirstValue == true)
                {
                    tula17 = string.Format("tula17 = \"{0}\"", tula17);
                    FirstValue = false;
                }
                else
                {
                    tula17 = string.Format(", tula17 = \"{0}\"", tula17);
                }
            }

            if (tula18 != null)
            {
                if (FirstValue == true)
                {
                    tula18 = string.Format("tula18 = \"{0}\"", tula18);
                    FirstValue = false;
                }
                else
                {
                    tula18 = string.Format(", tula18 = \"{0}\"", tula18);
                }
            }
            if (tula19 != null)
            {
                if (FirstValue == true)
                {
                    tula19 = string.Format("tula19 = \"{0}\"", tula19);
                    FirstValue = false;
                }
                else
                {
                    tula19 = string.Format(", tula19 = \"{0}\"", tula19);
                }
            }
            if (tula20 != null)
            {
                if (FirstValue == true)
                {
                    tula20 = string.Format("tula20 = \"{0}\"", tula20);
                    FirstValue = false;
                }
                else
                {
                    tula20 = string.Format(", tula20 = \"{0}\"", tula20);
                }
            }
            command = string.Format("UPDATE {0} SET " + tula1 + tula2 + tula3 + tula4 + tula5 + tula6 + tula7 + tula8 + tula9 + tula10 + tula11 + tula12 + tula13 + tula14 + tula15 + tula16 + tula17 + tula18 + tula19 + tula20
                                    + " WHERE tula_key = {1}", nameTable, tula_key);
            try
            {
                waitConnectFree();
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
                releaseConnect();
                return true;
            }
            catch (Exception)
            {
                releaseConnect();
                return false;
            }
        }

        public DataTable GetData(TABLE_DB tableName, UInt64 tulaKey )
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = null;
            if (tableName == TABLE_DB.tula_table1)
            {
                table_Name = "tula_table1";

                condition = string.Format("WHERE " + "tula_Key = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                table_Name = "tula_table3";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                table_Name = "tula_table4";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                table_Name = "tula_table5";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            else if (tableName == TABLE_DB.tula_table7)
            {
                table_Name = "tula_table7";
                condition = string.Format("WHERE " + "tula1 = {0}", tulaKey);
            }
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                waitConnectFree();
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                releaseConnect();
                return table;
            }
            catch (Exception)
            {
                releaseConnect();
                return null;
                //throw;
            }
        }

        public DataTable GetData(TABLE_DB tableName, UInt64 tulaKey, int tula1)
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = null;
            if (tableName == TABLE_DB.tula_table1)
            {
                table_Name = "tula_table1";
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";

            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                table_Name = "tula_table3";

            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                table_Name = "tula_table4";

            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                table_Name = "tula_table5";

            }
            waitConnectFree();
            try
            {
                if (tula1 != 0)
                {
                    condition = string.Format("WHERE " + "tula_Key = {0} AND tula1 = {1}", tulaKey, tula1);
                }
                else
                {
                    condition = string.Format("WHERE " + "tula_Key = {0}", tulaKey);
                }
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
 
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);

                
            }
            catch (Exception)
            {
                
            }
            releaseConnect();
            return table;
        }

        public DataTable GetData(TABLE_DB tableName, string value1, string value2)
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = null;
            if (tableName == TABLE_DB.tula_table1)
            {
                table_Name = "tula_table1";
                condition = string.Format("WHERE " + "tula3 = \"{0}\" AND tula4 = \"{1}\"", value1, value2);
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";

            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                table_Name = "tula_table3";

            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                table_Name = "tula_table4";

            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                table_Name = "tula_table5";

            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";

                condition = string.Format("WHERE " + "tula6 = \"{0}\" OR tula6 = \"{1}\"", value1, value2);
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                table_Name = "tula_table8";

                condition = string.Format("WHERE " + "tula1 = \"{0}\" OR tula3 = \"{1}\"", value1, value2);
            }

            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception)
            {

            }
            releaseConnect();
            return table;
        }

        public DataTable GetDataWithLineAndTime(TABLE_DB tableName, string line, string lane, string time1, string time2)
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = null;
            if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";
                if (lane == null)
                {
                    condition = string.Format("WHERE tula3 = \'{0}\' AND str_to_date(tula7,'%d-%m-%Y') BETWEEN \"{1}\" AND \"{2}\" ORDER BY tula_Key DESC", line, time1, time2);
                }
                else
                { 
                    condition = string.Format("WHERE tula3 = \'{0}\' AND tula4 = \'{1}\' AND str_to_date(tula7,'%d-%m-%Y') BETWEEN \"{2}\" AND \"{3}\" ORDER BY tula_Key DESC", line, lane, time1, time2);
                }
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
                if (line != null && lane == null)
                {
                    condition = string.Format("WHERE tula3 = \'{0}\' AND str_to_date(tula5,'%d-%m-%Y') BETWEEN \"{1}\" AND \"{2}\" ORDER BY tula_Key DESC", line, time1, time2);
                }
                else if (line == null && lane == null)
                {
                    condition = string.Format("WHERE str_to_date(tula5,'%d-%m-%Y') BETWEEN \"{0}\" AND \"{1}\" ORDER BY tula_Key DESC", time1, time2);
                }
                else
                {
                    condition = string.Format("WHERE tula3 = \'{0}\' AND tula4 = \'{1}\' AND str_to_date(tula5,'%d-%m-%Y') BETWEEN \"{2}\" AND \"{3}\" ORDER BY tula_Key DESC", line, lane, time1, time2);
                }
            }
            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);              
            }
            catch (Exception)
            {
            }
            releaseConnect();
            return table;
        }

        public DataTable GetAllData(TABLE_DB tableName)
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = null;
            if (tableName == TABLE_DB.tula_table1)
            {
                table_Name = "tula_table1";

            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2" + " ORDER BY tula_Key DESC LIMIT 100";
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                table_Name = "tula_table3";
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                table_Name = "tula_table4";
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                table_Name = "tula_table5";
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
            }
            else if (tableName == TABLE_DB.tula_table7)
            {
                table_Name = "tula_table7";
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                table_Name = "tula_table8";
            }
            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception)
            {
            }
            releaseConnect();
            return table;
        }

        public DataTable GetDataLikeValue(TABLE_DB tableName, string searchValue, string time1 = null, string time2 = null)
        {
            string command;
            string table_Name = null;
            DataTable table = new DataTable();
            string condition = string.Format("WHERE (tula1 LIKE '%{0}%' OR tula2 LIKE '%{0}%' OR tula3 LIKE '%{0}%' OR tula4 LIKE '%{0}%' OR " +
                                "tula5 LIKE '%{0}%' OR tula6 LIKE '%{0}%' OR tula7 LIKE '%{0}%' OR tula8 LIKE '%{0}%' OR tula9 LIKE '%{0}%' OR " +
                                "tula10 LIKE '%{0}%' OR tula11 LIKE '%{0}%' OR tula12 LIKE '%{0}%' OR tula13 LIKE '%{0}%' OR tula14 LIKE '%{0}%' OR " +
                                "tula15 LIKE '%{0}%')", searchValue);
            if (tableName == TABLE_DB.tula_table1)
            {
                table_Name = "tula_table1";
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";
                condition += string.Format(" AND str_to_date(tula7,'%d-%m-%Y') BETWEEN \"{0}\" AND \"{1}\" ORDER BY tula_Key DESC", time1, time2);

            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                table_Name = "tula_table3";
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                table_Name = "tula_table4";
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                table_Name = "tula_table5";
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
                condition += string.Format(" AND str_to_date(tula5,'%d-%m-%Y') BETWEEN \"{0}\" AND \"{1}\" ORDER BY tula_Key DESC", time1, time2);
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                table_Name = "tula_table8";
            }
            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception)
            {
            }
            releaseConnect();
            return table;
        }

        /* Get tula_key from tula1*/
        public UInt64 GetKey(TABLE_DB tableName, string tula1, string tula2 = null)
        {
            string command = "";

            UInt64 tula_key = 0;

            if (tableName == TABLE_DB.tula_table1)
            {
                command = string.Format("SELECT tula_Key FROM tula_table1 WHERE tula1 = '{0}'", tula1);
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                command = string.Format("SELECT tula_Key FROM tula_table2 WHERE tula5 = \"{0}\"", tula1);
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                if (tula1 != null && tula2 != null)
                {
                    command = string.Format("SELECT tula_Key FROM tula_table3 WHERE tula1 = {0} AND tula2 = \"{1}\"", Convert.ToInt32(tula1), tula2);
                }
                else
                {
                    command = string.Format("SELECT tula_Key FROM tula_table3 WHERE tula1 = {0}", Convert.ToInt32(tula1));
                }
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                command = string.Format("SELECT tula_Key FROM tula_table4 WHERE tula1 = {0}", Convert.ToInt32(tula1));
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                command = string.Format("SELECT tula_Key FROM tula_table5 WHERE tula1 = {0}", Convert.ToInt32(tula1));
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                command = string.Format("SELECT tula_Key FROM tula_table6 WHERE tula2 = \"{0}\"", tula1);
            }
            else if (tableName == TABLE_DB.tula_table7)
            {
                command = string.Format("SELECT tula_Key FROM tula_table7");
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                command = string.Format("SELECT tula_Key FROM tula_table7");
            }
            waitConnectFree();
            try
            {
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                using (var cursor = cmd.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        tula_key = Convert.ToUInt64(cursor["tula_key"]);
                    }
                }
            }
            catch (Exception)
            {
                //throw;
            }
            releaseConnect();
            return tula_key;
        }
        public void GetValue(TABLE_DB tableName, int tula_key, out string tula1, out string tula2, out string tula3, out string tula4)
        {
            string command;
            MySqlCommand cmd;
            tula1 = string.Empty;
            tula2 = string.Empty;
            tula3 = string.Empty;
            tula4 = string.Empty;
            if (tableName == TABLE_DB.tula_table1)
            {
                command = string.Format("SELECT tula1, tula2, tula3 , tula4 FROM tula_table1 WHERE tula_key = {0}", tula_key);
                waitConnectFree();
                cmd = new MySqlCommand(command, myConnection);
                try
                {
                    using (var cursor = cmd.ExecuteReader())
                    {
                        while (cursor.Read())
                        {
                            tula1 = Convert.ToString(cursor["tula1"]);
                            tula2 = Convert.ToString(cursor["tula2"]);
                            tula3 = Convert.ToString(cursor["tula3"]);
                            tula4 = Convert.ToString(cursor["tula4"]);
                        }
                    }
                }
                catch (Exception)
                {
                    //throw;
                }
                releaseConnect();
            }
        }


        public bool DeleteData(TABLE_DB tableName, int tula_key)
        {
            string command = "";
            MySqlCommand cmd;
            waitConnectFree();
            if (tableName == TABLE_DB.tula_table1)
            {
                command = string.Format("DELETE FROM tula_table1 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                command = string.Format("DELETE FROM tula_table2 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                command = string.Format("DELETE FROM tula_table3 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                command = string.Format("DELETE FROM tula_table4 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                command = string.Format("DELETE FROM tula_table5 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                command = string.Format("DELETE FROM tula_table6 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table8)
            {
                command = string.Format("DELETE FROM tula_table8 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            releaseConnect();
            return true;
        }

        public bool DeleteData(TABLE_DB tableName, UInt64 tula_key)
        {
            string command = "";
            MySqlCommand cmd;
            waitConnectFree();
            if (tableName == TABLE_DB.tula_table1)
            {
                command = string.Format("DELETE FROM tula_table1 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table2)
            {
                command = string.Format("DELETE FROM tula_table2 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table3)
            {
                command = string.Format("DELETE FROM tula_table3 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table4)
            {
                command = string.Format("DELETE FROM tula_table4 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table5)
            {
                command = string.Format("DELETE FROM tula_table5 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                command = string.Format("DELETE FROM tula_table6 WHERE tula_Key= {0};", tula_key);
                cmd = new MySqlCommand(command, myConnection);
                cmd.ExecuteNonQuery();
            }
            releaseConnect();
            return true;
        }

        public DataTable GetDataExtend(TABLE_DB tableName, UInt64 tulaKeyEqua, int tula1, string tulaData)
        {
            string command;
            string table_Name = null;
            string condition = "";
            DataTable table = new DataTable();


            if (tableName == TABLE_DB.tula_table2)
            {
                table_Name = "tula_table2";
                condition = string.Format("WHERE tula_Key > {0} AND tula1 = {1} AND tula8 = \"{2}\" LIMIT 1", tulaKeyEqua, tula1, tulaData);
            }
            else if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
                condition = string.Format("WHERE tula_Key > {0} AND tula1 = {1} AND tula6 = \"{2}\" LIMIT 1", tulaKeyEqua, tula1, tulaData);
            }
            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);

            }
            catch (Exception)
            {
            
            }
            releaseConnect();
            return table;
        }

        public DataTable GetDataExtend2(TABLE_DB tableName, int tula1)
        {
            string command;
            string table_Name = null;
            string condition = "";
            DataTable table = new DataTable();

            if (tableName == TABLE_DB.tula_table6)
            {
                table_Name = "tula_table6";
                condition = string.Format("WHERE tula1 = {0} ORDER BY tula_Key DESC LIMIT 1", tula1);
            }
            waitConnectFree();
            try
            {
                command = string.Format("SELECT * FROM {0} " + condition, table_Name);
                MySqlCommand cmd = new MySqlCommand(command, myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
            }
            catch (Exception)
            {

            }
            releaseConnect();
            return table;
        }

        public uint getLastTula_key(TABLE_DB tableName)
        {
            string command;
            MySqlCommand cmd;
            uint tula_Key = 0;
            if (tableName == TABLE_DB.tula_table2)
            {
                command = string.Format("SELECT tula_Key FROM tula_table2  ORDER BY tula_Key DESC LIMIT 1");
                waitConnectFree();
                cmd = new MySqlCommand(command, myConnection);
                using (var cursor = cmd.ExecuteReader())
                {
                    while (cursor.Read())
                    {
                        tula_Key = Convert.ToUInt32(cursor["tula_Key"]);
                    }
                }
                releaseConnect();
            }
            return tula_Key;
        }
    }
}
