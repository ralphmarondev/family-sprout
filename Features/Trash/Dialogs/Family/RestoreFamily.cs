using FamilySprout.Core.DB;
using FamilySprout.Shared.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Trash.Dialogs.Family
{
    public partial class RestoreFamily : Form
    {
        private FamilyModel family;
        public RestoreFamily(FamilyModel _family)
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

        private void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                DBFamily.RestoreFamilyDetails(_famId: family.id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Close();
        }
    }
}
