using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Children.Controls;
using FamilySprout.Features.Children.DB;
using FamilySprout.Features.Children.Dialog;
using FamilySprout.Features.Home;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Children
{
    public partial class ChildrenMainForm : Form
    {
        private List<ChildModel> children = new List<ChildModel>();
        private long famId;
        public ChildrenMainForm(long famId)
        {
            InitializeComponent();

            this.famId = famId;
            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;

            // user role check
            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                btnNewChild.Visible = false;
            }

            FetchChildren();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyDetailsMainForm(famId);
            }
        }

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }


        #region GET_ALL_CHILDRENS
        public void FetchChildren()
        {
            children.Clear();
            children = DBChildren.GetAllChildren(famId);
            listPanel.Controls.Clear();
            listPanel.AutoScroll = true;
            int currentY = 10;

            if (children.Count == 0)
            {
                Label label = new Label();
                label.Text = "No children found!";
                label.Font = new Font("Courier New", 14, FontStyle.Bold);
                label.AutoSize = true;

                // Calculate the position to ensure a 20-pixel padding on each side
                int labelWidth = label.Width;
                int labelHeight = label.Height;

                int panelWidth = listPanel.ClientSize.Width;
                int panelHeight = listPanel.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                listPanel.Controls.Add(label);
            }
            else
            {
                foreach (var child in children)
                {
                    ChildUserControl childUserControl = new ChildUserControl(child);

                    childUserControl.Location = new Point(10, currentY);
                    childUserControl.Width = listPanel.ClientSize.Width - 20;
                    childUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    listPanel.Controls.Add(childUserControl);
                    currentY += childUserControl.Height + 10;
                }
            }
        }
        #endregion GET_ALL_CHILDRENS

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildDialog newChild = new NewChildDialog(famId);

            if (newChild.ShowDialog(this) == DialogResult.OK)
            {
                FetchChildren();
            }
        }
    }
}
