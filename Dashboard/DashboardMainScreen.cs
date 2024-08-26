using FamilySprout.Core.Helper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Dashboard
{
    public partial class DashboardMainScreen : Form
    {
        public DashboardMainScreen()
        {
            InitializeComponent();
        }

        private void DashboardMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();
        }



        #region TOPBAR
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = this.ParentForm as MainScreen;

            if (mainScreen != null)
            {
                mainScreen.ToggleFullScreen();
            }
        }

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = this.ParentForm as MainScreen;

            if (mainScreen != null)
            {
                mainScreen.LogoutForm();
            }
        }

        private void btnToggleNavPanel_Click(object sender, EventArgs e)
        {
            MainScreen mainScreen = this.ParentForm as MainScreen;

            if (mainScreen != null)
            {
                mainScreen.ToggleNavigationPanel();
            }
        }
        #endregion TOPBAR



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
                MainScreen mainScreen = this.ParentForm as MainScreen;

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
    }
}
