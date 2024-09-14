namespace FamilySprout.Features.FamilyList.Forms
{
    partial class FamilyDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FamilyDetailsForm));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblDestination = new System.Windows.Forms.Label();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelHusbandWife = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbWifeFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbWifeFullName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbHusbandFrom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHusbandFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRemarks = new System.Windows.Forms.TextBox();
            this.lblBack = new System.Windows.Forms.LinkLabel();
            this.lblNonSuperUserIndicator = new System.Windows.Forms.Label();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnToggleNavPanel = new System.Windows.Forms.Button();
            this.btnEmployeeInfo = new System.Windows.Forms.PictureBox();
            this.panelTitle.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelHusbandWife.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployeeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.White;
            this.panelTitle.Controls.Add(this.lblDestination);
            this.panelTitle.Controls.Add(this.btnFullScreen);
            this.panelTitle.Controls.Add(this.btnToggleNavPanel);
            this.panelTitle.Controls.Add(this.btnEmployeeInfo);
            this.panelTitle.Controls.Add(this.lblAdminName);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelTitle.ForeColor = System.Drawing.Color.Purple;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.MinimumSize = new System.Drawing.Size(717, 68);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(930, 68);
            this.panelTitle.TabIndex = 19;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(370, 22);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "FAMILY LIST/PARENT INFORMATION\r\n";
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
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(930, 591);
            this.mainPanel.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.panelHusbandWife);
            this.panel1.Controls.Add(this.lblBack);
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 472);
            this.panel1.TabIndex = 23;
            // 
            // panelHusbandWife
            // 
            this.panelHusbandWife.BackColor = System.Drawing.Color.White;
            this.panelHusbandWife.Controls.Add(this.lblNonSuperUserIndicator);
            this.panelHusbandWife.Controls.Add(this.btnDelete);
            this.panelHusbandWife.Controls.Add(this.btnUpdate);
            this.panelHusbandWife.Controls.Add(this.btnNext);
            this.panelHusbandWife.Controls.Add(this.panel3);
            this.panelHusbandWife.Controls.Add(this.panel2);
            this.panelHusbandWife.Controls.Add(this.label5);
            this.panelHusbandWife.Controls.Add(this.tbRemarks);
            this.panelHusbandWife.ForeColor = System.Drawing.Color.Purple;
            this.panelHusbandWife.Location = new System.Drawing.Point(140, 32);
            this.panelHusbandWife.Name = "panelHusbandWife";
            this.panelHusbandWife.Size = new System.Drawing.Size(595, 408);
            this.panelHusbandWife.TabIndex = 21;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.HotPink;
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Purple;
            this.btnDelete.Location = new System.Drawing.Point(53, 336);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(0);
            this.btnDelete.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(157, 43);
            this.btnDelete.TabIndex = 20;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.LightYellow;
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Purple;
            this.btnUpdate.Location = new System.Drawing.Point(234, 336);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(157, 43);
            this.btnUpdate.TabIndex = 19;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.BackColor = System.Drawing.Color.PaleGreen;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.Purple;
            this.btnNext.Location = new System.Drawing.Point(408, 336);
            this.btnNext.Margin = new System.Windows.Forms.Padding(0);
            this.btnNext.MaximumSize = new System.Drawing.Size(200, 68);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(157, 43);
            this.btnNext.TabIndex = 18;
            this.btnNext.Text = "NEXT";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.tbWifeFrom);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.tbWifeFullName);
            this.panel3.Location = new System.Drawing.Point(298, 14);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(280, 197);
            this.panel3.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Courier New", 12F);
            this.label7.Location = new System.Drawing.Point(14, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "WIFE INFORMATION";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Courier New", 10F);
            this.label8.Location = new System.Drawing.Point(15, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "From:";
            // 
            // tbWifeFrom
            // 
            this.tbWifeFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbWifeFrom.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbWifeFrom.Location = new System.Drawing.Point(15, 137);
            this.tbWifeFrom.Name = "tbWifeFrom";
            this.tbWifeFrom.ReadOnly = true;
            this.tbWifeFrom.Size = new System.Drawing.Size(252, 30);
            this.tbWifeFrom.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Courier New", 10F);
            this.label9.Location = new System.Drawing.Point(15, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 5;
            this.label9.Text = "Full Name:";
            // 
            // tbWifeFullName
            // 
            this.tbWifeFullName.BackColor = System.Drawing.SystemColors.Window;
            this.tbWifeFullName.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbWifeFullName.Location = new System.Drawing.Point(15, 75);
            this.tbWifeFullName.Name = "tbWifeFullName";
            this.tbWifeFullName.ReadOnly = true;
            this.tbWifeFullName.Size = new System.Drawing.Size(252, 30);
            this.tbWifeFullName.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.tbHusbandFrom);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbHusbandFullName);
            this.panel2.Location = new System.Drawing.Point(12, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(280, 197);
            this.panel2.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Courier New", 12F);
            this.label6.Location = new System.Drawing.Point(14, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(238, 22);
            this.label6.TabIndex = 8;
            this.label6.Text = "HUSBAND INFORMATION";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 10F);
            this.label2.Location = new System.Drawing.Point(15, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "From:";
            // 
            // tbHusbandFrom
            // 
            this.tbHusbandFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbHusbandFrom.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbHusbandFrom.Location = new System.Drawing.Point(15, 137);
            this.tbHusbandFrom.Name = "tbHusbandFrom";
            this.tbHusbandFrom.ReadOnly = true;
            this.tbHusbandFrom.Size = new System.Drawing.Size(252, 30);
            this.tbHusbandFrom.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 10F);
            this.label1.Location = new System.Drawing.Point(15, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Full Name:";
            // 
            // tbHusbandFullName
            // 
            this.tbHusbandFullName.BackColor = System.Drawing.SystemColors.Window;
            this.tbHusbandFullName.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbHusbandFullName.Location = new System.Drawing.Point(15, 75);
            this.tbHusbandFullName.Name = "tbHusbandFullName";
            this.tbHusbandFullName.ReadOnly = true;
            this.tbHusbandFullName.Size = new System.Drawing.Size(252, 30);
            this.tbHusbandFullName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Courier New", 12F);
            this.label5.Location = new System.Drawing.Point(26, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 22);
            this.label5.TabIndex = 9;
            this.label5.Text = "Remarks:";
            // 
            // tbRemarks
            // 
            this.tbRemarks.BackColor = System.Drawing.SystemColors.Window;
            this.tbRemarks.Font = new System.Drawing.Font("Courier New", 12F);
            this.tbRemarks.Location = new System.Drawing.Point(27, 251);
            this.tbRemarks.Multiline = true;
            this.tbRemarks.Name = "tbRemarks";
            this.tbRemarks.ReadOnly = true;
            this.tbRemarks.Size = new System.Drawing.Size(538, 54);
            this.tbRemarks.TabIndex = 8;
            this.tbRemarks.Text = "No Remarks";
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
            // lblNonSuperUserIndicator
            // 
            this.lblNonSuperUserIndicator.AutoSize = true;
            this.lblNonSuperUserIndicator.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblNonSuperUserIndicator.Location = new System.Drawing.Point(8, 308);
            this.lblNonSuperUserIndicator.Name = "lblNonSuperUserIndicator";
            this.lblNonSuperUserIndicator.Size = new System.Drawing.Size(529, 20);
            this.lblNonSuperUserIndicator.TabIndex = 21;
            this.lblNonSuperUserIndicator.Text = "**Delete and Update is Disabled for non-superusers**";
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
            // btnEmployeeInfo
            // 
            this.btnEmployeeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmployeeInfo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEmployeeInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEmployeeInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmployeeInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployeeInfo.Image")));
            this.btnEmployeeInfo.Location = new System.Drawing.Point(533, 16);
            this.btnEmployeeInfo.Name = "btnEmployeeInfo";
            this.btnEmployeeInfo.Size = new System.Drawing.Size(30, 30);
            this.btnEmployeeInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnEmployeeInfo.TabIndex = 4;
            this.btnEmployeeInfo.TabStop = false;
            // 
            // FamilyDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 659);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelTitle);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FamilyDetailsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FamilyDetailsForm";
            this.Load += new System.EventHandler(this.FamilyDetailsForm_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHusbandWife.ResumeLayout(false);
            this.panelHusbandWife.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnEmployeeInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Button btnToggleNavPanel;
        private System.Windows.Forms.PictureBox btnEmployeeInfo;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lblBack;
        private System.Windows.Forms.Panel panelHusbandWife;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbWifeFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbWifeFullName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbHusbandFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHusbandFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRemarks;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNonSuperUserIndicator;
    }
}