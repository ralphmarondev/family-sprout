using FamilySprout.Core.DB;
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
            InitializeVariables();
            if (IsRequiredFieldEmpty()) return;

            try
            {
                DBFamily.UpdateRemarks(id: family.id, newRemark: family.remarks);
                DBParents.UpdateParentDetails(husband);
                DBParents.UpdateParentDetails(wife);

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

        private void InitializeVariables()
        {
            family.remarks = tbRemarks.Text.Trim();

            husband.name = tbHusbandFullName.Text.Trim();
            husband.hometown = tbHusbandFrom.Text.Trim();

            wife.name = tbWifeFullName.Text.Trim();
            wife.hometown = tbWifeFrom.Text.Trim();
        }
    }
}
