using FamilySprout.Core.DB;
using FamilySprout.Shared.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.Family
{
    public partial class PermanentlyDeleteFamily : Form
    {
        private FamilyModel family;
        public PermanentlyDeleteFamily(FamilyModel _family)
        {
            InitializeComponent();

            family = _family;

            tbHusbandFullName.Text = family.husband;
            tbHusbandFrom.Text = family.husbandFrom;
            tbWifeFullName.Text = family.wife;
            tbWifeFrom.Text = family.wifeFrom;
            tbRemarks.Text = family.remarks;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPermanentlyDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
                        "Are your sure you want to permanently delete this family?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                if (result == DialogResult.Yes)
                {
                    DBFamily.PermanentlyDeleteFamilyDetails(_famId: family.id);
                    MessageBox.Show("This family has been permanently deleted.");
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Close();
        }
    }
}
