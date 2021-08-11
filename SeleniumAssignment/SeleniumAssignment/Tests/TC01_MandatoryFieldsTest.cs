using NUnit.Framework;
using SeleniumAssignment.Data;
using SeleniumAssignment.Pages;
using System.Threading;

namespace SeleniumAssignment.Tests
{
    [TestFixture]
    [Category("SaveRecord")]
    [Property("Priority", 1)]
    public class TC01_MandatoryFieldsTest : TestBase
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
        public void VerifyAddRecordPopupTest()
        {
            Page.HomePage.AddRecordIconClick();
            Assert.IsTrue(Page.HomePage.ISAddNewRecordPopupDisplayed(), "Add New Record Popup Displayed");
        }

        [Test, Order(2)]
        public void VerifySaveNewRecordTest()
        {
            Page.HomePage.EnterFirstName(Constants.RandomName("First Name"));
            Page.HomePage.EnterLastName(Constants.RandomName("Last Name"));
            Page.HomePage.EnterAddress(AssignmentData._Data.TestData.Address);
            Page.HomePage.EnterCity(AssignmentData._Data.TestData.City);
            Page.HomePage.EnterProvince(AssignmentData._Data.TestData.Province);
            Page.HomePage.EnterPostalCode(AssignmentData._Data.TestData.PostalCode);
            Page.HomePage.EnterPhoneNumber(AssignmentData._Data.TestData.PhoneNumber);
            Page.HomePage.EnterEmail(AssignmentData._Data.TestData.Email);
            Page.HomePage.EnterNotes(Constants._notes);
            Page.HomePage.SubmitButtonClick();
        }

        [Test, Order(3)]
        public void VerifySavedRecordInGridTest()
        {
            Assert.IsTrue(Page.HomePage.VerifySavedRecordInGrid(AssignmentData._Data.TestData.Email), "New Record Successfully Saved In Grid");
        }
    }
}
