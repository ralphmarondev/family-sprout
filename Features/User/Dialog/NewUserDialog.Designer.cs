namespace FamilySprout.Features.User.Dialog
{
    partial class NewUserDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbRoles = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.loginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.BackColor = System.Drawing.SystemColors.Window;
            this.loginPanel.Controls.Add(this.label2);
            this.loginPanel.Controls.Add(this.tbRoles);
            this.loginPanel.Controls.Add(this.label6);
            this.loginPanel.Controls.Add(this.tbUsername);
            this.loginPanel.Controls.Add(this.label7);
            this.loginPanel.Controls.Add(this.tbConfirmPassword);
            this.loginPanel.Controls.Add(this.btnCancel);
            this.loginPanel.Controls.Add(this.label5);
            this.loginPanel.Controls.Add(this.tbName);
            this.loginPanel.Controls.Add(this.btnRegister);
            this.loginPanel.Controls.Add(this.label3);
            this.loginPanel.Controls.Add(this.label1);
            this.loginPanel.Controls.Add(this.tbPassword);
            this.loginPanel.Location = new System.Drawing.Point(22, 22);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.Size = new System.Drawing.Size(580, 398);
            this.loginPanel.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F);
            this.label2.Location = new System.Drawing.Point(46, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "ROLE:";
            // 
            // tbRoles
            // 
            this.tbRoles.BackColor = System.Drawing.SystemColors.Window;
            this.tbRoles.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbRoles.FormattingEnabled = true;
            this.tbRoles.Items.AddRange(new object[] {
            "USER",
            "SUPERUSER"});
            this.tbRoles.Location = new System.Drawing.Point(46, 252);
            this.tbRoles.Name = "tbRoles";
            this.tbRoles.Size = new System.Drawing.Size(234, 33);
            this.tbRoles.TabIndex = 5;
            this.tbRoles.Text = "USER";
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
            this.tbUsername.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbUsername.Location = new System.Drawing.Point(295, 113);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(234, 34);
            this.tbUsername.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 12F);
            this.label7.Location = new System.Drawing.Point(295, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(214, 22);
            this.label7.TabIndex = 28;
            this.label7.Text = "CONFIRM PASSWORD:";
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbConfirmPassword.Location = new System.Drawing.Point(295, 183);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.Size = new System.Drawing.Size(234, 34);
            this.tbConfirmPassword.TabIndex = 4;
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
            this.btnCancel.TabIndex = 7;
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
            this.tbName.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbName.Location = new System.Drawing.Point(46, 113);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(234, 34);
            this.tbName.TabIndex = 1;
            // 
            // btnRegister
            // 
            this.btnRegister.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRegister.BackColor = System.Drawing.Color.Plum;
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.Purple;
            this.btnRegister.Location = new System.Drawing.Point(329, 321);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(0);
            this.btnRegister.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(200, 43);
            this.btnRegister.TabIndex = 6;
            this.btnRegister.Text = "REGISTER";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 16F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(48, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "REGISTER";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F);
            this.label1.Location = new System.Drawing.Point(46, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "PASSWORD:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbPassword.Location = new System.Drawing.Point(46, 183);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(234, 34);
            this.tbPassword.TabIndex = 3;
            // 
            // NewUserDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 448);
            this.Controls.Add(this.loginPanel);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "NewUserDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CREATE NEW USER";
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox tbRoles;
    }
}