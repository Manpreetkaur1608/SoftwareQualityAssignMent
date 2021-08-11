using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.IO;

namespace SeleniumAssignment
{
   // [TestFixture]
    public class TestBase 
    {
        private static string logpath { get; set; }

        [SetUp]
        public void Setup()
        {
        }
        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                ScreenShot("Failure", true);
            }
        }
        [OneTimeSetUp]
        public virtual void Onetimesetup()
        {
        }
        [OneTimeTearDown]
        public virtual void Onetimeteardown()
        {
            Browser.Quit();
        }
        public static void ScreenShot(string fileName = null, bool hasTimeStamp = false)
        {
            fileName = fileName ?? TestContext.CurrentContext.Test.MethodName;
            Screenshot ss = ((ITakesScreenshot)Browser._Driver).GetScreenshot();
            string timestamp = DateTime.Now.ToString("yy-MM-dd hh-mm-ss");
            string screenshotFile = Path.Combine(TestContext.CurrentContext.WorkDirectory, fileName + (hasTimeStamp ? timestamp : null) + ".png");
            ss.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            TestContext.AddTestAttachment(screenshotFile, fileName + "Screenshot");
        }
    }
}
