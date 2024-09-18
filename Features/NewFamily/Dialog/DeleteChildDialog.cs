﻿using FamilySprout.Core.DB;
using FamilySprout.Core.Utils;
using System;
using System.Windows.Forms;

namespace FamilySprout.Features.NewFamily.Dialog
{
    public partial class DeleteChildDialog : Form
    {
        long id;
        public string name { get; private set; }
        public string bday { get; private set; }
        public string baptism { get; private set; }
        public string hc { get; private set; }
        public string obitus { get; private set; }
        public string matrimony { get; private set; }

        public DeleteChildDialog(
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
            tbBday.Text = DateUtils.ConvertToUserReaderFormat(_bday);
            tbBaptism.Text = DateUtils.ConvertToUserReaderFormat(_baptism);
            tbHc.Text = DateUtils.ConvertToUserReaderFormat(_hc);
            tbObitus.Text = DateUtils.ConvertToUserReaderFormat(_obitus);
            tbMatrimony.Text = DateUtils.ConvertToUserReaderFormat(_matrimony);

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            name = tbName.Text.Trim();
            bday = tbBday.Text.Trim();
            baptism = tbBaptism.Text.Trim();
            hc = tbHc.Text.Trim();
            obitus = tbObitus.Text.Trim();
            matrimony = tbMatrimony.Text.Trim();

            try
            {
                DBChildren.DeleteChild(_id: id);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
