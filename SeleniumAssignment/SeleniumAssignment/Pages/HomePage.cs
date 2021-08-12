using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumAssignment.Pages
{
    public class HomePage
    {
        //WebElements
        IWebElement AddRecordIcon => Browser._Driver.FindElementTimeout(By.CssSelector("[aria-label*='icon-button']"));
        IWebElement NewRecordPopup => Browser._Driver.FindElementTimeout(By.CssSelector(".cdk-overlay-pane .mat-dialog-container "));
        IWebElement FirstName => Browser._Driver.FindElementTimeout(By.XPath("//input[@placeholder='First Name']"));
        IWebElement LastName => Browser._Driver.FindElementTimeout(By.Name("lastName"));
        IWebElement Address => Browser._Driver.FindElementTimeout(By.XPath("//input[@placeholder='Address']"));
        IWebElement City => Browser._Driver.FindElementTimeout(By.XPath("//input[@placeholder='City']"));
        IWebElement Province => Browser._Driver.FindElementTimeout(By.XPath("//input[@placeholder='Province']"));
        IWebElement PostalCode => Browser._Driver.FindElementTimeout(By.CssSelector("input[placeholder*='Postal']"));
        IWebElement PhoneNumber => Browser._Driver.FindElementTimeout(By.CssSelector("input[placeholder*='Phone']"));
        IWebElement Email => Browser._Driver.FindElementTimeout(By.CssSelector("input[placeholder*='Email']"));
        IWebElement Notes => Browser._Driver.FindElementTimeout(By.CssSelector("input[placeholder*='Notes']"));
        IWebElement Save => Browser._Driver.FindElementTimeout(By.XPath("//span[text()='Save']"));
        IWebElement Cancel => Browser._Driver.FindElementTimeout(By.XPath("//span[text()='Cancel']"));
        IWebElement Filter => Browser._Driver.FindElementTimeout(By.CssSelector("[placeholder*='Filter']"));
        IWebElement ConfirmationPopup => Browser._Driver.FindElementTimeout(DeletConfirmation);
        By DeletConfirmation = By.CssSelector("mat-dialog-container.mat-dialog-container"); IWebElement PopupDeleteButton => Browser._Driver.FindElementTimeout(By.XPath("//span[text()='Delete']"));

        IWebElement RequiredFieldError(string fieldName)
        {
            By errorMessage = By.XPath($"//input[@placeholder='{fieldName}'] /../../.. //mat-error ");
            return Browser._Driver.FindElementTimeout(errorMessage);
        }
        IWebElement EditButton(string emailId)
        {
            By editButton = By.XPath($"//mat-cell[text()=' {emailId}']/..//mat-icon[@aria-label='Edit']");
            return Browser._Driver.FindElementTimeout(editButton);
        }
        IWebElement DeleteButton(string emailId)
        {
            By editButton = By.XPath($"//mat-cell[text()=' {emailId}']/..//mat-icon[@aria-label='Delete']");
            return Browser._Driver.FindElementTimeout(editButton);
        }
        By SearchButtonSelector = By.XPath("//input[@type='search']");
        IReadOnlyList<IWebElement> AllRecordEmailColumn => Browser._Driver.FindElementsTimeout(By.CssSelector("mat-cell.mat-column-email"));
        IReadOnlyList<IWebElement> AllRecordFirstNameColumn => Browser._Driver.FindElementsTimeout(By.CssSelector("mat-cell.cdk-column-firstName"));
        IReadOnlyList<IWebElement> RecordFieldError => Browser._Driver.FindElementsTimeout(By.CssSelector("[role='alert']"));


        //Methods
        public void AddRecordIconClick()
        {
            AddRecordIcon.Click();
        }

        public bool ISAddNewRecordPopupDisplayed()
        {
            return NewRecordPopup.Displayed;
        }

        public void EnterFirstName(string firstName)
        {
            FirstName.Clear();
            FirstName.SendKeys(firstName);
        }

        public void EnterLastName(string lastName)
        {
            LastName.SendKeys(lastName);
        }

        public void EnterAddress(string address)
        {
            Address.SendKeys(address);
        }

        public void EnterCity(string city)
        {
            City.SendKeys(city);
        }

        public void EnterProvince(string province)
        {
            Province.SendKeys(province);
        }

        public void EnterPostalCode(string code)
        {
            PostalCode.SendKeys(code);
            PhoneNumber.Click();
        }

        public void EnterPhoneNumber(string phone)
        {
            Browser.ScollToElement(PhoneNumber);
            PhoneNumber.SendKeys(phone);
        }

        public void EnterEmail(string email)
        {
            Email.SendKeys(email);
        }

        public void SubmitButtonClick()
        {
            Save.Click();
            Browser._Driver.WaitUntilInvisible(SearchButtonSelector);
        }

        public void EnterNotes(string notes)
        {
            Notes.SendKeys(notes);
        }

        public bool VerifySavedRecordInGrid(string emaiId)
        {
            bool recordIsPresent = false;
            for (int i = 0; i < AllRecordEmailColumn.Count; i++)
            {
                if (AllRecordEmailColumn[i].Text.Contains(emaiId))
                {
                    recordIsPresent = true;
                    break;
                }
            }
            return recordIsPresent;
        }

        public bool VerifyAllFieldsMandatory_OnAddRecordPopup()
        {
            Browser._Driver.WaitUntilElementClickable(FirstName);
            FirstName.Click();
            LastName.Click();
            Address.Click();
            City.Click();
            Province.Click();
            return RequiredFieldError("First Name").Text.Contains("Required field") &&
            RequiredFieldError("Address").Text.Contains("Required field") &&
            RequiredFieldError("City").Text.Contains("Required field"); // So On...
        }

        public void CloseAddNewRecordPopup()
        {
            Browser.ScollToElement(Cancel);
            Cancel.Click();
        }

        public void SearchRecord(string emailId) // Unique Email Id
        {
            Filter.SendKeys(emailId);
        }

        public bool IsRecordFiltered(string emailId)
        {
            if (AllRecordEmailColumn.Count == 1 && AllRecordEmailColumn.First().Text.Contains(emailId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EditRecord(string emailId) // Unique Email Id
        {
            EditButton(emailId).Click();
        }

        public bool VerifyFirstNameUpdated()
        {
            bool risRecordUpdated = false;
            for (int i = 0; i < AllRecordEmailColumn.Count; i++)
            {
                if (AllRecordFirstNameColumn[i].Text.Contains("Updated"))
                {
                    risRecordUpdated = true;
                    break;
                }
            }
            return risRecordUpdated;
        }

        public void DeleteRecordButtonClick(string emailId) // Unique Email Id
        {
            DeleteButton(emailId).Click();
        }

        public bool IsDeleteConfirmationPopuDIsplayed()
        {
            Browser._Driver.WaitUntilVisible(DeletConfirmation);
            return ConfirmationPopup.Displayed;
        }

        public void PopupDeleteButtonClick()
        {
            PopupDeleteButton.Click();
            Browser._Driver.WaitUntilInvisible(By.XPath("//span[text()='Delete']"));
        }

        public bool IsFieldErrorDisplayed(string fieldName)
        {
            return RequiredFieldError(fieldName).Displayed ? true : false;
        }

        public bool VerifyTitle(string partialTitle)
        {
            return Browser._Driver.Title.Contains(partialTitle);
        }
    }
}