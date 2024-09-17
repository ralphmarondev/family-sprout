using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using FamilySprout.Features.Trash.Controls;
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
            SetupPopupPanel();

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
                    familyControl.Width = listOfItemsPanel.ClientSize.Width - 20;
                    familyControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

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
                    userRestoreUserControl.Width = listOfItemsPanel.ClientSize.Width - 20;
                    userRestoreUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    listOfItemsPanel.Controls.Add(userRestoreUserControl);
                    currentY += userRestoreUserControl.Height + 10;
                }
            }
        }


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
            string role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? Roles.SUPERUSER_LABEL : Roles.USER_LABEL;
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


        #region LABEL_DESTINATION
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
        #endregion LABEL_DESTINATION


        #region LABEL_ADMIN_NAME
        private void lblAdminName_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblAdminName_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblAdminName_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }

        private void lblAdminName_Click(object sender, System.EventArgs e)
        {
            lblAdminName_MouseHover(sender, e);
        }
        private void lblAdminName_MouseHover(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }

        private void lblAdminName_MouseLeave(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }
        #endregion LABEL_ADMIN_NAME


        #region BUTTON_CURRENT_USER
        private void btnCurrentUserInfo_Click(object sender, System.EventArgs e)
        {
            HidePopUp();
        }
        private void btnCurrentUserInfo_MouseHover(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }

        private void btnCurrentUserInfo_MouseLeave(object sender, System.EventArgs e)
        {
            TogglePopUp();
        }
        #endregion BUTTON_CURRENT_USER


        #region BUTTON_FULL_SCREEN
        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
                popupPanel.Visible = false;
            }
        }
        #endregion BUTTON_FULL_SCREEN
    }
}
