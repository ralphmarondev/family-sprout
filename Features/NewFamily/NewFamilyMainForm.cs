using FamilySprout.Core.DB;
using FamilySprout.Features.NewFamily.Dialog;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily
{
    public partial class NewFamilyMainForm : Form
    {
        public NewFamilyMainForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldEmpty()) return;

            try
            {
                long familyId = DBFamily.CreateNewFamily(
                    _husband: tbHusbandFullName.Text.Trim(),
                    _husbandFrom: tbHusbandFrom.Text.Trim(),
                    _wife: tbWifeFullName.Text.Trim(),
                    _wifeFrom: tbWifeFrom.Text.Trim(),
                    _remarks: tbRemarks.Text.Trim()
                    );

                MainForm mainForm = this.ParentForm as MainForm;
                ConfirmAddingNewFamily confirmAddingNewFamily = new ConfirmAddingNewFamily();

                if (confirmAddingNewFamily.ShowDialog(this) == DialogResult.OK)
                {
                    MessageBox.Show("Family Created successfully!");

                    if (mainForm != null)
                    {
                        mainForm.OpenNewChildrenForm(_famId: familyId);
                    }
                }
                else
                {
                    if (mainForm != null)
                    {
                        mainForm.OpenFamilyListForm();
                    }
                }
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
