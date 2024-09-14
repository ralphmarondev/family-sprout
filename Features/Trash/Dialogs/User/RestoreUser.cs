using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.User
{
    public partial class RestoreUser : Form
    {
        private UserModel user;
        public RestoreUser(UserModel _user)
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

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DBUsers.RestoreUser(_id: user.id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Close();
        }
    }
}
