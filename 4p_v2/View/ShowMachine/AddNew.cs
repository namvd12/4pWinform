using GiamSat.model;
using GiamSat.viewDb;
using Mysqlx.Crud;
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
    public partial class AddNew : Form
    {
        private bool isEditing = false;
        private SearchDb mSearchDbInstance;
        private Main mSearchDbInstance_main;
        private Machine machine;
        private ClientRF clientRF;

        private string _machineCode;
        private string _machineName;
        private string _line;
        private string _lane;

        private string _model;
        private string _serial;
        private string _TopBot;
        public SearchDb CalledSearchDb
        {
            get
            {
                return mSearchDbInstance;
            }
            set
            {
                mSearchDbInstance    = value;
                machine.database     = mSearchDbInstance.mAppInstance.MainDatabase;
                clientRF.database    = mSearchDbInstance.mAppInstance.MainDatabase;

            }
        }
        public Main CalledSearchDb_main
        {
            get
            {
                return mSearchDbInstance_main;
            }
            set
            {
                mSearchDbInstance_main = value;
                machine.database = mSearchDbInstance_main.MainDatabase;
                clientRF.database = mSearchDbInstance_main.MainDatabase;
            }
        }
        public AddNew()
        {
            InitializeComponent();
            machine = new Machine();
            clientRF = new ClientRF();

        }

        public void Set(string machineCode)
        {
            isEditing = true;
            btn_delete.Enabled = true;

            /* get infor machine */
            int machineID = machine.getMachineID(machineCode);
            machineData mcData = machine.get(machineID);
            _machineCode = machineCode;
            _machineName = mcData.machineName;
            _line = mcData.linePosition;
            _lane = mcData.lane;
            _model = mcData.Model;
            _serial = mcData.Serial;
            _TopBot = mcData.TopBot;

            tb_machineCode.Text = machineCode;
            tb_machineName.Text = _machineName;
            tb_line.Text = _line;
            tb_lane.Text = _lane = mcData.lane;
            tb_model.Text = _model;
            tb_serial.Text = _serial;
            if (_TopBot == "Top")
            {
                cb_topBot.SelectedIndex = 0;
            }
            else
            {
                cb_topBot.SelectedIndex = 1;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool status = false;
            if (tb_machineCode.Text == string.Empty && tb_machineName.Text == string.Empty &&
                tb_line.Text == string.Empty && tb_lane.Text == string.Empty &&
                tb_model.Text == string.Empty && tb_serial.Text == string.Empty && cb_topBot.SelectedText == string.Empty)
            {
                MessageBox.Show("Empty content");
                return;
            }
            if (tb_line.Text == string.Empty)
            {
                tb_line.Text = "0";
            }
            if (tb_lane.Text == string.Empty)
            {
                tb_lane.Text = "0";
            }
            if (isEditing)
            {
                int machineID = machine.getMachineID(_machineCode);
                status = machine.update(machineID, tb_machineCode.Text, tb_machineName.Text, tb_line.Text, tb_lane.Text, null, null, null, null, null, 
                                        tb_model.Text, tb_serial.Text, cb_topBot.Text);
            }
            else
            {
                status = machine.add(tb_machineCode.Text, tb_machineName.Text, tb_line.Text, tb_lane.Text, null, null, null, null, null,
                                        tb_model.Text, tb_serial.Text, cb_topBot.Text);
            }
            if (status)
            {
                DialogResult dialogResult;
                if (isEditing)
                {
                    dialogResult = MessageBox.Show("Done", "Done", MessageBoxButtons.OK);
                    if (dialogResult == DialogResult.OK)
                    { 
                        this.Close();
                    }
                }
                else
                {
                    dialogResult = MessageBox.Show("Done. Exits?", "Done", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
            {
                int machineID = machine.getMachineID(_machineCode);
                clientRF.delete(machineID);
                machine.delete(machineID);
                mSearchDbInstance.resumeUI();
                this.Close();
            }
        }

        private void AddNew_Load(object sender, EventArgs e)
        {
            if (isEditing == false)
            {
                tb_machineCode.ReadOnly = false;
            }
        }

        private void tb_line_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_lane_KeyPress(object sender, KeyPressEventArgs e)
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
