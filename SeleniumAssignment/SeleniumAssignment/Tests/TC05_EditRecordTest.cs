using NUnit.Framework;
using SeleniumAssignment.Data;
using SeleniumAssignment.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAssignment.Tests
{
    [TestFixture]
    [Category("EditRecord")]
    [Property("Priority", 1)]
    class TC05_EditRecordTest : TestBase
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
        public void VerifyEditRecordTest()
        {
            //Search Record Based on Email Id
            Page.HomePage.EditRecord(Constants._email);
            Assert.IsTrue(Page.HomePage.ISAddNewRecordPopupDisplayed(), "Add New Record Popup Displayed");
            Page.HomePage.EnterFirstName(Constants.RandomName("First Name : Updated")); //Updated First Name
            Page.HomePage.EnterNotes(Constants._notes);
            Page.HomePage.SubmitButtonClick();
            Assert.IsTrue(Page.HomePage.VerifyFirstNameUpdated(), "First Name Updated Successfully");
        }
    }
}
