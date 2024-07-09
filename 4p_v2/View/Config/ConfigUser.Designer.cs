namespace SabanWi.View.Config
{
    partial class ConfigUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            tb_user = new TextBox();
            btn_search = new Button();
            btn_addnew = new Button();
            panel2 = new Panel();
            g_dataGritSource = new DataGridView();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)g_dataGritSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 53);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(tb_user);
            flowLayoutPanel1.Controls.Add(btn_search);
            flowLayoutPanel1.Controls.Add(btn_addnew);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(800, 53);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(63, 44);
            label1.TabIndex = 4;
            label1.Text = "User name";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_user
            // 
            tb_user.Dock = DockStyle.Fill;
            tb_user.Location = new Point(72, 3);
            tb_user.Multiline = true;
            tb_user.Name = "tb_user";
            tb_user.Size = new Size(203, 38);
            tb_user.TabIndex = 3;
            // 
            // btn_search
            // 
            btn_search.Dock = DockStyle.Fill;
            btn_search.Location = new Point(281, 3);
            btn_search.Name = "btn_search";
            btn_search.Size = new Size(110, 38);
            btn_search.TabIndex = 0;
            btn_search.Text = "Search";
            btn_search.UseVisualStyleBackColor = true;
            btn_search.Click += btn_search_Click;
            // 
            // btn_addnew
            // 
            btn_addnew.Dock = DockStyle.Top;
            btn_addnew.Location = new Point(397, 3);
            btn_addnew.Name = "btn_addnew";
            btn_addnew.Size = new Size(83, 38);
            btn_addnew.TabIndex = 1;
            btn_addnew.Text = "Add new";
            btn_addnew.UseVisualStyleBackColor = true;
            btn_addnew.Click += btn_addnew_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(g_dataGritSource);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 53);
            panel2.Name = "panel2";
            panel2.Size = new Size(800, 397);
            panel2.TabIndex = 1;
            // 
            // g_dataGritSource
            // 
            g_dataGritSource.AllowUserToAddRows = false;
            g_dataGritSource.AllowUserToDeleteRows = false;
            g_dataGritSource.BackgroundColor = SystemColors.ButtonHighlight;
            g_dataGritSource.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            g_dataGritSource.Dock = DockStyle.Fill;
            g_dataGritSource.Location = new Point(0, 0);
            g_dataGritSource.Name = "g_dataGritSource";
            g_dataGritSource.ReadOnly = true;
            g_dataGritSource.RowTemplate.Height = 25;
            g_dataGritSource.Size = new Size(800, 397);
            g_dataGritSource.TabIndex = 0;
            g_dataGritSource.CellContentDoubleClick += g_dataGritSource_CellContentDoubleClick;
            // 
            // ConfigUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ConfigUser";
            Text = "ConfigUser";
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)g_dataGritSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox tb_user;
        private Button btn_search;
        private Button btn_addnew;
        private DataGridView g_dataGritSource;
        private Label label1;
    }
}