using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.Children.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Children.Controls
{
    public partial class TrashChildUserControl : UserControl
    {
        private ChildModel child;
        public TrashChildUserControl(ChildModel child)
        {
            InitializeComponent();
            this.child = child;

            lblName.Text = child.name;
            lblBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
        }

        private void btnRestore_Click(object sender, System.EventArgs e)
        {
            RestoreChildDialog restore = new RestoreChildDialog(child);

            if (restore.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedChildren();
                }
            }
        }

        private void btnPermanentDelete_Click(object sender, System.EventArgs e)
        {
            PermanentlyDeleteChildDialog permanentDelete = new PermanentlyDeleteChildDialog(child);

            if (permanentDelete.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedChildren();
                }
            }
        }
    }
}
