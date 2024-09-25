using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.FamilyDetails.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.FamilyDetails.Dialogs
{
    public partial class UpdateParentDialog : Form
    {
        ParentModel parent;
        public UpdateParentDialog(ParentModel parent)
        {
            InitializeComponent();
            this.parent = parent;

            SetupFields();
            tbName.Text = parent.name;
            tbContactNumber.Text = parent.contactNumber;
            tbBirthPlace.Text = parent.birthPlace;
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(parent.bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(parent.baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(parent.hc);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(parent.matrimony);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(parent.obitus);


            // set datepicker to their current values
            dtBday.Value = DateUtils.ToReadableFormatInDateTime(tbBday.Text.Trim());
            dtBaptism.Value = DateUtils.ToReadableFormatInDateTime(tbBaptism.Text.Trim());
            dtHc.Value = DateUtils.ToReadableFormatInDateTime(tbHc.Text.Trim());
            dtMatrimony.Value = DateUtils.ToReadableFormatInDateTime(tbMatrimony.Text.Trim());
            dtObitus.Value = DateUtils.ToReadableFormatInDateTime(tbObitus.Text.Trim());
        }


        #region BUTTONS
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            // check if required fields are empty
            // check if dates are valid
            // format dates for db storing
            if (IsRequiredFieldsEmpty()) return;

            parent.name = tbName.Text.Trim();
            parent.contactNumber = tbContactNumber.Text.Trim();
            parent.bday = tbBday.Text.Trim();
            parent.birthPlace = tbBirthPlace.Text.Trim();
            parent.baptism = tbBaptism.Text.Trim();
            parent.hc = tbHc.Text.Trim();
            parent.matrimony = tbMatrimony.Text.Trim();
            parent.obitus = tbObitus.Text.Trim();

            if (!IsInputDateValid()) return;

            if (parent.bday != string.Empty)
            {
                parent.bday = dtBday.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.baptism != string.Empty)
            {
                parent.baptism = dtBaptism.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.hc != string.Empty)
            {
                parent.hc = dtHc.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.matrimony != string.Empty)
            {
                parent.matrimony = dtMatrimony.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.obitus != string.Empty)
            {
                parent.obitus = dtObitus.Value.ToString(DateUtils.DB_FORMAT);
            }

            if (DBFamilyDetails.UpdateParentDetails(parent))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ChangeDateFormatForDatabase()
        {
            if (parent.bday != string.Empty)
            {
                parent.bday = dtBday.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.baptism != string.Empty)
            {
                parent.baptism = dtBaptism.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.hc != string.Empty)
            {
                parent.hc = dtHc.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.matrimony != string.Empty)
            {
                parent.matrimony = dtMatrimony.Value.ToString(DateUtils.DB_FORMAT);
            }
            if (parent.obitus != string.Empty)
            {
                parent.obitus = dtObitus.Value.ToString(DateUtils.DB_FORMAT);
            }
        }

        private bool IsRequiredFieldsEmpty()
        {
            if (tbName.Text == "" && tbBday.Text == "")
            {
                MessageBox.Show("Name and birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text == "" && tbBday.Text != "")
            {
                MessageBox.Show("Name cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text != "" && tbBday.Text == "")
            {
                MessageBox.Show("Birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            if (tbBirthPlace.Text.Trim() == string.Empty || tbContactNumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Birthpace and/or Contact number cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
        private bool IsInputDateValid()
        {
            if (!DateUtils.IsDateFormatValid(parent.bday) && parent.bday != string.Empty)
            {
                return Message(parent.bday);
            }
            if (!DateUtils.IsDateFormatValid(parent.baptism) && parent.baptism != string.Empty)
            {
                return Message(parent.baptism);
            }
            if (!DateUtils.IsDateFormatValid(parent.hc) && parent.hc != string.Empty)
            {
                return Message(parent.hc);
            }
            if (!DateUtils.IsDateFormatValid(parent.matrimony) && parent.matrimony != string.Empty)
            {
                return Message(parent.matrimony);
            }
            if (!DateUtils.IsDateFormatValid(parent.obitus) && parent.obitus != string.Empty)
            {
                return Message(parent.obitus);
            }
            return true;
        }
        private bool Message(string message)
        {
            MessageBox.Show($"'{message}' is not a valid date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        #endregion BUTTONS



        #region TEXT_FIELDS

        #region SETUP_FIELDS
        private void SetupFields()
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

        #endregion TEXT_FIELDS
    }
}
