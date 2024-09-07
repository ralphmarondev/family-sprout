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
            panelHusbandWife.Visible = true;
            panelChildrenInformation.Visible = false;

            childrens.Clear();
            lblChildIndex.Text = $"{count + 1}";
            btnPrev.Enabled = false;
        }
        #endregion ONLOAD

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (tbHusbandFullName.Text == "" || tbHusbandFrom.Text == "" || tbWifeFullName.Text == "" || tbWifeFrom.Text == "" || tbRemarks.Text == "")
            {
                MessageBox.Show("Please fill in all fields!", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            panelHusbandWife.Visible = false;
            panelChildrenInformation.Visible = true;
        }


        #region ADDING_CHILDREN

        private void btnPrev_Click(object sender, EventArgs e)
        {
            OnPrev();
        }

        private void btnNextChild_Click(object sender, EventArgs e)
        {
            OnNext();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }
        #endregion ADDING_CHILDREN


        #region PrevNextSave
        private List<Children> childrens = new List<Children>();
        private int count = 0, maxCount = 0, prevMaxCount = 0;
        private void OnPrev()
        {
            count--;
            int index = count;
            if (index >= 0)
            {
                tbChildName.Text = childrens[index].name;
                tbBirthday.Text = childrens[index].bday;
                tbHolyCom.Text = childrens[index].hc;
                tbBaptism.Text = childrens[index].baptism;
                tbMatrimony.Text = childrens[index].matrimony;
                tbObitus.Text = childrens[index].obitus;

                lblChildIndex.Text = $"{count + 1}";
                if (count <= 0)
                {
                    btnPrev.Enabled = false;
                }
            }
        }

        private void OnNext()
        {
            if (InputsValid())
            {
                Children child = new Children();
                child.id = count; // setting count as id
                child.famId = Utils.DEFAULT_FAMID;
                child.name = tbChildName.Text;
                child.bday = tbBirthday.Text;
                child.hc = tbHolyCom.Text;
                child.baptism = tbBaptism.Text;
                child.matrimony = tbMatrimony.Text;
                child.obitus = tbObitus.Text;
                child.createdBy = lblAdminName.Text.Trim();
                child.createDate = Utils.GetCreateDate();

                childrens.Add(child);
                ClearFields();
                count++; // 0 + 1 = 1
                prevMaxCount = maxCount; // 0
                maxCount = count; // count = 0 + 1 = 1
                if (maxCount > prevMaxCount)
                {
                    prevMaxCount = maxCount;
                }

                lblChildIndex.Text = $"{count + 1}";
                if (count > 0)
                {
                    btnPrev.Enabled = true;
                }
            }
        }

        private void OnSave()
        {
            if (count == 0 && maxCount == 0)
            {
                DialogResult result = MessageBox.Show("No Children is added, are you sure you want to continue?\nYou can still add later.", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Saving to database.");
                }
            }
            else
            {
                if (InputsValid())
                {
                    MessageBox.Show("Saving to database.");
                }
            }
            //DBFamily.CreateNewFamily(new FamilyModel(
            //       _id: Utils.DEFAULT_ID,
            //       _husband: husband,
            //       _husbandFrom: husbandFrom,
            //       _wife: wife,
            //       _wifeFrom: wifeFrom,
            //       _remarks: remarks,
            //       _childrens: childrens,
            //       _createdBy: createdBy,
            //       _createDate: createDate
            //    ));
        }

        private bool InputsValid()
        {
            if (tbChildName.Text == "" || tbBirthday.Text == "")
            {
                MessageBox.Show("Child Name or birthday cannot be empty!", "Invalid Input!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void ClearFields()
        {
            tbChildName.Text = "";
            tbBirthday.Text = "";
            tbHolyCom.Text = "";
            tbBaptism.Text = "";
            tbMatrimony.Text = "";
            tbObitus.Text = "";
        }
        #endregion PrevNextSave


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
