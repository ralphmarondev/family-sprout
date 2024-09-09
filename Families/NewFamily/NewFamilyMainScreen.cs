using FamilySprout.Core.Helper;
using FamilySprout.Families.NewFamily.Components;
using FamilySprout.Families.NewFamily.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily
{
    public partial class NewFamilyMainScreen : Form
    {
        public NewFamilyMainScreen()
        {
            InitializeComponent();
        }

        private void NewFamilyMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();

            NewParentForm newParentForm = new NewParentForm();

            if (newParentForm.ShowDialog(this) == DialogResult.OK)
            {

                List<string> parents = new List<string> { "Husband: John Doe", "Wife: Jane Doe" };
                List<string> children = new List<string> { "Child 1: Alice", "Child 2: Bob", "Child 3: Charlie" };

                PopulatePanel(parents, children);
            }
            else
            {
                MainScreen mainScreen = this.ParentForm as MainScreen;

                if (mainScreen != null)
                {
                    mainScreen.OpenDashboard();
                }
            }
        }

        #region TOPBAR
        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            MainScreen main = this.ParentForm as MainScreen;

            if (main != null)
            {
                main.ToggleFullScreen();
            }
        }

        private void btnLogout2_Click(object sender, EventArgs e)
        {
            MainScreen main = this.ParentForm as MainScreen;

            if (main != null)
            {
                main.LogoutForm();
            }
        }

        private void btnToggleNavPanel_Click(object sender, EventArgs e)
        {
            MainScreen main = this.ParentForm as MainScreen;

            if (main != null)
            {
                main.ToggleNavigationPanel();
            }
        }
        #endregion TOPBAR


        #region DRAG_AND_DROP
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void panelTitle_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.ParentForm.Location;

        }

        private void panelTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point diff = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                MainScreen mainScreen = this.ParentForm as MainScreen;

                if (mainScreen != null)
                {
                    mainScreen.Location = Point.Add(dragFormPoint, new Size(diff));
                }
            }
        }
        #endregion DRAG_AND_DROP


        private void PopulatePanel(
            List<string> parentDetails,
            List<string> childDetails)
        {
            panel1.Controls.Clear(); // Clear existing controls
            panel1.AutoScroll = true; // Enable scrolling

            int currentY = 10; // Initial Y position for stacking controls

            // Add Parent Information label
            Label parentInfoLabel = new Label();
            parentInfoLabel.Text = "Parent Information";
            parentInfoLabel.Location = new Point(10, currentY);
            parentInfoLabel.AutoSize = true;
            parentInfoLabel.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            parentInfoLabel.ForeColor = System.Drawing.Color.Purple;
            panel1.Controls.Add(parentInfoLabel);
            currentY += parentInfoLabel.Height + 10; // Update Y position

            // Add Parent Controls
            foreach (var parent in parentDetails)
            {
                Components.ParentUserControl parentControl = new Components.ParentUserControl();
                parentControl.SetParentDetails(
                    _name: parent, _from: "From: Earth");
                parentControl.Location = new Point(10, currentY); // Set location
                panel1.Controls.Add(parentControl);
                currentY += parentControl.Height + 10; // Update Y position
            }

            // Add Children Information label
            Label childrenInfoLabel = new Label();
            childrenInfoLabel.Text = "Children Information";
            childrenInfoLabel.Location = new Point(10, currentY);
            childrenInfoLabel.AutoSize = true;
            childrenInfoLabel.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            childrenInfoLabel.ForeColor = System.Drawing.Color.Purple;
            panel1.Controls.Add(childrenInfoLabel);
            currentY += childrenInfoLabel.Height + 10; // Update Y position

            // Add Child Controls
            foreach (var child in childDetails)
            {
                ChildrenUserControl childControl = new ChildrenUserControl();
                childControl.SetChildrenDetails(_name: child, _bday: "September 9, 2024");
                childControl.Location = new Point(10, currentY); // Set location
                panel1.Controls.Add(childControl);
                currentY += childControl.Height + 10; // Update Y position
            }
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildForm newChildForm = new NewChildForm();

            if (newChildForm.ShowDialog(this) == DialogResult.OK)
            {
                string childName = newChildForm.name;

                MessageBox.Show($"Child Name: {childName}");
                // add to list
                // populate panel
            }
        }
    }
}
