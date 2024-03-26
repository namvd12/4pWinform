using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiamSat
{
    public partial class DanhsachThietbi : Form
    {
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
                UpdateUIControl();
            }
        }

        public DanhsachThietbi()
        {
            InitializeComponent();
        }

        private void UpdateUIControl()
        {

            if (mAppInstance != null)
            {

                Text = mAppInstance.MainResourceManager.GetString("DeviceListTitle");
                lbTitle.Text = mAppInstance.MainResourceManager.GetString("DeviceListLable");
                btnAdd.Text = mAppInstance.MainResourceManager.GetString ("AddButton");
                btnEdit.Text = mAppInstance.MainResourceManager.GetString("EditButton");
                btnDelete.Text = mAppInstance.MainResourceManager.GetString("DeleteButton");
                btnOK.Text = mAppInstance.MainResourceManager.GetString("OKButton");
                btnCancel.Text = mAppInstance.MainResourceManager.GetString("CancelButton");

                dataGridViewThietbi.Columns["Column1"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderSTT");
                dataGridViewThietbi.Columns["Column2"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderLocation");
                dataGridViewThietbi.Columns["Column3"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderName");
                dataGridViewThietbi.Columns["Column4"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderID");
                dataGridViewThietbi.Columns["Column5"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderSignalPosition");
                dataGridViewThietbi.Columns["Column6"].HeaderText = mAppInstance.MainResourceManager.GetString("HeaderNote");
            }
        }


        public void dataGridViewThietbiInit()
        {
            dataGridViewThietbi.ColumnHeadersDefaultCellStyle.ForeColor = Color.Blue;
            //dataGridViewThietbi.ColumnHeadersDefaultCellStyle.BackColor = Color.Orange;
            dataGridViewThietbi.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Bold);
            dataGridViewThietbi.EnableHeadersVisualStyles = false;

            //dataGridViewThietbi.Columns["Column1"].DefaultCellStyle.BackColor = Color.Green;
            //dataGridViewThietbi.Columns["Column1"].DefaultCellStyle.ForeColor = Color.Black;

            dataGridViewThietbi.Columns["Column1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column6"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewThietbi.Columns["Column1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewThietbi.Columns["Column4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewThietbi.Columns["Column6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dataGridViewThietbi.Columns["Column6"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        

            //foreach (DataGridViewHeaderCell header in dataGridViewThietbi.Columns)
            //{
            //    header.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    header.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            dataGridViewThietbi.ReadOnly = true;
            dataGridViewThietbi.AllowUserToAddRows = false;
        }

        private void UpdateDataGridViewThietbi()
        {
            int nRow = mAppInstance.ListItemInfor.Count;

            dataGridViewThietbi.AllowUserToAddRows = true;

            dataGridViewThietbi.Rows.Clear();

            for (int i = 0; i < nRow; i++)
            {
                dataGridViewThietbi.Rows.Add();

                DataGridViewRow newrow = dataGridViewThietbi.Rows[i];
                newrow.Cells[0].Value = i + 1;
                newrow.Cells[1].Value = mAppInstance.ListItemInfor[i].ButtonItem.Location.X + ", " + mAppInstance.ListItemInfor[i].ButtonItem.Location.Y ;
                newrow.Cells[2].Value = mAppInstance.ListItemInfor[i].Ten;
                newrow.Cells[3].Value = mAppInstance.ListItemInfor[i].ID;

                newrow.Cells[5].Value = mAppInstance.ListItemInfor[i].Note;

                if (lbTitle.Text == "          DEVICE LIST")
                {
                    if (mAppInstance.ListItemInfor[i].TinhieuIndex == 0)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Top";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 1)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Bottom";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 2)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Right";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 3)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Left";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                }

                else
                {
                    if (mAppInstance.ListItemInfor[i].TinhieuIndex == 0)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Phía trên";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 1)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Phía dưới";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 2)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Bên phải";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                    else if (mAppInstance.ListItemInfor[i].TinhieuIndex == 3)
                    {
                        mAppInstance.ListItemInfor[i].VitriTinhieu = "Bên trái";
                        newrow.Cells[4].Value = mAppInstance.ListItemInfor[i].VitriTinhieu;
                    }
                }
                    
            }

            dataGridViewThietbi.AllowUserToAddRows = false;

        }
         
        private ItemInfor SeachItem(uint id)
        {
            ItemInfor item = new ItemInfor();

            int nCount = mAppInstance.ListItemInfor.Count;

            for (int i = 0; i < nCount; i++)
            {
                if(mAppInstance.ListItemInfor[i].ID == id)
                {
                    item = mAppInstance.ListItemInfor[i];
                    mAppInstance.ItemIndex = i;
                    break;
                }
            }

            return item;
        }

        private void EditItem(DataGridViewRow row)
        {
            uint id = Convert.ToUInt32(row.Cells[3].Value);
            //string ten = Convert.ToString(row.Cells[2].Value);
            //string vitri = Convert.ToString(row.Cells[4].Value);
            //string note = Convert.ToString(row.Cells[5].Value);

            ItemInfor item = new ItemInfor();
            item = SeachItem(id);

            CauhinhThietbi frmNew = new CauhinhThietbi(item);
            frmNew.CalledApplication = mAppInstance;

            DialogResult dialogResult = frmNew.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                int index = mAppInstance.ItemIndex;
                mAppInstance.ListItemInfor[index].ID = mAppInstance.DeviceID;
                mAppInstance.ListItemInfor[index].Ten = mAppInstance.DeviceTen;
                mAppInstance.ListItemInfor[index].VitriTinhieu = mAppInstance.DeviceVitriTinhieu;
                mAppInstance.ListItemInfor[index].TinhieuIndex = mAppInstance.DeviceTinhieuIndex;
                mAppInstance.ListItemInfor[index].Note = mAppInstance.DeviceNote;

                mAppInstance.UpdateItem(mAppInstance.ListItemInfor[index]);
                UpdateDataGridViewThietbi();

                dataGridViewThietbi.FirstDisplayedScrollingRowIndex = index;
                dataGridViewThietbi.Refresh();
                dataGridViewThietbi.CurrentCell = dataGridViewThietbi.Rows[index].Cells[0];
                dataGridViewThietbi.Rows[index].Selected = true;

            }

            else
            {
                return;
            }
        }

        private void DanhsachThietbi_Load(object sender, EventArgs e)
        {
            dataGridViewThietbiInit();
            UpdateDataGridViewThietbi();

            if (!mAppInstance.EditEnable)
            {
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnEdit.Enabled = false;
            }
        }

        private void dataGridViewThietbi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (mAppInstance.EditEnable)
            {
                try
                {
                    if (e.RowIndex >= 0)
                    {
                        int rowIndex = e.RowIndex;
                        DataGridViewRow row = dataGridViewThietbi.Rows[rowIndex];

                        EditItem(row);
                    }

                }

                catch
                {
                    //MessageBox.Show(e.RowIndex.ToString());
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CauhinhThietbi frmNew = new CauhinhThietbi();
            frmNew.CalledApplication = mAppInstance;

            DialogResult dialogResult = frmNew.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                mAppInstance.AddNewItem();
                UpdateDataGridViewThietbi();
            }

            else
            {
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewThietbi.CurrentCell.RowIndex >= 0)
                {
                    DialogResult dialog = MessageBox.Show(CalledApplication.MainResourceManager.GetString("DeleteDeviceMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (dialog == DialogResult.OK)
                    {
                        int rowIndex = dataGridViewThietbi.CurrentCell.RowIndex;
                        DataGridViewRow row = dataGridViewThietbi.Rows[rowIndex];
                        uint id = Convert.ToUInt32(row.Cells[3].Value);

                        ItemInfor item = new ItemInfor();
                        item = SeachItem(id);
                        mAppInstance.RemoveItem(item);
                        UpdateDataGridViewThietbi();
                    }
                }

                else
                {
                    MessageBox.Show(CalledApplication.MainResourceManager.GetString("ErrorNoDeviceSelected"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }

            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewThietbi.CurrentCell.RowIndex >= 0)
                {
                    int rowIndex = dataGridViewThietbi.CurrentCell.RowIndex;
                    DataGridViewRow row = dataGridViewThietbi.Rows[rowIndex];
                    EditItem(row);
                }

                else
                {
                    MessageBox.Show(CalledApplication.MainResourceManager.GetString("ErrorNoDeviceSelected"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                }
            }
            catch
            {

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DanhsachThietbi_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbTitle_Click(object sender, EventArgs e)
        {

        }

    }
}
