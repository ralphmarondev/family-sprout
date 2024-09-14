using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.Controls;
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

        private void btnChildrens_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/CHILDRENS";
            PopulatePanelWithDeletedChildrens();
        }

        private void btnUsers_Click(object sender, System.EventArgs e)
        {
            lblDestination.Text = "TRASH/USERS";
            PopulatePanelWithDeletedUsers();
        }


        List<FamilyModel> deletedFamilies = new List<FamilyModel>();
        List<ChildModel> deletedChildren = new List<ChildModel>();
        List<UserModel> deletedUsers = new List<UserModel>();
        public void PopulatePanelWithDeletedFamilies()
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
                    FamilyRestoreUserControl familyControl = new FamilyRestoreUserControl(family);

                    familyControl.Location = new System.Drawing.Point(10, currentY);
                    listOfItemsPanel.Controls.Add(familyControl);
                    currentY += familyControl.Height + 10;
                }
            }
        }

        public void PopulatePanelWithDeletedChildrens()
        {
            deletedChildren.Clear();
            deletedChildren = DBChildren.GetAllDeletedChildren();
            listOfItemsPanel.Controls.Clear();
            listOfItemsPanel.AutoScroll = true;
            int currentY = 10;

            if (deletedChildren.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.AutoSize = true;
                lblEmpty.Font = new Font("Courier New", 18F);
                lblEmpty.Location = new Point(164, 201);  // Adjust the location as needed
                lblEmpty.Name = "lblEmpty";
                lblEmpty.Size = new Size(483, 33);
                lblEmpty.TabIndex = 0;
                lblEmpty.Text = "NO DELETED CHILDREN FOUND!";

                listOfItemsPanel.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var family in deletedChildren)
                {
                    ChildRestoreUserControl childRestoreUserControl = new ChildRestoreUserControl(family);

                    childRestoreUserControl.Location = new Point(10, currentY);
                    listOfItemsPanel.Controls.Add(childRestoreUserControl);
                    currentY += childRestoreUserControl.Height + 10;
                }
            }
        }

        public void PopulatePanelWithDeletedUsers()
        {
            deletedUsers.Clear();
            deletedUsers = DBUsers.GetAllDeletedUsers();
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
            else
            {
                foreach (var user in deletedUsers)
                {
                    UserRestoreUserControl userRestoreUserControl = new UserRestoreUserControl(user);

                    userRestoreUserControl.Location = new Point(10, currentY);
                    listOfItemsPanel.Controls.Add(userRestoreUserControl);
                    currentY += userRestoreUserControl.Height + 10;
                }
            }
        }
    }
}
