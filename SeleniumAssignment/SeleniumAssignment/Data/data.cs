using NUnit.Framework;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

    public class AssignmentData
    {
        public static Data _Data { get; set; }
        public static string dir = TestContext.CurrentContext.TestDirectory + @"\Data\JSON\";
        public static string file = null;
        public static Dictionary<string, object> direct = new Dictionary<string, object>();

        public static void Generate(string jsonFileName = "")
        {
            file = dir + jsonFileName;
            if(Directory.Exists(dir))
            {
                _Data = JsonConvert.DeserializeObject<Data>(File.ReadAllText(file));
            }
        }
    public class Data
    {
     public TestData TestData { get; set; }

    }
    public class TestData
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
