using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Home;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard
{
    public partial class DashboardMainScreen : Form
    {
        public DashboardMainScreen()
        {
            InitializeComponent();
            SetupPopupPanel();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            var role = (SessionManager.CurrentUser.role == Roles.SUPERUSER) ? "SUPERUSER" : "USER";
            lblGreetings.Text = $"Hello, {SessionManager.CurrentUser.fullName} [{role}]";

            lblFamiliesCount.Text = $"{DBFamily.GetTotalFamilyCount()}";
            lblChildrenCount.Text = $"{DBChildren.GetTotalChildCount()}";
            lblUserCount.Text = $"{DBUsers.GetTotalUserCount()}";
        }

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
                popupPanel.Visible = false;
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

        private void DashboardMainScreen_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the popup is visible and if the click is outside of the panel
            if (popupPanel.Visible)
            {
                Point clickLocation = this.PointToClient(Cursor.Position);

                // If the click is outside the bounds of the popup panel, hide it
                if (!popupPanel.Bounds.Contains(clickLocation))
                {
                    popupPanel.Visible = false;
                }
            }
        }
    }
}
