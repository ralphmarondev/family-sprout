using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Shared.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash
{
    public partial class TrashMainForm : Form
    {
        public TrashMainForm()
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            lblDestination.Text = "TRASH/FAMILIES";
            PopulatePanelWithDeletedFamilies();
        }

        private void btnFamilies_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/FAMILIES";
            PopulatePanelWithDeletedFamilies();
        }

        private void btnParents_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/PARENTS";
        }

        private void btnChildrens_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/CHILDRENS";
        }

        private void btnUsers_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/USERS";
            PopulatePanelWithDeletedUsers();
        }


        List<FamilyModel> deletedFamilies = new List<FamilyModel>();
        List<UserModel> deletedUsers = new List<UserModel>();
        private void PopulatePanelWithDeletedFamilies()
        {
            deletedFamilies.Clear();
            deletedFamilies = DBFamily.GetDeletedFamilies();
            listOfItemsPanel.Controls.Clear();
            listOfItemsPanel.AutoScroll = true;
            int currentY = 10;

            if (deletedFamilies.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Courier New", 18F);
                lblEmpty.Location = new Point(164, 201);  // Adjust the location as needed
                lblEmpty.Name = "lblEmpty";
                lblEmpty.Size = new Size(483, 33);
                lblEmpty.TabIndex = 0;
                lblEmpty.Text = "NO DELETED FAMILIES FOUND!";

                listOfItemsPanel.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var family in deletedFamilies)
                {
                    Controls.FamilyRestoreUserControl familyControl = new Controls.FamilyRestoreUserControl(
                        _famId: family.id,
                        _husband: family.husband,
                        _wife: family.wife
                        );

                    familyControl.Location = new System.Drawing.Point(10, currentY);
                    listOfItemsPanel.Controls.Add(familyControl);
                    currentY += familyControl.Height + 10;
                }
            }
        }

        private void PopulatePanelWithDeletedUsers()
        {
            deletedUsers.Clear();
            listOfItemsPanel.Controls.Clear();
            listOfItemsPanel.AutoScroll = true;
            int currentY = 10;

            if (deletedUsers.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Courier New", 18F);
                lblEmpty.Location = new Point(164, 201);  // Adjust the location as needed
                lblEmpty.Name = "lblEmpty";
                lblEmpty.Size = new Size(483, 33);
                lblEmpty.TabIndex = 0;
                lblEmpty.Text = "NO DELETED USERS FOUND!";

                listOfItemsPanel.Controls.Add(lblEmpty);
            }
        }
    }
}
