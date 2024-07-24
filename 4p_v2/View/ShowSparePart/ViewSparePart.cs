using DevComponents.DotNetBar.Controls;
using Giamsat.Model;
using GiamSat.model;
using GiamSat.View;

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Linq;
using static Giamsat.Model.MachinePlan;
using static Giamsat.Model.SparePart;
using static GiamSat.model.Machine;



namespace GiamSat
{
    public partial class ViewSparePart : Form
    {

        private MachinePlan machinePlan = new MachinePlan();
        private Machine machine = new Machine();
        private SparePart sparePart = new SparePart();
        private Main mAppInstance;
        static int numFirstCellMerge = 0;
        static int numLastCellMerge = 0;
        public Main CalledMainDb
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                machinePlan.database = mAppInstance.db;
                machine.database = mAppInstance.db;
                sparePart.database = mAppInstance.db;
            }
        }
        public enum GritSource
        {
            Data_Machine_Plan,
            Data_SparePart_Plan,
            Data_Non_Plan
        };
        public GritSource dataGritSource = GritSource.Data_Machine_Plan;
        public ViewSparePart()
        {
            InitializeComponent();
        }
        public void resume()
        {
            if (dataGritSource == GritSource.Data_Machine_Plan)
            {
                button1_Click(new object(), new EventArgs());
            }
            else if (dataGritSource == GritSource.Data_SparePart_Plan)
            {
                button2_Click(new object(), new EventArgs());
            }
        }

        private DataGridView dataSourceMachinePlan()
        {
            List<ArrayList> listLine0 = new List<ArrayList>();
            List<ArrayList> listLine1 = new List<ArrayList>();
            List<ArrayList> listLine2 = new List<ArrayList>();
            List<ArrayList> listLine3 = new List<ArrayList>();
            List<ArrayList> listLine4 = new List<ArrayList>();
            List<ArrayList> listLine5 = new List<ArrayList>();
            List<ArrayList> listLine6 = new List<ArrayList>();
            List<ArrayList> listLine7 = new List<ArrayList>();
            List<ArrayList> listLine8 = new List<ArrayList>();

            DataGridView dataviewTotal = dataGridView1;
            dataviewTotal.Rows.Clear();
            dataviewTotal.Columns.Clear();
            List<MachinePlanData> lsdata = new List<MachinePlanData>();
            lsdata = machinePlan.getAll();

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "Line";
            column0.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            column0.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.Name = column0.HeaderText;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Machine";
            column1.Name = column1.HeaderText;
            column1.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            column1.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Item";
            column2.Name = column2.HeaderText;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column2.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Status";
            column3.Name = column3.HeaderText;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            column3.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Cycles";
            column4.Name = column4.HeaderText;
            column4.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column4.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Time Lates";
            column5.Name = column5.HeaderText;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            column5.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            column5.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Time Maintenace";
            column6.Name = column5.HeaderText;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column6.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            column6.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            column7.HeaderText = "Time Remaining";
            column7.Name = column7.HeaderText;
            column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column7.HeaderCell.Style.Font = new Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            column7.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // save MachineDataID
            DataGridViewTextBoxColumn columnX = new DataGridViewTextBoxColumn();
            columnX.HeaderText = "MaintenanceID";
            columnX.Name = columnX.HeaderText;
            columnX.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnX.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataviewTotal.Columns.Add(column0);
            dataviewTotal.Columns.Add(column1);
            dataviewTotal.Columns.Add(column2);
            dataviewTotal.Columns.Add(column3);
            dataviewTotal.Columns.Add(column4);
            dataviewTotal.Columns.Add(column5);
            dataviewTotal.Columns.Add(column6);
            dataviewTotal.Columns.Add(column7);
            dataviewTotal.Columns.Add(columnX);
            dataviewTotal.Columns[columnX.Name].Visible = false;

            /* not show MachineDataID*/
            foreach (var item in lsdata)
            {
                machineData Data = machine.get((int)item.MachineID);
                if (item.TimeMaintenace < DateTime.Now)
                {
                    item.TimeRemaining = 0;
                }
                else
                {
                    item.TimeRemaining = (uint)item.TimeMaintenace.Subtract(DateTime.Now).TotalDays;
                    if (item.TimeRemaining < 0)
                    {
                        item.TimeRemaining = 0;
                    }
                }
                List<ArrayList> listLine = listLine0;
                if (Data.linePosition == "0")
                {
                    listLine = listLine0;
                }
                else if (Data.linePosition == "1")
                {
                    listLine = listLine1;
                }
                else if (Data.linePosition == "2")
                {
                    listLine = listLine2;
                }
                else if (Data.linePosition == "3")
                {
                    listLine = listLine3;
                }
                else if (Data.linePosition == "4")
                {
                    listLine = listLine4;
                }
                else if (Data.linePosition == "5")
                {
                    listLine = listLine5;
                }
                else if (Data.linePosition == "6")
                {
                    listLine = listLine6;
                }
                else if (Data.linePosition == "7")
                {
                    listLine = listLine7;
                }
                else if (Data.linePosition == "8")
                {
                    listLine = listLine8;
                }
                Color color;
                if (item.TimeRemaining <= 3)
                {
                    color = Color.Red;
                }
                else if (item.TimeRemaining <= 10)
                {
                    color = Color.LightYellow;
                }
                else
                {
                    color = Color.LightGreen;
                }
                var array = new ArrayList{Data.linePosition, Data.machineName, item.ItemName, item.status,
                                        item.Cycles, item.TimeLatest.ToString("dd-MM-yyyy"), item.TimeMaintenace.ToString("dd-MM-yyyy"),
                                        item.TimeRemaining, item.MaintenanceID ,color};

                // add array to list
                listLine.Add(array);

            }

            int numRowAdded = 0;
            numRowAdded = updateToDataView(dataviewTotal, ref listLine0, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine1, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine2, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine3, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine4, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine5, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine6, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine7, ref numRowAdded);
            numRowAdded = updateToDataView(dataviewTotal, ref listLine8, ref numRowAdded);
            dataGritSource = GritSource.Data_Machine_Plan;
            return dataviewTotal;
        }

        private int updateToDataView(DataGridView dataGridView,ref List<ArrayList> list, ref int numRowAdded)
        {
            list = list.OrderBy(arr => arr[1]).ThenBy(arr => arr[7]).ToList();
            foreach (var data in list)
            {
                dataGridView.Rows.Add(data[0], data[1], data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
                for (int i = 2; i < 9; i++)
                {
                    dataGridView.Rows[numRowAdded].Cells[i].Style.BackColor = (Color)data[9];
                }
                numRowAdded++;
            }
            return numRowAdded;
        }
        private DataGridView dataSourceSparePart()
        {
            DataGridView dataview = dataGridView1;
            dataview.Rows.Clear();
            dataview.Columns.Clear();

            List<SparePartData> lsSPdata = sparePart.getAll();

            List<machineData> LsMcData = machine.getAll();

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "Spare Part code";
            column0.Name = column0.HeaderText;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Spare Part name";
            column1.Name = column1.HeaderText;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Machine name";
            column2.Name = column2.HeaderText;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Line";
            column3.Name = column3.HeaderText;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Seri number";
            column4.Name = column4.HeaderText;
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Time Maintenace";
            column5.Name = column5.HeaderText;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Number of item";
            column6.Name = column6.HeaderText;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column7 = new DataGridViewTextBoxColumn();
            column7.HeaderText = " Cycle ";
            column7.Name = column7.HeaderText;
            column7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column7.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column8 = new DataGridViewTextBoxColumn();
            column8.HeaderText = "Time remaining ";
            column8.Name = column8.HeaderText;
            column8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column8.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // save MachineDataID
            DataGridViewTextBoxColumn columnX = new DataGridViewTextBoxColumn();
            columnX.HeaderText = "MachineDataID";
            columnX.Name = columnX.HeaderText;
            columnX.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            columnX.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dataview.Columns.Add(column0);
            dataview.Columns.Add(column1);
            dataview.Columns.Add(column2);
            dataview.Columns.Add(column3);
            dataview.Columns.Add(column4);
            dataview.Columns.Add(column5);
            dataview.Columns.Add(column6);
            dataview.Columns.Add(column7);
            dataview.Columns.Add(column8);
            dataview.Columns.Add(columnX);
            /* not show MachineDataID*/
            dataview.Columns[columnX.Name].Visible = false;
            int rowNo = 0;
            foreach (var item in lsSPdata)
            {
                string machineName = string.Empty;
                string linePosition = string.Empty;
                foreach (var itemMc in LsMcData)
                {
                    if (item.MachineID == itemMc.machineID)
                    {
                        machineName = itemMc.machineName;
                        linePosition = itemMc.linePosition;
                    }
                }
                dataview.Rows.Add(item.SpareCode, item.SpareName, machineName, linePosition,
                    item.SN, item.TimeMaintenace.ToString("dd-MM-yyyy"), item.NumberItem, item.Cycle, item.TimeRemaining,
                    item.SparePartID);

                Color color;
                if (item.TimeRemaining <= 10)
                {
                    color = Color.Red;
                }
                else if (item.TimeRemaining <= 20)
                {
                    color = Color.Yellow;
                }
                else
                {
                    color = Color.LightGreen;
                }
                dataview.Rows[rowNo].DefaultCellStyle.BackColor = color;
                rowNo++;
            }

            /* Sort dataGridView1*/
            dataview.Sort(dataview.Columns[column8.Name], ListSortDirection.Ascending);

            dataGritSource = GritSource.Data_SparePart_Plan;

            return dataview;
        }

        private void disableSortDataGridView()
        {
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1 = dataSourceMachinePlan();
            disableSortDataGridView();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1 = dataSourceSparePart();
            disableSortDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddMachinePlan formMC = new AddMachinePlan();
            formMC.CalledApplication = mAppInstance;
            formMC.viewSparePart = this;
            formMC.Show();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGritSource == GritSource.Data_Machine_Plan)
                {
                    AddMachinePlan form = new AddMachinePlan();
                    form.CalledApplication = mAppInstance;
                    string machineName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string item = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string status = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string cycle = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string timeStart = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string timeEnd = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                    form.Set(id, machineName, cycle, timeStart, timeEnd, item, status);
                    form.viewSparePart = this;
                    form.Show();
                }
                else if (dataGritSource == GritSource.Data_SparePart_Plan)
                {
                    AddSparePart form = new AddSparePart();
                    form.CalledApplication = mAppInstance;

                    string SpCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string SpName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string machineName = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string SN = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string timeReplace = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string numberItem = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                    string cycle = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                    form.Set(id, machineName, SpCode, SpName, SN, timeReplace, numberItem, cycle);
                    form.Show();
                }
            }
            catch
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            resume();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            AddSparePart formSP = new AddSparePart();
            formSP.CalledApplication = mAppInstance;
            formSP.Show();
        }


        private void serverIPToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ViewSparePart_Load(object sender, EventArgs e)
        {
            resume();
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dataGridView1[column, row];
            DataGridViewCell cell2 = dataGridView1[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            return cell1.Value.ToString() == cell2.Value.ToString();
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
            {             
                e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
                return;
            }
            
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dataGridView1.AdvancedCellBorderStyle.Top;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && (e.ColumnIndex == 0 || e.ColumnIndex == 1))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
    }
}
