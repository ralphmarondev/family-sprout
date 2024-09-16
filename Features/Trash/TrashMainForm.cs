using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
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
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
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

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;
        }
        #endregion DRAG_AND_DROP

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
                popupPanel.Visible = false;
            }
        }


        private Panel popupPanel;
        private void SetupPopupPanel()
        {
            // Initialize the panel
            popupPanel = new Panel();
            popupPanel.Size = new Size(340, 100);
            popupPanel.BackColor = Color.Lavender;

            // You can add controls inside the popup panel if needed
            Label lblInfo = new Label
            {
                Text = SessionManager.CurrentUser.fullName,
                AutoSize = true,
                Location = new Point(10, 10)
            };
            Label lblInfo2 = new Label
            {
                Text = SessionManager.CurrentUser.username,
                AutoSize = true,
                Location = new Point(10, lblInfo.Bottom + 5)
            };
            string role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? "SUPERUSER" : "USER";
            Label lblInfo3 = new Label
            {
                Text = role,
                AutoSize = true,
                Location = new Point(10, lblInfo2.Bottom + 5)
            };

            popupPanel.Controls.Add(lblInfo);
            popupPanel.Controls.Add(lblInfo2);
            popupPanel.Controls.Add(lblInfo3);

            // Initially hide the panel
            popupPanel.Visible = false;

            // Add the panel to the form's controls
            this.Controls.Add(popupPanel);
        }
        private void btnCurrentUserInfo_Click(object sender, System.EventArgs e)
        {
            // Toggle popup visibility
            popupPanel.Visible = !popupPanel.Visible;

            // Set the location of the popup panel below the button
            var buttonLocation = btnCurrentUserInfo.PointToScreen(Point.Empty);
            popupPanel.Location = this.PointToClient(new Point(buttonLocation.X, buttonLocation.Y + btnCurrentUserInfo.Height));
            popupPanel.BringToFront();
        }

    }
}
