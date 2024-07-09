
using DevComponents.DotNetBar;
using Giamsat.Control.Devices;
using GiamSat.model;
using GiamSat.viewDb;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.Main;
using static GiamSat.model.ClientRF;
using static GiamSat.model.Machine;


namespace GiamSat.View
{
    public partial class AddItems : Form
    {
        private bool isEditing = false;

        private int _machineid;
        private string _machineName;

        private string _machinecode;

        private uint _MaintenanceID;

        List<machineData> lsMachine = new List<machineData>();


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

                loadform();
            }
        }

        public AddItems()
        {
            InitializeComponent();
        }

        public void loadform()
        {
            Machine machine = new Machine();
            machine.database = mAppInstance.db;

            lsMachine = machine.getAll();
            foreach (var machineData in lsMachine)
            {
                cb_machineName.Items.Add(machineData.machineName);
            }
        }
        public void Set(uint addr, uint port, string name)
        {
            //isEditing = true;
            //btn_delete.Enabled = true;
            //_MaintenanceID = Convert.ToUInt16(id);

        }
        
        public void LoadItem(int machineID, string machineCode, string machineName, uint addr, uint port, string status,string time, int x, int y, int line, int lane, string region , bool edit)
        {
            ItemRF item = new ItemRF();

            item.machineid = machineID;
            item.machineCode = machineCode;
            item.addr = addr;
            item.port = port;
            item.machineName = machineName;
            item.status = status;
            item.timeNG = time;
            item.location_x = x;
            item.location_y = y;
            item.line = line;
            item.lane = lane;
            item.region = region;
            item.ButtonItem = new ButtonX();

            item.ButtonItem.Text = "";
            item.ButtonItem.Name = machineName;
            item.ButtonItem.MouseEnter += new System.EventHandler(handleMouseEnter);
            item.ButtonItem.MouseLeave += new System.EventHandler(handleMouseLeave);
            item.ButtonItem.MouseClick += new MouseEventHandler(handleDoubleClick);

            item.ButtonItem.Image = mAppInstance.LedDisplay(LedColour.BLACK, 0, 15, 15);
            item.ButtonItem.Location = new System.Drawing.Point(x, y);

            item.ButtonItem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            item.ButtonItem.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;

            //item.ButtonItem.BackColor = DevCom;
            item.ButtonItem.FocusCuesEnabled = false;
            //item.ButtonItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            item.ButtonItem.Font = new System.Drawing.Font("Arial", 8.0F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            item.ButtonItem.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;

            int nLength;

            nLength = item.ButtonItem.Text.Length;
            if (nLength < 3) nLength = 3;

            item.ButtonItem.Size = new System.Drawing.Size(15, 15);
            item.ButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            item.ButtonItem.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Center;

            item.xRatio = (float)(mAppInstance.pb_lineLTE.Width) / (float)item.ButtonItem.Location.X;
            item.yRatio = (float)(mAppInstance.pb_lineLTE.Height) / (float)item.ButtonItem.Location.Y;
            item.RatioWidth = (float)(mAppInstance.pb_lineLTE.Width) / (float)item.ButtonItem.Width;
            item.RatioHeight = (float)(mAppInstance.pb_lineLTE.Height) / (float)item.ButtonItem.Height;
            item.RatioImageWidth = (float)(mAppInstance.pb_lineLTE.Width) / (float)item.ButtonItem.Image.Width;
            item.RatioImageHeight = (float)(mAppInstance.pb_lineLTE.Height) / (float)item.ButtonItem.Image.Height;
            if (line == 1)
            {
                mAppInstance.pb_lineLTE.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line1;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 2)
            {
                mAppInstance.pb_line1.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line2;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 3)
            {
                mAppInstance.pb_line2.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line3;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 4)
            {
                mAppInstance.pb_line3.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line4;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 5)
            {
                mAppInstance.pb_line4.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line5;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 6)
            {
                mAppInstance.pb_line5.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line6;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 7)
            {
                mAppInstance.pb_line6.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line7;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            else if (line == 8)
            {
                mAppInstance.pb_line7.Controls.Add(item.ButtonItem);
                item.ButtonItem.Parent = mAppInstance.pb_line8;
                item.ButtonItem.BackColor = Color.Transparent;
            }
            //else if (line == 9)
            //{
            //    mAppInstance.pb_line8.Controls.Add(item.ButtonItem);
            //    item.ButtonItem.Parent = mAppInstance.pb_line8;
            //    item.ButtonItem.BackColor = Color.Transparent;
            //}
            mAppInstance.lsItems.Add(item);

            if (edit)
            {
                Helper.ControlMover.Init(item.ButtonItem);
            }
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void handleMouseEnter(object sender, EventArgs e)
        {
            ButtonX button = sender as ButtonX;

            string showToolTip = button.Name + "\r\n";
            foreach (var item in mAppInstance.lsItems)
            {
                if (!button.Name.Contains("Region") && button.Name == item.machineName)
                {
                    button.Tooltip = string.Format("{0} [RF:{1}-{2}]", button.Name, item.addr, item.port) ;
                }
                else
                {
                    if (item.region != "" && button.Name.Contains(item.region))
                    {
                        showToolTip += string.Format("Line{0}-{1}: {2} {3} [RF:{4}-{5}]\r\n", item.line, item.lane, item.machineCode, item.status, item.addr, item.port);
                    }
                }
            }
            button.Tooltip = showToolTip;
        }

        private void handleMouseLeave(object sender, EventArgs e)
        {
            ButtonX button = sender as ButtonX;
            button.Tooltip = string.Empty;

        }

        private void handleDoubleClick(object sender, EventArgs e)
        {
            if (mAppInstance.WindowState != FormWindowState.Normal)
            {             
                ButtonX button = sender as ButtonX;
                bool showDataNG = false;
                foreach (var item in mAppInstance.lsItems)
                {
                    if (item.region != "" && item.status == "NG")
                    {
                        showDataNG = true;
                        break;
                    }
                }

                if (showDataNG)
                {
                    SearchDb searchFrom = new SearchDb();
                    searchFrom.CalledApplication = mAppInstance;
                    searchFrom.resumeUI("NG");
                    searchFrom.Show();
                }
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (cb_machineName.Text != string.Empty && cb_addr.Text != string.Empty
                && cb_port.Text != string.Empty && tb_region.Text != string.Empty)
            {
                LoadItem(_machineid, _machinecode, _machineName, Convert.ToUInt16(cb_addr.Text), Convert.ToUInt16(cb_port.Text), "", "",0, 0, Convert.ToUInt16(tb_line.Text), 0, tb_region.Text + "_" + tb_line.Text, true);

                //this.Close();
            }
            else
            {
                MessageBox.Show("Empty");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
            {

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
                    _machineName = machineData.machineName;
                    _machinecode = machineData.machineCode;

                }
            }
        }

        private void cb_addr_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cb_port_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            if (cb_machineName.Text != string.Empty && cb_addr.Text != string.Empty
                && cb_port.Text != string.Empty)
            {
                btn_save.Enabled = true;
            }
        }
    }
}
