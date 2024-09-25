using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Users.Dialog
{
    public partial class RestoreUserDialog : Form
    {
        private UserModel user;
        public RestoreUserDialog(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            tbName.Text = user.fullName;
            tbUsername.Text = user.username;
            tbPassword.Text = user.password;
            tbRoles.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (DBTrash.RestoreUser(user.id))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

    }
}
