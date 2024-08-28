using System;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class HusbandWifeForm : Form
    {
        public HusbandWifeForm()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Printing details...");
            Console.WriteLine($"Husband: {tbHusbandFullName.Text}, From: {tbHusbandFrom.Text}");
            Console.WriteLine($"Wife: {tbWifeFullName.Text}, From: {tbWifeFrom.Text}");
            Console.WriteLine($"Remarks: {tbRemarks}\nNothing follows.\n");

            NewFamilyMainScreen newFamilyMainScreen = this.ParentForm as NewFamilyMainScreen;

            if (newFamilyMainScreen != null)
            {
                newFamilyMainScreen.OnHusbandWifeNext();
            }
        }
    }
}
