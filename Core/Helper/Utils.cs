using System;

namespace FamilySprout.Core.Helper
{
    internal static class Utils
    {
        public static string GetCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MMMM dd, yyyy");
            Console.WriteLine($"Formatted Date [GetCurrentDate]: {formattedDate}");
            return formattedDate;
        }

        public static string GetAdmin()
        {
            return "RALPH MARON EDA";
        }
    }
}
