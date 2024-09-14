using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyList.Controls;
using FamilySprout.Features.Home;
using FamilySprout.Features.NewFamily.Dialog;
using FamilySprout.Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Forms
{
    public partial class FamilyChildListForm : Form
    {
        private List<ChildModel> childrens = new List<ChildModel>();
        private long famId;
        public FamilyChildListForm(
            long _famId
            )
        {
            InitializeComponent();

            famId = _famId;
            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            lblNonSuperUserIndicator.Visible = false;

            if (SessionManager.CurrentUser.role == Roles.USER)
            {
                btnNewChild.Enabled = false;
                lblNonSuperUserIndicator.Visible = true;
            }

            childrens = DBChildren.GetChildrenByFamilyId(famId);
            PopulatePanel();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyDetailsForm(famId);
            }
        }

        public void PopulatePanel()
        {
            childrens.Clear();
            childrens = DBChildren.GetChildrenByFamilyId(famId);
            childListPanel.Controls.Clear();
            childListPanel.AutoScroll = true;
            int currentY = 10;

            if (childrens.Count == 0)
            {
                Label label = new Label();
                label.Text = "No children found!";
                label.Font = new Font("Courier New", 14, FontStyle.Bold);
                label.AutoSize = true;

                // Calculate the position to ensure a 20-pixel padding on each side
                int labelWidth = label.Width;
                int labelHeight = label.Height;

                int panelWidth = childListPanel.ClientSize.Width;
                int panelHeight = childListPanel.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                childListPanel.Controls.Add(label);
            }
            else
            {
                foreach (var child in childrens)
                {
                    FamilyChildUserControl childUserControl = new FamilyChildUserControl(child);

                    childUserControl.Location = new Point(10, currentY);
                    childListPanel.Controls.Add(childUserControl);
                    currentY += childUserControl.Height + 10;
                }
            }
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildDialog newChild = new NewChildDialog(famId);

            if (newChild.ShowDialog(this) == DialogResult.OK)
            {
                PopulatePanel();
            }
        }
    }
}
