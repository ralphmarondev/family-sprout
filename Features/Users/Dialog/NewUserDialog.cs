using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Users.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Dialog
{
    public partial class NewUserDialog : Form
    {
        public NewUserDialog()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();

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
            if (DBUsers.CreateNewUser(user))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
