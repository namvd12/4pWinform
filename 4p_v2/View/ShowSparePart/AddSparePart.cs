
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
using static Giamsat.Model.SparePart;
using static GiamSat.model.Machine;


namespace GiamSat.View
{
    public partial class AddSparePart : Form
    {
        private bool isEditing = false;

        private int _machineid = 0;

        private int _SparePartID = 0;

        List<SparePartData> lsSP = new List<SparePartData>();

        List<machineData> lsMachine = new List<machineData>();

        Machine machine = new Machine();

        SparePart SP_Plan = new SparePart();

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
                SP_Plan.database = mAppInstance.db;
                loadform();
            }
        }

        public AddSparePart()
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
        public void Set(string id, string machineName, string SpCode, string SpName, string SN, string timeReplace, string numberItem, string cycle)
        {
            isEditing = true;
            btn_delete.Enabled = true;
            _SparePartID = Convert.ToUInt16(id);
            cb_machineName.SelectedIndex = cb_machineName.Items.IndexOf(machineName);
            tb_SPCode.Text = SpCode;
            tb_SPName.Text = SpName;
            tb_SN.Text = SN;
            dateTimePicker.Text = timeReplace;
            tb_number.Text = numberItem;
            tb_cycle.Text = cycle;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_SPName.Text != string.Empty && tb_SPCode.Text != string.Empty && tb_SN.Text != string.Empty &&
                tb_cycle.Text != string.Empty && dateTimePicker.Text != string.Empty && tb_number.Text != string.Empty)
            {

                DateTime TimeStart = DateTime.ParseExact(dateTimePicker.Text, "dd-MM-yyyy", null);
                DateTime TimeEnd = TimeStart.AddDays(Convert.ToDouble(tb_cycle.Text));
                uint TimeRemaining = Convert.ToUInt32(TimeEnd.Subtract(DateTime.Now).TotalDays);
                bool status = SP_Plan.set(_SparePartID, _machineid, tb_SPCode.Text, tb_SPName.Text, tb_SN.Text, TimeStart, Convert.ToUInt32(tb_number.Text),
                                            Convert.ToUInt32(tb_cycle.Text), TimeRemaining);
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
                SparePart machinePlan = new SparePart();
                machinePlan.delete(_SparePartID);
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
            if (tb_cycle.Text != string.Empty && dateTimePicker.Text != string.Empty)
            {

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

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
