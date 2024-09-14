using FamilySprout.Features.Trash.Dialogs.Children;
using FamilySprout.Shared.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Controls
{
    public partial class ChildRestoreUserControl : UserControl
    {
        private ChildModel child;
        public ChildRestoreUserControl(ChildModel _child)
        {
            InitializeComponent();

            child = _child;
            lblName.Text = child.name;
            lblBday.Text = child.bday;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreChildren restoreChild = new RestoreChildren(child);

            if (restoreChild.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    trashMainForm.PopulatePanelWithDeletedChildrens();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
