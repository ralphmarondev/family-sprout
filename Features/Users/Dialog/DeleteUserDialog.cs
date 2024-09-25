using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Users.DB;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Dialog
{
    public partial class DeleteUserDialog : Form
    {
        private UserModel user;
        public DeleteUserDialog(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbRoles.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (DBUsers.DeleteUser(user.id))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
