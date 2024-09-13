using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.Dashboard
{
    public partial class DashboardMainScreen : Form
    {
        public DashboardMainScreen()
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
        }
    }
}
