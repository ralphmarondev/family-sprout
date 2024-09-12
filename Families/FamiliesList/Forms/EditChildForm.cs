using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Forms
{
    public partial class EditChildForm : Form
    {
        public int id { get; set; }
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
           int _id, string _name, string _bday, string _baptism, string _hc, string _matrimony, string _obitus)
        {
            InitializeComponent();

            id = _id;
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

            Console.WriteLine($"Editing child with id: {id}");
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (tbChildName.Text == "" || tbBirthday.Text == "")
            {
                MessageBox.Show("Name and Birthday cannot be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                name = tbChildName.Text.Trim();
                bday = tbBirthday.Text.Trim();
                baptism = tbBaptism.Text.Trim();
                hc = tbHolyCom.Text.Trim();
                matrimony = tbMatrimony.Text.Trim();
                obitus = tbObitus.Text.Trim();

                // updating child
                DBChildren.UpdateChild(
                    _id: id,
                    _name: name,
                    _bday: bday,
                    _baptism: baptism,
                    _hc: hc,
                    _matrimony: matrimony,
                    _obitus: obitus
                    );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
