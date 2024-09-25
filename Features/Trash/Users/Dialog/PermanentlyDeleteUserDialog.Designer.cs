namespace FamilySprout.Features.Trash.Users.Dialog
{
    partial class PermanentlyDeleteUserDialog
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
            this.loginPanel = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tbRoles = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.SystemColors.Window;
            this.loginPanel.Controls.Add(this.btnDelete);
            this.loginPanel.Controls.Add(this.tbRoles);
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.label6);
            this.loginPanel.Controls.Add(this.tbUsername);
            this.loginPanel.Controls.Add(this.label7);
            this.loginPanel.Controls.Add(this.tbPassword);
            this.loginPanel.Controls.Add(this.btnCancel);
            this.loginPanel.Controls.Add(this.label5);
            this.loginPanel.Controls.Add(this.tbName);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Location = new System.Drawing.Point(22, 22);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(580, 398);
            this.loginPanel.TabIndex = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.Plum;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.Purple;
            this.btnDelete.Location = new System.Drawing.Point(329, 321);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(200, 43);
            this.btnDelete.TabIndex = 33;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tbRoles
            // 
            this.tbRoles.BackColor = System.Drawing.SystemColors.Window;
            this.tbRoles.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbRoles.Location = new System.Drawing.Point(46, 183);
            this.tbRoles.Name = "tbRoles";
            this.tbRoles.ReadOnly = true;
            this.tbRoles.Size = new System.Drawing.Size(234, 34);
            this.tbRoles.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F);
            this.label2.Location = new System.Drawing.Point(46, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "ROLE:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 12F);
            this.label6.Location = new System.Drawing.Point(295, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 22);
            this.label6.TabIndex = 30;
            this.label6.Text = "USERNAME:";
            // 
            // tbUsername
            // 
            this.tbUsername.BackColor = System.Drawing.SystemColors.Window;
            this.tbUsername.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbUsername.Location = new System.Drawing.Point(295, 113);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.ReadOnly = true;
            this.tbUsername.Size = new System.Drawing.Size(234, 34);
            this.tbUsername.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 12F);
            this.label7.Location = new System.Drawing.Point(295, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 22);
            this.label7.TabIndex = 28;
            this.label7.Text = "PASSWORD:";
            // 
            // tbPassword
            // 
            this.tbPassword.BackColor = System.Drawing.SystemColors.Window;
            this.tbPassword.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbPassword.Location = new System.Drawing.Point(295, 183);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '•';
            this.tbPassword.ReadOnly = true;
            this.tbPassword.Size = new System.Drawing.Size(234, 34);
            this.tbPassword.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.LightYellow;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Purple;
            this.btnCancel.Location = new System.Drawing.Point(89, 322);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnCancel.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 43);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 12F);
            this.label5.Location = new System.Drawing.Point(46, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 22);
            this.label5.TabIndex = 25;
            this.label5.Text = "FULL NAME:";
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.SystemColors.Window;
            this.tbName.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbName.Location = new System.Drawing.Point(46, 113);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(234, 34);
            this.tbName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(48, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "USER INFORMATION";
            // 
            // PermanentlyDeleteUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 448);
            this.Controls.Add(this.loginPanel);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PermanentlyDeleteUserDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PERMANENTLY DELETE USER";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox tbRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
    }
}