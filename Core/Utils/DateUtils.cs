using System;
using System.Globalization;

namespace FamilySprout.Core.Utils
{
    public static class DateUtils
    {
        public const string USER_FORMAT = "MMM dd, yyyy";
        public const string DB_FORMAT = "yyyy-MM-dd";

        public static string ConvertToUserReaderFormat(string _dateFromDatabase)
        {
            if (string.IsNullOrEmpty(_dateFromDatabase))
            {
                return string.Empty;
            }

            DateTime parsedDate = DateTime.ParseExact(
                _dateFromDatabase, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);
            string formattedDate = parsedDate.ToString("MMM dd, yyyy");

            return formattedDate;
        }

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
