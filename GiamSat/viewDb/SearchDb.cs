using _4P_PROJECT.DataBase;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
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
            btn_showHistory.Enabled = false;
            loadDeviceTable();
        }
        private void loadDeviceTable()
        {
            dataGridView1.Columns.Clear();
            string command = string.Format("SELECT DeviceID, Name, SN, Person, Time , Status, Note FROM device");
            MySqlCommand cmd = new MySqlCommand(command, db.myConnection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.DataSource = table;
        }

        private void tb_deviceID_TextChanged(object sender, EventArgs e)
        {
            if (tb_deviceID.Text == "")
            {
                btn_showHistory.Enabled = false;
            }
            else
            {
                btn_showHistory.Enabled = true;
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
            dataGridView1.ReadOnly = false;
            tb_deviceID.Text = "";
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
                    command = string.Format("UPDATE device\r\nSET Name = \'{0}\', SN = \'{1}\', Person = \'{2}\', Time = \'{3}\', Status = \'{4}\', Note = \'{5}\' WHERE DeviceID = \'{6}\'",
                                        dataGridView1.Rows[i].Cells["Name"].Value.ToString(), dataGridView1.Rows[i].Cells["SN"].Value.ToString(), dataGridView1.Rows[i].Cells["Person"].Value.ToString(),
                                        dataGridView1.Rows[i].Cells["Time"].Value.ToString(), dataGridView1.Rows[i].Cells["Status"].Value.ToString(),
                                        dataGridView1.Rows[i].Cells["Note"].Value.ToString(), dataGridView1.Rows[i].Cells["DeviceID"].Value).ToString();
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

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            string command;
            MySqlCommand cmd;
            command = string.Format("DELETE FROM device WHERE DeviceID = \'{0}\';", dataGridView1.Rows[e.Row.Index].Cells["DeviceID"].Value);
            cmd = new MySqlCommand(command, db.myConnection);
            cmd.ExecuteNonQuery();
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            string command;
            dataGridView1.Columns.Clear();

            if (tb_deviceID.Text != "")
            {
                // init dataGridView
                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();

                DataGridViewTextBoxColumn columnNum = new DataGridViewTextBoxColumn();
                columnNum.HeaderText = "Number";
                columnNum.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                columnNum.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnDeviceID = new DataGridViewTextBoxColumn();
                columnDeviceID.HeaderText = "DeviceID";
                columnDeviceID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnName = new DataGridViewTextBoxColumn();
                columnName.HeaderText = "Name";
                //columnName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnSN = new DataGridViewTextBoxColumn();
                columnSN.HeaderText = "SN";
                //columnSN.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnPerson = new DataGridViewTextBoxColumn();
                columnPerson.HeaderText = "Person";
                columnPerson.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnstatus = new DataGridViewTextBoxColumn();
                columnstatus.HeaderText = "status";
                columnstatus.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnTime = new DataGridViewTextBoxColumn();
                columnTime.HeaderText = "Time";
                //columnTime.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewImageColumn columnImage = new DataGridViewImageColumn();
                columnImage.HeaderText = "Image";
                columnImage.ImageLayout = DataGridViewImageCellLayout.Zoom;
                columnImage.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                DataGridViewTextBoxColumn columnNote = new DataGridViewTextBoxColumn();
                columnNote.HeaderText = "Note";

                dataGridView1.Columns.Add(columnNum);
                dataGridView1.Columns.Add(columnDeviceID);
                dataGridView1.Columns.Add(columnName);
                dataGridView1.Columns.Add(columnSN);
                dataGridView1.Columns.Add(columnPerson);
                dataGridView1.Columns.Add(columnstatus);
                dataGridView1.Columns.Add(columnTime);
                dataGridView1.Columns.Add(columnImage);
                dataGridView1.Columns.Add(columnNote);

                dataGridView1.RowTemplate.Height = 200;
                dataGridView1.ReadOnly = true;
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // query SQL
                command = string.Format("SELECT A.DeviceID, A.Name, A.SN, A.Person, B.status, B.Time, B.Image_path, B.Note\r\nFROM device A, status B WHERE A.DeviceID = \'{0}\' AND B.DeviceID = \'{0}\';", tb_deviceID.Text);
                MySqlCommand cmd = new MySqlCommand(command, db.myConnection);
                cmd = new MySqlCommand(command, db.myConnection);
                using (var cursor = cmd.ExecuteReader())
                {
                    int number = 0;
                    while (cursor.Read())
                    {
                        number++;
                        string num = number.ToString();
;                       string DeviceID = Convert.ToString(cursor["DeviceID"]);
                        string Name = Convert.ToString(cursor["Name"]);
                        string SN = Convert.ToString(cursor["SN"]);
                        string Person = Convert.ToString(cursor["Person"]);
                        string status = Convert.ToString(cursor["status"]);
                        string Time = Convert.ToString(cursor["Time"]);
                        string Image_path = Convert.ToString(cursor["Image_path"]);
                        string Note = Convert.ToString(cursor["Note"]);
                        string imageText = "";

                        try
                        {
                            imageText = File.ReadAllText(Image_path);
                            Byte[] bitmapData = Convert.FromBase64String(imageText);
                            dataGridView1.Rows.Add(num, DeviceID, Name, SN, Person, status, Time, bitmapData, Note);
                        }
                        catch
                        {
                            dataGridView1.Rows.Add(num, DeviceID, Name, SN, Person, status, Time, new Bitmap(1, 1), Note);
                        }
                    }
                }
               
            }
        }

        private void SearchDb_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_update.Enabled)
            { 
                DialogResult result = MessageBox.Show("Do you really want to save data?", "Dialog Title", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    btn_update.PerformClick();
                }         
            }
        }
    }
}
