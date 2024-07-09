namespace GiamSat.viewDb
{
    partial class SearchDb
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
            dataGridView1 = new DataGridView();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            tb_MachineSearch = new TextBox();
            label1 = new Label();
            btn_searchMachine = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label3 = new Label();
            tb_historySearch = new TextBox();
            label4 = new Label();
            dateTime_SearchFirst = new DateTimePicker();
            label5 = new Label();
            dateTime_SearchSecond = new DateTimePicker();
            btn_searchHistory = new Button();
            btn_searchforReport = new Button();
            panel3 = new Panel();
            btn_addNew = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4, 3, 4, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1321, 633);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(tb_MachineSearch);
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Controls.Add(btn_searchMachine);
            flowLayoutPanel1.Controls.Add(btn_addNew);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(4, 3);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(832, 44);
            flowLayoutPanel1.TabIndex = 10;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 39);
            label2.TabIndex = 11;
            label2.Text = "Device data";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_MachineSearch
            // 
            tb_MachineSearch.Dock = DockStyle.Fill;
            tb_MachineSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tb_MachineSearch.Location = new Point(110, 3);
            tb_MachineSearch.Margin = new Padding(4, 3, 4, 3);
            tb_MachineSearch.Multiline = true;
            tb_MachineSearch.Name = "tb_MachineSearch";
            tb_MachineSearch.Size = new Size(220, 33);
            tb_MachineSearch.TabIndex = 0;
            tb_MachineSearch.TextChanged += tb_deviceID_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(337, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 10;
            // 
            // btn_searchMachine
            // 
            btn_searchMachine.Location = new Point(344, 3);
            btn_searchMachine.Margin = new Padding(4, 3, 4, 3);
            btn_searchMachine.Name = "btn_searchMachine";
            btn_searchMachine.Size = new Size(104, 33);
            btn_searchMachine.TabIndex = 4;
            btn_searchMachine.Text = "Search";
            btn_searchMachine.UseVisualStyleBackColor = true;
            btn_searchMachine.Click += btn_search_Click;
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1321, 22);
            panel1.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Controls.Add(tableLayoutPanel1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 22);
            panel2.Margin = new Padding(4, 3, 4, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1321, 98);
            panel2.TabIndex = 12;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.588192F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.411808F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            tableLayoutPanel1.Size = new Size(1321, 98);
            tableLayoutPanel1.TabIndex = 11;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel3.Controls.Add(label3);
            flowLayoutPanel3.Controls.Add(tb_historySearch);
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(dateTime_SearchFirst);
            flowLayoutPanel3.Controls.Add(label5);
            flowLayoutPanel3.Controls.Add(dateTime_SearchSecond);
            flowLayoutPanel3.Controls.Add(btn_searchHistory);
            flowLayoutPanel3.Controls.Add(btn_searchforReport);
            flowLayoutPanel3.Dock = DockStyle.Top;
            flowLayoutPanel3.Location = new Point(3, 53);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(834, 42);
            flowLayoutPanel3.TabIndex = 12;
            // 
            // label3
            // 
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 35);
            label3.TabIndex = 11;
            label3.Text = "Status data";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_historySearch
            // 
            tb_historySearch.Dock = DockStyle.Fill;
            tb_historySearch.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tb_historySearch.Location = new Point(110, 3);
            tb_historySearch.Multiline = true;
            tb_historySearch.Name = "tb_historySearch";
            tb_historySearch.Size = new Size(160, 29);
            tb_historySearch.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(276, 0);
            label4.Name = "label4";
            label4.Size = new Size(43, 35);
            label4.TabIndex = 12;
            label4.Text = "From";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTime_SearchFirst
            // 
            dateTime_SearchFirst.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dateTime_SearchFirst.CustomFormat = "yyyy-MM-dd";
            dateTime_SearchFirst.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTime_SearchFirst.Format = DateTimePickerFormat.Custom;
            dateTime_SearchFirst.Location = new Point(325, 3);
            dateTime_SearchFirst.Name = "dateTime_SearchFirst";
            dateTime_SearchFirst.RightToLeft = RightToLeft.Yes;
            dateTime_SearchFirst.Size = new Size(110, 29);
            dateTime_SearchFirst.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(441, 0);
            label5.Name = "label5";
            label5.Size = new Size(25, 35);
            label5.TabIndex = 12;
            label5.Text = "To";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dateTime_SearchSecond
            // 
            dateTime_SearchSecond.CustomFormat = "yyyy-MM-dd";
            dateTime_SearchSecond.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTime_SearchSecond.Format = DateTimePickerFormat.Custom;
            dateTime_SearchSecond.Location = new Point(472, 3);
            dateTime_SearchSecond.Name = "dateTime_SearchSecond";
            dateTime_SearchSecond.Size = new Size(107, 29);
            dateTime_SearchSecond.TabIndex = 11;
            // 
            // btn_searchHistory
            // 
            btn_searchHistory.Dock = DockStyle.Fill;
            btn_searchHistory.Location = new Point(586, 3);
            btn_searchHistory.Margin = new Padding(4, 3, 4, 3);
            btn_searchHistory.Name = "btn_searchHistory";
            btn_searchHistory.Size = new Size(85, 29);
            btn_searchHistory.TabIndex = 4;
            btn_searchHistory.Text = "Search status";
            btn_searchHistory.UseVisualStyleBackColor = true;
            btn_searchHistory.Click += btn_searchHistory_Click;
            // 
            // btn_searchforReport
            // 
            btn_searchforReport.Dock = DockStyle.Fill;
            btn_searchforReport.Location = new Point(679, 3);
            btn_searchforReport.Margin = new Padding(4, 3, 4, 3);
            btn_searchforReport.Name = "btn_searchforReport";
            btn_searchforReport.Size = new Size(107, 29);
            btn_searchforReport.TabIndex = 4;
            btn_searchforReport.Text = "Search for report";
            btn_searchforReport.UseVisualStyleBackColor = true;
            btn_searchforReport.Click += button2_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 120);
            panel3.Margin = new Padding(4, 3, 4, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1321, 633);
            panel3.TabIndex = 13;
            // 
            // btn_addNew
            // 
            btn_addNew.Dock = DockStyle.Fill;
            btn_addNew.Location = new Point(455, 3);
            btn_addNew.Name = "btn_addNew";
            btn_addNew.Size = new Size(75, 33);
            btn_addNew.TabIndex = 12;
            btn_addNew.Text = "Add new";
            btn_addNew.UseVisualStyleBackColor = true;
            btn_addNew.Click += btn_addNew_Click;
            // 
            // SearchDb
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1321, 753);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "SearchDb";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Device data and reports";
            WindowState = FormWindowState.Maximized;
            FormClosing += SearchDb_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel2.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox tb_MachineSearch;
        private System.Windows.Forms.Button btn_searchMachine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label3;
        private TextBox tb_historySearch;
        private Button btn_searchHistory;
        private DateTimePicker dateTime_SearchFirst;
        private DateTimePicker dateTime_SearchSecond;
        private Label label4;
        private Label label5;
        private Button btn_searchforReport;
        private Button btn_addNew;
    }
}