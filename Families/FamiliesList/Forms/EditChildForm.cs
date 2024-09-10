using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class EditChildForm : Form
    {
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string matrimony { get; private set; }
        public string obitus { get; private set; }

        public EditChildForm()
        {
            InitializeComponent();
        }
        public EditChildForm(
            string _name, string _bday, string _baptism, string _hc, string _matrimony, string _obitus)
        {
            InitializeComponent();

            name = _name;
            bday = _bday;
            baptism = _baptism;
            hc = _hc;
            matrimony = _matrimony;
            obitus = _obitus;

            tbChildName.Text = _name;
            tbBirthday.Text = _bday;
            tbBaptism.Text = _baptism;
            tbHolyCom.Text = _hc;
            tbMatrimony.Text = _matrimony;
            tbObitus.Text = _obitus;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (tbChildName.Text == "" || tbBirthday.Text == "")
            {
                MessageBox.Show("Name and Birthday cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            name = tbChildName.Text.Trim();
            bday = tbBirthday.Text.Trim();
            baptism = tbBaptism.Text.Trim();
            hc = tbHolyCom.Text.Trim();
            matrimony = tbMatrimony.Text.Trim();
            obitus = tbObitus.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
