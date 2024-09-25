using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.Children.Controls;
using FamilySprout.Features.Trash.DB;
using FamilySprout.Features.Trash.Families.Controls;
using FamilySprout.Features.Trash.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash
{
    public partial class TrashMainForm : Form
    {
        private const string FAMILY_LABEL = "TRASH/FAMILIES";
        private const string CHILDREN_LABEL = "TRASH/CHILDREN";
        private const string USER_LABEL = "TRASH/USERS";
        public TrashMainForm()
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            lblDestination.Text = FAMILY_LABEL;
            PopulatePanelWithDeletedFamilies();
        }

        private void btnFamilies_Click(object sender, EventArgs e)
        {
            lblDestination.Text = FAMILY_LABEL;
            PopulatePanelWithDeletedFamilies();
        }

        private void btnChildrens_Click(object sender, EventArgs e)
        {
            lblDestination.Text = CHILDREN_LABEL;
            PopulatePanelWithDeletedChildren();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            lblDestination.Text = USER_LABEL;
            PopulatePanelWithDeletedUsers();
        }


        #region POPULATE_PANEL
        List<FamilyModel> deletedFamilies = new List<FamilyModel>();
        List<ChildModel> deletedChildren = new List<ChildModel>();
        List<UserModel> deletedUsers = new List<UserModel>();
        public void PopulatePanelWithDeletedFamilies()
        {
            deletedFamilies.Clear();
            deletedFamilies = DBTrash.GetDeletedFamilies();
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
                    TrashFamilyUserControl familyControl = new TrashFamilyUserControl(family);

                    familyControl.Location = new System.Drawing.Point(10, currentY);
                    familyControl.Width = listOfItemsPanel.ClientSize.Width - 20;
                    familyControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    listOfItemsPanel.Controls.Add(familyControl);
                    currentY += familyControl.Height + 10;
                }
            }
        }
        public void PopulatePanelWithDeletedChildren()
        {
            deletedChildren.Clear();
            deletedChildren = DBTrash.GetDeletedChildren();
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
                foreach (var child in deletedChildren)
                {
                    TrashChildUserControl childRestoreUserControl = new TrashChildUserControl(child);

                    childRestoreUserControl.Location = new Point(10, currentY);
                    childRestoreUserControl.Width = listOfItemsPanel.ClientSize.Width - 20;
                    childRestoreUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    listOfItemsPanel.Controls.Add(childRestoreUserControl);
                    currentY += childRestoreUserControl.Height + 10;
                }
            }
        }

        public void PopulatePanelWithDeletedUsers()
        {
            deletedUsers.Clear();
            deletedUsers = DBTrash.GetDeletedUsers();
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
                    TrashUsersUserControl userRestoreUserControl = new TrashUsersUserControl(user);

                    userRestoreUserControl.Location = new Point(10, currentY);
                    userRestoreUserControl.Width = listOfItemsPanel.ClientSize.Width - 20;
                    userRestoreUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    listOfItemsPanel.Controls.Add(userRestoreUserControl);
                    currentY += userRestoreUserControl.Height + 10;
                }
            }
        }
        #endregion POPULATE_PANEL
    }
}
