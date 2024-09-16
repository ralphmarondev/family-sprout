using FamilySprout.Features.Trash.Dialogs.Family;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Controls
{
    public partial class FamilyRestoreUserControl : UserControl
    {
        private FamilyModel family;

        public FamilyRestoreUserControl(
            FamilyModel _family)
        {
            InitializeComponent();

            family = _family;

            lblHusband.Text = family.husband;
            lblWife.Text = family.wife;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            RestoreFamily restoreFamily = new RestoreFamily(family);

            if (restoreFamily.ShowDialog(this) == DialogResult.OK)
            {
                this.Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    trashMainForm.PopulatePanelWithDeletedFamilies();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PermanentlyDeleteFamily permanentlyDeleteFamily = new PermanentlyDeleteFamily(family);

            if (permanentlyDeleteFamily.ShowDialog(this) == DialogResult.OK)
            {
                this.Hide();
                TrashMainForm trashMainForm = this.ParentForm as TrashMainForm;

                if (trashMainForm != null)
                {
                    trashMainForm.PopulatePanelWithDeletedFamilies();
                }
            }
        }
    }
}
