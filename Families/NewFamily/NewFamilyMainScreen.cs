using FamilySprout.Core.DB;
using FamilySprout.Core.Helper;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily
{
    public partial class NewFamilyMainScreen : Form
    {
        private int childCount;
        private string name, bday, baptism, holyCom, matrimony, obitus;
        public NewFamilyMainScreen()
        {
            InitializeComponent();
        }

        private void NewFamilyMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();

            OnLoad();
        }


        #region ONLOAD
        private void OnLoad()
        {
            childCount = 0;
            panelHusbandWife.Visible = true;
            panelChildrenInformation.Visible = false;

            SetChildCount();
        }
        #endregion ONLOAD

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tbHusbandFullName.Text == "" || tbHusbandFrom.Text == "" || tbWifeFullName.Text == "" || tbWifeFrom.Text == "" || tbRemarks.Text == "")
            {
                MessageBox.Show("Please fill in all fields!");
                return;
            }

            panelHusbandWife.Visible = false;
            panelChildrenInformation.Visible = true;
        }


        #region ADDING_CHILDREN
        private List<Children> childrens = new List<Children>();

        private void SetChildCount()
        {
            lblChildIndex.Text = $"{childCount + 1}";
        }

        private void IncrementChildCount()
        {
            childCount++;
        }

        private void DecrementChildCount()
        {
            if (childCount > 0)
            {
                childCount--;
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            DecrementChildCount();
            SetChildCount();

            if (childCount == 0)
                return;

            if (childCount >= 0)
            {
                tbChildName.Text = childrens[childCount].name;
                tbBirthday.Text = childrens[childCount].bday;
                tbHolyCom.Text = childrens[childCount].hc;
                tbBaptism.Text = childrens[childCount].baptism;
                tbMatrimony.Text = childrens[childCount].matrimony;
                tbObitus.Text = childrens[childCount].obitus;
            }
        }

        private void btnNextChild_Click(object sender, EventArgs e)
        {
            IncrementChildCount();
            SetChildCount();

            Children child = new Children();
            child.name = tbChildName.Text;
            child.bday = tbBirthday.Text;
            child.hc = tbHolyCom.Text;
            child.baptism = tbBaptism.Text;
            child.matrimony = tbMatrimony.Text;
            child.obitus = tbObitus.Text;

            childrens.Add(child);

            tbChildName.Text = "";
            tbBirthday.Text = "";
            tbHolyCom.Text = "";
            tbBaptism.Text = "";
            tbMatrimony.Text = "";
            tbObitus.Text = "";

            //TODO: error childs are duplicating. Fix  this!
            if (childCount < childrens.Count)
            {
                tbChildName.Text = childrens[childCount].name;
                tbBirthday.Text = childrens[childCount].bday;
                tbHolyCom.Text = childrens[childCount].hc;
                tbBaptism.Text = childrens[childCount].baptism;
                tbMatrimony.Text = childrens[childCount].matrimony;
                tbObitus.Text = childrens[childCount].obitus;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IncrementChildCount();
            SetChildCount();

            Children child = new Children();
            child.name = tbChildName.Text;
            child.bday = tbBirthday.Text;
            child.hc = tbHolyCom.Text;
            child.baptism = tbBaptism.Text;
            child.matrimony = tbMatrimony.Text;
            child.obitus = tbObitus.Text;

            childrens.Add(child);

            string husband = tbHusbandFullName.Text.Trim();
            string husbandFrom = tbHusbandFrom.Text.Trim();
            string wife = tbWifeFullName.Text.Trim();
            string wifeFrom = tbWifeFrom.Text.Trim();
            string remarks = tbRemarks.Text.Trim();

            DBFamily.CreateNewFamily(new FamilyModel(
                   _husband: husband,
                   _husbandFrom: husbandFrom,
                   _wife: wife,
                   _wifeFrom: wifeFrom,
                   _remarks: remarks,
                   _childrens: childrens
                ));

            Console.WriteLine("Family Card");
            Console.WriteLine($"Husband: {husband}, From: {husbandFrom}");
            Console.WriteLine($"Wife: {wife}, From: {wifeFrom}");
            Console.WriteLine($"Remarks: {remarks}");
            Console.WriteLine("Children:");
            foreach (var childr in childrens)
            {
                Console.WriteLine($"- {childr.name}, Birthday: {childr.bday}, Baptism: {childr.baptism}, HC: {childr.hc}");
            }
            Console.WriteLine();
            Close();
        }
        #endregion ADDING_CHILDREN

        private void lblBack_Click(object sender, EventArgs e)
        {
            panelHusbandWife.Visible = true;
            panelChildrenInformation.Visible = false;
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
    }
}
