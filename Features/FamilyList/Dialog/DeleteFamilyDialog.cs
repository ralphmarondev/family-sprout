using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Dialog
{
    public partial class DeleteFamilyDialog : Form
    {
        FamilyModel family;
        ParentModel husband, wife;
        public DeleteFamilyDialog(FamilyModel family, ParentModel husband, ParentModel wife)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldEmpty()) return;

            try
            {
                DBFamily.DeleteFamilyDetails(family.id);
                DBParents.DeleteParentByFamilyId(family.id);
                DBChildren.DeleteChildByFamId(family.id);

                MessageBox.Show("Deleted Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Some fields are empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}
