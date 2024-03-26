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
    public partial class CauhinhThietbi : Form
    {
        private string VitriTH;

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

        public CauhinhThietbi()
        {
            InitializeComponent();
        }

        public CauhinhThietbi(ItemInfor item)
        {
            InitializeComponent();

            ComboSignalLoad();

            txtID.Text = item.ID.ToString();
            txtName.Text = item.Ten;
            richTextBoxNote.Text = item.Note;
            VitriTH = item.VitriTinhieu;

        }

        private void UpdateUIControl()
        {

            if (mAppInstance != null)
            {

                Text = mAppInstance.MainResourceManager.GetString("SettingDialogTitle");
                lbID.Text = mAppInstance.MainResourceManager.GetString("DeviceIDLable");
                lbName.Text = mAppInstance.MainResourceManager.GetString("DeviceNameLable");
                lbSignal.Text = mAppInstance.MainResourceManager.GetString("DeviceSignalLable");
                lbNote.Text = mAppInstance.MainResourceManager.GetString("DeviceNoteLable");
                btnOK.Text = mAppInstance.MainResourceManager.GetString("OKButton");
                btnCancel.Text = mAppInstance.MainResourceManager.GetString("CancelButton");

            }   
        }

        private void ComboSignalLoad()
        {
            cbSignal.Items.Clear();


            if (lbSignal.Text == "ID Position")
            {
                cbSignal.Items.Add("Top");
                cbSignal.Items.Add("Bottom");
                cbSignal.Items.Add("Right");
                cbSignal.Items.Add("Left");
            }
            else
            {
                cbSignal.Items.Add("Phía trên");
                cbSignal.Items.Add("Phía dưới");
                cbSignal.Items.Add("Bên phải");
                cbSignal.Items.Add("Bên trái");
                //cbSignal.Items.Add("Phía trên tên");
                //cbSignal.Items.Add("Phía dưới tên");
                //cbSignal.Items.Add("Bên phải tên");
                //cbSignal.Items.Add("Bên trái tên");
            }
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
      
            if (txtID.Text == "")
            {

                MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputAddressMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtID.Text = "";
                txtID.Focus();
                return;

            }

            if (uint.Parse(txtID.Text) > 255)
            {
                MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputOutOfRangeAddressMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtID.Text = "";
                txtID.Focus();
                return;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputNameMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            if (cbSignal.Text == "")
            {
                MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputSignalMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                cbSignal.Focus();
                return;
            }

            //if (richTextBoxNote.Text == "")
            //{
            //    MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputNoteMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
   
            //}  

            if (mAppInstance != null)
            {
                uint id;

                id = uint.Parse(txtID.Text);
                int iListItemCount = mAppInstance.ListItemInfor.Count;
                bool idExist = false;

                for (int i = 0; i < iListItemCount; i++)
                {
                    if (mAppInstance.ListItemInfor[i] != null)
                    {
                        if((mAppInstance.ListItemInfor[i].ID == id) && (mAppInstance.ItemIndex!=i))
                        {
                            idExist = true;
                            break;
                        }
                    }
                }

                if (idExist)
                {
                    MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputAddressExit"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    txtID.Text = "";
                    txtID.Focus();
                    return;
                }
                else
                {
                    mAppInstance.DeviceID = ushort.Parse(txtID.Text);
                    mAppInstance.DeviceTen = txtName.Text;
                    mAppInstance.DeviceVitriTinhieu = cbSignal.Text;
                    mAppInstance.DeviceNote = richTextBoxNote.Text;
                    mAppInstance.DeviceTinhieuIndex = (byte)cbSignal.SelectedIndex;
                    mAppInstance.DeviceVitriTinhieu = cbSignal.Text;

                    this.DialogResult = DialogResult.OK;
                }

            }
            
            this.Close();
        }

        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(CalledApplication.MainResourceManager.GetString("InputFormatAddressMessage"), CalledApplication.MainResourceManager.GetString("LabelApplicationName"), MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CauhinhThietbi_Load(object sender, EventArgs e)
        {

            ComboSignalLoad();
            cbSignal.SelectedIndex = 0;
        }

        private void CauhinhThietbi_KeyDown(object sender, KeyEventArgs e)
        {
            
            //switch (e.KeyCode)
            //{
            //    case Keys.Enter:
            //        btnOK.PerformClick();
            //        break;

            //    case Keys.Escape:
            //        btnCancel.PerformClick();
            //        break;
            //}
        }

    }
}
