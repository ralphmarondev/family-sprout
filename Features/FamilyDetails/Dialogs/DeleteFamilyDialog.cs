using FamilySprout.Core.Model;
using FamilySprout.Features.FamilyDetails.DB;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails.Dialogs
{
    public partial class DeleteFamilyDialog : Form
    {
        private FamilyModel family;
        public DeleteFamilyDialog(FamilyModel family)
        {
            InitializeComponent();
            this.family = family;

            tbHusband.Text = family.husbandName;
            tbWife.Text = family.wifeName;
            tbChildCount.Text = $"{family.childCount}";
            tbHometown.Text = family.hometown;
            tbRemarks.Text = family.remarks;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            if (DBFamilyDetails.DeleteFamilyDetails(family.id))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
