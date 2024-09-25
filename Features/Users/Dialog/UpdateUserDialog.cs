using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Users.DB;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Dialog
{
    public partial class UpdateUserDialog : Form
    {
        private UserModel user;
        private string oldPassword;
        public UpdateUserDialog(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbConfirmPassword.Text = user.password;
            tbRoles.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;

            oldPassword = user.password;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            user.fullName = tbName.Text.Trim();
            user.username = tbUsername.Text.Trim();
            user.password = tbPassword.Text.Trim();

            if (user.fullName == string.Empty || user.username == string.Empty || user.password == string.Empty)
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // password check
            if (user.password != tbConfirmPassword.Text.Trim())
            {
                MessageBox.Show("Password did not match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (user.password == oldPassword)
            {
                MessageBox.Show("Password must not be the same as the old password!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // role check
            if (tbRoles.Text.Trim() != string.Empty)
            {
                if (tbRoles.Text.Trim() == Constants.User.SUPERUSER_LABEL)
                {
                    user.role = Constants.User.SUPERUSER;
                }
                else if (tbRoles.Text.Trim() == Constants.User.USER_LABEL)
                {
                    user.role = Constants.User.USER;
                }
                else
                {
                    MessageBox.Show("Invalid User Role!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (DBUsers.UpdateUser(user))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
