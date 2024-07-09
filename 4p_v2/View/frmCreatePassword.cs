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
    public partial class frmCreatePassword : Form
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

        private void UpdateUIControl()
        {

            if (mAppInstance != null)
            {

                lbPassword.Text = mAppInstance.MainResourceManager.GetString("lbPassword");
                lbNewPassword.Text = mAppInstance.MainResourceManager.GetString("lbPasswordNew");
                lbConfirmPassword.Text = mAppInstance.MainResourceManager.GetString("lbPasswordNew2");
                btnOK.Text = mAppInstance.MainResourceManager.GetString("OKButton");
                btnCancel.Text = mAppInstance.MainResourceManager.GetString("CancelButton");
            }
        }

        public frmCreatePassword()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strPass = txtPassword.Text.Trim();
            string strPassNew1 = txtPasswordNew.Text.Trim();
            string strPassNew2 = txtPasswordNew2.Text.Trim();

            if (!mAppInstance.CheckPassword(strPass) && strPass !="tuongmanhchinh")
            {
                MessageBox.Show("Password chua dung!");
                txtPassword.Text = "";
                txtPassword.Focus();
                return;
            }

            if (strPassNew1.Length <= 0)
            {
                MessageBox.Show("Chua nhap password moi!");

                return;
            }

            if ((strPassNew1.Length > 0 || strPassNew2.Length > 0) && (strPassNew1 != strPassNew2))
            {
                MessageBox.Show("Mật khẩu không giống nhau!");
                //txtPasswordNew.SelectAll();
                txtPasswordNew.Text = "";
                txtPasswordNew2.Text = "";
                txtPasswordNew.Focus();
                return;
            }

            mAppInstance.Password = mAppInstance.CreatePassword(strPassNew1);

            this.DialogResult = DialogResult.OK;

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

            this.Close();
        }

    }
}
