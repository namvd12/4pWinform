namespace GiamSat.viewDb
{
    partial class SearchDb
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
            this.tb_deviceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_searchHistory = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_SearchImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_deviceID
            // 
            this.tb_deviceID.Location = new System.Drawing.Point(113, 49);
            this.tb_deviceID.Name = "tb_deviceID";
            this.tb_deviceID.Size = new System.Drawing.Size(116, 20);
            this.tb_deviceID.TabIndex = 0;
            this.tb_deviceID.TextChanged += new System.EventHandler(this.tb_deviceID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(788, 403);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserAddedRow);
            this.dataGridView1.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_UserDeletedRow);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // btn_searchHistory
            // 
            this.btn_searchHistory.Enabled = false;
            this.btn_searchHistory.Location = new System.Drawing.Point(471, 81);
            this.btn_searchHistory.Name = "btn_searchHistory";
            this.btn_searchHistory.Size = new System.Drawing.Size(142, 23);
            this.btn_searchHistory.TabIndex = 3;
            this.btn_searchHistory.Text = "Search History";
            this.btn_searchHistory.UseVisualStyleBackColor = true;
            this.btn_searchHistory.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(272, 46);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(142, 23);
            this.btn_search.TabIndex = 4;
            this.btn_search.Text = "Search all device";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_update
            // 
            this.btn_update.Enabled = false;
            this.btn_update.Location = new System.Drawing.Point(272, 78);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(142, 23);
            this.btn_update.TabIndex = 3;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_SearchImage
            // 
            this.btn_SearchImage.Enabled = false;
            this.btn_SearchImage.Location = new System.Drawing.Point(471, 47);
            this.btn_SearchImage.Name = "btn_SearchImage";
            this.btn_SearchImage.Size = new System.Drawing.Size(142, 23);
            this.btn_SearchImage.TabIndex = 3;
            this.btn_SearchImage.Text = "Search Image";
            this.btn_SearchImage.UseVisualStyleBackColor = true;
            this.btn_SearchImage.Click += new System.EventHandler(this.btn_SearchImage_Click);
            // 
            // SearchDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 515);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.btn_SearchImage);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.btn_searchHistory);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_deviceID);
            this.Name = "SearchDb";
            this.Text = "SearchDb";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_deviceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_searchHistory;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_SearchImage;
    }
}