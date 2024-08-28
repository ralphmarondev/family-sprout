using FamilySprout.Core.Helper;
using FamilySprout.Core.Model;
using FamilySprout.Families.NewFamily.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily
{
    public partial class NewFamilyMainScreen : Form
    {
        private string name;
        private int age;
        public NewFamilyMainScreen()
        {
            InitializeComponent();
        }

        private void NewFamilyMainScreen_Load(object sender, EventArgs e)
        {
            lblCurrentDate.Text = Utils.GetCurrentDate();
            lblAdminName.Text = Utils.GetAdmin();

            SaveToDatabase();
            OnLoad();
        }



        #region NAVIGATION
        private void OnLoad()
        {
            OpenFormInPanel(new Forms.HusbandWifeForm());
        }

        public void OnHusbandWifeNext()
        {
            OpenFormInPanel(new Forms.NewChildrenForm());
            Console.WriteLine($"[Next] Name: {name}, Age: {age}");
        }

        public void OnBackToHusbandWifeForm()
        {
            OpenFormInPanel(new Forms.HusbandWifeForm());
            Console.WriteLine($"[Back] Name: {name}, Age: {age}");
        }

        public void OnSave()
        { // triggered when the save from newchildren form is clicked
            Console.WriteLine($"[Save] Name: {name}, Age: {age}");

            ConfirmInputForm confirm = new ConfirmInputForm();
            confirm.StartPosition = FormStartPosition.CenterParent;
            confirm.ShowDialog(this);
        }

        public void PrintData(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        private void OpenFormInPanel(Form form)
        {
            foreach (Control control in mainPanel.Controls)
            {
                if (control is Form)
                {
                    ((Form)control).Close();
                }
            }

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(form);
            mainPanel.Tag = form;
            form.BringToFront();
            form.Show();
        }
        #endregion NAVIGATION

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
    }
}
