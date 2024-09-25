namespace FamilySprout.Features.Trash.Users.Controls
{
    partial class TrashUsersUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRestore = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPermanentDelete = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnRestore);
            this.panel1.Controls.Add(this.lblRole);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnPermanentDelete);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(9, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 65);
            this.panel1.TabIndex = 5;
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRestore.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_restore_48;
            this.btnRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestore.FlatAppearance.BorderSize = 0;
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.Purple;
            this.btnRestore.Location = new System.Drawing.Point(571, 12);
            this.btnRestore.Margin = new System.Windows.Forms.Padding(0);
            this.btnRestore.MaximumSize = new System.Drawing.Size(300, 94);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(45, 41);
            this.btnRestore.TabIndex = 10;
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Courier New", 14F);
            this.lblRole.Location = new System.Drawing.Point(4, 29);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(68, 27);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "USER";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Courier New", 14F);
            this.lblName.Location = new System.Drawing.Point(4, 7);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(208, 27);
            this.lblName.TabIndex = 8;
            this.lblName.Text = "USER FULL NAME";
            // 
            // btnPermanentDelete
            // 
            this.btnPermanentDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPermanentDelete.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPermanentDelete.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_delete_48;
            this.btnPermanentDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPermanentDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPermanentDelete.FlatAppearance.BorderSize = 0;
            this.btnPermanentDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermanentDelete.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPermanentDelete.ForeColor = System.Drawing.Color.Purple;
            this.btnPermanentDelete.Location = new System.Drawing.Point(625, 12);
            this.btnPermanentDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnPermanentDelete.MaximumSize = new System.Drawing.Size(300, 94);
            this.btnPermanentDelete.Name = "btnPermanentDelete";
            this.btnPermanentDelete.Size = new System.Drawing.Size(45, 41);
            this.btnPermanentDelete.TabIndex = 7;
            this.btnPermanentDelete.UseVisualStyleBackColor = false;
            this.btnPermanentDelete.Click += new System.EventHandler(this.btnPermanentDelete_Click);
            // 
            // TrashUsersUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrashUsersUserControl";
            this.Size = new System.Drawing.Size(696, 83);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPermanentDelete;
    }
}
