using FamilySprout.Core.Helper;
using FamilySprout.Core.Model;
using System;
using System.Collections.Generic;
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


        #region SAVING

        private void SaveToDatabase()
        {
            FamilyModel familyWithThreeChildren = new FamilyModel
            {
                husband = "John Doe",
                husbandFrom = "New York",
                wife = "Jane Doe",
                wifeFrom = "Boston",
                childrens = new List<Children>
            {
                new Children { name = "Alice", bday = "01/01/2010", baptism = "02/02/2010", hc = "01/01/2018", matrimony = "", obitus = "" },
                new Children { name = "Bob", bday = "03/03/2012", baptism = "04/04/2012", hc = "01/01/2020", matrimony = "", obitus = "" },
                new Children { name = "Charlie", bday = "05/05/2014", baptism = "06/06/2014", hc = "01/01/2022", matrimony = "", obitus = "" }
            }
            };

            // Create a family with four children
            FamilyModel familyWithFourChildren = new FamilyModel
            {
                husband = "Michael Smith",
                husbandFrom = "Chicago",
                wife = "Emily Smith",
                wifeFrom = "San Francisco",
                childrens = new List<Children>
            {
                new Children { name = "David", bday = "07/07/2011", baptism = "08/08/2011", hc = "01/01/2019", matrimony = "", obitus = "" },
                new Children { name = "Eve", bday = "09/09/2013", baptism = "10/10/2013", hc = "01/01/2021", matrimony = "", obitus = "" },
                new Children { name = "Frank", bday = "11/11/2015", baptism = "12/12/2015", hc = "01/01/2023", matrimony = "", obitus = "" },
                new Children { name = "Grace", bday = "01/02/2017", baptism = "02/03/2017", hc = "01/01/2024", matrimony = "", obitus = "" }
            }
            };

            // Print family with three children
            PrintFamilyDetails(familyWithThreeChildren);

            // Print family with four children
            PrintFamilyDetails(familyWithFourChildren);
        }

        static void PrintFamilyDetails(FamilyModel family)
        {
            Console.WriteLine($"Husband: {family.husband} from {family.husbandFrom}");
            Console.WriteLine($"Wife: {family.wife} from {family.wifeFrom}");
            Console.WriteLine("Children:");
            foreach (var child in family.childrens)
            {
                Console.WriteLine($"- {child.name}, Birthday: {child.bday}, Baptism: {child.baptism}, HC: {child.hc}");
            }
            Console.WriteLine();
        }
        #endregion SAVING

        private void btnNext_Click(object sender, EventArgs e)
        {
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
            Console.WriteLine("Children:");
            foreach (var child in childrens)
            {
                Console.WriteLine($"- {child.name}, Birthday: {child.bday}, Baptism: {child.baptism}, HC: {child.hc}");
            }
            Console.WriteLine();
        }
        #endregion ADDING_CHILDREN

        private void lblBack_Click(object sender, EventArgs e)
        {
            panelHusbandWife.Visible = true;
            panelChildrenInformation.Visible = false;
        }
    }
}
