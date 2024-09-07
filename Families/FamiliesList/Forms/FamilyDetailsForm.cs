using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class FamilyDetailsForm : Form
    {
        private int id;
        private FamilyModel family = null;
        public FamilyDetailsForm()
        {
            InitializeComponent();
        }

        public FamilyDetailsForm(int _id)
        {
            InitializeComponent();

            this.id = _id;
        }

        private void FamilyDetailsForm_Load(object sender, EventArgs e)
        {
            family = DBFamily.GetFamilyDetailsById(id);
            GetDetailsWithId();
        }

        private void GetDetailsWithId()
        {
            if (family == null) return;
            tbHusbandFullName.Text = family.husband;
            tbHusbandFrom.Text = family.husbandFrom;
            tbWifeFullName.Text = family.wife;
            tbWifeFrom.Text = family.wifeFrom;
            tbRemarks.Text = family.remarks;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
