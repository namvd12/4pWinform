namespace GiamSat.View.ShowReporting
{
    partial class VisualReporting
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            mySqlCommand2 = new MySql.Data.MySqlClient.MySqlCommand();
            panel4 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            cartesianChart1 = new LiveCharts.WinForms.CartesianChart();
            lb_title = new Label();
            tbLayout_Search = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            dateTime_To = new DateTimePicker();
            button1 = new Button();
            label1 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            cb_week = new ComboBox();
            btn_seachWeek = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            cb_month = new ComboBox();
            btn_searchMonth = new Button();
            lb_month = new Label();
            label4 = new Label();
            menuStrip1 = new MenuStrip();
            menu_allLine = new ToolStripMenuItem();
            Menu_eachLine = new ToolStripMenuItem();
            Menu_MTTR = new ToolStripMenuItem();
            Menu_MTBF = new ToolStripMenuItem();
            tableLayoutPanel1 = new TableLayoutPanel();
            tbLayout_colorLine = new TableLayoutPanel();
            tb_line1 = new TextBox();
            tb_line2 = new TextBox();
            tb_line3 = new TextBox();
            tb_line4 = new TextBox();
            tb_line5 = new TextBox();
            tb_line6 = new TextBox();
            tb_line7 = new TextBox();
            tb_line8 = new TextBox();
            tb_line9 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            panel1 = new Panel();
            panel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tbLayout_Search.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tbLayout_colorLine.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // mySqlCommand2
            // 
            mySqlCommand2.CacheAge = 0;
            mySqlCommand2.Connection = null;
            mySqlCommand2.EnableCaching = false;
            mySqlCommand2.Transaction = null;
            // 
            // panel4
            // 
            panel4.Controls.Add(tableLayoutPanel2);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(1370, 709);
            panel4.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(cartesianChart1, 0, 3);
            tableLayoutPanel2.Controls.Add(lb_title, 0, 1);
            tableLayoutPanel2.Controls.Add(tbLayout_Search, 0, 0);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel1, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 15.336463F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 4.69483566F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 23.16119F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 56.6510162F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1370, 709);
            tableLayoutPanel2.TabIndex = 3;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Location = new Point(3, 308);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(1329, 343);
            cartesianChart1.TabIndex = 5;
            cartesianChart1.Text = "cartesianChart2";
            // 
            // lb_title
            // 
            lb_title.Dock = DockStyle.Fill;
            lb_title.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_title.Location = new Point(3, 108);
            lb_title.Name = "lb_title";
            lb_title.Size = new Size(1364, 33);
            lb_title.TabIndex = 0;
            lb_title.Text = "Title";
            lb_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbLayout_Search
            // 
            tbLayout_Search.ColumnCount = 3;
            tbLayout_Search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbLayout_Search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbLayout_Search.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tbLayout_Search.Controls.Add(flowLayoutPanel1, 0, 2);
            tbLayout_Search.Controls.Add(label1, 0, 1);
            tbLayout_Search.Controls.Add(flowLayoutPanel2, 1, 2);
            tbLayout_Search.Controls.Add(flowLayoutPanel3, 2, 2);
            tbLayout_Search.Controls.Add(lb_month, 2, 1);
            tbLayout_Search.Controls.Add(label4, 1, 1);
            tbLayout_Search.Controls.Add(menuStrip1, 0, 0);
            tbLayout_Search.Dock = DockStyle.Fill;
            tbLayout_Search.Location = new Point(3, 3);
            tbLayout_Search.Name = "tbLayout_Search";
            tbLayout_Search.RowCount = 3;
            tbLayout_Search.RowStyles.Add(new RowStyle(SizeType.Percent, 67.92453F));
            tbLayout_Search.RowStyles.Add(new RowStyle(SizeType.Percent, 32.07547F));
            tbLayout_Search.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tbLayout_Search.Size = new Size(1364, 102);
            tbLayout_Search.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(dateTime_To);
            flowLayoutPanel1.Controls.Add(button1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(3, 66);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(448, 33);
            flowLayoutPanel1.TabIndex = 1;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // dateTime_To
            // 
            dateTime_To.CalendarFont = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            dateTime_To.CustomFormat = "yyyy-MM-dd";
            dateTime_To.Dock = DockStyle.Fill;
            dateTime_To.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dateTime_To.Format = DateTimePickerFormat.Custom;
            dateTime_To.Location = new Point(3, 3);
            dateTime_To.Name = "dateTime_To";
            dateTime_To.Size = new Size(107, 23);
            dateTime_To.TabIndex = 13;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Dock = DockStyle.Fill;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(116, 3);
            button1.Name = "button1";
            button1.Size = new Size(107, 25);
            button1.TabIndex = 14;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 43);
            label1.Name = "label1";
            label1.Size = new Size(448, 20);
            label1.TabIndex = 0;
            label1.Text = "Date";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel2.Controls.Add(cb_week);
            flowLayoutPanel2.Controls.Add(btn_seachWeek);
            flowLayoutPanel2.Dock = DockStyle.Fill;
            flowLayoutPanel2.Location = new Point(457, 66);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(448, 33);
            flowLayoutPanel2.TabIndex = 1;
            flowLayoutPanel2.Paint += flowLayoutPanel1_Paint;
            // 
            // cb_week
            // 
            cb_week.Dock = DockStyle.Fill;
            cb_week.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_week.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cb_week.FormattingEnabled = true;
            cb_week.Items.AddRange(new object[] { "W1", "W2", "W3", "W4", "W5", "W6", "W7", "W8", "W9", "W10", "W11", "W12", "W13", "W14", "W15", "W16", "W17", "W18", "W19", "W20", "W21", "W22", "W23", "W24", "W25", "W26", "W27", "W28", "W29", "W30", "W31", "W32", "W33", "W34", "W35", "W36", "W37", "W38", "W39", "W40", "W41", "W42", "W43", "W44", "W45", "W46", "W47", "W48", "W49", "W50", "W51", "W52" });
            cb_week.Location = new Point(3, 3);
            cb_week.Name = "cb_week";
            cb_week.Size = new Size(121, 23);
            cb_week.TabIndex = 15;
            // 
            // btn_seachWeek
            // 
            btn_seachWeek.AutoSize = true;
            btn_seachWeek.Dock = DockStyle.Fill;
            btn_seachWeek.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_seachWeek.Location = new Point(130, 3);
            btn_seachWeek.Name = "btn_seachWeek";
            btn_seachWeek.Size = new Size(107, 25);
            btn_seachWeek.TabIndex = 14;
            btn_seachWeek.Text = "Search";
            btn_seachWeek.UseVisualStyleBackColor = true;
            btn_seachWeek.Click += button2_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel3.Controls.Add(cb_month);
            flowLayoutPanel3.Controls.Add(btn_searchMonth);
            flowLayoutPanel3.Dock = DockStyle.Fill;
            flowLayoutPanel3.Location = new Point(911, 66);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(450, 33);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // cb_month
            // 
            cb_month.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_month.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            cb_month.FormattingEnabled = true;
            cb_month.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            cb_month.Location = new Point(3, 3);
            cb_month.Name = "cb_month";
            cb_month.Size = new Size(121, 23);
            cb_month.TabIndex = 0;
            // 
            // btn_searchMonth
            // 
            btn_searchMonth.AutoSize = true;
            btn_searchMonth.Dock = DockStyle.Fill;
            btn_searchMonth.Location = new Point(130, 3);
            btn_searchMonth.Name = "btn_searchMonth";
            btn_searchMonth.Size = new Size(104, 25);
            btn_searchMonth.TabIndex = 1;
            btn_searchMonth.Text = "Search";
            btn_searchMonth.UseVisualStyleBackColor = true;
            btn_searchMonth.Click += button3_Click;
            // 
            // lb_month
            // 
            lb_month.AutoSize = true;
            lb_month.Dock = DockStyle.Fill;
            lb_month.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lb_month.Location = new Point(911, 43);
            lb_month.Name = "lb_month";
            lb_month.Size = new Size(450, 20);
            lb_month.TabIndex = 2;
            lb_month.Text = "Month";
            lb_month.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(457, 43);
            label4.Name = "label4";
            label4.Size = new Size(448, 20);
            label4.TabIndex = 0;
            label4.Text = "Week";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.Fill;
            menuStrip1.Items.AddRange(new ToolStripItem[] { menu_allLine, Menu_eachLine, Menu_MTTR, Menu_MTBF });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(454, 43);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // menu_allLine
            // 
            menu_allLine.BackColor = SystemColors.Control;
            menu_allLine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menu_allLine.ForeColor = Color.DimGray;
            menu_allLine.ImageTransparentColor = Color.White;
            menu_allLine.Name = "menu_allLine";
            menu_allLine.Size = new Size(73, 39);
            menu_allLine.Text = "All Line";
            menu_allLine.Click += menu_allLine_Click;
            // 
            // Menu_eachLine
            // 
            Menu_eachLine.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Menu_eachLine.ForeColor = SystemColors.ControlDarkDark;
            Menu_eachLine.Name = "Menu_eachLine";
            Menu_eachLine.Size = new Size(87, 39);
            Menu_eachLine.Text = "Each Line";
            Menu_eachLine.Click += Menu_eachLine_Click;
            // 
            // Menu_MTTR
            // 
            Menu_MTTR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Menu_MTTR.ForeColor = SystemColors.ControlDarkDark;
            Menu_MTTR.Name = "Menu_MTTR";
            Menu_MTTR.Size = new Size(62, 39);
            Menu_MTTR.Text = "MTTR";
            Menu_MTTR.Click += Menu_MTTR_Click;
            // 
            // Menu_MTBF
            // 
            Menu_MTBF.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Menu_MTBF.ForeColor = SystemColors.ControlDarkDark;
            Menu_MTBF.Name = "Menu_MTBF";
            Menu_MTBF.Size = new Size(61, 39);
            Menu_MTBF.Text = "MTBF";
            Menu_MTBF.Click += Menu_MTBF_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.94276F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.0572357F));
            tableLayoutPanel1.Controls.Add(tbLayout_colorLine, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 144);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1364, 158);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // tbLayout_colorLine
            // 
            tbLayout_colorLine.ColumnCount = 4;
            tbLayout_colorLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tbLayout_colorLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tbLayout_colorLine.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.Controls.Add(tb_line1, 0, 0);
            tbLayout_colorLine.Controls.Add(tb_line2, 0, 1);
            tbLayout_colorLine.Controls.Add(tb_line3, 0, 2);
            tbLayout_colorLine.Controls.Add(tb_line4, 0, 3);
            tbLayout_colorLine.Controls.Add(tb_line5, 0, 4);
            tbLayout_colorLine.Controls.Add(tb_line6, 2, 0);
            tbLayout_colorLine.Controls.Add(tb_line7, 2, 1);
            tbLayout_colorLine.Controls.Add(tb_line8, 2, 2);
            tbLayout_colorLine.Controls.Add(tb_line9, 2, 3);
            tbLayout_colorLine.Controls.Add(label2, 1, 0);
            tbLayout_colorLine.Controls.Add(label3, 1, 1);
            tbLayout_colorLine.Controls.Add(label5, 1, 2);
            tbLayout_colorLine.Controls.Add(label6, 1, 3);
            tbLayout_colorLine.Controls.Add(label7, 1, 4);
            tbLayout_colorLine.Controls.Add(label8, 3, 0);
            tbLayout_colorLine.Controls.Add(label9, 3, 1);
            tbLayout_colorLine.Controls.Add(label10, 3, 2);
            tbLayout_colorLine.Controls.Add(label11, 3, 3);
            tbLayout_colorLine.Dock = DockStyle.Fill;
            tbLayout_colorLine.Location = new Point(3, 3);
            tbLayout_colorLine.Name = "tbLayout_colorLine";
            tbLayout_colorLine.RowCount = 5;
            tbLayout_colorLine.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tbLayout_colorLine.Size = new Size(484, 152);
            tbLayout_colorLine.TabIndex = 2;
            // 
            // tb_line1
            // 
            tb_line1.Dock = DockStyle.Fill;
            tb_line1.Location = new Point(3, 3);
            tb_line1.Name = "tb_line1";
            tb_line1.Size = new Size(139, 23);
            tb_line1.TabIndex = 0;
            // 
            // tb_line2
            // 
            tb_line2.Dock = DockStyle.Fill;
            tb_line2.Location = new Point(3, 33);
            tb_line2.Name = "tb_line2";
            tb_line2.Size = new Size(139, 23);
            tb_line2.TabIndex = 0;
            // 
            // tb_line3
            // 
            tb_line3.Dock = DockStyle.Fill;
            tb_line3.Location = new Point(3, 63);
            tb_line3.Name = "tb_line3";
            tb_line3.Size = new Size(139, 23);
            tb_line3.TabIndex = 0;
            // 
            // tb_line4
            // 
            tb_line4.Dock = DockStyle.Fill;
            tb_line4.Location = new Point(3, 93);
            tb_line4.Name = "tb_line4";
            tb_line4.Size = new Size(139, 23);
            tb_line4.TabIndex = 0;
            // 
            // tb_line5
            // 
            tb_line5.Dock = DockStyle.Fill;
            tb_line5.Location = new Point(3, 123);
            tb_line5.Name = "tb_line5";
            tb_line5.Size = new Size(139, 23);
            tb_line5.TabIndex = 0;
            // 
            // tb_line6
            // 
            tb_line6.Dock = DockStyle.Fill;
            tb_line6.Location = new Point(244, 3);
            tb_line6.Name = "tb_line6";
            tb_line6.Size = new Size(139, 23);
            tb_line6.TabIndex = 0;
            // 
            // tb_line7
            // 
            tb_line7.Dock = DockStyle.Fill;
            tb_line7.Location = new Point(244, 33);
            tb_line7.Name = "tb_line7";
            tb_line7.Size = new Size(139, 23);
            tb_line7.TabIndex = 0;
            // 
            // tb_line8
            // 
            tb_line8.Dock = DockStyle.Fill;
            tb_line8.Location = new Point(244, 63);
            tb_line8.Name = "tb_line8";
            tb_line8.Size = new Size(139, 23);
            tb_line8.TabIndex = 0;
            // 
            // tb_line9
            // 
            tb_line9.Dock = DockStyle.Fill;
            tb_line9.Location = new Point(244, 93);
            tb_line9.Name = "tb_line9";
            tb_line9.Size = new Size(139, 23);
            tb_line9.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(148, 0);
            label2.Name = "label2";
            label2.Size = new Size(24, 15);
            label2.TabIndex = 1;
            label2.Text = "LTE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(148, 30);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 1;
            label3.Text = "Line 1";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(148, 60);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 1;
            label5.Text = "Line 2";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(148, 90);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 1;
            label6.Text = "Line 3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(148, 120);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 1;
            label7.Text = "Line 4";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(389, 0);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 1;
            label8.Text = "Line 5";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(389, 30);
            label9.Name = "label9";
            label9.Size = new Size(38, 15);
            label9.TabIndex = 1;
            label9.Text = "Line 6";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(389, 60);
            label10.Name = "label10";
            label10.Size = new Size(38, 15);
            label10.TabIndex = 1;
            label10.Text = "Line 7";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(389, 90);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 1;
            label11.Text = "Line 8";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 709);
            panel1.TabIndex = 1;
            // 
            // VisualReporting
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 709);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "VisualReporting";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Visual Reporting";
            Load += VisualReporting_Load;
            panel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tbLayout_Search.ResumeLayout(false);
            tbLayout_Search.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tbLayout_colorLine.ResumeLayout(false);
            tbLayout_colorLine.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand2;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lb_title;
        private TableLayoutPanel tbLayout_Search;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private DateTimePicker dateTime_To;
        private Button button1;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel2;
        private ComboBox cb_week;
        private Button btn_seachWeek;
        private Label lb_month;
        private FlowLayoutPanel flowLayoutPanel3;
        private ComboBox cb_month;
        private Button btn_searchMonth;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tbLayout_colorLine;
        private TextBox tb_line1;
        private TextBox tb_line2;
        private TextBox tb_line3;
        private TextBox tb_line4;
        private TextBox tb_line5;
        private TextBox tb_line6;
        private TextBox tb_line7;
        private TextBox tb_line8;
        private TextBox tb_line9;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private LiveCharts.WinForms.CartesianChart cartesianChart1;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel4;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menu_allLine;
        private ToolStripMenuItem Menu_eachLine;
        private ToolStripMenuItem Menu_MTTR;
        private ToolStripMenuItem Menu_MTBF;
    }
}