using FamilySprout.Core.DB;
using FamilySprout.Features.NewFamily.Controls;
using FamilySprout.Features.NewFamily.Dialog;
using FamilySprout.Shared.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Forms
{
    public partial class NewChildForm : Form
    {
        private long famId;
        public NewChildForm()
        {
            InitializeComponent();
        }

        public NewChildForm(long _famId)
        {
            InitializeComponent();

            famId = _famId;
            FetchData();
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildDialog newChild = new NewChildDialog(famId);

            if (newChild.ShowDialog(this) == DialogResult.OK)
            {
                FetchData();
            }
        }

        List<ChildModel> childrens = new List<ChildModel>();
        public void FetchData()
        {
            childrens.Clear();
            childrens = DBChildren.GetChildrenByFamilyId(famId);
            panelChildrenList.Controls.Clear();
            panelChildrenList.AutoScroll = true;
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

                int panelWidth = panelChildrenList.ClientSize.Width;
                int panelHeight = panelChildrenList.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                panelChildrenList.Controls.Add(label);
            }
            else
            {
                foreach (var child in childrens)
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
                    panelChildrenList.Controls.Add(childUserControl);
                    currentY += childUserControl.Height + 10;
                }
            }
        }
    }
}
