using FamilySprout.Core.Model;
using FamilySprout.Features.User.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Controls
{
    public partial class AdminUserControl : UserControl
    {
        private UserModel user;
        public AdminUserControl(
            UserModel _user)
        {
            InitializeComponent();
            user = _user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == 0) ? "SUPERUSER" : "USER";
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
                UserMainForm userMainForm = this.ParentForm as UserMainForm;

                if (userMainForm != null)
                {
                    userMainForm.PopulatePanel();
                }
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteUserDialog deleteUser = new DeleteUserDialog(user);

            if (deleteUser.ShowDialog(this) == DialogResult.OK)
            {
                UserMainForm userMainForm = this.ParentForm as UserMainForm;

                if (userMainForm != null)
                {
                    userMainForm.PopulatePanel();
                }
            }
        }
    }
}
