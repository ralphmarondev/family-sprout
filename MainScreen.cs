using System;
using System.Windows.Forms;

namespace FamilySprout
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            OpenFormInPanel(new Dashboard.DashboardMainScreen());
        }


        #region NAVIGATION
        private void OpenFormInPanel(Form form)
        {
            foreach (Control control in panelNavigation.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            mainPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new Dashboard.DashboardMainScreen());
        }


        private void btnFamilies_Click(object sender, EventArgs e)
        {

        }

        private void btnNewFamily_Click(object sender, EventArgs e)
        {
            OpenFormInPanel(new Families.NewFamily.NewFamilyMainScreen());
        }

        private void btnTrash_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LogoutForm();
        }
        #endregion NAVIGATION



        #region TOP_BAR
        internal void LogoutForm()
        {
            Close();
        }

        internal void ToggleFullScreen()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                // full screen
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        internal void ToggleNavigationPanel()
        {
            if (panelNavigation.Visible)
            {
                panelNavigation.Visible = false;
            }
            else
            {
                panelNavigation.Visible = true;
            }
        }
        #endregion TOP_BAR
    }
}
