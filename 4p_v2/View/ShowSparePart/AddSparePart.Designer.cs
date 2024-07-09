namespace GiamSat.View
{
    partial class AddSparePart
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
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label12 = new Label();
            tb_line = new TextBox();
            tb_SPCode = new TextBox();
            tb_SPName = new TextBox();
            tb_SN = new TextBox();
            dateTimePicker = new DateTimePicker();
            tb_number = new TextBox();
            tb_cycle = new TextBox();
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
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.8222923F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.17771F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(cb_machineName, 1, 0);
            tableLayoutPanel1.Controls.Add(tb_machineCode, 1, 1);
            tableLayoutPanel1.Controls.Add(label7, 0, 4);
            tableLayoutPanel1.Controls.Add(label8, 0, 5);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(label10, 0, 7);
            tableLayoutPanel1.Controls.Add(label12, 0, 8);
            tableLayoutPanel1.Controls.Add(tb_line, 1, 2);
            tableLayoutPanel1.Controls.Add(tb_SPCode, 1, 3);
            tableLayoutPanel1.Controls.Add(tb_SPName, 1, 4);
            tableLayoutPanel1.Controls.Add(tb_SN, 1, 5);
            tableLayoutPanel1.Controls.Add(dateTimePicker, 1, 6);
            tableLayoutPanel1.Controls.Add(tb_number, 1, 7);
            tableLayoutPanel1.Controls.Add(tb_cycle, 1, 8);
            tableLayoutPanel1.Location = new Point(0, 1);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 9;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.60241F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.39759F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanel1.Size = new Size(951, 306);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
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
            label1.Size = new Size(171, 46);
            label1.TabIndex = 0;
            label1.Text = "Machine name";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 46);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(171, 44);
            label2.TabIndex = 0;
            label2.Text = "Machine code";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 90);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(171, 29);
            label5.TabIndex = 1;
            label5.Text = "Line position";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(4, 119);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(171, 30);
            label6.TabIndex = 2;
            label6.Text = "Spare part code";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cb_machineName
            // 
            cb_machineName.Dock = DockStyle.Fill;
            cb_machineName.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_machineName.FormattingEnabled = true;
            cb_machineName.Location = new Point(182, 3);
            cb_machineName.Name = "cb_machineName";
            cb_machineName.Size = new Size(766, 23);
            cb_machineName.TabIndex = 6;
            cb_machineName.SelectedIndexChanged += cb_machineName_SelectedIndexChanged;
            // 
            // tb_machineCode
            // 
            tb_machineCode.Dock = DockStyle.Fill;
            tb_machineCode.Location = new Point(182, 49);
            tb_machineCode.Name = "tb_machineCode";
            tb_machineCode.ReadOnly = true;
            tb_machineCode.Size = new Size(766, 23);
            tb_machineCode.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(4, 149);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(171, 30);
            label7.TabIndex = 5;
            label7.Text = "Spare part name";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            label7.Click += label7_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(4, 179);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(171, 30);
            label8.TabIndex = 5;
            label8.Text = "Seri number";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            label8.Click += label7_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(4, 209);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(171, 32);
            label9.TabIndex = 5;
            label9.Text = "Replacement Date";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            label9.Click += label7_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(4, 241);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(171, 32);
            label10.TabIndex = 5;
            label10.Text = "Number of stock";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            label10.Click += label7_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Dock = DockStyle.Fill;
            label12.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(4, 273);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(171, 33);
            label12.TabIndex = 9;
            label12.Text = "Cycle";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tb_line
            // 
            tb_line.Dock = DockStyle.Fill;
            tb_line.Location = new Point(182, 93);
            tb_line.Name = "tb_line";
            tb_line.ReadOnly = true;
            tb_line.Size = new Size(766, 23);
            tb_line.TabIndex = 8;
            // 
            // tb_SPCode
            // 
            tb_SPCode.Dock = DockStyle.Fill;
            tb_SPCode.Location = new Point(182, 122);
            tb_SPCode.Name = "tb_SPCode";
            tb_SPCode.Size = new Size(766, 23);
            tb_SPCode.TabIndex = 10;
            // 
            // tb_SPName
            // 
            tb_SPName.Dock = DockStyle.Fill;
            tb_SPName.Location = new Point(182, 152);
            tb_SPName.Name = "tb_SPName";
            tb_SPName.Size = new Size(766, 23);
            tb_SPName.TabIndex = 11;
            // 
            // tb_SN
            // 
            tb_SN.Dock = DockStyle.Fill;
            tb_SN.Location = new Point(182, 182);
            tb_SN.Name = "tb_SN";
            tb_SN.Size = new Size(766, 23);
            tb_SN.TabIndex = 12;
            // 
            // dateTimePicker
            // 
            dateTimePicker.CustomFormat = "dd-MM-yyyy";
            dateTimePicker.Dock = DockStyle.Fill;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.Location = new Point(182, 212);
            dateTimePicker.Name = "dateTimePicker";
            dateTimePicker.Size = new Size(766, 23);
            dateTimePicker.TabIndex = 13;
            // 
            // tb_number
            // 
            tb_number.Dock = DockStyle.Fill;
            tb_number.Location = new Point(182, 244);
            tb_number.MaxLength = 10;
            tb_number.Name = "tb_number";
            tb_number.Size = new Size(766, 23);
            tb_number.TabIndex = 14;
            tb_number.KeyPress += tb_number_KeyPress;
            // 
            // tb_cycle
            // 
            tb_cycle.Dock = DockStyle.Fill;
            tb_cycle.Location = new Point(182, 276);
            tb_cycle.MaxLength = 10;
            tb_cycle.Name = "tb_cycle";
            tb_cycle.Size = new Size(766, 23);
            tb_cycle.TabIndex = 15;
            tb_cycle.KeyPress += tb_cycle_KeyPress;
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
            flowLayoutPanel1.Location = new Point(0, 313);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(947, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // AddSparePart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(947, 376);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "AddSparePart";
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
        private Label label8;
        private Label label9;
        private Label label11;
        private Label label10;
        private Label label12;
        private TextBox tb_SPCode;
        private TextBox tb_SPName;
        private TextBox tb_SN;
        private DateTimePicker dateTimePicker;
        private TextBox tb_number;
        private TextBox tb_cycle;
    }
}