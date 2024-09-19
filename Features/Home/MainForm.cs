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

            if (SessionManager.CurrentUser.role == Roles.USER)
            {
                btnNewFamily.Enabled = false;
                btnTrash.Enabled = false;
                btnUsers.Enabled = false;
            }
        }


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

        public void OpenNewFamilyMainForm()
        {
            OpenFormInPanel(new NewFamily.NewFamilyMainForm());
        }

        public void OpenNewChildrenForm(long famId)
        {
            OpenFormInPanel(new NewFamily.Forms.NewChildForm(famId));
        }

        public void OpenFamilyListForm()
        {
            OpenFormInPanel(new FamilyList.FamilyListMainForm());
        }

        public void OpenFamilyDetailsForm(long famId)
        {
            OpenFormInPanel(new FamilyList.Forms.FamilyDetailsForm(famId));
        }

        public void OpenFamilyChildListForm(long famId)
        {
            OpenFormInPanel(new FamilyList.Forms.FamilyChildListForm(famId));
        }

        public void OpenTrashMainForm()
        {
            OpenFormInPanel(new Trash.TrashMainForm());
        }

        public void OpenUserMainForm()
        {
            OpenFormInPanel(new User.UserMainForm());
        }
        public void OpenDashboard()
        {
            OpenFormInPanel(new Dashboard.DashboardMainScreen());
        }
        #endregion NAVIGATION


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
