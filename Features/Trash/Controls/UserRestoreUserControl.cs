using FamilySprout.Core.Model;
using FamilySprout.Features.Trash.Dialogs.User;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Controls
{
    public partial class UserRestoreUserControl : UserControl
    {
        private UserModel user;
        public UserRestoreUserControl(UserModel _user)
        {
            InitializeComponent();

            user = _user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == 0) ? "SUPERUSER" : "USER";
        }

        private void btnRestore_Click(object sender, System.EventArgs e)
        {
            RestoreUser restoreUser = new RestoreUser(user);

            if (restoreUser.ShowDialog(this) == DialogResult.OK)
            {
                this.Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    trashMainForm.PopulatePanelWithDeletedUsers();
                }
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            PermanentlyDeleteUser permanentlyDelete = new PermanentlyDeleteUser(user);

            if (permanentlyDelete.ShowDialog(this) == DialogResult.OK)
            {
                this.Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    trashMainForm.PopulatePanelWithDeletedUsers();
                }
            }
        }
    }
}
