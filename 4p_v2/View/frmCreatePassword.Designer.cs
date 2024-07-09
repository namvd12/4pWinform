namespace GiamSat
{
    partial class frmCreatePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreatePassword));
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbNewPassword = new System.Windows.Forms.Label();
            this.lbConfirmPassword = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPasswordNew = new System.Windows.Forms.TextBox();
            this.txtPasswordNew2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(12, 29);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(52, 13);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Mật khẩu";
            // 
            // lbNewPassword
            // 
            this.lbNewPassword.AutoSize = true;
            this.lbNewPassword.Location = new System.Drawing.Point(12, 69);
            this.lbNewPassword.Name = "lbNewPassword";
            this.lbNewPassword.Size = new System.Drawing.Size(71, 13);
            this.lbNewPassword.TabIndex = 1;
            this.lbNewPassword.Text = "Mật khẩu mới";
            // 
            // lbConfirmPassword
            // 
            this.lbConfirmPassword.AutoSize = true;
            this.lbConfirmPassword.Location = new System.Drawing.Point(12, 109);
            this.lbConfirmPassword.Name = "lbConfirmPassword";
            this.lbConfirmPassword.Size = new System.Drawing.Size(112, 13);
            this.lbConfirmPassword.TabIndex = 2;
            this.lbConfirmPassword.Text = "Nhập lại mật khẩu mới";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(153, 154);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 154);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 29);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(184, 20);
            this.txtPassword.TabIndex = 5;
            // 
            // txtPasswordNew
            // 
            this.txtPasswordNew.Location = new System.Drawing.Point(135, 69);
            this.txtPasswordNew.Name = "txtPasswordNew";
            this.txtPasswordNew.PasswordChar = '*';
            this.txtPasswordNew.Size = new System.Drawing.Size(184, 20);
            this.txtPasswordNew.TabIndex = 6;
            // 
            // txtPasswordNew2
            // 
            this.txtPasswordNew2.Location = new System.Drawing.Point(135, 106);
            this.txtPasswordNew2.Name = "txtPasswordNew2";
            this.txtPasswordNew2.PasswordChar = '*';
            this.txtPasswordNew2.Size = new System.Drawing.Size(184, 20);
            this.txtPasswordNew2.TabIndex = 7;
            // 
            // frmCreatePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 189);
            this.Controls.Add(this.txtPasswordNew2);
            this.Controls.Add(this.txtPasswordNew);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lbConfirmPassword);
            this.Controls.Add(this.lbNewPassword);
            this.Controls.Add(this.lbPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCreatePassword";
            this.Text = "Saban-Wi Monitor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbNewPassword;
        private System.Windows.Forms.Label lbConfirmPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtPasswordNew;
        private System.Windows.Forms.TextBox txtPasswordNew2;
    }
}