using GiamSat;
using GiamSat.model;
using GiamSat.viewDb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Giamsat.View.Config
{
    public partial class ConfigFolderReport : Form
    {
        private Main mSearchDbInstance;

        private ConfigSystem mConfig = new ConfigSystem();

        public Main CalledSearchDb
        {
            get
            {
                return mSearchDbInstance;
            }
            set
            {
                mSearchDbInstance = value;
                mConfig.database = mSearchDbInstance.MainDatabase;
            }
        }
        public ConfigFolderReport()
        {
            InitializeComponent();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            /*Check folder exis*/

            if (!Directory.Exists(tb_time.Text))
            {
                MessageBox.Show("Error folder");
                return;
            }

            bool status = mConfig.setFolder(tb_time.Text.Replace("\\", "/"));
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

        private void tb_time_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_time_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConfigTimeNG_Load(object sender, EventArgs e)
        {
            if (!mSearchDbInstance.ShowLoginDlgCheckPass("Edit_device"))
            {
                this.Close();
            }
            tb_time.Text = mConfig.getFolderReport().ToString();
        }

        private void ConfigFolderReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            mSearchDbInstance.userCurrent.logout();
        }
    }
}
