
using NUnit.Framework;
using SeleniumAssignment.Data;
using SeleniumAssignment.Pages;

namespace SeleniumAssignment.Tests
{
    [TestFixture]
    [Category("SearchRecord")]
    [Property("Priority", 1)]
    class TC04_SearchRecordTest : TestBase
    {
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            AssignmentApp.Generate();
            AssignmentData.Generate("SampleData.json");
            Browser.Initialize(AssignmentApp.LastGeneratedApp.URL, "cdk-overlay-container");
            Browser._Driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(2);
            Browser.GotoUrl();
        }

        [Test, Order(1)]
        public void VerifySearchRecordTest()
        {
            //Search Record Based on Email Id (It's unique)
            Page.HomePage.EditRecord(AssignmentData._Data.TestData.Email);
            Assert.IsTrue(Page.HomePage.IsRecordFiltered(AssignmentData._Data.TestData.Email), "Searched Record Successfully filtered");
        }

    }
}
