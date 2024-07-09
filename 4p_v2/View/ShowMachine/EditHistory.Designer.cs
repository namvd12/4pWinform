namespace GiamSat.View
{
    partial class EditHistory
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
            tableLayoutPanel2 = new TableLayoutPanel();
            label3 = new Label();
            label4 = new Label();
            btn_save = new Button();
            btn_cancel = new Button();
            btn_exportPPT = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_viewRp = new Button();
            label10 = new Label();
            label8 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tb_deviceCode = new TextBox();
            tb_deviceName = new TextBox();
            tb_line = new TextBox();
            tb_TroubleName = new TextBox();
            tb_note1 = new TextBox();
            tb_note6 = new TextBox();
            pb_1 = new PictureBox();
            pb_6 = new PictureBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tb_note2 = new TextBox();
            tb_note3 = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            pb_3 = new PictureBox();
            pb_2 = new PictureBox();
            tableLayoutPanel5 = new TableLayoutPanel();
            tb_note4 = new TextBox();
            tb_note5 = new TextBox();
            tableLayoutPanel6 = new TableLayoutPanel();
            pb_4 = new PictureBox();
            pb_5 = new PictureBox();
            tableLayoutPanel7 = new TableLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_6).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_2).BeginInit();
            tableLayoutPanel5.SuspendLayout();
            tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pb_4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pb_5).BeginInit();
            tableLayoutPanel7.SuspendLayout();
            SuspendLayout();
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
            btn_save.Size = new Size(317, 44);
            btn_save.TabIndex = 4;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Location = new Point(329, 3);
            btn_cancel.Margin = new Padding(4, 3, 4, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(282, 44);
            btn_cancel.TabIndex = 5;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // btn_exportPPT
            // 
            btn_exportPPT.Enabled = false;
            btn_exportPPT.Location = new Point(619, 3);
            btn_exportPPT.Margin = new Padding(4, 3, 4, 3);
            btn_exportPPT.Name = "btn_exportPPT";
            btn_exportPPT.Size = new Size(250, 44);
            btn_exportPPT.TabIndex = 6;
            btn_exportPPT.Text = "Export data";
            btn_exportPPT.UseVisualStyleBackColor = true;
            btn_exportPPT.Click += btn_exportPPT_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.Controls.Add(btn_save);
            flowLayoutPanel1.Controls.Add(btn_cancel);
            flowLayoutPanel1.Controls.Add(btn_exportPPT);
            flowLayoutPanel1.Controls.Add(btn_viewRp);
            flowLayoutPanel1.Location = new Point(4, 677);
            flowLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1006, 50);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // btn_viewRp
            // 
            btn_viewRp.Dock = DockStyle.Fill;
            btn_viewRp.Enabled = false;
            btn_viewRp.Location = new Point(876, 3);
            btn_viewRp.Name = "btn_viewRp";
            btn_viewRp.Size = new Size(127, 44);
            btn_viewRp.TabIndex = 7;
            btn_viewRp.Text = "View report";
            btn_viewRp.UseVisualStyleBackColor = true;
            btn_viewRp.Click += btn_viewRp_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = DockStyle.Fill;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(4, 294);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(135, 139);
            label10.TabIndex = 2;
            label10.Text = "Checking";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = DockStyle.Fill;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(4, 572);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(135, 96);
            label8.TabIndex = 2;
            label8.Text = "Result";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = DockStyle.Fill;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(4, 433);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(135, 139);
            label9.TabIndex = 2;
            label9.Text = "Action";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(4, 201);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(135, 93);
            label7.TabIndex = 2;
            label7.Text = "Issue";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Dock = DockStyle.Fill;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(4, 108);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(135, 93);
            label6.TabIndex = 2;
            label6.Text = "Trouble name";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(4, 72);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(135, 36);
            label5.TabIndex = 1;
            label5.Text = "Line/Lane";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(4, 36);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(135, 36);
            label2.TabIndex = 0;
            label2.Text = "Device name";
            label2.TextAlign = ContentAlignment.MiddleLeft;
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
            label1.Size = new Size(135, 36);
            label1.TabIndex = 0;
            label1.Text = "Device code";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.29837F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.70163F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 279F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label5, 0, 2);
            tableLayoutPanel1.Controls.Add(label6, 0, 3);
            tableLayoutPanel1.Controls.Add(label7, 0, 4);
            tableLayoutPanel1.Controls.Add(label9, 0, 6);
            tableLayoutPanel1.Controls.Add(label8, 0, 7);
            tableLayoutPanel1.Controls.Add(label10, 0, 5);
            tableLayoutPanel1.Controls.Add(tb_deviceCode, 1, 0);
            tableLayoutPanel1.Controls.Add(tb_deviceName, 1, 1);
            tableLayoutPanel1.Controls.Add(tb_line, 1, 2);
            tableLayoutPanel1.Controls.Add(tb_TroubleName, 1, 3);
            tableLayoutPanel1.Controls.Add(tb_note1, 1, 4);
            tableLayoutPanel1.Controls.Add(tb_note6, 1, 7);
            tableLayoutPanel1.Controls.Add(pb_1, 2, 4);
            tableLayoutPanel1.Controls.Add(pb_6, 2, 7);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel4, 2, 5);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 1, 6);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel6, 2, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(4, 3);
            tableLayoutPanel1.Margin = new Padding(4, 3, 4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.46674442F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.46674347F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.46674347F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.9332943F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.9332943F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.89994F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.89994F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.9332943F));
            tableLayoutPanel1.Size = new Size(1065, 668);
            tableLayoutPanel1.TabIndex = 1;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // tb_deviceCode
            // 
            tb_deviceCode.Dock = DockStyle.Fill;
            tb_deviceCode.Location = new Point(146, 3);
            tb_deviceCode.Multiline = true;
            tb_deviceCode.Name = "tb_deviceCode";
            tb_deviceCode.ReadOnly = true;
            tb_deviceCode.Size = new Size(636, 30);
            tb_deviceCode.TabIndex = 0;
            // 
            // tb_deviceName
            // 
            tb_deviceName.Dock = DockStyle.Fill;
            tb_deviceName.Location = new Point(146, 39);
            tb_deviceName.Multiline = true;
            tb_deviceName.Name = "tb_deviceName";
            tb_deviceName.ReadOnly = true;
            tb_deviceName.Size = new Size(636, 30);
            tb_deviceName.TabIndex = 0;
            // 
            // tb_line
            // 
            tb_line.Dock = DockStyle.Fill;
            tb_line.Location = new Point(146, 75);
            tb_line.Multiline = true;
            tb_line.Name = "tb_line";
            tb_line.ReadOnly = true;
            tb_line.Size = new Size(636, 30);
            tb_line.TabIndex = 0;
            // 
            // tb_TroubleName
            // 
            tb_TroubleName.Dock = DockStyle.Fill;
            tb_TroubleName.Location = new Point(146, 111);
            tb_TroubleName.Multiline = true;
            tb_TroubleName.Name = "tb_TroubleName";
            tb_TroubleName.Size = new Size(636, 87);
            tb_TroubleName.TabIndex = 0;
            // 
            // tb_note1
            // 
            tb_note1.Dock = DockStyle.Fill;
            tb_note1.Location = new Point(146, 204);
            tb_note1.Multiline = true;
            tb_note1.Name = "tb_note1";
            tb_note1.Size = new Size(636, 87);
            tb_note1.TabIndex = 1;
            // 
            // tb_note6
            // 
            tb_note6.Dock = DockStyle.Fill;
            tb_note6.Location = new Point(146, 575);
            tb_note6.Multiline = true;
            tb_note6.Name = "tb_note6";
            tb_note6.Size = new Size(636, 90);
            tb_note6.TabIndex = 4;
            // 
            // pb_1
            // 
            pb_1.Dock = DockStyle.Fill;
            pb_1.Location = new Point(788, 204);
            pb_1.Name = "pb_1";
            pb_1.Size = new Size(274, 87);
            pb_1.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_1.TabIndex = 6;
            pb_1.TabStop = false;
            pb_1.MouseEnter += pb_1_MouseEnter;
            // 
            // pb_6
            // 
            pb_6.Dock = DockStyle.Fill;
            pb_6.Location = new Point(788, 575);
            pb_6.Name = "pb_6";
            pb_6.Size = new Size(274, 90);
            pb_6.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_6.TabIndex = 6;
            pb_6.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(tb_note2, 0, 0);
            tableLayoutPanel3.Controls.Add(tb_note3, 0, 1);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(146, 297);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 69F));
            tableLayoutPanel3.Size = new Size(636, 133);
            tableLayoutPanel3.TabIndex = 7;
            // 
            // tb_note2
            // 
            tb_note2.Dock = DockStyle.Fill;
            tb_note2.Location = new Point(3, 3);
            tb_note2.Multiline = true;
            tb_note2.Name = "tb_note2";
            tb_note2.Size = new Size(630, 58);
            tb_note2.TabIndex = 0;
            // 
            // tb_note3
            // 
            tb_note3.Dock = DockStyle.Fill;
            tb_note3.Location = new Point(3, 67);
            tb_note3.Multiline = true;
            tb_note3.Name = "tb_note3";
            tb_note3.Size = new Size(630, 63);
            tb_note3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel4.Controls.Add(pb_3, 0, 1);
            tableLayoutPanel4.Controls.Add(pb_2, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(788, 297);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 54.2857132F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 45.7142868F));
            tableLayoutPanel4.Size = new Size(274, 133);
            tableLayoutPanel4.TabIndex = 8;
            // 
            // pb_3
            // 
            pb_3.Dock = DockStyle.Fill;
            pb_3.Location = new Point(3, 75);
            pb_3.Name = "pb_3";
            pb_3.Size = new Size(268, 55);
            pb_3.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_3.TabIndex = 6;
            pb_3.TabStop = false;
            // 
            // pb_2
            // 
            pb_2.Dock = DockStyle.Fill;
            pb_2.Location = new Point(3, 3);
            pb_2.Name = "pb_2";
            pb_2.Size = new Size(268, 66);
            pb_2.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_2.TabIndex = 6;
            pb_2.TabStop = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 1;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Controls.Add(tb_note4, 0, 0);
            tableLayoutPanel5.Controls.Add(tb_note5, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(146, 436);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel5.Size = new Size(636, 133);
            tableLayoutPanel5.TabIndex = 7;
            // 
            // tb_note4
            // 
            tb_note4.Dock = DockStyle.Fill;
            tb_note4.Location = new Point(3, 3);
            tb_note4.Multiline = true;
            tb_note4.Name = "tb_note4";
            tb_note4.Size = new Size(630, 52);
            tb_note4.TabIndex = 0;
            // 
            // tb_note5
            // 
            tb_note5.Dock = DockStyle.Fill;
            tb_note5.Location = new Point(3, 61);
            tb_note5.Multiline = true;
            tb_note5.Name = "tb_note5";
            tb_note5.Size = new Size(630, 69);
            tb_note5.TabIndex = 0;
            // 
            // tableLayoutPanel6
            // 
            tableLayoutPanel6.ColumnCount = 1;
            tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Controls.Add(pb_4, 0, 0);
            tableLayoutPanel6.Controls.Add(pb_5, 0, 1);
            tableLayoutPanel6.Dock = DockStyle.Fill;
            tableLayoutPanel6.Location = new Point(788, 436);
            tableLayoutPanel6.Name = "tableLayoutPanel6";
            tableLayoutPanel6.RowCount = 2;
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel6.Size = new Size(274, 133);
            tableLayoutPanel6.TabIndex = 9;
            // 
            // pb_4
            // 
            pb_4.Dock = DockStyle.Fill;
            pb_4.Location = new Point(3, 3);
            pb_4.Name = "pb_4";
            pb_4.Size = new Size(268, 60);
            pb_4.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_4.TabIndex = 0;
            pb_4.TabStop = false;
            // 
            // pb_5
            // 
            pb_5.Dock = DockStyle.Fill;
            pb_5.Location = new Point(3, 69);
            pb_5.Name = "pb_5";
            pb_5.Size = new Size(268, 61);
            pb_5.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_5.TabIndex = 1;
            pb_5.TabStop = false;
            // 
            // tableLayoutPanel7
            // 
            tableLayoutPanel7.ColumnCount = 1;
            tableLayoutPanel7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel7.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel7.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel7.Dock = DockStyle.Fill;
            tableLayoutPanel7.Location = new Point(0, 0);
            tableLayoutPanel7.Name = "tableLayoutPanel7";
            tableLayoutPanel7.RowCount = 2;
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 90F));
            tableLayoutPanel7.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel7.Size = new Size(1073, 749);
            tableLayoutPanel7.TabIndex = 4;
            // 
            // EditHistory
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1073, 749);
            Controls.Add(tableLayoutPanel7);
            Margin = new Padding(4, 3, 4, 3);
            Name = "EditHistory";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Status device";
            Load += AddNew_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pb_1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_6).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_2).EndInit();
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pb_4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pb_5).EndInit();
            tableLayoutPanel7.ResumeLayout(false);
            tableLayoutPanel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_exportPPT;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Label label10;
        private Label label8;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox tb_deviceCode;
        private TextBox tb_deviceName;
        private TextBox tb_line;
        private TextBox tb_TroubleName;
        private TextBox tb_note1;
        private TextBox tb_note6;
        private PictureBox pb_1;
        private PictureBox pb_6;
        private Button btn_viewRp;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private PictureBox pb_3;
        private PictureBox pb_2;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private PictureBox pb_4;
        private PictureBox pb_5;
        private TextBox tb_note2;
        private TextBox tb_note3;
        private TextBox tb_note4;
        private TextBox tb_note5;
        private TableLayoutPanel tableLayoutPanel7;
    }
}