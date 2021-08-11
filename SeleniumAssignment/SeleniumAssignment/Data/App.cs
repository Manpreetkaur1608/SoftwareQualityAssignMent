using NUnit.Framework;
using System.Configuration;

namespace SeleniumAssignment.Data
{
    public class AssignmentApp
    {
        public static App LastGeneratedApp;
        public static void Initialize()
        {
            LastGeneratedApp = null;
        }
        public static App Generate()
        {
            var app = new App
            {
                URL = TestContext.Parameters["WebAppUrl"] ?? ConfigurationManager.AppSettings["AppURL"]
            };
            LastGeneratedApp = app;
            return app;
        }
    }
    public class App
    {
        public string URL { get; set; }
    }
}

