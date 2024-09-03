using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FamilySprout.Core.Helper
{
    internal static class Utils
    {
        public static int DEFAULT_ID = 0;
        public static int DEFAULT_FAMID = 0;

        public static string GetCurrentDate()
        {
            DateTime currentDate = DateTime.Now;
            string formattedDate = currentDate.ToString("MMMM dd, yyyy");
            Console.WriteLine($"Formatted Date [GetCurrentDate]: {formattedDate}");
            return formattedDate;
        }

        public static string GetAdmin()
        {
            return "Ralph Maron Eda";
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



        #region FAMILYSPROUT_CONFIG
        public static void ReadFamilySproutConfig()
        {
            string fileName = "familysprout.config.txt";

            Dictionary<string, string> data = new Dictionary<string, string>();

            try
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(new[] { ':' }, 2);

                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        data[key] = value;
                    }
                }

                CheckAndPrintKey(data, "name");
                CheckAndPrintKey(data, "age");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void CheckAndPrintKey(Dictionary<string, string> data, string keyTocCheck)
        {
            if (data.ContainsKey(keyTocCheck))
            {
                Console.WriteLine($"Key: {keyTocCheck}, Value: {data[keyTocCheck]}");
            }
            else
            {
                Console.WriteLine($"Key: '{keyTocCheck}' does not exist.");
            }
        }
        #endregion FAMILYSPROUT_CONFIG
    }
}
