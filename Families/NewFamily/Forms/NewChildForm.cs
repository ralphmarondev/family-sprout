using System;
using System.Windows.Forms;

namespace FamilySprout.Families.NewFamily.Forms
{
    public partial class NewChildForm : Form
    {
        public string name { get; private set; }
        public NewChildForm()
        {
            InitializeComponent();
        }

        private void NewChildForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            name = tbChildName.Text.Trim();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
