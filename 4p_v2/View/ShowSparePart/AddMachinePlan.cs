using Giamsat.Model;
using GiamSat.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.Machine;

namespace GiamSat.View
{
    public partial class AddMachinePlan : Form
    {
        private bool isEditing = false;

        private int _maintenanceID = 0;

        private int _machineid = 0;

        List<machineData> lsMachine = new List<machineData>();

        Machine machine = new Machine();

        MachinePlan machinePlan = new MachinePlan();

        private Main mAppInstance;

        public Main CalledApplication
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                machine.database = mAppInstance.db;
                machinePlan.database = mAppInstance.db;
                loadform();
            }
        }

        public AddMachinePlan()
        {
            InitializeComponent();
        }

        public void loadform()
        {


            lsMachine = machine.getAll();
            foreach (var machineData in lsMachine)
            {
                cb_machineName.Items.Add(machineData.machineName);
            }
        }
        public void Set(string id, string machineName, string cycle, string timeStart, string timeEnd)
        {
            isEditing = true;
            btn_delete.Enabled = true;
            _maintenanceID = Convert.ToUInt16(id);
            tb_cycle.Text = cycle;
            dateTimePicker_latest.Text = timeStart;
            dateTimePicker_Maintenance.Text = timeEnd;
            cb_machineName.SelectedIndex = cb_machineName.Items.IndexOf(machineName);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_cycle.Text != string.Empty && dateTimePicker_latest.Text != string.Empty)
            {

                DateTime Timelatest = DateTime.ParseExact(dateTimePicker_latest.Text, "dd-MM-yyyy", null);
                DateTime TimeMaintenace = DateTime.ParseExact(dateTimePicker_Maintenance.Text, "dd-MM-yyyy", null);
                TimeSpan TimeRemaining = TimeMaintenace.Subtract(Timelatest);
                bool status = machinePlan.set(_maintenanceID, _machineid, Convert.ToUInt16(tb_cycle.Text), Timelatest, TimeMaintenace, Convert.ToUInt16(TimeRemaining.Days));
                if (status)
                {
                    MessageBox.Show("Done");
                }
                else
                {
                    MessageBox.Show("Error");
                }

                this.Close();

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
            {
                machinePlan.delete(_maintenanceID);
                this.Close();

            }
        }

        private void cb_machineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var machineData in lsMachine)
            {
                if (cb_machineName.GetItemText(cb_machineName.SelectedItem) == machineData.machineName)
                {
                    tb_machineCode.Text = machineData.machineCode;
                    tb_line.Text = machineData.linePosition;
                    _machineid = machineData.machineID;
                }
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tb_cycle_TextChanged(object sender, EventArgs e)
        {
            if (tb_cycle.Text != string.Empty && dateTimePicker_latest.Text != string.Empty)
            {
                DateTime Timelatest = DateTime.ParseExact(dateTimePicker_latest.Text, "dd-MM-yyyy", null);
                dateTimePicker_Maintenance.Text = Timelatest.AddDays(Convert.ToUInt32(tb_cycle.Text)).ToString();
            }
        }

        private void tb_cycle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker_latest_ValueChanged(object sender, EventArgs e)
        {
            if (tb_cycle.Text != string.Empty && dateTimePicker_latest.Text != string.Empty)
            {
                DateTime Timelatest = DateTime.ParseExact(dateTimePicker_latest.Text, "dd-MM-yyyy", null);
                dateTimePicker_Maintenance.Text = Timelatest.AddDays(Convert.ToUInt32(tb_cycle.Text)).ToString();
            }
        }
    }
}
