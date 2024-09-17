using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Dialog
{
    public partial class UpdateUserDialog : Form
    {
        private UserModel user;
        public UpdateUserDialog(UserModel _user)
        {
            InitializeComponent();

            user = _user;

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbOldPassword.Text = user.password;

            tbRoles.Text = (user.role == 0) ? "SUPERUSER" : "USER";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldsEmpty()) return;

            if (tbNewPassword.Text != tbConfirmNewPass.Text)
            {
                MessageBox.Show("Password didn't match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (tbOldPassword.Text == tbNewPassword.Text)
            {
                MessageBox.Show("New password must not be\nthe same as the old password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                user.fullName = tbName.Text.Trim();
                user.username = tbUsername.Text.Trim();
                user.password = tbNewPassword.Text.Trim();

                if (tbRoles.Text == "SUPERUSER") { user.role = 0; }
                else if (tbRoles.Text == "USER") { user.role = 1; }
                else
                {
                    MessageBox.Show("Invalid User Role!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBUsers.UpdateUser(user);
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
            if (tbName.Text == "" || tbUsername.Text == "" || tbOldPassword.Text == "" || tbNewPassword.Text == "" || tbConfirmNewPass.Text == "")
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
