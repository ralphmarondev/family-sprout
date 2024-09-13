using FamilySprout.Core.Model;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Controls
{
    public partial class AdminUserControl : UserControl
    {
        public AdminUserControl(
            UserModel user)
        {
            InitializeComponent();

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == 0) ? "SUPERUSER" : "USER";
        }
    }
}
