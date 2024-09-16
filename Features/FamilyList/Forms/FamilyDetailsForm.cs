using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyList.Dialog;
using FamilySprout.Features.Home;
using FamilySprout.Core.Model;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyList.Forms
{
    public partial class FamilyDetailsForm : Form
    {
        long famId;
        FamilyModel familyModel;
        public FamilyDetailsForm(long _famId)
        {
            InitializeComponent();
            famId = _famId;

            lblAdminName.Text = SessionManager.CurrentUser.fullName;
            lblNonSuperUserIndicator.Visible = false;

            if (SessionManager.CurrentUser.role == 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                lblNonSuperUserIndicator.Visible = true;
            }

            familyModel = DBFamily.GetFamilyDetails(_famId);

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
                mainForm.OpenFamilyChildListForm(famId);
            }
        }

        private void FamilyDetailsForm_Load(object sender, System.EventArgs e)
        {
            tbHusbandFullName.Text = familyModel.husband;
            tbHusbandFrom.Text = familyModel.husbandFrom;
            tbWifeFullName.Text = familyModel.wife;
            tbWifeFrom.Text = familyModel.wifeFrom;
            tbRemarks.Text = familyModel.remarks;
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateParentDialog updateParent = new UpdateParentDialog(
                _famId: familyModel.id,
                _husband: familyModel.husband,
                _husbandFrom: familyModel.husbandFrom,
                _wife: familyModel.wife,
                _wifeFrom: familyModel.wifeFrom,
                _remarks: familyModel.remarks);

            if (updateParent.ShowDialog(this) == DialogResult.OK)
            {
                familyModel = DBFamily.GetFamilyDetails(famId);

                tbHusbandFullName.Text = familyModel.husband;
                tbHusbandFrom.Text = familyModel.husbandFrom;
                tbWifeFullName.Text = familyModel.wife;
                tbWifeFrom.Text = familyModel.wifeFrom;
                tbRemarks.Text = familyModel.remarks;
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteFamilyDialog deleteFamily = new DeleteFamilyDialog(
                _famId: familyModel.id,
                _husband: familyModel.husband,
                _husbandFrom: familyModel.husbandFrom,
                _wife: familyModel.wife,
                _wifeFrom: familyModel.wifeFrom,
                _remarks: familyModel.remarks);

            if (deleteFamily.ShowDialog(this) == DialogResult.OK)
            {
                MainForm mainForm = this.ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamilyListForm();
                }
            }
        }
    }
}
