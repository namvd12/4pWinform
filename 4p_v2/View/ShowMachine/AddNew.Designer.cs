namespace GiamSat.View
{
    partial class AddNew
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
            tb_machineName = new TextBox();
            tb_machineCode = new TextBox();
            label6 = new Label();
            tb_lane = new TextBox();
            label5 = new Label();
            tb_line = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            tb_model = new TextBox();
            tb_serial = new TextBox();
            cb_topBot = new ComboBox();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.99472F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.00528F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(tb_machineName, 1, 1);
            tableLayoutPanel1.Controls.Add(tb_machineCode, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 6);
            tableLayoutPanel1.Controls.Add(tb_lane, 1, 6);
            tableLayoutPanel1.Controls.Add(label5, 0, 5);
            tableLayoutPanel1.Controls.Add(tb_line, 1, 5);
            tableLayoutPanel1.Controls.Add(label7, 0, 2);
            tableLayoutPanel1.Controls.Add(label8, 0, 3);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(tb_model, 1, 2);
            tableLayoutPanel1.Controls.Add(tb_serial, 1, 3);
            tableLayoutPanel1.Controls.Add(cb_topBot, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.125F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.875F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 33F));
            tableLayoutPanel1.Size = new Size(819, 235);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ImageAlign = ContentAlignment.TopLeft;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 35);
            label1.TabIndex = 0;
            label1.Text = "Machine code";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 35);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(114, 30);
            label2.TabIndex = 0;
            label2.Text = "Machine name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_machineName
            // 
            tb_machineName.Dock = DockStyle.Fill;
            tb_machineName.Location = new Point(126, 38);
            tb_machineName.Margin = new Padding(4, 3, 4, 3);
            tb_machineName.Multiline = true;
            tb_machineName.Name = "tb_machineName";
            tb_machineName.Size = new Size(689, 24);
            tb_machineName.TabIndex = 2;
            // 
            // tb_machineCode
            // 
            tb_machineCode.Dock = DockStyle.Fill;
            tb_machineCode.Location = new Point(126, 3);
            tb_machineCode.Margin = new Padding(4, 3, 4, 3);
            tb_machineCode.Multiline = true;
            tb_machineCode.Name = "tb_machineCode";
            tb_machineCode.ReadOnly = true;
            tb_machineCode.Size = new Size(689, 29);
            tb_machineCode.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(4, 201);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(114, 34);
            label6.TabIndex = 2;
            label6.Text = "Lane";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_lane
            // 
            tb_lane.Dock = DockStyle.Fill;
            tb_lane.Location = new Point(126, 204);
            tb_lane.Margin = new Padding(4, 3, 4, 3);
            tb_lane.Multiline = true;
            tb_lane.Name = "tb_lane";
            tb_lane.Size = new Size(689, 28);
            tb_lane.TabIndex = 4;
            tb_lane.KeyPress += tb_lane_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 167);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(114, 34);
            label5.TabIndex = 1;
            label5.Text = "Line";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_line
            // 
            tb_line.Dock = DockStyle.Fill;
            tb_line.Location = new Point(126, 170);
            tb_line.Margin = new Padding(4, 3, 4, 3);
            tb_line.Multiline = true;
            tb_line.Name = "tb_line";
            tb_line.Size = new Size(689, 28);
            tb_line.TabIndex = 3;
            tb_line.KeyPress += tb_line_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(4, 65);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(114, 33);
            label7.TabIndex = 1;
            label7.Text = "Model";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(4, 98);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(114, 35);
            label8.TabIndex = 1;
            label8.Text = "Serial";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(4, 133);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(114, 34);
            label9.TabIndex = 1;
            label9.Text = "Top/Bot";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_model
            // 
            tb_model.Dock = DockStyle.Fill;
            tb_model.Location = new Point(126, 68);
            tb_model.Margin = new Padding(4, 3, 4, 3);
            tb_model.Multiline = true;
            tb_model.Name = "tb_model";
            tb_model.Size = new Size(689, 27);
            tb_model.TabIndex = 3;
            // 
            // tb_serial
            // 
            tb_serial.Dock = DockStyle.Fill;
            tb_serial.Location = new Point(126, 101);
            tb_serial.Margin = new Padding(4, 3, 4, 3);
            tb_serial.Multiline = true;
            tb_serial.Name = "tb_serial";
            tb_serial.Size = new Size(689, 29);
            tb_serial.TabIndex = 3;
            // 
            // cb_topBot
            // 
            cb_topBot.Dock = DockStyle.Fill;
            cb_topBot.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_topBot.FormattingEnabled = true;
            cb_topBot.Items.AddRange(new object[] { "Top", "Bot" });
            cb_topBot.Location = new Point(125, 136);
            cb_topBot.Name = "cb_topBot";
            cb_topBot.Size = new Size(691, 23);
            cb_topBot.TabIndex = 5;
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
            btn_save.Size = new Size(271, 44);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(283, 3);
            btn_cancel.Margin = new Padding(4, 3, 4, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(278, 44);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_delete
            // 
            btn_delete.Enabled = false;
            btn_delete.Location = new Point(569, 3);
            btn_delete.Margin = new Padding(4, 3, 4, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(245, 44);
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
            flowLayoutPanel1.Location = new Point(0, 235);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(819, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // AddNew
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(819, 304);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddNew";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Device";
            Load += AddNew_Load;
            Enter += btn_save_Click;
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
        private System.Windows.Forms.TextBox tb_machineName;
        private System.Windows.Forms.TextBox tb_line;
        private System.Windows.Forms.TextBox tb_lane;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox tb_machineCode;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox tb_model;
        private TextBox tb_serial;
        private ComboBox cb_topBot;
    }
}