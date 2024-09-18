using System;
using System.Windows.Forms;

namespace FamilySprout.Core.Components.Controls
{
    public class CustomDateTimePicker : DateTimePicker
    {
        private static readonly DateTime BlankDate = new DateTime(1900, 01, 01);

        public CustomDateTimePicker()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = " ";
            Value = BlankDate;
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            if (Value == BlankDate)
            {
                CustomFormat = " "; // Blank format
            }
            else
            {
                CustomFormat = "MMM dd, yyyy"; // Display selected date
            }
        }
        public void SetBlank()
        {
            Value = BlankDate;
            CustomFormat = " "; // Blank format
        }
    }
}
