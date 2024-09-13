using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Dialog
{
    public partial class DeleteUserDialog : Form
    {
        private UserModel user;
        public DeleteUserDialog(UserModel _user)
        {
            InitializeComponent();

            user = _user;
            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbConfirmPassword.Text = user.password;
            tbRoles.Text = (user.role == 0) ? "SUPERUSER" : "USER";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DBUsers.DeleteUser(user.id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Deletion failed!\nError: {ex.Message}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
