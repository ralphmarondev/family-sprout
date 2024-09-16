using FamilySprout.Core.Utils;
using FamilySprout.Features.Auth;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.Home
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            OpenDashboard();

            if (SessionManager.CurrentUser.role == 1)
            {
                btnNewFamily.Enabled = false;
                btnTrash.Enabled = false;
                btnUsers.Enabled = false;
            }
        }

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

        public void OpenNewFamilyMainForm()
        {
            OpenFormInPanel(new Features.NewFamily.NewFamilyMainForm());
        }

        public void OpenNewChildrenForm(long _famId)
        {
            OpenFormInPanel(new Features.NewFamily.Forms.NewChildForm(_famId: _famId));
        }

        public void OpenFamilyListForm()
        {
            OpenFormInPanel(new Features.FamilyList.FamilyListMainForm());
        }

        public void OpenFamilyDetailsForm(long _famId)
        {
            OpenFormInPanel(new Features.FamilyList.Forms.FamilyDetailsForm(_famId: _famId));
        }

        public void OpenFamilyChildListForm(long _famId)
        {
            OpenFormInPanel(new Features.FamilyList.Forms.FamilyChildListForm(_famId));
        }

        public void OpenTrashMainForm()
        {
            OpenFormInPanel(new Features.Trash.TrashMainForm());
        }

        public void OpenUserMainForm()
        {
            OpenFormInPanel(new Features.User.UserMainForm());
        }
        public void OpenDashboard()
        {
            OpenFormInPanel(new Features.Dashboard.DashboardMainScreen());
        }



        #region NAVIGATION_BUTTON_CLICKS
        private void btnFamilies_Click(object sender, System.EventArgs e)
        {
            OpenFamilyListForm();
        }

        private void btnNewFamily_Click(object sender, System.EventArgs e)
        {
            OpenNewFamilyMainForm();
        }
        private void btnUsers_Click(object sender, System.EventArgs e)
        {
            OpenUserMainForm();
        }
        private void btnLogout_Click(object sender, System.EventArgs e)
        {
            Close();
            AuthenticationForm authenticationForm = new AuthenticationForm();

            authenticationForm.Show();
        }
        private void btnTrash_Click(object sender, System.EventArgs e)
        {
            OpenTrashMainForm();
        }
        private void btnDashboard_Click(object sender, System.EventArgs e)
        {
            OpenDashboard();
        }
        #endregion NAVIGATION_BUTTON_CLICKS


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
        private void panelLogo_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
        #endregion DRAG_AND_DROP

        private void lblLogo_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lblLogo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(diff));
            }
        }

        private void lblLogo_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }
    }
}
