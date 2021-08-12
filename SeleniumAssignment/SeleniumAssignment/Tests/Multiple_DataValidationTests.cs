using NUnit.Framework;
using SeleniumAssignment.Data;
using SeleniumAssignment.Pages;

namespace SeleniumAssignment.Tests
{
    [TestFixture]
    [Category("DataValidation")]
    [Property("Priority", 2)]
    class Multiple_DataValidationTests : TestBase
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
        public void VerifyHomePageTitleTest()
        {
            Assert.IsTrue(Page.HomePage.VerifyTitle(Constants._homePageTitle), "Verified that title is correct");
        }

        [Test, Order(2)]
        public void VerifyInvalidPhoneNumberTest()
        {
            Page.HomePage.AddRecordIconClick();
            Assert.IsTrue(Page.HomePage.ISAddNewRecordPopupDisplayed(), "Add New Record Popup Displayed");

            //Enter 5 digit random invalid Phone number
            Page.HomePage.EnterPhoneNumber(Constants.RandomNumber(5));
            Assert.IsTrue(Page.HomePage.IsFieldErrorDisplayed("Phone Number"), "An error displayed for invalid 'Phone Number'");
            Page.HomePage.CloseAddNewRecordPopup();
        }

        [Test, Order(3)]
        public void VerifyInvalidPostalCodeTestNumberTest()
        {
            Page.HomePage.AddRecordIconClick();
            Assert.IsTrue(Page.HomePage.ISAddNewRecordPopupDisplayed(), "Add New Record Popup Displayed");

            //Enter random invalid Postal Code
            Page.HomePage.EnterPostalCode(Constants.RandomNumber(10));
            Assert.IsTrue(Page.HomePage.IsFieldErrorDisplayed("Postal Code"), "An error displayed for invalid 'Postal Code'");
            Page.HomePage.CloseAddNewRecordPopup();
        }
    }
}
