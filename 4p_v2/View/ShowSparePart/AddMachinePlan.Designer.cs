namespace GiamSat.View
{
    partial class AddMachinePlan
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
            cb_machineName = new ComboBox();
            tb_machineCode = new TextBox();
            tb_line = new TextBox();
            label7 = new Label();
            label8 = new Label();
            dateTimePicker_Maintenance = new DateTimePicker();
            dateTimePicker_latest = new DateTimePicker();
            label6 = new Label();
            tb_cycle = new TextBox();
            lb_Item = new Label();
            label10 = new Label();
            tb_item = new TextBox();
            tb_status = new TextBox();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.82229F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.17771F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(cb_machineName, 1, 0);
            tableLayoutPanel1.Controls.Add(tb_machineCode, 1, 1);
            tableLayoutPanel1.Controls.Add(tb_line, 1, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 7);
            tableLayoutPanel1.Controls.Add(dateTimePicker_Maintenance, 1, 7);
            tableLayoutPanel1.Controls.Add(dateTimePicker_latest, 1, 6);
            tableLayoutPanel1.Controls.Add(label6, 0, 5);
            tableLayoutPanel1.Controls.Add(tb_cycle, 1, 5);
            tableLayoutPanel1.Controls.Add(lb_Item, 0, 3);
            tableLayoutPanel1.Controls.Add(label10, 0, 4);
            tableLayoutPanel1.Controls.Add(tb_item, 1, 3);
            tableLayoutPanel1.Controls.Add(tb_status, 1, 4);
            tableLayoutPanel1.Location = new Point(0, 12);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Size = new Size(940, 284);
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
            label1.Size = new Size(168, 35);
            label1.TabIndex = 0;
            label1.Text = "Machine name";
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
            label2.Size = new Size(168, 35);
            label2.TabIndex = 0;
            label2.Text = "Machine code";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 70);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(168, 35);
            label5.TabIndex = 1;
            label5.Text = "Line";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_machineName
            // 
            cb_machineName.Dock = DockStyle.Fill;
            cb_machineName.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_machineName.FormattingEnabled = true;
            cb_machineName.Location = new Point(179, 3);
            cb_machineName.Name = "cb_machineName";
            cb_machineName.Size = new Size(758, 23);
            cb_machineName.TabIndex = 6;
            cb_machineName.SelectedIndexChanged += cb_machineName_SelectedIndexChanged;
            // 
            // tb_machineCode
            // 
            tb_machineCode.Dock = DockStyle.Fill;
            tb_machineCode.Location = new Point(179, 38);
            tb_machineCode.Name = "tb_machineCode";
            tb_machineCode.ReadOnly = true;
            tb_machineCode.Size = new Size(758, 23);
            tb_machineCode.TabIndex = 7;
            // 
            // tb_line
            // 
            tb_line.Dock = DockStyle.Fill;
            tb_line.Location = new Point(179, 73);
            tb_line.Name = "tb_line";
            tb_line.ReadOnly = true;
            tb_line.Size = new Size(758, 23);
            tb_line.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(4, 210);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(168, 35);
            label7.TabIndex = 5;
            label7.Text = "Time start";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(4, 245);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(168, 39);
            label8.TabIndex = 5;
            label8.Text = "Time Maintenance";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Click += label7_Click;
            // 
            // dateTimePicker_Maintenance
            // 
            dateTimePicker_Maintenance.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker_Maintenance.CustomFormat = "dd-MM-yyyy";
            dateTimePicker_Maintenance.Dock = DockStyle.Fill;
            dateTimePicker_Maintenance.Enabled = false;
            dateTimePicker_Maintenance.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Maintenance.Location = new Point(179, 248);
            dateTimePicker_Maintenance.Name = "dateTimePicker_Maintenance";
            dateTimePicker_Maintenance.Size = new Size(758, 23);
            dateTimePicker_Maintenance.TabIndex = 13;
            // 
            // dateTimePicker_latest
            // 
            dateTimePicker_latest.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            dateTimePicker_latest.CustomFormat = "dd-MM-yyyy";
            dateTimePicker_latest.Dock = DockStyle.Fill;
            dateTimePicker_latest.Format = DateTimePickerFormat.Custom;
            dateTimePicker_latest.Location = new Point(179, 213);
            dateTimePicker_latest.Name = "dateTimePicker_latest";
            dateTimePicker_latest.Size = new Size(758, 23);
            dateTimePicker_latest.TabIndex = 13;
            dateTimePicker_latest.ValueChanged += dateTimePicker_latest_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(4, 175);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(168, 35);
            label6.TabIndex = 2;
            label6.Text = "Cycle";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            label6.Click += label6_Click;
            // 
            // tb_cycle
            // 
            tb_cycle.Dock = DockStyle.Fill;
            tb_cycle.Location = new Point(179, 178);
            tb_cycle.MaxLength = 3;
            tb_cycle.Name = "tb_cycle";
            tb_cycle.Size = new Size(758, 23);
            tb_cycle.TabIndex = 9;
            tb_cycle.TextChanged += tb_cycle_TextChanged;
            tb_cycle.KeyPress += tb_cycle_KeyPress;
            // 
            // lb_Item
            // 
            lb_Item.AutoSize = true;
            lb_Item.Dock = DockStyle.Fill;
            lb_Item.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_Item.Location = new Point(4, 105);
            lb_Item.Margin = new Padding(4, 0, 4, 0);
            lb_Item.Name = "lb_Item";
            lb_Item.Size = new Size(168, 35);
            lb_Item.TabIndex = 2;
            lb_Item.Text = "Item";
            lb_Item.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(4, 140);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(168, 35);
            label10.TabIndex = 2;
            label10.Text = "Status";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Click += label6_Click;
            // 
            // tb_item
            // 
            tb_item.Dock = DockStyle.Fill;
            tb_item.Location = new Point(179, 108);
            tb_item.Name = "tb_item";
            tb_item.Size = new Size(758, 23);
            tb_item.TabIndex = 14;
            // 
            // tb_status
            // 
            tb_status.Dock = DockStyle.Fill;
            tb_status.Location = new Point(179, 143);
            tb_status.Name = "tb_status";
            tb_status.Size = new Size(758, 23);
            tb_status.TabIndex = 14;
            tb_status.Text = "OK";
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
            btn_save.Size = new Size(326, 44);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(338, 3);
            btn_cancel.Margin = new Padding(4, 3, 4, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(294, 44);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_delete
            // 
            btn_delete.Enabled = false;
            btn_delete.Location = new Point(640, 3);
            btn_delete.Margin = new Padding(4, 3, 4, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(292, 44);
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
            flowLayoutPanel1.Location = new Point(4, 302);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(936, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // AddMachinePlan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 373);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddMachinePlan";
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
        private TextBox tb_cycle;
        private DateTimePicker dateTimePicker_latest;
        private Label label8;
        private DateTimePicker dateTimePicker_Maintenance;
        private Label lb_Item;
        private Label label10;
        private TextBox tb_item;
        private TextBox tb_status;
    }
}