using Giamsat.Model;
using GiamSat.model;
using GiamSat.View;

using System;
using System.ComponentModel;
using System.Drawing;
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
            DataGridView dataview = dataGridView1;
            dataview.Rows.Clear();
            dataview.Columns.Clear();

            List<MachinePlanData> lsdata = new List<MachinePlanData>();
            lsdata = machinePlan.getAll();

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "Machine name";
            column0.Name = column0.HeaderText;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "Line position";
            column1.Name = column1.HeaderText;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "Status";
            column2.Name = column2.HeaderText;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Cycles";
            column3.Name = column3.HeaderText;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "Time Latest";
            column4.Name = column4.HeaderText;
            column4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "Time Maintenace";
            column5.Name = column5.HeaderText;
            column5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "Time Remaining";
            column6.Name = column6.HeaderText;
            column6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // save MachineDataID
            DataGridViewTextBoxColumn columnX = new DataGridViewTextBoxColumn();
            columnX.HeaderText = "MaintenanceID";
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
            dataview.Columns.Add(columnX);
            /* not show MachineDataID*/
            dataview.Columns[columnX.Name].Visible = false;
            int rowNo = 0;
            foreach (var item in lsdata)
            {
                machineData Data = machine.get((int)item.MachineID);
                item.TimeRemaining = (uint)item.TimeMaintenace.Subtract(DateTime.Now).TotalDays;
                if (item.TimeRemaining < 0)
                {
                    item.TimeRemaining = 0;
                }
                dataview.Rows.Add(Data.machineName, Data.lane, Data.status,
                                        item.Cycles, item.TimeLatest.ToString("dd-MM-yyyy"), item.TimeMaintenace.ToString("dd-MM-yyyy"),
                                        item.TimeRemaining, item.MaintenanceID);

                Color color;
                if (item.TimeRemaining <= 10)
                {
                    color = Color.Red;
                }
                else if (item.TimeRemaining <= 20)
                {
                    color = Color.LightYellow;
                }
                else
                {
                    color = Color.LightGreen;
                }
                dataview.Rows[rowNo].DefaultCellStyle.BackColor = color;
                rowNo++;
            }


            dataview.Sort(dataview.Columns[column6.Name], ListSortDirection.Ascending);
            dataGritSource = GritSource.Data_Machine_Plan;
            return dataview;
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
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1 = dataSourceMachinePlan();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1 = dataSourceSparePart();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddMachinePlan formMC = new AddMachinePlan();
            formMC.CalledApplication = mAppInstance;
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
                    string machineName = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string cycle = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string timeStart = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string timeEnd = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string id = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                    form.Set(id, machineName, cycle, timeStart, timeEnd);
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
    }
}
