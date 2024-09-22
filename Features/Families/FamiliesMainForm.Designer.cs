namespace FamilySprout.Features.Families
{
    partial class FamiliesMainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearchWife = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSelectedHometown = new System.Windows.Forms.ComboBox();
            this.lblSearchText = new System.Windows.Forms.Label();
            this.tbSearchHusband = new System.Windows.Forms.TextBox();
            this.lblEmpty = new System.Windows.Forms.Label();
            this.dataGridViewFamilies = new System.Windows.Forms.DataGridView();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).BeginInit();
            this.mainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilies)).BeginInit();
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
            this.panelTitle.TabIndex = 24;
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(12, 25);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(106, 22);
            this.lblDestination.TabIndex = 7;
            this.lblDestination.Text = "FAMILIES";
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
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(this.panel1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 68);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(930, 591);
            this.mainPanel.TabIndex = 25;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbSearchWife);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbSelectedHometown);
            this.panel1.Controls.Add(this.lblSearchText);
            this.panel1.Controls.Add(this.tbSearchHusband);
            this.panel1.Controls.Add(this.lblEmpty);
            this.panel1.Controls.Add(this.dataGridViewFamilies);
            this.panel1.Location = new System.Drawing.Point(22, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 546);
            this.panel1.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 10F);
            this.label2.Location = new System.Drawing.Point(250, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "SEARCH WIFE:";
            // 
            // tbSearchWife
            // 
            this.tbSearchWife.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbSearchWife.Location = new System.Drawing.Point(253, 30);
            this.tbSearchWife.Name = "tbSearchWife";
            this.tbSearchWife.Size = new System.Drawing.Size(209, 34);
            this.tbSearchWife.TabIndex = 7;
            this.tbSearchWife.TextChanged += new System.EventHandler(this.tbSearchWife_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 10F);
            this.label1.Location = new System.Drawing.Point(634, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "SELECT HOMETOWN";
            // 
            // tbSelectedHometown
            // 
            this.tbSelectedHometown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSelectedHometown.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbSelectedHometown.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSelectedHometown.FormattingEnabled = true;
            this.tbSelectedHometown.Items.AddRange(new object[] {
            "MALUBIBIT NORTE",
            "MALUBIBIT SUR",
            "POB. WEST",
            "POB. EAST",
            "ALLIG",
            "BALLUYAN",
            "STA. MARIA",
            "ANNINIPAN"});
            this.tbSelectedHometown.Location = new System.Drawing.Point(638, 31);
            this.tbSelectedHometown.Name = "tbSelectedHometown";
            this.tbSelectedHometown.Size = new System.Drawing.Size(209, 33);
            this.tbSelectedHometown.TabIndex = 4;
            this.tbSelectedHometown.TextChanged += new System.EventHandler(this.tbSelectedHometown_TextChanged);
            // 
            // lblSearchText
            // 
            this.lblSearchText.AutoSize = true;
            this.lblSearchText.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblSearchText.Location = new System.Drawing.Point(24, 10);
            this.lblSearchText.Name = "lblSearchText";
            this.lblSearchText.Size = new System.Drawing.Size(159, 20);
            this.lblSearchText.TabIndex = 2;
            this.lblSearchText.Text = "SEARCH HUSBAND:";
            // 
            // tbSearchHusband
            // 
            this.tbSearchHusband.Font = new System.Drawing.Font("Courier New", 14F);
            this.tbSearchHusband.Location = new System.Drawing.Point(28, 30);
            this.tbSearchHusband.Name = "tbSearchHusband";
            this.tbSearchHusband.Size = new System.Drawing.Size(209, 34);
            this.tbSearchHusband.TabIndex = 3;
            this.tbSearchHusband.TextChanged += new System.EventHandler(this.tbSearchHusband_TextChanged);
            // 
            // lblEmpty
            // 
            this.lblEmpty.AutoSize = true;
            this.lblEmpty.Font = new System.Drawing.Font("Courier New", 18F);
            this.lblEmpty.Location = new System.Drawing.Point(150, 236);
            this.lblEmpty.Name = "lblEmpty";
            this.lblEmpty.Size = new System.Drawing.Size(555, 33);
            this.lblEmpty.TabIndex = 1;
            this.lblEmpty.Text = "TABLE IS EMPTY. NO DATA FOUND!";
            // 
            // dataGridViewFamilies
            // 
            this.dataGridViewFamilies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFamilies.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewFamilies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewFamilies.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewFamilies.ColumnHeadersHeight = 50;
            this.dataGridViewFamilies.Location = new System.Drawing.Point(28, 70);
            this.dataGridViewFamilies.MultiSelect = false;
            this.dataGridViewFamilies.Name = "dataGridViewFamilies";
            this.dataGridViewFamilies.RowHeadersWidth = 51;
            this.dataGridViewFamilies.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewFamilies.Size = new System.Drawing.Size(821, 452);
            this.dataGridViewFamilies.TabIndex = 0;
            // 
            // FamiliesMainForm
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
            this.Name = "FamiliesMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FamiliesMainForm";
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCurrentUserInfo)).EndInit();
            this.mainPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFamilies)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.DataGridView dataGridViewFamilies;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tbSelectedHometown;
        private System.Windows.Forms.Label lblSearchText;
        private System.Windows.Forms.TextBox tbSearchHusband;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearchWife;
    }
}