using FamilySprout.Core.Model;
using FamilySprout.Features.Trash.Families.Dialog;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Families.Controls
{
    public partial class TrashFamilyUserControl : UserControl
    {
        private FamilyModel family;
        public TrashFamilyUserControl(FamilyModel family)
        {
            InitializeComponent();
            this.family = family;

            lblHusband.Text = family.husbandName;
            lblWife.Text = family.wifeName;
        }

        private void btnRestore_Click(object sender, System.EventArgs e)
        {
            RestoreFamilyDialog restore = new RestoreFamilyDialog(family);

            if (restore.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedFamilies();
                }
            }
        }

        private void btnPermanentDelete_Click(object sender, System.EventArgs e)
        {
            PermanentlyDeleteFamilyDialog permanentDelete = new PermanentlyDeleteFamilyDialog(family);

            if (permanentDelete.ShowDialog(this) == DialogResult.OK)
            {
                Hide();
                TrashMainForm mainForm = ParentForm as TrashMainForm;

                if (mainForm != null)
                {
                    mainForm.PopulatePanelWithDeletedFamilies();
                }
            }
        }
    }
}
