using FamilySprout.Core.DB;
using FamilySprout.Core.Model;
using FamilySprout.Core.Utils;
using FamilySprout.Features.User.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Features.User
{
    public partial class UserMainForm : Form
    {
        public UserMainForm()
        {
            InitializeComponent();

            lblAdminName.Text = SessionManager.CurrentUser.fullName;

            PopulatePanel();
        }

        List<UserModel> users = new List<UserModel>();
        public void PopulatePanel()
        {
            users.Clear();
            users = DBUsers.GetAllUsers();
            userListPanel.Controls.Clear();
            userListPanel.AutoScroll = true;
            int currentY = 10;

            if (users.Count == 0)
            {
                Label label = new Label();
                label.Text = "No children found!";
                label.Font = new Font("Courier New", 14, FontStyle.Bold);
                label.AutoSize = true;

                // Calculate the position to ensure a 20-pixel padding on each side
                int labelWidth = label.Width;
                int labelHeight = label.Height;

                int panelWidth = userListPanel.ClientSize.Width;
                int panelHeight = userListPanel.ClientSize.Height;

                int xPosition = Math.Max(20, (panelWidth - labelWidth - 20)); // Padding from left side
                int yPosition = Math.Max(20, (panelHeight - labelHeight - 20)); // Padding from top side

                label.Location = new Point(
                    (panelWidth - labelWidth) / 2, // Center horizontally within the padded area
                    (panelHeight - labelHeight) / 2  // Center vertically within the padded area
                );

                label.Anchor = AnchorStyles.None;
                userListPanel.Controls.Add(label);
            }
            else
            {
                foreach (var user in users)
                {
                    AdminUserControl adminUserControl = new AdminUserControl(user);

                    adminUserControl.Location = new Point(10, currentY);
                    userListPanel.Controls.Add(adminUserControl);
                    currentY += adminUserControl.Height + 10;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Dialog.NewUserDialog dialog = new Dialog.NewUserDialog();

            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                PopulatePanel();
            }
        }
    }
}
