using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using FamilySprout.Features.User.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.User
{
    public partial class UserMainForm : Form
    {
        public UserMainForm()
        {
            InitializeComponent();
            SetupPopupPanel();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;

            PopulatePanel();
        }

        List<UserModel> users = new List<UserModel>();
        public void PopulatePanel()
        {
            users.Clear();
            users = DBUsers.GetAllUsers();
            userListPanel.Controls.Clear();
            userListPanel.AutoScroll = true;
            int currentY = 10;

            if (users.Count == 0)
            {
                Label label = new Label();
                label.Text = "No children found!";
                label.Font = new Font("Courier New", 14, FontStyle.Bold);
                label.AutoSize = true;

                // Calculate the position to ensure a 20-pixel padding on each side
                int labelWidth = label.Width;
                int labelHeight = label.Height;

                int panelWidth = userListPanel.ClientSize.Width;
                int panelHeight = userListPanel.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                userListPanel.Controls.Add(label);
            }
            else
            {
                foreach (var user in users)
                {
                    AdminUserControl adminUserControl = new AdminUserControl(user);

                    adminUserControl.Location = new Point(10, currentY);

                    // Set the size of the UserControl based on the parent panel
                    adminUserControl.Width = userListPanel.ClientSize.Width - 20;
                    adminUserControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                    userListPanel.Controls.Add(adminUserControl);
                    currentY += adminUserControl.Height + 10;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dialog.NewUserDialog dialog = new Dialog.NewUserDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                PopulatePanel();
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

        private void btnFullScreen_Click(object sender, EventArgs e)
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
