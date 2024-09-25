using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Users
{
    public partial class TrashUsersUserControl : UserControl
    {
        private UserModel user;
        public TrashUsersUserControl(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }
    }
}
