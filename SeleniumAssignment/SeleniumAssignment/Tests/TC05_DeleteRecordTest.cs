using NUnit.Framework;
using SeleniumAssignment.Data;
using SeleniumAssignment.Pages;
namespace SeleniumAssignment.Tests
{
    class TC05_DeleteRecordTest : TestBase
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
        public void VerifyDeleteRecordTest()
        {
            //Search Record Based on Unique Email Id
            Page.HomePage.DeleteRecordButtonClick(Constants._email);
            Assert.IsTrue(Page.HomePage.IsDeleteConfirmationPopuDIsplayed(), "Confirmation Popup Displayed");
            Page.HomePage.PopupDeleteButtonClick();
            Assert.IsFalse(Page.HomePage.VerifySavedRecordInGrid(Constants._email), "Record Deleted Successfully");
        }
    }
}
