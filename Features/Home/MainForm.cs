using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Home
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            OpenDashboard();
        }


        #region NAVIGATION_BUTTONS
        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenDashboard();
        }

        private void btnFamilies_Click(object sender, EventArgs e)
        {

        }

        private void btnNewFamily_Click(object sender, EventArgs e)
        {
            OpenNewFamilyMainForm();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {

        }

        private void btnTrash_Click(object sender, EventArgs e)
        {

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

        public void OpenNewFamilyMainForm()
        {
            OpenFormInPanel(new NewFamily.NewFamilyMainScreen());
        }
        #endregion NAVIGATION

    }
}
