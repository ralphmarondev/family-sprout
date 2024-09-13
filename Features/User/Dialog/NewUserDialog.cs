﻿using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.User.Dialog
{
    public partial class NewUserDialog : Form
    {
        public NewUserDialog()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
        {
            if (IsRequiredFieldsEmpty()) return;

            if (tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Password didn't match!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                UserModel user = new UserModel();
                user.fullName = tbName.Text.Trim();
                user.username = tbUsername.Text.Trim();
                user.password = tbPassword.Text.Trim();

                if (tbRoles.Text == "SUPERUSER") { user.role = 0; }
                else if (tbRoles.Text == "USER") { user.role = 1; }
                else
                {
                    MessageBox.Show("Invalid User Role!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DBUsers.CreateNewUser(user);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Registration Failed!\nError: {ex.Message}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Close();
        }

        private bool IsRequiredFieldsEmpty()
        {
            if (tbName.Text == "" || tbUsername.Text == "" || tbPassword.Text == "" || tbConfirmPassword.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}