using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class DeleteFamilyForm : Form
    {
        private int id;
        public DeleteFamilyForm()
        {
            InitializeComponent();
        }

        public DeleteFamilyForm(
            string _husband, string _husbandFrom, string _wife, string _wifeFrom,
            int _childCount, string _createDate, int _id
            )
        {
            InitializeComponent();

            tbHusband.Text = _husband;
            tbHusbandFrom.Text = _husbandFrom;
            tbWife.Text = _wife;
            tbWifeFrom.Text = _wifeFrom;
            tbChildCount.Text = _childCount.ToString();
            tbCreateDate.Text = _createDate;

            id = _id;
        }

        private void DeleteFamilyForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBFamily.DeleteFamily(id);
                MessageBox.Show("Family Deleted Successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
