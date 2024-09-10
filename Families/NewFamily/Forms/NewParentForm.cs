using System;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class NewParentForm : Form
    {
        public string husband { get; private set; }
        public string husbandFrom { get; private set; }
        public string wife { get; private set; }
        public string wifeFrom { get; private set; }
        public string remarks { get; private set; }

        public NewParentForm()
        {
            InitializeComponent();
        }

        public NewParentForm(string _husband, string _husbandFrom, string _wife, string _wifeFrom, string _remarks)
        {
            InitializeComponent();

            tbHusbandFullName.Text = _husband;
            tbHusbandFrom.Text = _husbandFrom;
            tbWifeFullName.Text = _wife;
            tbWifeFrom.Text = _wifeFrom;
            tbRemarks.Text = _remarks;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (
                tbHusbandFullName.Text == "" ||
                tbHusbandFrom.Text == "" ||
                tbWifeFullName.Text == "" ||
                tbWifeFrom.Text == "" ||
                tbRemarks.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            husband = tbHusbandFullName.Text.Trim();
            husbandFrom = tbHusbandFrom.Text.Trim();
            wife = tbWifeFullName.Text.Trim();
            wifeFrom = tbWifeFrom.Text.Trim();
            remarks = tbRemarks.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
