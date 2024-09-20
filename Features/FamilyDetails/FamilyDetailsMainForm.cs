using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails
{
    public partial class FamilyDetailsMainForm : Form
    {
        private long famId;
        private FamilyModel family = new FamilyModel();
        public FamilyDetailsMainForm(long famId)
        {
            InitializeComponent();
            this.famId = famId;
            Console.WriteLine($"FamId: {famId}");

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
            FetchFamilyDetails();
        }

        private void FetchFamilyDetails()
        {
            listPanel.Controls.Clear();
            listPanel.AutoScroll = true;
            int currentY = 10;


            for (int i = 0; i < 10; i++)
            {
                FamilyDetailsUserControl familyControl = new FamilyDetailsUserControl();

                familyControl.Location = new Point(10, currentY);
                familyControl.Width = listPanel.ClientSize.Width - 20;
                familyControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                listPanel.Controls.Add(familyControl);
                currentY += familyControl.Height + 10;
            }
        }
    }
}
