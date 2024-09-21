using FamilySprout.Core.Model;
using FamilySprout.Features.FamilyDetails.DB;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails.Dialogs
{
    public partial class UpdateFamilyDialog : Form
    {
        FamilyModel family;
        public UpdateFamilyDialog(FamilyModel family)
        {
            InitializeComponent();
            this.family = family;

            tbRemarks.Text = family.remarks;
            tbTown.Text = family.hometown;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (tbRemarks.Text.Trim() == string.Empty || tbTown.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (tbRemarks.Text.Trim() != string.Empty && tbTown.Text.Trim() != string.Empty)
            {
                family.remarks = tbRemarks.Text.Trim();
                family.hometown = tbTown.Text.Trim();

                if (DBFamilyDetails.UpdateFamilyDetails(family))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }
    }
}
