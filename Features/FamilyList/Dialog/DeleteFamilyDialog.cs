using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Dialog
{
    public partial class DeleteFamilyDialog : Form
    {
        private long famId;
        public DeleteFamilyDialog(long _famId,
            string _husband,
            string _husbandFrom,
            string _wife,
            string _wifeFrom,
            string _remarks)
        {
            InitializeComponent();

            famId = _famId;
            tbHusbandFullName.Text = _husband;
            tbHusbandFrom.Text = _husbandFrom;
            tbWifeFullName.Text = _wife;
            tbWifeFrom.Text = _wifeFrom;
            tbRemarks.Text = _remarks;
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
                DBFamily.DeleteFamilyDetails(_famId: famId);
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
