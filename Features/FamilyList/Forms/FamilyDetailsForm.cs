using FamilySprout.Core.DB;
using FamilySprout.Features.FamilyList.Dialog;
using FamilySprout.Shared.Model;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Forms
{
    public partial class FamilyDetailsForm : Form
    {
        long famId;
        FamilyData familyData;
        public FamilyDetailsForm(long _famId)
        {
            InitializeComponent();
            famId = _famId;

            familyData = DBFamily.GetFamilyDetails(_famId);

        }

        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyListForm();
            }
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            MainForm mainForm = this.ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamilyChildListForm(familyData);
            }
        }

        private void FamilyDetailsForm_Load(object sender, System.EventArgs e)
        {
            tbHusbandFullName.Text = familyData.husband;
            tbHusbandFrom.Text = familyData.husbandFrom;
            tbWifeFullName.Text = familyData.wife;
            tbWifeFrom.Text = familyData.wifeFrom;
            tbRemarks.Text = familyData.remarks;
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateParentDialog updateParent = new UpdateParentDialog(
                _famId: familyData.id,
                _husband: familyData.husband,
                _husbandFrom: familyData.husbandFrom,
                _wife: familyData.wife,
                _wifeFrom: familyData.wifeFrom,
                _remarks: familyData.remarks);

            if (updateParent.ShowDialog(this) == DialogResult.OK)
            {
                familyData = DBFamily.GetFamilyDetails(famId);

                tbHusbandFullName.Text = familyData.husband;
                tbHusbandFrom.Text = familyData.husbandFrom;
                tbWifeFullName.Text = familyData.wife;
                tbWifeFrom.Text = familyData.wifeFrom;
                tbRemarks.Text = familyData.remarks;
            }
        }
    }

    public class FamilyData
    {
        public long id { get; set; }
        public string husband { get; set; }
        public string husbandFrom { get; set; }
        public string wife { get; set; }
        public string wifeFrom { get; set; }
        public string remarks { get; set; }
        public string createdBy { get; set; }
        public string createDate { get; set; }
        public List<ChildModel> childrens { get; set; }

        public FamilyData()
        {
            childrens = new List<ChildModel>();
        }
    }
}
