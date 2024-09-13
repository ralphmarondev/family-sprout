using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class UpdateChildDialog : Form
    {
        long id;
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string obitus { get; private set; }
        public string matrimony { get; private set; }

        public UpdateChildDialog(
            long _id,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _obitus,
            string _matrimony)
        {
            InitializeComponent();

            id = _id;
            tbName.Text = _name;
            tbBday.Text = _bday;
            tbBaptism.Text = _baptism;
            tbHc.Text = _hc;
            tbObitus.Text = _obitus;
            tbMatrimony.Text = _matrimony;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsRequiredFieldsEmpty()) return;

            name = tbName.Text.Trim();
            bday = tbBday.Text.Trim();
            baptism = tbBaptism.Text.Trim();
            hc = tbHc.Text.Trim();
            obitus = tbObitus.Text.Trim();
            matrimony = tbMatrimony.Text.Trim();

            try
            {
                DBChildren.UpdateChild(
                    _id: id,
                    _name: name,
                    _bday: bday,
                    _baptism: baptism,
                    _hc: hc,
                    _obitus: obitus,
                    _matrimony: matrimony
                    );
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }


        private bool IsRequiredFieldsEmpty()
        {
            if (tbName.Text == "" && tbBday.Text == "")
            {
                MessageBox.Show("Name and birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text == "" && tbBday.Text != "")
            {
                MessageBox.Show("Name cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }
            else if (tbName.Text != "" && tbBday.Text == "")
            {
                MessageBox.Show("Birthday cannot be empty!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }

            return false;
        }
    }
}
