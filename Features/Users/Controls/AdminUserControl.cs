using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Users.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Controls
{
    public partial class AdminUserControl : UserControl
    {
        private UserModel user;
        public AdminUserControl(UserModel user)
        {
            InitializeComponent();
            lblName.Text = SessionManager.CurrentUser.fullName;
            this.user = user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            ViewUserDialog viewUser = new ViewUserDialog(user);

            viewUser.ShowDialog(this);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateUserDialog updateUser = new UpdateUserDialog(user);

            if (updateUser.ShowDialog(this) == DialogResult.OK)
            {
                UsersMainForm mainForm = ParentForm as UsersMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanel();
                }
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteUserDialog deleteUser = new DeleteUserDialog(user);

            if (deleteUser.ShowDialog(this) == DialogResult.OK)
            {
                UsersMainForm mainForm = ParentForm as UsersMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanel();
                }
            }
        }
    }
}
