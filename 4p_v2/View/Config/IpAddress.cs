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
    public partial class ipAddress : Form
    {
        string path = "setting.bin";
        public ipAddress()
        {
            InitializeComponent();

        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            File.WriteAllText(path, tb_text.Text);
            MessageBox.Show("Done");
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
            if (File.Exists(path))
            {
                tb_text.Text = File.ReadAllText(path);
            }
        }
    }
}
