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
    public partial class ConfigTimeNG : Form
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
        public ConfigTimeNG()
        {
            InitializeComponent();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            bool status = mConfig.setTimeNG(1, Convert.ToUInt16(tb_time.Text));

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
            tb_time.Text = mConfig.getTimeReport().ToString();
        }

        private void ConfigTimeNG_FormClosing(object sender, FormClosingEventArgs e)
        {
            mSearchDbInstance.userCurrent.logout();
        }
    }
}
