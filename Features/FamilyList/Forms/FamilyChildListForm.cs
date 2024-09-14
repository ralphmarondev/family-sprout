using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using FamilySprout.Features.NewFamily.Controls;
using FamilySprout.Features.NewFamily.Dialog;
using FamilySprout.Shared.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Forms
{
    public partial class FamilyChildListForm : Form
    {
        private FamilyModel familyModel;
        public FamilyChildListForm(
            FamilyModel _familyModel
            )
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;

            if (SessionManager.CurrentUser.role == 1)
            {
                btnNewChild.Enabled = false;
            }

            familyModel = _familyModel;
            PopulatePanel();
        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyDetailsForm(_famId: familyModel.id);
            }
        }

        private void PopulatePanel()
        {
            childListPanel.Controls.Clear();
            childListPanel.AutoScroll = true;
            int currentY = 10;

            if (familyModel.childrens.Count == 0)
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
                foreach (var child in familyModel.childrens)
                {
                    ChildUserControl childUserControl = new ChildUserControl(
                        _id: child.id,
                        _name: child.name,
                        _bday: child.bday,
                        _baptism: child.baptism,
                        _hc: child.hc,
                        _obitus: child.obitus,
                        _matrimony: child.matrimony
                        );

                    childUserControl.Location = new Point(10, currentY);
                    childListPanel.Controls.Add(childUserControl);
                    currentY += childUserControl.Height + 10;
                }
            }
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildDialog newChild = new NewChildDialog(familyModel.id);

            if (newChild.ShowDialog(this) == DialogResult.OK)
            {
                PopulatePanel();
            }
        }
    }
}
