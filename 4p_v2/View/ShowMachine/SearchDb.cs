using _4P_PROJECT.Control;
using _4P_PROJECT.DataBase;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using GiamSat.model;
using GiamSat.View;
using GiamSat.View.ShowReporting;
using MySql.Data.MySqlClient;
using Mysqlx;
using MySqlX.XDevAPI;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Crypto.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.ClientRF;
using static GiamSat.model.DataAnalysis;
using static GiamSat.model.History;
using static GiamSat.model.Machine;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.LinkLabel;

namespace GiamSat.viewDb
{
    public partial class SearchDb : Form
    {
        private GiamSat.model.Machine g_machine = new GiamSat.model.Machine();


        private History g_history = new History();

        private ClientRF g_clientRF = new ClientRF();

        private DataAnalysis g_dataAnalys = new DataAnalysis();

        private HistoryNG g_historyNG = new HistoryNG();


        public enum GridSource
        {
            Data_Machine,
            Data_History,
            Data_Mttr,
            Data_ShowReport,
            Data_Non_Plan,
            Data_History_NG
        };

        private GridSource g_dataGritSource = GridSource.Data_Machine;

        public Main mAppInstance;

        public Main CalledApplication
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                g_machine.database = mAppInstance.MainDatabase;
                g_history.database = mAppInstance.MainDatabase;
                g_clientRF.database = mAppInstance.MainDatabase;
                g_dataAnalys.database = mAppInstance.MainDatabase;
                g_historyNG.database = mAppInstance.MainDatabase;
                UpdateUIControl();
                //resumeUI();
            }
        }

        public SearchDb()
        {
            InitializeComponent();
        }
        private void UpdateUIControl()
        {
            this.Text = mAppInstance.MainResourceManager.GetString("SettingDialogTitle");
        }

        public void resumeUI(string dataMachine = null)
        {
            if (dataMachine != null)
            {
                tb_MachineSearch.Text = "NG";
            }
            if (g_dataGritSource == GridSource.Data_Machine)
            {
                loadMachineTable();
            }
            else if (g_dataGritSource == GridSource.Data_Machine)
            {
                loadHistoryTable();
            }
        }
        private void loadMachineTable()
        {
            g_dataGritSource = GridSource.Data_Machine;

            List<machineData> lsMachine = new List<machineData>();
            int count = 0;
            if (tb_MachineSearch.Text != "")
            {
                lsMachine = g_machine.SearchValue(tb_MachineSearch.Text);
            }
            else
            {
                lsMachine = g_machine.getAll();
            }
            dataGridView1.Columns.Clear();

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "No";
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Device Code";
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Device Name";
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Line";
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Lane";
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Status";
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Time";
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewImageColumn column7 = new DataGridViewImageColumn();
            column7.HeaderText = "Picture";
            column7.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            column8.HeaderText = "Note";
            column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
            column9.HeaderText = "Manager";
            column9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();
            column10.HeaderText = "Model";
            column10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn();
            column11.HeaderText = "Serial";
            column11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn();
            column12.HeaderText = "TOP/BOT";
            column12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column12.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column10);
            dataGridView1.Columns.Add(column11);
            dataGridView1.Columns.Add(column12);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);
            dataGridView1.Columns.Add(column8);
            dataGridView1.Columns.Add(column9);
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowTemplate.Height = 130;
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (var machine in lsMachine)
            {
                count++;
                try
                {
                    Https http = new Https();

                    string imageText = http.GetDataImage(machine.picture);
                    if (imageText != "")
                    {
                        Byte[] bitmapData = Convert.FromBase64String(imageText);
                        dataGridView1.Rows.Add(count.ToString(), machine.machineCode, machine.machineName, machine.Model, machine.Serial, machine.TopBot, machine.linePosition, machine.lane, machine.status, machine.time, bitmapData, machine.note, machine.manager);
                    }
                    else
                    {
                        dataGridView1.Rows.Add(count.ToString(), machine.machineCode, machine.machineName, machine.Model, machine.Serial, machine.TopBot, machine.linePosition, machine.lane, machine.status, machine.time, new Bitmap(1, 1), machine.note, machine.manager);
                    }
                }
                catch
                {
                    dataGridView1.Rows.Add(count.ToString(), machine.machineCode, machine.machineName, machine.Model, machine.Serial, machine.TopBot, machine.linePosition, machine.lane, machine.status, machine.time, new Bitmap(1, 1), machine.note, machine.manager);
                }
            }
        }

        private void loadHistoryTable()
        {

            List<HistoryData> lsdata = new List<HistoryData>();
            int count = 0;

            if (g_dataGritSource == GridSource.Data_History)
            {
                lsdata = g_history.searchValue(tb_historySearch.Text, dateTime_SearchFirst.Text, dateTime_SearchSecond.Text);
            }
            else if (g_dataGritSource == GridSource.Data_History_NG)
            {
                lsdata = g_historyNG.searchValue(tb_historySearch.Text, dateTime_SearchFirst.Text, dateTime_SearchSecond.Text);
            }

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "No";
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "No. Trouble";
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Month";
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Week";
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Date Production";
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Day/Night";
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Opening time";
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            column7.HeaderText = "Line (A)";
            column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; ;

            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            column8.HeaderText = "Lane(B)";
            column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column9 = new DataGridViewTextBoxColumn();
            column9.HeaderText = "BOT/TOP/PCBA";
            column9.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column10 = new DataGridViewTextBoxColumn();
            column10.HeaderText = "Line_A_C";
            column10.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column11 = new DataGridViewTextBoxColumn();
            column11.HeaderText = "Machine Name";
            column11.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column12 = new DataGridViewTextBoxColumn();
            column12.HeaderText = "Trouble name";
            column12.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column13 = new DataGridViewTextBoxColumn();
            column13.HeaderText = "Status";
            column13.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewImageColumn column14 = new DataGridViewImageColumn();
            column14.HeaderText = "Issue Image";
            column14.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column14.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DataGridViewTextBoxColumn column15 = new DataGridViewTextBoxColumn();
            column15.HeaderText = "Issue note";
            column15.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn column16 = new DataGridViewImageColumn();
            column16.HeaderText = "Action Image";
            column16.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column16.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DataGridViewTextBoxColumn column17 = new DataGridViewTextBoxColumn();
            column17.HeaderText = "Action note";
            column17.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn column18 = new DataGridViewImageColumn();
            column18.HeaderText = "Checking Image";
            column18.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column18.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DataGridViewTextBoxColumn column19 = new DataGridViewTextBoxColumn();
            column19.HeaderText = "Checking note";
            column19.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewImageColumn column20 = new DataGridViewImageColumn();
            column20.HeaderText = "Result Image";
            column20.ImageLayout = DataGridViewImageCellLayout.Zoom;
            column20.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;

            DataGridViewTextBoxColumn column21 = new DataGridViewTextBoxColumn();
            column21.HeaderText = "Result note";
            column21.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;


            //columnPicture.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(column0);
            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);
            dataGridView1.Columns.Add(column6);
            dataGridView1.Columns.Add(column7);
            dataGridView1.Columns.Add(column8);
            dataGridView1.Columns.Add(column9);
            dataGridView1.Columns.Add(column10);
            dataGridView1.Columns.Add(column11);
            dataGridView1.Columns.Add(column12);
            dataGridView1.Columns.Add(column13);
            //dataGridView1.Columns.Add(column14);
            dataGridView1.Columns.Add(column15);
            //dataGridView1.Columns.Add(column16);
            dataGridView1.Columns.Add(column17);
            //dataGridView1.Columns.Add(column18);
            dataGridView1.Columns.Add(column19);
            //dataGridView1.Columns.Add(column20);
            dataGridView1.Columns.Add(column21);
            dataGridView1.RowTemplate.Height = 60;

            foreach (var item in lsdata)
            {
                count++;
                string NoTrouble = item.noTrouble;
                var date = new DateTime();
                try
                {
                    date = DateTime.ParseExact(item.time, "dd-MM-yyyy HH:mm", null);
                }
                catch
                {

                    date = DateTime.Now;
                }
                string month = date.Month.ToString();
                string week = calWeekOfYear(date).ToString();
                string dateProduct = date.ToString("dd-MMMM");
                string day = date.ToString("tt") == "AM" ? "Day" : "Night";
                string time = date.ToString("dd/MM HH:mm");
                string line = item.line;
                string lane = item.lane;
                string bot_top_pcba = "TOP";
                string line_a_c = "Line_" + line + "_" + bot_top_pcba[0];
                string mc = item.machineName;
                string troubleName = item.troubleName;
                string status = item.status;
                try
                {
                    //Https http = new Https();
                    //string imageText = File.ReadAllText(machine.picture);
                    //string picture1 = http.GetDataImage(item.picture1);
                    //string picture2 = http.GetDataImage(item.picture2);
                    //string picture3 = http.GetDataImage(item.picture3);
                    //string picture4 = http.GetDataImage(item.picture4);
                    //string picture1 = File.ReadAllText(item.picture1);
                    //string picture2 = File.ReadAllText(item.picture2);
                    //string picture3 = File.ReadAllText(item.picture3);
                    //string picture4 = File.ReadAllText(item.picture4);


                    //Byte[] bitmapData1 = null;
                    //Byte[] bitmapData2 = null;
                    //Byte[] bitmapData3 = null;
                    //Byte[] bitmapData4 = null;
                    //if (picture1 != string.Empty)
                    //{
                    //    bitmapData1 = Convert.FromBase64String(picture1);
                    //}
                    //if (picture2 != string.Empty)
                    //{
                    //    bitmapData2 = Convert.FromBase64String(picture2);
                    //}
                    //if (picture3 != string.Empty)
                    //{
                    //    bitmapData3 = Convert.FromBase64String(picture3);
                    //}
                    //if (picture4 != string.Empty)
                    //{
                    //    bitmapData4 = Convert.FromBase64String(picture4);
                    //}

                    dataGridView1.Rows.Add(count.ToString(), NoTrouble, month, week, dateProduct, day, time, line, lane, bot_top_pcba, line_a_c, mc, troubleName, status,
                                                 item.note1, item.note2, item.note3, item.note4);
                }
                catch
                {
                    dataGridView1.Rows.Add(count.ToString(), NoTrouble, month, week, dateProduct, day, time, line, lane, bot_top_pcba, line_a_c, mc, troubleName, status,
                                                item.note1, item.note2, item.note3, item.note4);
                }
            }
        }

        private int calWeekOfYear(DateTime time)
        {
            var d = time;
            CultureInfo cul = CultureInfo.CurrentCulture;

            int weekNum = cul.Calendar.GetWeekOfYear(
                d,
                CalendarWeekRule.FirstDay,
                DayOfWeek.Monday);

            return weekNum;

        }
        private void tb_deviceID_TextChanged(object sender, EventArgs e)
        {
            //if (tb_MachineCode.Text == "")
            //{
            //    btn_showHistory.Enabled = false;
            //}
            //else
            //{
            //    btn_showHistory.Enabled = true;
            //}
        }

        private void SearchDb_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            loadMachineTable();
            Cursor.Current = Cursors.Default;

        }

        private void btn_addNew_Click(object sender, EventArgs e)
        {
            AddNew addform = new AddNew();
            addform.CalledSearchDb = this;
            addform.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (g_dataGritSource == GridSource.Data_Machine)
            {
                AddNew addform = new AddNew();
                addform.CalledSearchDb = this;
                int machineID = g_machine.getMachineID(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                ClientData dataRF = g_clientRF.get(machineID);
                addform.Set(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                addform.Show();
            }
            else if (g_dataGritSource == GridSource.Data_History)
            {
                //EditHistory editHistory = new EditHistory();
                //editHistory.CalledEditDb = this;

                //HistoryData dataShowHistory = new HistoryData();
                //int historyID = g_history.getHistoryID(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                //dataShowHistory = g_history.get(historyID, 0);

                //editHistory.Set(dataShowHistory);
                //editHistory.Show();
            }
            else if (g_dataGritSource == GridSource.Data_History_NG)
            {
                EditHistory editHistory = new EditHistory();
                editHistory.CalledEditDb = this;

                HistoryData dataShowHistory = new HistoryData();
                UInt64 historyID = g_history.getHistoryID(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString());
                dataShowHistory = g_history.get(historyID, 0);
                if(dataShowHistory != null) 
                {                 
                    editHistory.Set(dataShowHistory);
                    editHistory.Show();
                }
            }
        }

        private void btn_mttr_Click(object sender, EventArgs e)
        {

        }

        private void btn_report_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_searchHistory_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            g_dataGritSource = GridSource.Data_History;
            loadHistoryTable();
            Cursor.Current = Cursors.Default;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            g_dataGritSource = GridSource.Data_History_NG;
            loadHistoryTable();
            Cursor.Current = Cursors.Default;
        }

    }
}
