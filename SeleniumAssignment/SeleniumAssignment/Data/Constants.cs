

using System;

namespace SeleniumAssignment.Data
{
    public class Constants
    {
        public static readonly string _notes = "Notes for testing purpose";
        public static readonly string _email = "first@gmail.com";
        public static readonly string _homePageTitle = "CRUD Example";


        // Instantiate random number generator.  
        private static readonly Random _random = new Random();

        public static string RandomName(string name, int length = 3)
        {
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(_random.Next(1, 26) + 64)).ToString().ToLower();
            }
            return name + rString;
        }

        // Generates a random number within a range.      
        public static string RandomNumber(int length)
        {
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, _random.Next(10).ToString());
            return s;
        }
    }
}
