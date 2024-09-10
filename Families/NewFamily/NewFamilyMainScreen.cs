using FamilySprout.Core.DB;
using FamilySprout.Core.Helper;
using FamilySprout.Core.Model;
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
        private string husbandName, husbandFrom, wifeName, wifeFrom, remarks;
        private List<Children> childrens = new List<Children>();
        private List<Parents> parents = new List<Parents>();
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
                husbandName = newParentForm.husband;
                husbandFrom = newParentForm.husbandFrom;
                wifeName = newParentForm.wife;
                wifeFrom = newParentForm.wifeFrom;
                remarks = newParentForm.remarks;

                parents.Clear();
                var parent1 = new Parents(
                    name: husbandName,
                    from: husbandFrom,
                    husband: husbandName,
                    husbandFrom: husbandFrom,
                    wife: wifeName,
                    wifeFrom: wifeFrom,
                    remarks: remarks);

                var parent2 = new Parents(
                    name: wifeName,
                    from: wifeFrom,
                    husband: husbandName,
                    husbandFrom: husbandFrom,
                    wife: wifeName,
                    wifeFrom: wifeFrom,
                    remarks: remarks);

                parents.Add(parent1);
                parents.Add(parent2);

                PopulatePanel();
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


        private void PopulatePanel()
        {
            panel1.Controls.Clear(); // Clear existing controls
            panel1.AutoScroll = true; // Enable scrolling

            int currentY = 10; // Initial Y position for stacking controls

            // Add Parent Information label
            Label parentInfoLabel = new Label();
            parentInfoLabel.Text = "Parent Information";
            parentInfoLabel.Location = new Point(10, currentY);
            parentInfoLabel.AutoSize = true;
            parentInfoLabel.Font = new Font("Courier New", 14F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            parentInfoLabel.ForeColor = Color.Purple;
            panel1.Controls.Add(parentInfoLabel);
            currentY += parentInfoLabel.Height + 10; // Update Y position

            foreach (var parent in parents)
            {
                ParentUserControl parentControl = new ParentUserControl();
                parentControl.SetParentDetails(
                    name: parent.name,
                    from: parent.from,
                    _husband: parent.husband,
                    _husbandFrom: parent.husbandFrom,
                    _wife: parent.wife,
                    _wifeFrom: parent.wifeFrom,
                    _remarks: parent.remarks);
                parentControl.Location = new Point(10, currentY); // Set location
                panel1.Controls.Add(parentControl);
                currentY += parentControl.Height + 10; // Update Y position
            }

            Label childrenInfoLabel = new Label();
            childrenInfoLabel.Text = "Children Information";
            childrenInfoLabel.Location = new Point(10, currentY);
            childrenInfoLabel.AutoSize = true;
            childrenInfoLabel.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            childrenInfoLabel.ForeColor = System.Drawing.Color.Purple;
            panel1.Controls.Add(childrenInfoLabel);
            currentY += childrenInfoLabel.Height + 10; // Update Y position

            foreach (var child in childrens)
            {
                ChildrenUserControl childControl = new ChildrenUserControl(
                    _name: child.name,
                    _bday: child.bday,
                    _baptism: child.baptism,
                    _hc: child.hc,
                    _matrimony: child.matrimony,
                    _obitus: child.obitus
                    );
                childControl.Location = new Point(10, currentY); // Set location

                childControl.Click += (sender, args) => ChildControl_Click(childControl);

                panel1.Controls.Add(childControl);
                currentY += childControl.Height + 10; // Update Y position
            }
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            NewChildForm newChildForm = new NewChildForm();

            if (newChildForm.ShowDialog(this) == DialogResult.OK)
            {
                Children child = new Children();

                child.name = newChildForm.name;
                child.bday = newChildForm.bday;
                child.baptism = newChildForm.baptism;
                child.hc = newChildForm.hc;
                child.matrimony = newChildForm.matrimony;
                child.obitus = newChildForm.obitus;
                child.createdBy = Utils.GetAdmin();
                child.createDate = Utils.GetCreateDate();

                childrens.Add(child);
                PopulatePanel();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var family = new FamilyModel(
                _id: Utils.DEFAULT_ID,
                _husband: husbandName,
                _husbandFrom: husbandFrom,
                _wife: wifeName,
                _wifeFrom: wifeFrom,
                _remarks: remarks,
                _childCount: childrens.Count,
                _childrens: childrens,
                _createdBy: Utils.GetAdmin(),
                _createDate: Utils.GetCreateDate()
                );

            Console.WriteLine($"Saving to database...");
            Console.WriteLine("Parent details.....");
            Console.WriteLine($"Husband: {husbandName}, From: {husbandFrom}");
            Console.WriteLine($"Wife: {wifeName}, From: {wifeFrom}");
            Console.WriteLine("Children details....");
            foreach (var child in family.childrens)
            {
                Console.WriteLine($"Name: {child.name}, birthday: {child.bday}, Baptism: {child.baptism}");
                Console.WriteLine($"HC: {child.hc}, Matrimony: {child.matrimony}, Obitus: {child.obitus}");
            }
            Console.WriteLine();

            try
            {
                DBFamily.CreateNewFamily(family);
                MessageBox.Show("Family created successfully!", "Saved Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainScreen mainScreen = this.ParentForm as MainScreen;

                if (mainScreen != null)
                {
                    mainScreen.OpenFamilyList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed! {ex.Message}", "Saving Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // adding click event on child usercontrol
        public void ChildControl_Click(ChildrenUserControl childControl)
        {
            string currentChildName = childControl.name;
            var child = childrens.Find(c => c.name == currentChildName);

            Console.WriteLine($"Current child name: {currentChildName}");

            if (child != null)
            {
                NewChildForm childForm = new NewChildForm(
                    _name: child.name,
                    _bday: child.bday,
                    _baptism: child.baptism,
                    _hc: child.hc,
                    _matrimony: child.matrimony,
                    _obitus: child.obitus
                    );

                if (childForm.ShowDialog(this) == DialogResult.OK)
                {
                    child.name = childForm.name;
                    child.bday = childForm.bday;
                    child.baptism = childForm.baptism;
                    child.hc = childForm.hc;
                    child.matrimony = childForm.matrimony;
                    child.obitus = childForm.obitus;

                    childControl.SetChildrenDetails(_name: child.name,
                        _bday: child.bday);
                }
            }
        }
    }

    public class Parents
    {
        public string name { get; set; }
        public string from { get; set; }
        public string husband { get; set; }
        public string husbandFrom { get; set; }
        public string wife { get; set; }
        public string wifeFrom { get; set; }
        public string remarks { get; set; }
        public Parents(string name, string from, string husband, string husbandFrom, string wife,
            string wifeFrom, string remarks)
        {
            this.name = name;
            this.from = from;
            this.husband = husband;
            this.husbandFrom = husbandFrom;
            this.wife = wife;
            this.wifeFrom = wifeFrom;
            this.remarks = remarks;
        }
    }
}
