namespace GiamSat
{
    partial class PasswordForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordForm));
            lbPassword = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            tb_pw = new TextBox();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            tb_user = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // lbPassword
            // 
            lbPassword.AutoSize = true;
            lbPassword.Location = new Point(13, 53);
            lbPassword.Margin = new Padding(4, 0, 4, 0);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(57, 15);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Password";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(104, 88);
            btnOK.Margin = new Padding(4, 3, 4, 3);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(88, 27);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(202, 88);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(88, 27);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // tb_pw
            // 
            tb_pw.Location = new Point(84, 50);
            tb_pw.Margin = new Padding(4, 3, 4, 3);
            tb_pw.Name = "tb_pw";
            tb_pw.PasswordChar = '*';
            tb_pw.Size = new Size(206, 23);
            tb_pw.TabIndex = 2;
            tb_pw.TextChanged += txtPassword_TextChanged;
            tb_pw.KeyPress += txtPassword_KeyPress;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(30, 15);
            label1.TabIndex = 6;
            label1.Text = "User";
            // 
            // tb_user
            // 
            tb_user.Location = new Point(84, 12);
            tb_user.Margin = new Padding(4, 3, 4, 3);
            tb_user.Name = "tb_user";
            tb_user.Size = new Size(206, 23);
            tb_user.TabIndex = 1;
            // 
            // PasswordForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 132);
            Controls.Add(tb_user);
            Controls.Add(label1);
            Controls.Add(tb_pw);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lbPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "PasswordForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Saban-Wi Monitor";
            Load += PasswordForm_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tb_pw;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Label label1;
        private TextBox tb_user;
    }
}