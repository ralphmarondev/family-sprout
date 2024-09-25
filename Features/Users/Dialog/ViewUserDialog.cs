using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Users.Dialog
{
    public partial class ViewUserDialog : Form
    {
        public ViewUserDialog(UserModel user)
        {
            InitializeComponent();

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbRoles.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
