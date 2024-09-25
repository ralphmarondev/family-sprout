using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.Users.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Users.Controls
{
    public partial class TrashUsersUserControl : UserControl
    {
        private UserModel user;
        public TrashUsersUserControl(UserModel user)
        {
            InitializeComponent();
            this.user = user;

            lblName.Text = user.fullName;
            lblRole.Text = (user.role == Constants.User.SUPERUSER) ? Constants.User.SUPERUSER_LABEL : Constants.User.USER_LABEL;
        }

        private void btnRestore_Click(object sender, System.EventArgs e)
        {
            RestoreUserDialog restore = new RestoreUserDialog(user);

            if (restore.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedUsers();
                }
            }
        }

        private void btnPermanentDelete_Click(object sender, System.EventArgs e)
        {
            PermanentlyDeleteUserDialog permanentDelete = new PermanentlyDeleteUserDialog(user);

            if (permanentDelete.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedUsers();
                }
            }
        }
    }
}
