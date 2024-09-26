namespace FamilySprout.Features.Dashboard
{
    partial class DashboardMainForm
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblGreetings = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnToggleNavPanel = new System.Windows.Forms.Button();
            this.btnCurrentUserInfo = new System.Windows.Forms.PictureBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.btnBackup);
            this.panelTitle.Controls.Add(this.lblDestination);
            this.panelTitle.Controls.Add(this.btnFullScreen);
            this.panelTitle.Controls.Add(this.btnToggleNavPanel);
            this.panelTitle.Controls.Add(this.btnCurrentUserInfo);
            this.panelTitle.Controls.Add(this.lblCurrentUser);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitle.ForeColor = System.Drawing.Color.Purple;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.MinimumSize = new System.Drawing.Size(717, 68);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(930, 68);
            this.panelTitle.TabIndex = 21;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(118, 22);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "DASHBOARD";
            this.lblDestination.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseDown);
            this.lblDestination.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseMove);
            this.lblDestination.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseUp);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.White;
            this.lblCurrentUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblCurrentUser.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Purple;
            this.lblCurrentUser.Location = new System.Drawing.Point(566, 23);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(70, 22);
            this.lblCurrentUser.TabIndex = 0;
            this.lblCurrentUser.Text = "ADMIN";
            this.lblCurrentUser.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCurrentUser_MouseDown);
            this.lblCurrentUser.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblCurrentUser_MouseMove);
            this.lblCurrentUser.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblCurrentUser_MouseUp);
            // 
            // mainPanel
            // 
            this.mainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainPanel.BackColor = System.Drawing.SystemColors.Window;
            this.mainPanel.Controls.Add(this.label1);
            this.mainPanel.Controls.Add(this.monthCalendar1);
            this.mainPanel.Controls.Add(this.lblGreetings);
            this.mainPanel.Controls.Add(this.flowLayoutPanel1);
            this.mainPanel.Location = new System.Drawing.Point(24, 92);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(877, 532);
            this.mainPanel.TabIndex = 22;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Window;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 291);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(781, 184);
            this.flowLayoutPanel1.TabIndex = 23;
            // 
            // lblGreetings
            // 
            this.lblGreetings.AutoSize = true;
            this.lblGreetings.Font = new System.Drawing.Font("Courier New", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreetings.Location = new System.Drawing.Point(13, 16);
            this.lblGreetings.Name = "lblGreetings";
            this.lblGreetings.Size = new System.Drawing.Size(411, 34);
            this.lblGreetings.TabIndex = 28;
            this.lblGreetings.Text = "HELLO, RALPH MARON EDA";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(19, 59);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "OTHER INFORMATION";
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnBackup.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_backup_24;
            this.btnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackup.FlatAppearance.BorderSize = 0;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Purple;
            this.btnBackup.Location = new System.Drawing.Point(812, 16);
            this.btnBackup.Margin = new System.Windows.Forms.Padding(0);
            this.btnBackup.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(30, 30);
            this.btnBackup.TabIndex = 8;
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFullScreen.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_full_screen_48;
            this.btnFullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFullScreen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFullScreen.FlatAppearance.BorderSize = 0;
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullScreen.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullScreen.ForeColor = System.Drawing.Color.Purple;
            this.btnFullScreen.Location = new System.Drawing.Point(851, 17);
            this.btnFullScreen.Margin = new System.Windows.Forms.Padding(0);
            this.btnFullScreen.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(30, 30);
            this.btnFullScreen.TabIndex = 6;
            this.btnFullScreen.UseVisualStyleBackColor = false;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnToggleNavPanel
            // 
            this.btnToggleNavPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleNavPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnToggleNavPanel.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_hide_sidepanel_50;
            this.btnToggleNavPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnToggleNavPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleNavPanel.FlatAppearance.BorderSize = 0;
            this.btnToggleNavPanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleNavPanel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleNavPanel.ForeColor = System.Drawing.Color.Purple;
            this.btnToggleNavPanel.Location = new System.Drawing.Point(891, 17);
            this.btnToggleNavPanel.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleNavPanel.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnToggleNavPanel.Name = "btnToggleNavPanel";
            this.btnToggleNavPanel.Size = new System.Drawing.Size(30, 30);
            this.btnToggleNavPanel.TabIndex = 5;
            this.btnToggleNavPanel.UseVisualStyleBackColor = false;
            // 
            // btnCurrentUserInfo
            // 
            this.btnCurrentUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCurrentUserInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCurrentUserInfo.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_test_account_80;
            this.btnCurrentUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCurrentUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurrentUserInfo.Location = new System.Drawing.Point(533, 16);
            this.btnCurrentUserInfo.Name = "btnCurrentUserInfo";
            this.btnCurrentUserInfo.Size = new System.Drawing.Size(30, 30);
            this.btnCurrentUserInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCurrentUserInfo.TabIndex = 4;
            this.btnCurrentUserInfo.TabStop = false;
            this.btnCurrentUserInfo.MouseLeave += new System.EventHandler(this.btnCurrentUserInfo_MouseLeave);
            this.btnCurrentUserInfo.MouseHover += new System.EventHandler(this.btnCurrentUserInfo_MouseHover);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblNotice.ForeColor = System.Drawing.Color.Tomato;
            this.lblNotice.Location = new System.Drawing.Point(0, 627);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(5);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Padding = new System.Windows.Forms.Padding(5);
            this.lblNotice.Size = new System.Drawing.Size(680, 32);
            this.lblNotice.TabIndex = 31;
            this.lblNotice.Text = "***SOME FUNCTIONALITES ARE DISALBED ON NON-SUPERUSER***";
            this.lblNotice.Visible = false;
            // 
            // DashboardMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 659);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DashboardMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DashboardMainForm";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnToggleNavPanel;
        private System.Windows.Forms.PictureBox btnCurrentUserInfo;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label lblGreetings;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNotice;
    }
}