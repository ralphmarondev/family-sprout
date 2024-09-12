using FamilySprout.Families.FamiliesList.Forms;
using System;
using System.Windows.Forms;

namespace FamilySprout.Families.FamiliesList.Components
{
    public partial class ChildControlFL : UserControl
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string matrimony { get; private set; }
        public string obitus { get; private set; }

        public ChildControlFL()
        {
            InitializeComponent();
        }

        public ChildControlFL(
            int _id,
            string _name,
            string _bday,
            string _baptism,
            string _hc,
            string _matrimony,
            string _obitus
            )
        {
            InitializeComponent();

            id = _id;
            name = _name;
            bday = _bday;
            baptism = _baptism;
            hc = _hc;
            matrimony = _matrimony;
            obitus = _obitus;

            lblChildName.Text = _name;
            lblChildBirthday.Text = _bday;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            EditChildForm childForm = new EditChildForm(
                _id: id,
                _name: name,
                _bday: bday,
                _baptism: baptism,
                _hc: hc,
                _matrimony: matrimony,
                _obitus: obitus
                );

            if (childForm.ShowDialog(this) == DialogResult.OK)
            {
                Console.WriteLine("Updated successfully!");
            }
        }
    }
}
