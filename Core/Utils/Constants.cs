using System.Collections.Generic;

namespace FamilySprout.Core.Utils
{
    public class Constants
    {
        public const int ZERO = 0;
        public const int FALSE = 0;
        public const int TRUE = 1;
        public const string REMARKS = "NO REMARKS.";
        public static class User
        {
            public const int SUPERUSER = 1;
            public const int USER = 0;

            public const string SUPERUSER_LABEL = "SUPERUSER";
            public const string USER_LABEL = "USER";
        }

        public static class Parent
        {
            public const int HUSBAND = 1;
            public const int WIFE = 0;

            public const string HUSBAND_LABEL = "HUSBAND";
            public const string WIFE_LABEL = "WIFE";
        }

        public static List<string> itemsList = new List<string>
        {
            "MAL. NORTE",
            "MAL. SUR",
            "ALLIG",
            "BALLUYAN",
            "STA. MARIA",
            "ANNINIPAN",
            "SAN JOSE",
            "POB. EAST",
            "POB. WEST"
        };
    }
}
