namespace GiamSat.View
{
    partial class AddItems
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label5 = new Label();
            label6 = new Label();
            cb_machineName = new ComboBox();
            tb_machineCode = new TextBox();
            tb_line = new TextBox();
            label7 = new Label();
            cb_addr = new ComboBox();
            cb_port = new ComboBox();
            label9 = new Label();
            tb_region = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            btn_save = new Button();
            btn_cancel = new Button();
            btn_delete = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.6308537F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 82.36915F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(cb_machineName, 1, 0);
            tableLayoutPanel1.Controls.Add(tb_machineCode, 1, 1);
            tableLayoutPanel1.Controls.Add(tb_line, 1, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 4);
            tableLayoutPanel1.Controls.Add(cb_addr, 1, 3);
            tableLayoutPanel1.Controls.Add(cb_port, 1, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 5);
            tableLayoutPanel1.Controls.Add(tb_region, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.20635F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.79365F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.Size = new Size(726, 211);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 31);
            label1.TabIndex = 0;
            label1.Text = "Machine name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 31);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(120, 32);
            label2.TabIndex = 0;
            label2.Text = "Machine code";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 63);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(120, 35);
            label5.TabIndex = 1;
            label5.Text = "Line";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(4, 98);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(120, 39);
            label6.TabIndex = 2;
            label6.Text = "Addr client";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_machineName
            // 
            cb_machineName.Dock = DockStyle.Fill;
            cb_machineName.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_machineName.FormattingEnabled = true;
            cb_machineName.Location = new Point(131, 3);
            cb_machineName.Name = "cb_machineName";
            cb_machineName.Size = new Size(592, 23);
            cb_machineName.TabIndex = 6;
            cb_machineName.SelectedIndexChanged += cb_machineName_SelectedIndexChanged;
            // 
            // tb_machineCode
            // 
            tb_machineCode.Dock = DockStyle.Fill;
            tb_machineCode.Location = new Point(131, 34);
            tb_machineCode.Name = "tb_machineCode";
            tb_machineCode.ReadOnly = true;
            tb_machineCode.Size = new Size(592, 23);
            tb_machineCode.TabIndex = 7;
            // 
            // tb_line
            // 
            tb_line.Dock = DockStyle.Fill;
            tb_line.Location = new Point(131, 66);
            tb_line.Name = "tb_line";
            tb_line.ReadOnly = true;
            tb_line.Size = new Size(592, 23);
            tb_line.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(4, 137);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(120, 38);
            label7.TabIndex = 5;
            label7.Text = "Port client";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_addr
            // 
            cb_addr.Dock = DockStyle.Fill;
            cb_addr.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_addr.FormattingEnabled = true;
            cb_addr.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30" });
            cb_addr.Location = new Point(131, 101);
            cb_addr.Name = "cb_addr";
            cb_addr.Size = new Size(592, 23);
            cb_addr.TabIndex = 9;
            cb_addr.KeyPress += cb_addr_KeyPress;
            // 
            // cb_port
            // 
            cb_port.Dock = DockStyle.Fill;
            cb_port.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_port.FormattingEnabled = true;
            cb_port.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8" });
            cb_port.Location = new Point(131, 140);
            cb_port.Name = "cb_port";
            cb_port.Size = new Size(592, 23);
            cb_port.TabIndex = 10;
            cb_port.KeyPress += cb_port_KeyPress;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(4, 175);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(120, 36);
            label9.TabIndex = 5;
            label9.Text = "Region";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_region
            // 
            tb_region.Dock = DockStyle.Fill;
            tb_region.DropDownStyle = ComboBoxStyle.DropDownList;
            tb_region.FormattingEnabled = true;
            tb_region.Items.AddRange(new object[] { "Region1", "Region2", "Region3", "Region4", "Region5", "Region6", "Region7", "Region8", "Region9", "Region10", "Region11", "Region12", "Region13", "Region14", "Region15" });
            tb_region.Location = new Point(131, 178);
            tb_region.Name = "tb_region";
            tb_region.Size = new Size(592, 23);
            tb_region.TabIndex = 10;
            tb_region.KeyPress += cb_port_KeyPress;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.10287F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.89713F));
            tableLayoutPanel2.Controls.Add(label3, 0, 0);
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 5;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(40, 20);
            label3.TabIndex = 0;
            label3.Text = "Machine code";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(3, 80);
            label4.Name = "label4";
            label4.Size = new Size(40, 80);
            label4.TabIndex = 0;
            label4.Text = "Machine name";
            // 
            // btn_save
            // 
            btn_save.Location = new Point(4, 3);
            btn_save.Margin = new Padding(4, 3, 4, 3);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(255, 44);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(267, 3);
            btn_cancel.Margin = new Padding(4, 3, 4, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(216, 44);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_delete
            // 
            btn_delete.Enabled = false;
            btn_delete.Location = new Point(491, 3);
            btn_delete.Margin = new Padding(4, 3, 4, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(228, 44);
            btn_delete.TabIndex = 6;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = true;
            btn_delete.Click += btn_delete_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btn_save);
            flowLayoutPanel1.Controls.Add(btn_cancel);
            flowLayoutPanel1.Controls.Add(btn_delete);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 211);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(726, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // AddItems
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 274);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddItems";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddNew";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private ComboBox cb_machineName;
        private TextBox tb_machineCode;
        private TextBox tb_line;
        private ComboBox cb_addr;
        private ComboBox cb_port;
        private Label label9;
        private ComboBox tb_region;
    }
}