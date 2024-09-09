using SabanWi.Model.user;
using SabanWi.View.Config;
using static SabanWi.Model.user.Group;
using static SabanWi.Model.user.User;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Group = SabanWi.Model.user.Group;


namespace GiamSat.View
{
    public partial class AddUser : Form
    {
        private bool isEditing = false;

        private User user;

        private Group group;

        private UserData g_Userdata;

        private List<UserData> lsUser = new List<UserData>();

        private Main mAppInstance;

        private ConfigUser mConfigUser;

        public ConfigUser CalledAppconfigUser { get { return mConfigUser; } set { mConfigUser = value; } }

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

        public AddUser()
        {
            InitializeComponent();
        }

        public void loadform()
        {
            user = new User();
            group = new Group();
            user.database = mAppInstance.db;
            group.database = mAppInstance.db;
            var lsGroup = group.getAll();
            foreach (var Group in lsGroup)
            {
                cb_position.Items.Add(Group.nameGroup);
            }
            cb_position.Text = "Test";
        }
        public void Set(UserData data)
        {
            g_Userdata = data;
            tb_id.Text = data.userID;
            tb_user.Text = data.userName;
            try
            {
                cb_position.Text = data.position;
            }
            catch (Exception)
            {

                cb_position.SelectedIndex = 0;
            }
            tb_fullName.Text = data.fullName;
            tb_phone.Text = data.phone;
            tb_email.Text = data.email;
            isEditing = true;
            tb_pw.Text = "";
            tb_confirmpw.Text = "";
            btn_delete.Enabled = true;

            if (data.userName == "admin")
            {
                cb_position.Enabled = false;
                tb_user.Enabled = false;
                tb_fullName.Enabled = false;
                tb_id.Enabled = false;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (tb_pw.Text != tb_confirmpw.Text)
            {
                MessageBox.Show("Check confirm password!!!");
                return;
            }
            if (tb_id.Text != string.Empty && tb_user.Text != string.Empty)
            {
                var status = false;
                if (isEditing)
                {
                    if (tb_pw.Text == "")
                    {
                        status = user.update(g_Userdata.userKey, tb_id.Text, cb_position.Text, tb_user.Text, null, tb_fullName.Text, tb_phone.Text, tb_email.Text);
                    }
                    else
                    {
                        // Hash
                        string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                        string hashPW = BCrypt.Net.BCrypt.HashPassword(tb_pw.Text, mySalt);
                        status = user.update(g_Userdata.userKey, tb_id.Text, cb_position.Text, tb_user.Text, hashPW, tb_fullName.Text, tb_phone.Text, tb_email.Text);
                    }
                }
                else
                {
                    // Hash
                    string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
                    string hashPW = BCrypt.Net.BCrypt.HashPassword(tb_pw.Text, mySalt);
                    status = user.add(tb_id.Text, cb_position.Text, tb_user.Text, hashPW, tb_fullName.Text, tb_phone.Text, tb_email.Text);
                }
                if (status)
                {
                    MessageBox.Show("Done");
                    mConfigUser.resumeUI();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error UserID or UserName");
                }
            }
            else
            {
                MessageBox.Show("Empty content");
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want Delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result.Equals(DialogResult.OK))
            {
                var status = user.delete((int)g_Userdata.userKey);
                if (status)
                {
                    MessageBox.Show("Done");
                    mConfigUser.resumeUI();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error");
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
            if (tb_id.Text != string.Empty && tb_user.Text != string.Empty
                 && tb_pw.Text != string.Empty && tb_confirmpw.Text != string.Empty)
            {
                btn_save.Enabled = true;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {

        }

        private void tb_id_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
