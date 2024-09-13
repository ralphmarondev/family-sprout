using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Dialog
{
    public partial class ViewUserDialog : Form
    {
        private UserModel user;
        public ViewUserDialog(UserModel _user)
        {
            InitializeComponent();

            user = _user;
            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbConfirmPassword.Text = user.password;
            tbRoles.Text = (user.role == 0) ? "SUPERUSER" : "USER";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
