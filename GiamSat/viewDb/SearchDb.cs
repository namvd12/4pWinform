using _4P_PROJECT.DataBase;
using DevComponents.DotNetBar;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiamSat.viewDb
{
    public partial class SearchDb : Form
    {
        DataBase db;
        public SearchDb()
        {
            InitializeComponent();
            /* Init data base */
            db = new DataBase();
            db.Connect();
            btn_searchHistory.Enabled = false;
            loadDeviceTable();
        }
        private void loadDeviceTable()
        {
            dataGridView1.Columns.Clear();
            string command = string.Format("SELECT DeviceID, Name, SN, Person, TimeOP , Status, Note FROM device");
            MySqlCommand cmd = new MySqlCommand(command, db.myConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = table;
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            string command;
            dataGridView1.Columns.Clear();
            dataGridView1.RowTemplate.Height = 20;
            if (tb_deviceID.Text != "")
            {
                command = string.Format("SELECT Status, Time FROM status WHERE DEVICEID = {0}",tb_deviceID.Text);
                MySqlCommand cmd = new MySqlCommand(command, db.myConnection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void tb_deviceID_TextChanged(object sender, EventArgs e)
        {
            if (tb_deviceID.Text == "")
            {
                btn_searchHistory.Enabled = false;
                btn_SearchImage.Enabled = false;
            }
            else
            {
                btn_searchHistory.Enabled = true;
                btn_SearchImage.Enabled = true;
            }
        }

        private void btn_SearchImage_Click(object sender, EventArgs e)
        {
            string command;
            MySqlCommand cmd;
            if (tb_deviceID.Text != "")
            {
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                DataGridViewImageColumn columnImage = new DataGridViewImageColumn();
                columnImage.HeaderText = "Image";
                columnImage.ImageLayout = DataGridViewImageCellLayout.Zoom;

                DataGridViewTextBoxColumn columntime = new DataGridViewTextBoxColumn();
                columntime.HeaderText = "time";

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.RowTemplate.Height = 120;

                dataGridView1.Columns.Add(columnImage);
                dataGridView1.Columns.Add(columntime);

                command = string.Format("SELECT Image_path, Time FROM image WHERE DeviceID = '{0}'", tb_deviceID.Text);
                cmd = new MySqlCommand(command, db.myConnection);
                using (var cursor = cmd.ExecuteReader())
                {
                    int cnt = 1;
                    while (cursor.Read())
                    {
                        string pathFile = Convert.ToString(cursor["Image_path"]);
                        string timeFile = Convert.ToString(cursor["Time"]);
                        string imageText = File.ReadAllText(pathFile);
                        Byte[] bitmapData = Convert.FromBase64String(imageText);
                        dataGridView1.Rows.Add(bitmapData, timeFile);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDeviceTable();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            string command;
            MySqlCommand cmd;
            btn_update.Enabled = true;
            try
            {
                for (var i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["TimeOP"].Value.ToString() == "")
                    {
                        command = string.Format("UPDATE device\r\nSET Name = \'{0}\', SN = \'{1}\', Person = \'{2}\', Status = \'{3}\', Note = \'{4}\' WHERE DeviceID = \'{4}\'",
                    dataGridView1.Rows[i].Cells["Name"].Value.ToString(), dataGridView1.Rows[i].Cells["SN"].Value.ToString(), dataGridView1.Rows[i].Cells["Person"].Value.ToString(),
                    dataGridView1.Rows[i].Cells["Status"].Value.ToString(),
                    dataGridView1.Rows[i].Cells["Note"].Value.ToString(), dataGridView1.Rows[i].Cells["DeviceID"].Value).ToString();
                    }
                    else
                    {                    
                        command = string.Format("UPDATE device\r\nSET Name = \'{0}\', SN = \'{1}\', Person = \'{2}\', TimeOP = {3}, Status = \'{4}\', Note = \'{5}\' WHERE DeviceID = \'{6}\'",
                                            dataGridView1.Rows[i].Cells["Name"].Value.ToString(), dataGridView1.Rows[i].Cells["SN"].Value.ToString(), dataGridView1.Rows[i].Cells["Person"].Value.ToString(),
                                            dataGridView1.Rows[i].Cells["TimeOP"].Value, dataGridView1.Rows[i].Cells["Status"].Value.ToString(),
                                            dataGridView1.Rows[i].Cells["Note"].Value.ToString(), dataGridView1.Rows[i].Cells["DeviceID"].Value).ToString();
                    }
                    cmd = new MySqlCommand(command, db.myConnection);
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Update done");
                btn_update.Enabled = false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            btn_update.Enabled = true;
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            string command;
            MySqlCommand cmd;
            command = string.Format("INSERT INTO device (DeviceID, Name)\r\nVALUES (\'{0}\', \'\')", e.Row.Index);
            cmd = new MySqlCommand(command, db.myConnection);
            cmd.ExecuteNonQuery();
        }

        private void dataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            string command;
            //MySqlCommand cmd;
            //command = string.Format("DELETE FROM device WHERE DeviceID = {0};", e.Row.Index);
            //cmd = new MySqlCommand(command, db.myConnection);
            //cmd.ExecuteNonQuery();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string command;
            MySqlCommand cmd;
            command = string.Format("DELETE FROM device WHERE DeviceID = \'{0}\';", dataGridView1.Rows[e.Row.Index].Cells["DeviceID"].Value);
            cmd = new MySqlCommand(command, db.myConnection);
            cmd.ExecuteNonQuery();
        }
    }
}
