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

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            lblGreetings.Text = $"Hello, {SessionManager.CurrentUser.fullName}";
        }

        private void btnFullScreen_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
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

    }
}
