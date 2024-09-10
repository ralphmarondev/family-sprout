namespace FamilySprout.Families.FamiliesList.Components
{
    partial class ChildControlFL
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
            this.lblChildBirthday = new System.Windows.Forms.Label();
            this.lblChildName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.lblChildBirthday);
            this.panel1.Controls.Add(this.lblChildName);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(7, 9);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 65);
            this.panel1.TabIndex = 2;
            // 
            // lblChildBirthday
            // 
            this.lblChildBirthday.AutoSize = true;
            this.lblChildBirthday.Font = new System.Drawing.Font("Courier New", 14F);
            this.lblChildBirthday.Location = new System.Drawing.Point(4, 29);
            this.lblChildBirthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChildBirthday.Name = "lblChildBirthday";
            this.lblChildBirthday.Size = new System.Drawing.Size(208, 27);
            this.lblChildBirthday.TabIndex = 9;
            this.lblChildBirthday.Text = "Child Birthday";
            // 
            // lblChildName
            // 
            this.lblChildName.AutoSize = true;
            this.lblChildName.Font = new System.Drawing.Font("Courier New", 14F);
            this.lblChildName.Location = new System.Drawing.Point(4, 7);
            this.lblChildName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChildName.Name = "lblChildName";
            this.lblChildName.Size = new System.Drawing.Size(152, 27);
            this.lblChildName.TabIndex = 8;
            this.lblChildName.Text = "CHILD Name";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEdit.BackgroundImage = global::FamilySprout.Properties.Resources.icons8_full_screen_48;
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.ForeColor = System.Drawing.Color.Purple;
            this.btnEdit.Location = new System.Drawing.Point(495, 12);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.MaximumSize = new System.Drawing.Size(300, 94);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(45, 41);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // ChildControlFL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Purple;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ChildControlFL";
            this.Size = new System.Drawing.Size(564, 83);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblChildBirthday;
        private System.Windows.Forms.Label lblChildName;
        private System.Windows.Forms.Button btnEdit;
    }
}
