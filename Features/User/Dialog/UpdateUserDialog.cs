using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Dialog
{
    public partial class UpdateUserDialog : Form
    {
        private UserModel user;
        private string oldUsername;
        public UpdateUserDialog(UserModel _user)
        {
            InitializeComponent();

            user = _user;

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbOldPassword.Text = user.password;

            tbRoles.Text = (user.role == 0) ? "SUPERUSER" : "USER";
            oldUsername = user.username;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                user.fullName = tbName.Text.Trim();
                user.username = tbUsername.Text.Trim();
                user.password = tbOldPassword.Text.Trim();

                if (IsRequiredFieldsEmpty()) return;

                if (tbNewPassword.Text != string.Empty)
                {
                    if (tbNewPassword.Text != tbConfirmNewPass.Text)
                    {
                        MessageBox.Show("New password didn't match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (tbOldPassword.Text == tbNewPassword.Text)
                    {
                        MessageBox.Show("New password must not be\nthe same as the old password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    user.password = tbNewPassword.Text.Trim();
                }

                if (user.username != oldUsername)
                {
                    if (DBUsers.IsUsernameTaken(_username: user.username))
                    {
                        MessageBox.Show("Username is already taken.\nPlease try a new one!", "Username Taken", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                if (tbRoles.Text == Roles.SUPERUSER_LABEL) { user.role = Roles.SUPERUSER; }
                else if (tbRoles.Text == Roles.USER_LABEL) { user.role = Roles.USER; }
                else
                {
                    MessageBox.Show("Invalid User Role!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBUsers.UpdateUser(user);
                // update parents, family, children
                if (user.username != oldUsername)
                {
                    DBFamily.UpdateFamilyCreatedBy(user.username, oldUsername);
                    DBParents.UpdateParentCreatedBy(user.username, oldUsername);
                    DBChildren.UpdateChildrenCreatedBy(user.username, oldUsername);
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update Failed!\nError: {ex.Message}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private bool IsRequiredFieldsEmpty()
        {
            if (tbName.Text == "" || tbUsername.Text == "" || tbOldPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
