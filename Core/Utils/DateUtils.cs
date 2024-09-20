using System;
using System.Globalization;

namespace FamilySprout.Core.Utils
{
    public static class DateUtils
    {
        public const string USER_FORMAT = "MMM dd, yyyy";
        public const string DB_FORMAT = "yyyy-MM-dd";


        #region USER_INPUT
        public static string ConvertToUserReaderFormat(string dateFromDatabase)
        {
            if (string.IsNullOrEmpty(dateFromDatabase) || dateFromDatabase == "")
            {
                return string.Empty;
            }
            else
            {
                DateTime parsedDate = DateTime.ParseExact(
                    dateFromDatabase, DB_FORMAT,
                    System.Globalization.CultureInfo.InvariantCulture);
                string formattedDate = parsedDate.ToString(USER_FORMAT);

                return formattedDate;
            }
        }

        public static bool IsDateFormatValid(string date)
        {
            DateTime parsedDate;

            bool isValid = DateTime.TryParseExact(
                date,
                USER_FORMAT,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            return isValid;
        }

        public static DateTime ToReadableFormatInDateTime(string date)
        {
            DateTime parsedDate;

            bool isValid = DateTime.TryParseExact(
                date, USER_FORMAT,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            if (isValid) return parsedDate;
            return DateTime.Today;
        }
        #endregion USER_INPUT


        #region DATABASE
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
        #endregion DATABASE
    }
}
