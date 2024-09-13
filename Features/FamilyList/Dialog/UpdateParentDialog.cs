using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Dialog
{
    public partial class UpdateParentDialog : Form
    {
        private long famId;
        public UpdateParentDialog(
            long _famId,
            string _husband,
            string _husbandFrom,
            string _wife,
            string _wifeFrom,
            string _remarks
            )
        {
            InitializeComponent();

            famId = _famId;
            tbHusbandFullName.Text = _husband;
            tbHusbandFrom.Text = _husbandFrom;
            tbWifeFullName.Text = _wife;
            tbWifeFrom.Text = _wifeFrom;
            tbRemarks.Text = _remarks;
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
                DBParents.UpdateParentInformation(
                    _famId: famId,
                    _husband: tbHusbandFullName.Text.Trim(),
                    _husbandFrom: tbHusbandFrom.Text.Trim(),
                    _wife: tbWifeFullName.Text.Trim(),
                    _wifeFrom: tbWifeFrom.Text.Trim(),
                    _remarks: tbRemarks.Text.Trim()
                    );
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
