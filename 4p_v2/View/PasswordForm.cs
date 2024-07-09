using SabanWi.Model;
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
    public partial class PasswordForm : Form
    {
        private User User = new User();
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
                User.database = mAppInstance.db;
                UpdateUIControl();
            }
        }

        private void UpdateUIControl()
        {

            if (mAppInstance != null)
            {

                lbPassword.Text = mAppInstance.MainResourceManager.GetString("lbPassword");
              
                btnOK.Text = mAppInstance.MainResourceManager.GetString("OKButton");
                btnCancel.Text = mAppInstance.MainResourceManager.GetString("CancelButton");
            }
        }


        public PasswordForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var isAdmin = User.loginAdmin(tb_user.Text, tb_pw.Text);

            if (!isAdmin)
            {
                errorProvider1.SetError(tb_pw, "Mật khẩu không đúng!");
                return ;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(ConsoleKey.Enter))
            {
                btnOK.PerformClick();
            }

            else if (e.KeyChar == Convert.ToChar(ConsoleKey.Escape))
            {
                btnCancel.PerformClick();
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
