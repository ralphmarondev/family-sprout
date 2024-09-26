using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using FamilySprout.Features.Trash.Children.Controls;
using FamilySprout.Features.Trash.DB;
using FamilySprout.Features.Trash.Families.Controls;
using FamilySprout.Features.Trash.Users.Controls;
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
            SetupPopupPanel();

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
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




        #region USER_INTERFACE

        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void OnMouseUp()
        {
            dragging = false;
        }

        private void OnMouseMove()
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                MainForm mainScreen = this.ParentForm as MainForm;

                if (mainScreen != null)
                {
                    mainScreen.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            }
        }

        private void OnMouseDown()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;
        }
        #endregion DRAG_AND_DROP


        #region POP_UP
        private Panel popupPanel;
        private void SetupPopupPanel()
        {
            popupPanel = new Panel();
            popupPanel.Size = new Size(340, 100);
            popupPanel.BackColor = Color.Lavender;

            Label lblInfo = new Label
            {
                Text = SessionManager.CurrentUser.fullName,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = SessionManager.CurrentUser.username,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            string role = (SessionManager.CurrentUser.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
            Label lblInfo3 = new Label
            {
                Text = role,
                Font = new Font("Courier New", 12),
                AutoSize = true,
                Location = new Point(10, lblInfo2.Bottom + 5)
            };

            popupPanel.Controls.Add(lblInfo);
            popupPanel.Controls.Add(lblInfo2);
            popupPanel.Controls.Add(lblInfo3);

            // Initially hide the panel
            popupPanel.Visible = false;
            this.Controls.Add(popupPanel);
        }

        private void TogglePopUp()
        {
            popupPanel.Visible = !popupPanel.Visible;

            var buttonLocation = btnCurrentUserInfo.PointToScreen(Point.Empty);
            popupPanel.Location = this.PointToClient(new Point(buttonLocation.X, buttonLocation.Y + btnCurrentUserInfo.Height));
            popupPanel.BringToFront();
        }

        private void HidePopUp()
        {
            popupPanel.Visible = false;
        }

        private void DashboardMainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (popupPanel.Visible)
            {
                Point clickLocation = this.PointToClient(Cursor.Position);

                if (!popupPanel.Bounds.Contains(clickLocation))
                {
                    popupPanel.Visible = false;
                }
            }
        }
        #endregion POP_UP


        #region PANEL_TITLE
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion PANEL_TITLE


        #region DESTINATION
        private void lblDestination_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblDestination_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblDestination_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion DESTINATION


        #region LABEL_CURRENT_USER
        private void lblCurrentUser_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblCurrentUser_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblCurrentUser_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_CURRENT_USER


        #region BUTTON_CURRENT_USER_INFO
        private void btnCurrentUserInfo_MouseHover(object sender, EventArgs e)
        {

            TogglePopUp();
        }

        private void btnCurrentUserInfo_MouseLeave(object sender, EventArgs e)
        {
            HidePopUp();
        }
        #endregion BUTTON_CURRENT_USER_INFO

        #endregion USER_INTERFACE


        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }
    }
}
