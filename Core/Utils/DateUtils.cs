using System;
using System.Globalization;

namespace FamilySprout.Core.Utils
{
    public static class DateUtils
    {
        public static string GetCreateDate()
        {
            DateTime now = DateTime.Now;
            string formattedDate = now.ToString("yyyy-MM-dd hh:mm:ss tt");
            Console.WriteLine($"Formatted Date [GetCreateDate]: {formattedDate}");
            return formattedDate;
        }

        public static string GetCreateDateForUserView(string originalFormat)
        {
            //string originalFormat = "2024-09-03 12:17:00 PM";
            DateTime parsedDate = DateTime.ParseExact(originalFormat, "yyyy-MM-dd hh:mm:ss tt", CultureInfo.InvariantCulture);
            string formattedDate = parsedDate.ToString("MMM. d, yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            Console.WriteLine(formattedDate); // Example: Sep. 3, 2024 12:17:00 PM
            return formattedDate;
        }
    }
}
