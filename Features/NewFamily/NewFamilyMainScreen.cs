using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily
{
    public partial class NewFamilyMainScreen : Form
    {
        private ParentModel husband = new ParentModel();
        private ParentModel wife = new ParentModel();
        private FamilyModel family = new FamilyModel();

        public NewFamilyMainScreen()
        {
            InitializeComponent();
            SetupHusbandFields();
            SetupWifeFields();

            lblCurrentUser.Text = "Ralph Maron Eda";
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            if (tbName.Text.Trim() == string.Empty || tbBday.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Name and birthday cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panelWifeInfo.BringToFront();
        }

        private void btnNextToOtherInfo_Click(object sender, EventArgs e)
        {
            if (tbWife.Text.Trim() == string.Empty || tbWifeBday.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Name and birthday cannot be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            panelFamInfoFinal.BringToFront();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // set values
            husband.name = tbName.Text.Trim();
            husband.bday = tbBday.Text.Trim();
            husband.baptism = tbBaptism.Text.Trim();
            husband.hc = tbHc.Text.Trim();
            husband.matrimony = tbMatrimony.Text.Trim();
            husband.obitus = tbObitus.Text.Trim();

            wife.name = tbWife.Text.Trim();
            wife.bday = tbWifeBday.Text.Trim();
            wife.baptism = tbWifeBaptism.Text.Trim();
            wife.hc = tbWifeHc.Text.Trim();
            wife.matrimony = tbWifeMatrimony.Text.Trim();
            wife.obitus = tbWifeObitus.Text.Trim();

            family.husbandName = husband.name;
            family.wifeName = wife.name;
            family.remarks = tbRemarks.Text.Trim();

            // check if input is valid
            // save
            Console.WriteLine($"Husband: name: {husband.name}, bday: {husband.bday}");
            Console.WriteLine($"Wife: name: {wife.name}, bday: {wife.bday}");
        }


        #region HUSBAND

        #region SETUP_FIELDS
        private void SetupHusbandFields()
        {
            // bday
            dtBday.Format = DateTimePickerFormat.Custom;
            dtBday.Value = DateTime.Today;
            dtBday.CustomFormat = DateUtils.USER_FORMAT;
            dtBday.SendToBack();
            tbBday.BringToFront();

            // baptism
            dtBaptism.Format = DateTimePickerFormat.Custom;
            dtBaptism.Value = DateTime.Today;
            dtBaptism.CustomFormat = DateUtils.USER_FORMAT;
            dtBaptism.SendToBack();
            tbBaptism.BringToFront();

            // holy communion
            dtHc.Format = DateTimePickerFormat.Custom;
            dtHc.Value = DateTime.Today;
            dtHc.CustomFormat = DateUtils.USER_FORMAT;
            dtHc.SendToBack();
            tbHc.BringToFront();

            // matrimony
            dtMatrimony.Format = DateTimePickerFormat.Custom;
            dtMatrimony.Value = DateTime.Today;
            dtMatrimony.CustomFormat = DateUtils.USER_FORMAT;
            dtMatrimony.SendToBack();
            tbMatrimony.BringToFront();

            // obitus
            dtObitus.Format = DateTimePickerFormat.Custom;
            dtObitus.Value = DateTime.Today;
            dtObitus.CustomFormat = DateUtils.USER_FORMAT;
            dtObitus.SendToBack();
            tbObitus.BringToFront();
        }
        #endregion SETUP_FIELDS


        #region BIRTHDAY
        private void dtBday_CloseUp(object sender, EventArgs e)
        {
            tbBday.Text = dtBday.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbBday_Enter(object sender, EventArgs e)
        {
            tbBday.Text = dtBday.Value.ToString(DateUtils.USER_FORMAT);
            tbBday.SendToBack();
            dtBday.BringToFront();
        }

        private void tbBday_Leave(object sender, EventArgs e)
        {
            dtBday.SendToBack();
            tbBday.BringToFront();
        }

        private void tbBday_TextChanged(object sender, EventArgs e)
        {
            if (tbBday.Text == string.Empty) lblClearBday.Visible = false;
            else lblClearBday.Visible = true;
        }

        private void lblClearBday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbBday.Text = string.Empty;
        }
        #endregion BIRTHDAY


        #region BAPTISM
        private void dtBaptism_CloseUp(object sender, EventArgs e)
        {
            tbBaptism.Text = dtBaptism.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbBaptism_Enter(object sender, EventArgs e)
        {
            tbBaptism.Text = dtBaptism.Value.ToString(DateUtils.USER_FORMAT);
            tbBaptism.SendToBack();
            dtBaptism.BringToFront();
        }

        private void tbBaptism_Leave(object sender, EventArgs e)
        {
            dtBaptism.SendToBack();
            tbBaptism.BringToFront();
        }

        private void tbBaptism_TextChanged(object sender, EventArgs e)
        {
            if (tbBaptism.Text == string.Empty) lblClearBaptism.Visible = false;
            else lblClearBaptism.Visible = true;
        }

        private void lblClearBaptism_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbBaptism.Text = string.Empty;
        }
        #endregion BAPTISM


        #region HC
        private void dtHc_CloseUp(object sender, EventArgs e)
        {
            tbHc.Text = dtHc.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbHc_Enter(object sender, EventArgs e)
        {
            tbHc.Text = dtHc.Value.ToString(DateUtils.USER_FORMAT);
            tbHc.SendToBack();
            dtHc.BringToFront();
        }

        private void tbHc_Leave(object sender, EventArgs e)
        {
            dtHc.SendToBack();
            tbHc.BringToFront();
        }

        private void tbHc_TextChanged(object sender, EventArgs e)
        {
            if (tbHc.Text == string.Empty) lblClearHc.Visible = false;
            else lblClearHc.Visible = true;
        }

        private void lblClearHc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbHc.Text = string.Empty;
        }
        #endregion HC


        #region MATRIMONY
        private void dtMatrimony_CloseUp(object sender, EventArgs e)
        {
            tbMatrimony.Text = dtMatrimony.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbMatrimony_Enter(object sender, EventArgs e)
        {
            tbMatrimony.Text = dtMatrimony.Value.ToString(DateUtils.USER_FORMAT);
            tbMatrimony.SendToBack();
            dtMatrimony.BringToFront();
        }

        private void tbMatrimony_Leave(object sender, EventArgs e)
        {
            dtMatrimony.SendToBack();
            tbMatrimony.BringToFront();
        }

        private void tbMatrimony_TextChanged(object sender, EventArgs e)
        {
            if (tbMatrimony.Text == string.Empty) lblClearMatrimony.Visible = false;
            else lblClearMatrimony.Visible = true;
        }

        private void lblClearMatrimony_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbMatrimony.Text = string.Empty;
        }
        #endregion MATRIMONY


        #region OBITUS
        private void dtObitus_CloseUp(object sender, EventArgs e)
        {
            tbObitus.Text = dtObitus.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbObitus_Enter(object sender, EventArgs e)
        {
            tbObitus.Text = dtObitus.Value.ToString(DateUtils.USER_FORMAT);
            tbObitus.SendToBack();
            dtObitus.BringToFront();
        }

        private void tbObitus_Leave(object sender, EventArgs e)
        {
            dtObitus.SendToBack();
            tbObitus.BringToFront();
        }

        private void tbObitus_TextChanged(object sender, EventArgs e)
        {
            if (tbObitus.Text == string.Empty) lblClearObitus.Visible = false;
            else lblClearObitus.Visible = true;
        }

        private void lblClearObitus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbObitus.Text = string.Empty;
        }
        #endregion OBITUS

        #endregion HUSBAND



        #region WIFE

        #region SETUP_FIELDS
        private void SetupWifeFields()
        {
            // bday
            dtWifeBday.Format = DateTimePickerFormat.Custom;
            dtWifeBday.Value = DateTime.Today;
            dtWifeBday.CustomFormat = DateUtils.USER_FORMAT;
            dtWifeBday.SendToBack();
            tbWifeBday.BringToFront();

            // baptism
            dtWifeBaptism.Format = DateTimePickerFormat.Custom;
            dtWifeBaptism.Value = DateTime.Today;
            dtWifeBaptism.CustomFormat = DateUtils.USER_FORMAT;
            dtWifeBaptism.SendToBack();
            tbWifeBaptism.BringToFront();

            // holy communion
            dtWifeHc.Format = DateTimePickerFormat.Custom;
            dtWifeHc.Value = DateTime.Today;
            dtWifeHc.CustomFormat = DateUtils.USER_FORMAT;
            dtWifeHc.SendToBack();
            tbWifeHc.BringToFront();

            // matrimony
            dtWifeMatrimony.Format = DateTimePickerFormat.Custom;
            dtWifeMatrimony.Value = DateTime.Today;
            dtWifeMatrimony.CustomFormat = DateUtils.USER_FORMAT;
            dtWifeMatrimony.SendToBack();
            tbWifeMatrimony.BringToFront();

            // obitus
            dtWifeObitus.Format = DateTimePickerFormat.Custom;
            dtWifeObitus.Value = DateTime.Today;
            dtWifeObitus.CustomFormat = DateUtils.USER_FORMAT;
            dtWifeObitus.SendToBack();
            tbWifeObitus.BringToFront();
        }
        #endregion SETUP_FIELDS


        #region BIRTHDAY
        private void dtWifeBday_CloseUp(object sender, EventArgs e)
        {
            tbWifeBday.Text = dtWifeBday.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbWifeBday_Enter(object sender, EventArgs e)
        {
            tbWifeBday.Text = dtWifeBday.Value.ToString(DateUtils.USER_FORMAT);
            tbWifeBday.SendToBack();
            dtWifeBday.BringToFront();
        }

        private void tbWifeBday_Leave(object sender, EventArgs e)
        {
            dtWifeBday.SendToBack();
            tbWifeBday.BringToFront();
        }

        private void tbWifeBday_TextChanged(object sender, EventArgs e)
        {
            if (tbWifeBday.Text == string.Empty) lblClearWifeBday.Visible = false;
            else lblClearWifeBday.Visible = true;
        }

        private void lblClearWifeBday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbWifeBday.Text = string.Empty;
        }
        #endregion BIRTHDAY


        #region BAPTISM
        private void dtWifeBaptism_CloseUp(object sender, EventArgs e)
        {
            tbWifeBaptism.Text = dtWifeBaptism.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbWifeBaptism_Enter(object sender, EventArgs e)
        {
            tbWifeBaptism.Text = dtWifeBaptism.Value.ToString(DateUtils.USER_FORMAT);
            tbWifeBaptism.SendToBack();
            dtWifeBaptism.BringToFront();
        }

        private void tbWifeBaptism_Leave(object sender, EventArgs e)
        {
            dtWifeBaptism.SendToBack();
            tbWifeBaptism.BringToFront();
        }

        private void tbWifeBaptism_TextChanged(object sender, EventArgs e)
        {
            if (tbWifeBaptism.Text == string.Empty) lblClearWifeBaptism.Visible = false;
            else lblClearWifeBaptism.Visible = true;
        }

        private void lblClearWifeBaptism_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbWifeBaptism.Text = string.Empty;
        }
        #endregion BAPTISM


        #region HC
        private void dtWifeHc_CloseUp(object sender, EventArgs e)
        {
            tbWifeHc.Text = dtWifeHc.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbWifeHc_Enter(object sender, EventArgs e)
        {
            tbWifeHc.Text = dtWifeHc.Value.ToString(DateUtils.USER_FORMAT);
            tbWifeHc.SendToBack();
            dtWifeHc.BringToFront();
        }

        private void tbWifeHc_Leave(object sender, EventArgs e)
        {
            dtWifeHc.SendToBack();
            tbWifeHc.BringToFront();
        }

        private void tbWifeHc_TextChanged(object sender, EventArgs e)
        {
            if (tbWifeHc.Text == string.Empty) lblClearWifeHc.Visible = false;
            else lblClearWifeHc.Visible = true;
        }

        private void lblClearWifeHc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbWifeHc.Text = string.Empty;
        }
        #endregion HC


        #region MATRIMONY
        private void dtWifeMatrimony_CloseUp(object sender, EventArgs e)
        {
            tbWifeMatrimony.Text = dtWifeMatrimony.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbWifeMatrimony_Enter(object sender, EventArgs e)
        {
            tbWifeMatrimony.Text = dtWifeMatrimony.Value.ToString(DateUtils.USER_FORMAT);
            tbWifeMatrimony.SendToBack();
            dtWifeMatrimony.BringToFront();
        }

        private void tbWifeMatrimony_Leave(object sender, EventArgs e)
        {
            dtWifeMatrimony.SendToBack();
            tbWifeMatrimony.BringToFront();
        }

        private void tbWifeMatrimony_TextChanged(object sender, EventArgs e)
        {
            if (tbWifeMatrimony.Text == string.Empty) lblClearWifeMatrimony.Visible = false;
            else lblClearWifeMatrimony.Visible = true;
        }

        private void lblClearWifeMatrimony_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbWifeMatrimony.Text = string.Empty;
        }
        #endregion MATRIMONY


        #region OBITUS
        private void dtWifeObitus_CloseUp(object sender, EventArgs e)
        {
            tbWifeObitus.Text = dtWifeObitus.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbWifeObitus_Enter(object sender, EventArgs e)
        {
            tbWifeObitus.Text = dtWifeObitus.Value.ToString(DateUtils.USER_FORMAT);
            tbWifeObitus.SendToBack();
            dtWifeObitus.BringToFront();
        }

        private void tbWifeObitus_Leave(object sender, EventArgs e)
        {
            dtWifeObitus.SendToBack();
            tbWifeObitus.BringToFront();
        }

        private void tbWifeObitus_TextChanged(object sender, EventArgs e)
        {
            if (tbWifeObitus.Text == string.Empty) lblClearWifeObitus.Visible = false;
            else lblClearWifeObitus.Visible = true;
        }

        private void lblClearWifeObitus_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbWifeObitus.Text = string.Empty;
        }
        #endregion OBITUS

        #endregion WIFE
    }
}
