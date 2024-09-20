using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard
{
    public partial class DashboardMainForm : Form
    {
        public DashboardMainForm()
        {
            InitializeComponent();

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {

        }

        private void btnBackup_Click(object sender, EventArgs e)
        {

        }
    }
}
