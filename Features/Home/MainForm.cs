using FamilySprout.Core.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Home
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            OpenDashboard();

            // user role check
            if (SessionManager.CurrentUser.role == Constants.User.USER)
            {
                btnNewFamily.Visible = false;
                btnUsers.Visible = false;
                btnTrash.Visible = false;
            }
        }


        #region NAVIGATION_BUTTONS
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void btnFamilies_Click(object sender, EventArgs e)
        {
            OpenFamiliesMainForm();
        }

        private void btnNewFamily_Click(object sender, EventArgs e)
        {
            OpenNewFamilyMainForm();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new Users.UsersMainForm());
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new Trash.TrashMainForm());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Auth.AuthMainForm auth = new Auth.AuthMainForm();

            Hide();
            auth.Show();
        }
        #endregion NAVIGATION_BUTTONS


        #region NAVIGATION
        private void OpenFormInPanel(Form form)
        {
            mainPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            mainPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        public void OpenDashboard()
        {
            OpenFormInPanel(new Dashboard.DashboardMainForm());
        }

        public void OpenFamiliesMainForm()
        {
            OpenFormInPanel(new Families.FamiliesMainForm());
        }

        public void OpenFamilyDetailsMainForm(long famId)
        {
            OpenFormInPanel(new FamilyDetails.FamilyDetailsMainForm(famId));
        }

        public void OpenNewFamilyMainForm()
        {
            OpenFormInPanel(new NewFamily.NewFamilyMainScreen());
        }

        public void OpenChildrenMainForm(long famId)
        {
            OpenFormInPanel(new Children.ChildrenMainForm(famId));
        }
        #endregion NAVIGATION


        #region TOP_BAR
        public void ToggleFullScreen()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        #endregion TOP_BAR


        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void OnMouseUp()
        {
            dragging = false;
        }

        private void OnMouseDown()
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void OnMouseMove()
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }
        #endregion DRAG_AND_DROP


        #region PANEL_LOGO
        private void panelLogo_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void panelLogo_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion PANEL_LOGO


        #region LABEL_LOGO
        private void lblLogo_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp();
        }

        private void lblLogo_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove();
        }

        private void lblLogo_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown();
        }
        #endregion LABEL_LOGO
    }
}
