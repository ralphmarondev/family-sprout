namespace FamilySprout.Features.Trash
{
    partial class TrashMainForm
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
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnToggleNavPanel = new System.Windows.Forms.Button();
            this.btnCurrentUserInfo = new System.Windows.Forms.PictureBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnChildrens = new System.Windows.Forms.Button();
            this.btnFamilies = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.listOfItemsPanel = new System.Windows.Forms.Panel();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.listOfItemsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
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
            this.panelTitle.TabIndex = 19;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(70, 22);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "TRASH";
            this.lblDestination.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseDown);
            this.lblDestination.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseMove);
            this.lblDestination.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseUp);
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
            this.btnFullScreen.TabIndex = 4;
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
            this.btnCurrentUserInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCurrentUserInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCurrentUserInfo.Image = global::FamilySprout.Properties.Resources.icons8_test_account_80;
            this.btnCurrentUserInfo.Location = new System.Drawing.Point(533, 16);
            this.btnCurrentUserInfo.Name = "btnCurrentUserInfo";
            this.btnCurrentUserInfo.Size = new System.Drawing.Size(30, 30);
            this.btnCurrentUserInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCurrentUserInfo.TabIndex = 4;
            this.btnCurrentUserInfo.TabStop = false;
            this.btnCurrentUserInfo.MouseLeave += new System.EventHandler(this.btnCurrentUserInfo_MouseLeave);
            this.btnCurrentUserInfo.MouseHover += new System.EventHandler(this.btnCurrentUserInfo_MouseHover);
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.BackColor = System.Drawing.Color.White;
            this.lblCurrentUser.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.Purple;
            this.lblCurrentUser.Location = new System.Drawing.Point(569, 24);
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
            this.mainPanel.Controls.Add(this.btnUsers);
            this.mainPanel.Controls.Add(this.btnChildrens);
            this.mainPanel.Controls.Add(this.btnFamilies);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(930, 591);
            this.mainPanel.TabIndex = 20;
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUsers.BackColor = System.Drawing.Color.Gainsboro;
            this.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsers.FlatAppearance.BorderSize = 0;
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.Purple;
            this.btnUsers.Location = new System.Drawing.Point(441, 502);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(0);
            this.btnUsers.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(200, 36);
            this.btnUsers.TabIndex = 3;
            this.btnUsers.Text = "USERS";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnChildrens
            // 
            this.btnChildrens.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChildrens.BackColor = System.Drawing.Color.Gainsboro;
            this.btnChildrens.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChildrens.FlatAppearance.BorderSize = 0;
            this.btnChildrens.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChildrens.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChildrens.ForeColor = System.Drawing.Color.Purple;
            this.btnChildrens.Location = new System.Drawing.Point(232, 502);
            this.btnChildrens.Margin = new System.Windows.Forms.Padding(0);
            this.btnChildrens.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnChildrens.Name = "btnChildrens";
            this.btnChildrens.Size = new System.Drawing.Size(200, 36);
            this.btnChildrens.TabIndex = 2;
            this.btnChildrens.Text = "CHILDRENS";
            this.btnChildrens.UseVisualStyleBackColor = false;
            this.btnChildrens.Click += new System.EventHandler(this.btnChildrens_Click);
            // 
            // btnFamilies
            // 
            this.btnFamilies.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFamilies.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFamilies.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFamilies.FlatAppearance.BorderSize = 0;
            this.btnFamilies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFamilies.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFamilies.ForeColor = System.Drawing.Color.Purple;
            this.btnFamilies.Location = new System.Drawing.Point(22, 502);
            this.btnFamilies.Margin = new System.Windows.Forms.Padding(0);
            this.btnFamilies.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnFamilies.Name = "btnFamilies";
            this.btnFamilies.Size = new System.Drawing.Size(200, 36);
            this.btnFamilies.TabIndex = 1;
            this.btnFamilies.Text = "FAMILIES";
            this.btnFamilies.UseVisualStyleBackColor = false;
            this.btnFamilies.Click += new System.EventHandler(this.btnFamilies_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.listOfItemsPanel);
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(859, 472);
            this.panel1.TabIndex = 0;
            // 
            // listOfItemsPanel
            // 
            this.listOfItemsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listOfItemsPanel.Controls.Add(this.lblEmpty);
            this.listOfItemsPanel.Location = new System.Drawing.Point(22, 22);
            this.listOfItemsPanel.Name = "listOfItemsPanel";
            this.listOfItemsPanel.Size = new System.Drawing.Size(817, 433);
            this.listOfItemsPanel.TabIndex = 0;
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Courier New", 18F);
            this.lblEmpty.Location = new System.Drawing.Point(164, 201);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(483, 33);
            this.lblEmpty.TabIndex = 0;
            this.lblEmpty.Text = "NO DELETED FAMILIES FOUND!";
            // 
            // TrashMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 659);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrashMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TrashMainForm";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.listOfItemsPanel.ResumeLayout(false);
            this.listOfItemsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnToggleNavPanel;
        private System.Windows.Forms.PictureBox btnCurrentUserInfo;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnChildrens;
        private System.Windows.Forms.Button btnFamilies;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel listOfItemsPanel;
        private System.Windows.Forms.Label lblEmpty;
    }
}