using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.DB;
using FamilySprout.Features.FamilyDetails.Dialogs;
using FamilySprout.Features.Home;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails
{
    public partial class FamilyDetailsMainForm : Form
    {
        private FamilyModel family = new FamilyModel();
        private ParentModel husband = new ParentModel();
        private ParentModel wife = new ParentModel();
        public FamilyDetailsMainForm(long famId)
        {
            InitializeComponent();
            family.id = famId;
            Console.WriteLine($"FamId: {famId}");

            lblCurrentUser.Text = SessionManager.CurrentUser.fullName;
            FetchData();
        }

        private void FetchData()
        {
            family = DBFamilyDetails.GetFamilyDetails(family.id);
            husband = DBFamilyDetails.GetParentDetails(family.id, family.husband);
            wife = DBFamilyDetails.GetParentDetails(family.id, family.wife);

            lblHusbandName.Text = husband.name;
            lblHusbandBday.Text = DateUtils.ConvertToUserReaderFormat(husband.bday);

            lblWifeName.Text = wife.name;
            lblWifeBday.Text = DateUtils.ConvertToUserReaderFormat(wife.bday);

            tbRemarks.Text = family.remarks;
            tbHometown.Text = family.hometown;

            Console.WriteLine($"HusbandName: {husband.name}, bday: {husband.bday}");
            Console.WriteLine($"WifeName: {wife.name}, bday: {wife.bday}");
            Console.WriteLine($"Remarks: {family.remarks}, hometown: {family.hometown}");
        }

        #region LABEL_BACK
        private void lblBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenFamiliesMainForm();
            }
        }
        #endregion LABEL_BACK

        private void btnNext_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.OpenChildrenMainForm(family.id);
            }
        }

        private void btnUpdateFamily_Click(object sender, EventArgs e)
        {
            UpdateFamilyDialog update = new UpdateFamilyDialog(family);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                FetchData();
            }
        }

        private void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            DeleteFamilyDialog delete = new DeleteFamilyDialog(family);

            if (delete.ShowDialog(this) == DialogResult.OK)
            {
                MainForm mainForm = ParentForm as MainForm;

                if (mainForm != null)
                {
                    mainForm.OpenFamiliesMainForm();
                }
            }
        }


        #region HUSBAND
        private void btnViewHusband_Click(object sender, EventArgs e)
        {
            ViewParentDetailsDialog view = new ViewParentDetailsDialog(husband);

            view.ShowDialog(this);
        }

        private void btnUpdateHusband_Click(object sender, EventArgs e)
        {
            UpdateParentDialog update = new UpdateParentDialog(husband);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                // refresh
            }
        }
        #endregion HUSBAND


        #region WIFE
        private void btnViewWife_Click(object sender, EventArgs e)
        {
            ViewParentDetailsDialog view = new ViewParentDetailsDialog(husband);

            view.ShowDialog(this);
        }

        private void btnUpdateWife_Click(object sender, EventArgs e)
        {
            UpdateParentDialog update = new UpdateParentDialog(wife);

            if (update.ShowDialog(this) == DialogResult.OK)
            {
                // refresh
            }
        }
        #endregion WIFE

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainForm mainForm = ParentForm as MainForm;

            if (mainForm != null)
            {
                mainForm.ToggleFullScreen();
            }
        }
    }
}
