using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumAssignment.Pages
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            IWebDriver driver = Browser._Driver;
            PageFactory.InitElements(Browser.Driver, page);
            return page;
        }
        public static HomePage HomePage
        {
            get { return GetPage<HomePage>(); }
        }
    }
}
