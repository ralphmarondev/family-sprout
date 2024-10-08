﻿using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.Children.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.Children.Dialog
{
    public partial class NewChildDialog : Form
    {
        private ChildModel child = new ChildModel();
        public NewChildDialog(long famId)
        {
            InitializeComponent();
            child.famId = famId;

            SetupFields();
        }

        #region BUTTON_CANCEL
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion BUTTON_CANCEL


        #region BUTTON_SAVE
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldsEmpty())
                return;

            child.name = tbName.Text.Trim();
            child.bday = tbBirthday.Text.Trim();
            child.baptism = tbBaptism.Text.Trim();
            child.hc = tbHc.Text.Trim();
            child.obitus = tbObitus.Text.Trim();
            child.matrimony = tbMatrimony.Text.Trim();

            if (!IsInputDateValid())
                return;

            child.bday = dtBday.Value.ToString(DateUtils.DB_FORMAT);
            if (child.baptism != string.Empty)
            {
                child.baptism = dtBaptism.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (child.hc != string.Empty)
            {
                child.hc = dtHc.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (child.matrimony != string.Empty)
            {
                child.matrimony = dtMatrimony.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (child.obitus != string.Empty)
            {
                child.obitus = dtObitus.Value.ToString(DateUtils.DB_FORMAT);
            }

            DBChildren.CreateNewChild(child);

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool IsRequiredFieldsEmpty()
        {
            if (tbName.Text == "" && tbBirthday.Text == "")
            {
                MessageBox.Show("Name and birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text == "" && tbBirthday.Text != "")
            {
                MessageBox.Show("Name cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text != "" && tbBirthday.Text == "")
            {
                MessageBox.Show("Birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private bool IsInputDateValid()
        {
            if (!DateUtils.IsDateFormatValid(child.bday) && child.bday != string.Empty)
            {
                MessageBox.Show($"'{child.bday}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateUtils.IsDateFormatValid(child.baptism) && child.baptism != string.Empty)
            {
                MessageBox.Show($"'{child.baptism}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateUtils.IsDateFormatValid(child.hc) && child.hc != string.Empty)
            {
                MessageBox.Show($"'{child.hc}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateUtils.IsDateFormatValid(child.matrimony) && child.matrimony != string.Empty)
            {
                MessageBox.Show($"'{child.matrimony}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateUtils.IsDateFormatValid(child.obitus) && child.obitus != string.Empty)
            {
                MessageBox.Show($"'{child.obitus}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion BUTTON_SAVE


        #region SETUP_FIELDS
        private void SetupFields()
        {
            // bday
            dtBday.Format = DateTimePickerFormat.Custom;
            dtBday.Value = DateTime.Today;
            dtBday.CustomFormat = DateUtils.USER_FORMAT;
            dtBday.SendToBack();
            tbBirthday.BringToFront();

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
            tbBirthday.Text = dtBday.Value.ToString(DateUtils.USER_FORMAT);
        }

        private void tbBirthday_Enter(object sender, EventArgs e)
        {
            tbBirthday.Text = dtBday.Value.ToString(DateUtils.USER_FORMAT);
            tbBirthday.SendToBack();
            dtBday.BringToFront();
        }

        private void tbBirthday_Leave(object sender, EventArgs e)
        {
            dtBday.SendToBack();
            tbBirthday.BringToFront();
        }

        private void tbBirthday_TextChanged(object sender, EventArgs e)
        {
            if (tbBirthday.Text == string.Empty) lblClearBday.Visible = false;
            else lblClearBday.Visible = true;
        }

        private void lblClearBday_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbBirthday.Text = string.Empty;
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
    }
}
