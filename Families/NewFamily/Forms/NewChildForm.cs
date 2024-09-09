using System;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class NewChildForm : Form
    {
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string matrimony { get; private set; }
        public string obitus { get; private set; }

        public NewChildForm()
        {
            InitializeComponent();
        }

        private void NewChildForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbChildName.Text == "" || tbBirthday.Text == "")
            {
                MessageBox.Show("Name and Birthday cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
