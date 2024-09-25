using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Users.Dialog
{
    public partial class PermanentlyDeleteUserDialog : Form
    {
        private UserModel user;
        public PermanentlyDeleteUserDialog(UserModel user)
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                     "Are your sure you want to permanently delete this user?",
                     "Last Warning!",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Warning
                 );

            if (result == DialogResult.Yes)
            {
                if (DBTrash.PermanentlyDeleteUser(user.id))
                {
                    MessageBox.Show("This user has been deleted permanently.");

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

    }
}
