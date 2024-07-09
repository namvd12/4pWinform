namespace Giamsat.View.Config
{
    partial class ConfigTimeNG
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            tb_time = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_save = new Button();
            btn_cancel = new Button();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 20);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 29.3918915F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70.60811F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(tb_time, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 20);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(296, 33);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(81, 33);
            label1.TabIndex = 0;
            label1.Text = "Time NG";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tb_time
            // 
            tb_time.Dock = DockStyle.Fill;
            tb_time.Location = new Point(90, 3);
            tb_time.Name = "tb_time";
            tb_time.Size = new Size(203, 23);
            tb_time.TabIndex = 1;
            tb_time.TextChanged += tb_time_TextChanged;
            tb_time.KeyPress += tb_time_KeyPress;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 47.6351357F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 52.3648643F));
            tableLayoutPanel2.Controls.Add(btn_save, 0, 0);
            tableLayoutPanel2.Controls.Add(btn_cancel, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 53);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(296, 36);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_save
            // 
            btn_save.Dock = DockStyle.Fill;
            btn_save.Location = new Point(3, 3);
            btn_save.Name = "btn_save";
            btn_save.Size = new Size(135, 30);
            btn_save.TabIndex = 0;
            btn_save.Text = "Save";
            btn_save.UseVisualStyleBackColor = true;
            btn_save.Click += btn_save_Click;
            // 
            // btn_cancel
            // 
            btn_cancel.Dock = DockStyle.Fill;
            btn_cancel.Location = new Point(144, 3);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new Size(149, 30);
            btn_cancel.TabIndex = 0;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // ConfigTimeNG
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(296, 101);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "ConfigTimeNG";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Setting time NG";
            Load += ConfigTimeNG_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private TextBox tb_time;
        private Button btn_save;
        private Button btn_cancel;
    }
}