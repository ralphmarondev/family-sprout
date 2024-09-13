using FamilySprout.Core.Utils;
using FamilySprout.Features.NewFamily.Dialog;
using FamilySprout.Features.NewFamily.Forms;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Controls
{
    public partial class ChildUserControl : UserControl
    {
        private long id;
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string obitus { get; private set; }
        public string matrimony { get; private set; }

        public ChildUserControl()
        {
            InitializeComponent();
        }
        public ChildUserControl(
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
            name = _name;
            bday = _bday;
            baptism = _baptism;
            hc = _hc;
            obitus = _obitus;
            matrimony = _matrimony;

            lblName.Text = name;
            lblBday.Text = bday;

            if (SessionManager.CurrentUser.role == 1)
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnView_Click(object sender, System.EventArgs e)
        {
            ViewChildDialog viewChild = new ViewChildDialog(
                _name: name,
                _bday: bday,
                _baptism: baptism,
                _hc: hc,
                _obitus: obitus,
                _matrimony: matrimony
                );

            viewChild.ShowDialog(this);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            UpdateChildDialog updateChild = new UpdateChildDialog(
                _id: id,
                _name: name,
                _bday: bday,
                _baptism: baptism,
                _hc: hc,
                _obitus: obitus,
                _matrimony: matrimony
                );

            if (updateChild.ShowDialog(this) == DialogResult.OK)
            {
                NewChildForm newChild = this.ParentForm as NewChildForm;

                if (newChild != null)
                {
                    newChild.FetchData();
                }
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
        {
            DeleteChildDialog deleteChild = new DeleteChildDialog(
                _id: id,
                 _name: name,
                _bday: bday,
                _baptism: baptism,
                _hc: hc,
                _obitus: obitus,
                _matrimony: matrimony
                );

            if (deleteChild.ShowDialog(this) == DialogResult.OK)
            {
                NewChildForm newChild = this.ParentForm as NewChildForm;

                if (newChild != null)
                {
                    newChild.FetchData();
                }
            }
        }
    }
}
