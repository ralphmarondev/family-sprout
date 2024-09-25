using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Controls
{
    public partial class AdminUserControl : UserControl
    {
        private UserModel user;
        public AdminUserControl(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {

        }
    }
}
