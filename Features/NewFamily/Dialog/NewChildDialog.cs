using FamilySprout.Core.DB;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class NewChildDialog : Form
    {
        private long famId;
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string obitus { get; private set; }
        public string matrimony { get; private set; }
        public NewChildDialog(long _famId)
        {
            InitializeComponent();
            famId = _famId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            name = tbName.Text.Trim();
            bday = tbBirthday.Text.Trim();
            baptism = tbBaptism.Text.Trim();
            hc = tbHc.Text.Trim();
            obitus = tbObitus.Text.Trim();
            matrimony = tbMatrimony.Text.Trim();

            try
            {
                DBChildren.CreateNewChild(
                    _famId: famId,
                    _name: name,
                    _bday: bday,
                    _baptism: baptism,
                    _hc: hc,
                    _obitus: obitus,
                    _matrimony: matrimony);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed adding new child!\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
