using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAssignment;
using System;

namespace SeleniumAssignment
{
    public class Browser
    {
        private static string _appURL = null;
        private static string _preloader = null;
        private static IWebDriver _driver = null;
        public Browser()
        {

        }
        public static void Initialize(string appURL, string preloader, string browserName = "Chrome")
        {
            switch (browserName)
            {
                case "Chrome":
                    _driver = new ChromeDriver();
                    _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
                    break;
                case "IE":
                    break;
            }
            _appURL = appURL;
            _preloader = preloader;
            _driver.Manage().Window.Maximize();
        }
        public static IWebDriver _Driver
        {
            get { return _driver; }
        }
        public static void GotoUrl()
        {
            _driver.Navigate().GoToUrl(_appURL);
        }
        public static ISearchContext Driver
        {
            get { return _driver; }
        }
        public static void Quit()
        {
            _driver.Quit();
        }
        public static void ScollToElement(IWebElement el)
        {
            ((IJavaScriptExecutor)Browser._Driver).ExecuteScript("arguments[0].scrollIntoView(true);", el);
        }
    }
}
