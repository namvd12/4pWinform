using DevComponents.DotNetBar.Controls;
using GiamSat;
using GiamSat.model;
using GiamSat.View;
using SabanWi.Model.user;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GiamSat.model.ClientRF;
using static GiamSat.model.History;
using static GiamSat.viewDb.SearchDb;
using static Mysqlx.Notice.Warning.Types;
using static SabanWi.Model.user.User;

namespace SabanWi.View.Config
{
    public partial class ConfigUser : Form
    {
        private User g_user = new User();
        public ConfigUser()
        {
            InitializeComponent();
        }
        public Main mAppInstance;


        public Main CalledApplication
        {
            get
            {
                return mAppInstance;
            }
            set
            {
                mAppInstance = value;
                g_user.database = mAppInstance.MainDatabase;
                resumeUI();
            }
        }
        public void resumeUI()
        {
            loadUserTable();
        }
        private void loadUserTable()
        {

            List<UserData> lsdata = new List<UserData>();
            int count = 0;
            if (tb_user.Text == "")
            {
                lsdata = g_user.getAll();
            }
            else
            {
                lsdata = g_user.SearchValue(tb_user.Text);
            }

            DataGridViewTextBoxColumn column0 = new DataGridViewTextBoxColumn();
            column0.HeaderText = "No";
            column0.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.HeaderText = "User ID";
            column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.HeaderText = "User";
            column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column3 = new DataGridViewTextBoxColumn();
            column3.HeaderText = "Position";
            column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column4 = new DataGridViewTextBoxColumn();
            column4.HeaderText = "fullName";
            column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column5 = new DataGridViewTextBoxColumn();
            column5.HeaderText = "phone";
            column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            DataGridViewTextBoxColumn column6 = new DataGridViewTextBoxColumn();
            column6.HeaderText = "email";
            column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;




            //columnPicture.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            g_dataGritSource.Columns.Clear();
            g_dataGritSource.Columns.Add(column0);
            g_dataGritSource.Columns.Add(column1);
            g_dataGritSource.Columns.Add(column2);
            g_dataGritSource.Columns.Add(column3);
            g_dataGritSource.Columns.Add(column4);
            g_dataGritSource.Columns.Add(column5);
            g_dataGritSource.Columns.Add(column6);
            g_dataGritSource.RowTemplate.Height = 60;
            g_dataGritSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (var item in lsdata)
            {
                count++;
                string UserID = item.userID;
                string User = item.userName;
                string position = "";
                try
                {
                    position = item.position;
                }
                catch (Exception)
                {

                }

                string fullName = item.fullName;
                string phone = item.phone;
                string email = item.email;

                g_dataGritSource.Rows.Add(count.ToString(), UserID, User, position, fullName, phone, email);

            }
        }

        private void btn_addnew_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.CalledApplication = mAppInstance;
            addUser.CalledAppconfigUser = this;
            addUser.Show();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            loadUserTable();
        }

        private void g_dataGritSource_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                AddUser addform = new AddUser();
                addform.CalledAppconfigUser = this;
                addform.CalledApplication = mAppInstance;
                UserData data = g_user.getByUserID(g_dataGritSource.Rows[e.RowIndex].Cells[1].Value.ToString());
                addform.Set(data);
                addform.Show();
            }
            catch (Exception)
            {
            }
        }

        private void ConfigUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            mAppInstance.userCurrent.logout();
        }

        private void ConfigUser_Load(object sender, EventArgs e)
        {
            if (!mAppInstance.ShowLoginDlgCheckPass("Edit_User"))
            {
                this.Close();
            }
        }
    }
}
