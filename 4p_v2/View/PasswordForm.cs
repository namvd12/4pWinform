using SabanWi.Model.user;
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
        public User User;
        private Main mAppInstance;
        private string g_permission = "";
        public Main CalledApplication
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                User = mAppInstance.userCurrent;
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


        public PasswordForm(string permission)
        {
            InitializeComponent();
            g_permission = permission;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            var userData = User.login(tb_user.Text, tb_pw.Text, g_permission);

            if (userData == null)
            {
                errorProvider1.SetError(tb_pw, "Mật khẩu không đúng!");
                return;
            }
            else
            {
                User.setCurrentUser(userData);
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
