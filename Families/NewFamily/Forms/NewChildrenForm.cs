using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class NewChildrenForm : Form
    {
        private int childCount = 1;
        public NewChildrenForm()
        {
            InitializeComponent();
        }

        private void NewChildrenForm_Load(object sender, System.EventArgs e)
        {
            btnPrev.Text = "BACK";
        }

        private void btnPrev_Click(object sender, System.EventArgs e)
        {
            if (childCount == 1)
            {
                btnPrev.Text = "BACK";
            }
            else
            {
                btnPrev.Text = "PREV";
                lblChildIndex.Text = childCount.ToString();
            }

            if (btnPrev.Text == "BACK")
            {
                NewFamilyMainScreen mainScreen = this.ParentForm as NewFamilyMainScreen;

                if (mainScreen != null)
                {
                    mainScreen.PrintData(_name: "Ralph Maron Eda", _age: 21);
                    mainScreen.OnBackToHusbandWifeForm();
                }
            }
            else
            {

            }
        }

        private void btnNext_Click(object sender, System.EventArgs e)
        {
            btnPrev.Text = "PREV";
            childCount++;
            lblChildIndex.Text = childCount.ToString();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            NewFamilyMainScreen mainScreen = this.ParentForm as NewFamilyMainScreen;

            if (mainScreen != null)
            {
                mainScreen.PrintData(_name: "Ralph Maron Eda", _age: 21);
                mainScreen.OnSave();
            }
        }
    }
}
