namespace Giamsat.View.ShowItems
{
    partial class AddRegion
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
            cb_line = new ComboBox();
            cb_region = new ComboBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btn_edit = new Button();
            button2 = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.2669678F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.73303F));
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(cb_line, 1, 0);
            tableLayoutPanel1.Controls.Add(cb_region, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 61.25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 38.75F));
            tableLayoutPanel1.Size = new Size(414, 67);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(82, 41);
            label1.TabIndex = 0;
            label1.Text = "Line";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(3, 41);
            label2.Name = "label2";
            label2.Size = new Size(82, 26);
            label2.TabIndex = 0;
            label2.Text = "Region";
            // 
            // cb_line
            // 
            cb_line.Dock = DockStyle.Fill;
            cb_line.FormattingEnabled = true;
            cb_line.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
            cb_line.Location = new Point(91, 3);
            cb_line.Name = "cb_line";
            cb_line.Size = new Size(320, 23);
            cb_line.TabIndex = 1;
            // 
            // cb_region
            // 
            cb_region.Dock = DockStyle.Fill;
            cb_region.FormattingEnabled = true;
            cb_region.Items.AddRange(new object[] { "Region1", "Region2", "Region3", "Region4", "Region5", "Region6", "Region7", "Region8", "Region9", "Region10", "Region11", "Region12", "Region13", "Region14", "Region15" });
            cb_region.Location = new Point(91, 44);
            cb_region.Name = "cb_region";
            cb_region.Size = new Size(320, 23);
            cb_region.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btn_edit);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Dock = DockStyle.Top;
            flowLayoutPanel1.Location = new Point(0, 67);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(414, 43);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_edit
            // 
            btn_edit.Location = new Point(3, 3);
            btn_edit.Name = "btn_edit";
            btn_edit.Size = new Size(198, 34);
            btn_edit.TabIndex = 2;
            btn_edit.Text = "Add Item";
            btn_edit.UseVisualStyleBackColor = true;
            btn_edit.Click += EditPosition_Click;
            // 
            // button2
            // 
            button2.Location = new Point(207, 3);
            button2.Name = "button2";
            button2.Size = new Size(195, 34);
            button2.TabIndex = 1;
            button2.Text = "Canncel";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // AddRegion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 123);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(tableLayoutPanel1);
            Name = "AddRegion";
            Text = "AddRegion";
            TopMost = true;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ComboBox cb_line;
        private ComboBox cb_region;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private Button btn_edit;
    }
}