﻿namespace FamilySprout.Features.FamilyList.Forms
{
    partial class FamilyChildListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyChildListForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblDestination = new System.Windows.Forms.Label();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnToggleNavPanel = new System.Windows.Forms.Button();
            this.btnCurrentUserInfo = new System.Windows.Forms.PictureBox();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.lblNonSuperUserIndicator = new System.Windows.Forms.Label();
            this.btnNewChild = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.childListPanel = new System.Windows.Forms.Panel();
            this.lblBack = new System.Windows.Forms.LinkLabel();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblDestination);
            this.panelTitle.Controls.Add(this.btnFullScreen);
            this.panelTitle.Controls.Add(this.btnToggleNavPanel);
            this.panelTitle.Controls.Add(this.btnCurrentUserInfo);
            this.panelTitle.Controls.Add(this.lblAdminName);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitle.ForeColor = System.Drawing.Color.Purple;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.MinimumSize = new System.Drawing.Size(717, 68);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(930, 68);
            this.panelTitle.TabIndex = 20;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseDown);
            this.panelTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseMove);
            this.panelTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTitle_MouseUp);
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(394, 22);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "FAMILY LIST/CHILDREN INFORMATION";
            this.lblDestination.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseDown);
            this.lblDestination.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseMove);
            this.lblDestination.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblDestination_MouseUp);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFullScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFullScreen.BackgroundImage")));
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
            this.btnToggleNavPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnToggleNavPanel.BackgroundImage")));
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
            this.btnCurrentUserInfo.Click += new System.EventHandler(this.btnCurrentUserInfo_Click);
            this.btnCurrentUserInfo.MouseLeave += new System.EventHandler(this.btnCurrentUserInfo_MouseLeave);
            this.btnCurrentUserInfo.MouseHover += new System.EventHandler(this.btnCurrentUserInfo_MouseHover);
            // 
            // lblAdminName
            // 
            this.lblAdminName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.BackColor = System.Drawing.Color.White;
            this.lblAdminName.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminName.ForeColor = System.Drawing.Color.Purple;
            this.lblAdminName.Location = new System.Drawing.Point(569, 24);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(70, 22);
            this.lblAdminName.TabIndex = 0;
            this.lblAdminName.Text = "ADMIN";
            this.lblAdminName.Click += new System.EventHandler(this.lblAdminName_Click);
            this.lblAdminName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblAdminName_MouseDown);
            this.lblAdminName.MouseLeave += new System.EventHandler(this.lblAdminName_MouseLeave);
            this.lblAdminName.MouseHover += new System.EventHandler(this.lblAdminName_MouseHover);
            this.lblAdminName.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblAdminName_MouseMove);
            this.lblAdminName.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblAdminName_MouseUp);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.lblNonSuperUserIndicator);
            this.mainPanel.Controls.Add(this.btnNewChild);
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(930, 591);
            this.mainPanel.TabIndex = 21;
            // 
            // lblNonSuperUserIndicator
            // 
            this.lblNonSuperUserIndicator.AutoSize = true;
            this.lblNonSuperUserIndicator.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblNonSuperUserIndicator.Location = new System.Drawing.Point(237, 504);
            this.lblNonSuperUserIndicator.Name = "lblNonSuperUserIndicator";
            this.lblNonSuperUserIndicator.Size = new System.Drawing.Size(659, 20);
            this.lblNonSuperUserIndicator.TabIndex = 26;
            this.lblNonSuperUserIndicator.Text = "**Adding, Updating, and Deleting is Disabled for non-superusers**";
            // 
            // btnNewChild
            // 
            this.btnNewChild.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewChild.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNewChild.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNewChild.FlatAppearance.BorderSize = 0;
            this.btnNewChild.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewChild.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewChild.ForeColor = System.Drawing.Color.Purple;
            this.btnNewChild.Location = new System.Drawing.Point(22, 504);
            this.btnNewChild.Margin = new System.Windows.Forms.Padding(0);
            this.btnNewChild.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnNewChild.Name = "btnNewChild";
            this.btnNewChild.Size = new System.Drawing.Size(200, 36);
            this.btnNewChild.TabIndex = 25;
            this.btnNewChild.Text = "NEW CHILD";
            this.btnNewChild.UseVisualStyleBackColor = false;
            this.btnNewChild.Click += new System.EventHandler(this.btnNewChild_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.childListPanel);
            this.panel1.Controls.Add(this.lblBack);
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 472);
            this.panel1.TabIndex = 23;
            // 
            // childListPanel
            // 
            this.childListPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.childListPanel.Location = new System.Drawing.Point(22, 35);
            this.childListPanel.Name = "childListPanel";
            this.childListPanel.Size = new System.Drawing.Size(837, 423);
            this.childListPanel.TabIndex = 2;
            // 
            // lblBack
            // 
            this.lblBack.AutoSize = true;
            this.lblBack.Location = new System.Drawing.Point(10, 10);
            this.lblBack.Name = "lblBack";
            this.lblBack.Size = new System.Drawing.Size(58, 22);
            this.lblBack.TabIndex = 1;
            this.lblBack.TabStop = true;
            this.lblBack.Text = "BACK";
            this.lblBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBack_LinkClicked);
            // 
            // FamilyChildListForm
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
            this.Name = "FamilyChildListForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FamilyChildListForm";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnToggleNavPanel;
        private System.Windows.Forms.PictureBox btnCurrentUserInfo;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblBack;
        private System.Windows.Forms.Panel childListPanel;
        private System.Windows.Forms.Button btnNewChild;
        private System.Windows.Forms.Label lblNonSuperUserIndicator;
    }
}