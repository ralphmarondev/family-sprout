using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Trash.Dialogs.Children;
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
            lblBday.Text = DateUtils.ConvertToUserReaderFormat(child.bday);
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
                    //trashMainForm.PopulatePanelWithDeletedChildrens();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PermanentlyDeleteChildren permanentlyDeleteChildren = new PermanentlyDeleteChildren(child);

            if (permanentlyDeleteChildren.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    //trashMainForm.PopulatePanelWithDeletedChildrens();
                }
            }
        }
    }
}
