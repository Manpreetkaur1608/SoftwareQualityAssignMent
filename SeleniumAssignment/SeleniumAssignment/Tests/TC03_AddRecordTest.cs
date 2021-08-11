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
    [Category("Mandatory")]
    [Property("Priority", 1)]
    public class TC03_AddRecordTest : TestBase
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
        public void VerifyMandatoryFieldTest()
        {
            Page.HomePage.AddRecordIconClick();
            Assert.IsTrue(Page.HomePage.VerifyAllFieldsMandatory_OnAddRecordPopup(), "All the fields are mandatory on 'Add new Record' popup");
            Page.HomePage.CloseAddNewRecordPopup();
        }
    }
}
