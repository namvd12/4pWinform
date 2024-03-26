namespace GiamSat
{
    partial class CauhinhThietbi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CauhinhThietbi));
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lbSignal = new System.Windows.Forms.Label();
            this.cbSignal = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbNote = new System.Windows.Forms.Label();
            this.richTextBoxNote = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lbID
            // 
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(13, 21);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(36, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "Mã ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(87, 19);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(65, 20);
            this.txtID.TabIndex = 1;
            this.txtID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDiaChi_KeyPress);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(13, 57);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(29, 13);
            this.lbName.TabIndex = 7;
            this.lbName.Text = "Tên ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(87, 54);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 2;
            // 
            // lbSignal
            // 
            this.lbSignal.AutoSize = true;
            this.lbSignal.Location = new System.Drawing.Point(13, 93);
            this.lbSignal.Name = "lbSignal";
            this.lbSignal.Size = new System.Drawing.Size(43, 13);
            this.lbSignal.TabIndex = 8;
            this.lbSignal.Text = "Vị trí ID";
            // 
            // cbSignal
            // 
            this.cbSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSignal.FormattingEnabled = true;
            this.cbSignal.Location = new System.Drawing.Point(87, 90);
            this.cbSignal.Name = "cbSignal";
            this.cbSignal.Size = new System.Drawing.Size(153, 21);
            this.cbSignal.TabIndex = 3;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(198, 267);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnChapNhan_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(294, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Thoát";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lbNote
            // 
            this.lbNote.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lbNote.AutoSize = true;
            this.lbNote.Location = new System.Drawing.Point(13, 132);
            this.lbNote.Name = "lbNote";
            this.lbNote.Size = new System.Drawing.Size(44, 13);
            this.lbNote.TabIndex = 9;
            this.lbNote.Text = "Ghi chú";
            // 
            // richTextBoxNote
            // 
            this.richTextBoxNote.Location = new System.Drawing.Point(87, 129);
            this.richTextBoxNote.Name = "richTextBoxNote";
            this.richTextBoxNote.Size = new System.Drawing.Size(300, 120);
            this.richTextBoxNote.TabIndex = 4;
            this.richTextBoxNote.Text = "";
            // 
            // CauhinhThietbi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 302);
            this.Controls.Add(this.richTextBoxNote);
            this.Controls.Add(this.lbNote);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbSignal);
            this.Controls.Add(this.lbSignal);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lbID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CauhinhThietbi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cấu hình ID";
            this.Load += new System.EventHandler(this.CauhinhThietbi_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CauhinhThietbi_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lbSignal;
        private System.Windows.Forms.ComboBox cbSignal;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbNote;
        private System.Windows.Forms.RichTextBox richTextBoxNote;
    }
}