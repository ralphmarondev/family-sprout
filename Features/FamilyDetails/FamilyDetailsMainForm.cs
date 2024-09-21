using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.Controls;
using FamilySprout.Features.Home;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails
{
    public partial class FamilyDetailsMainForm : Form
    {
        private FamilyModel family = new FamilyModel();
        private ParentModel husband = new ParentModel();
        private ParentModel wife = new ParentModel();
        public FamilyDetailsMainForm(long famId)
        {
            InitializeComponent();
            family.id = famId;
            Console.WriteLine($"FamId: {famId}");

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
            FetchFamilyDetails();
        }

        private void FetchFamilyDetails()
        {
            listPanel.Controls.Clear();
            listPanel.AutoScroll = true;
            int currentY = 10;

            Label lblHusband = new Label();
            lblHusband.AutoSize = true;
            lblHusband.Font = new System.Drawing.Font("Courier New", 14F);
            lblHusband.Location = new System.Drawing.Point(15, currentY);  // Set the label's position inside the panel
            lblHusband.Margin = new Padding(4, 0, 4, 0);
            lblHusband.Name = "lblHusband";
            lblHusband.Size = new System.Drawing.Size(222, 27);  // Optional, as AutoSize will resize it based on the text
            lblHusband.Text = "HUSBAND INFORMATION";
            currentY += lblHusband.Height + 5;

            listPanel.Controls.Add(lblHusband);
            FamilyDetailsUserControl husbandControl = new FamilyDetailsUserControl();

            husbandControl.Location = new Point(10, currentY);
            husbandControl.Width = listPanel.ClientSize.Width - 20;
            husbandControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listPanel.Controls.Add(husbandControl);
            currentY += husbandControl.Height + 10;

            Label lblWife = new Label();
            lblWife.AutoSize = true;
            lblWife.Font = new System.Drawing.Font("Courier New", 14F);
            lblWife.Location = new System.Drawing.Point(15, currentY);  // Set the label's position inside the panel
            lblWife.Margin = new Padding(4, 0, 4, 0);
            lblWife.Name = "lblWife";
            lblWife.Size = new System.Drawing.Size(222, 27);  // Optional, as AutoSize will resize it based on the text
            lblWife.Text = "WIFE INFORMATION";
            currentY += lblWife.Height + 5;

            listPanel.Controls.Add(lblWife);
            FamilyDetailsUserControl familyControl = new FamilyDetailsUserControl();

            familyControl.Location = new Point(10, currentY);
            familyControl.Width = listPanel.ClientSize.Width - 20;
            familyControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listPanel.Controls.Add(familyControl);
            currentY += familyControl.Height + 10;
        }


        #region LABEL_BACK
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamiliesMainForm();
            }
        }
        #endregion LABEL_BACK

        private void btnNext_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenChildrenMainForm(family.id);
            }
        }
    }
}
