using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Dialog
{
    public partial class UpdateParentDialog : Form
    {
        FamilyModel family;
        ParentModel husband, wife;
        public UpdateParentDialog(FamilyModel family, ParentModel husband, ParentModel wife)
        {
            InitializeComponent();
            this.family = family;
            this.husband = husband;
            this.wife = wife;

            tbHusbandFullName.Text = husband.name;
            tbHusbandFrom.Text = husband.hometown;
            tbWifeFullName.Text = wife.name;
            tbWifeFrom.Text = wife.hometown;
            tbRemarks.Text = family.remarks;
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (IsRequiredFieldEmpty()) return;

            try
            {
                //DBParents.UpdateParentInformation(
                //    _famId: famId,
                //    _husband: tbHusbandFullName.Text.Trim(),
                //    _husbandFrom: tbHusbandFrom.Text.Trim(),
                //    _wife: tbWifeFullName.Text.Trim(),
                //    _wifeFrom: tbWifeFrom.Text.Trim(),
                //    _remarks: tbRemarks.Text.Trim()
                //    );
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private bool IsRequiredFieldEmpty()
        {
            if (tbHusbandFullName.Text == "" || tbWifeFullName.Text == "" || tbHusbandFrom.Text == "" || tbWifeFrom.Text == "" || tbRemarks.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}
