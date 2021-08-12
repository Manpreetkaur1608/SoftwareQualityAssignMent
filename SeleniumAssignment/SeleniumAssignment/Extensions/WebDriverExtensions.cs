using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumAssignment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SeleniumAssignment
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElementTimeout(this IWebDriver driver, By by, int timeoutInSeconds = 15)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until((d) =>
                {
                    return d.FindElement(by);
                });
            }
            return driver.FindElement(by);
        }
                public static IReadOnlyList<IWebElement> FindElementsTimeout(this IWebDriver driver, By by, int timeoutInSeconds = 15)
        {
            if (timeoutInSeconds > 0)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElements(by));
            }
            return driver.FindElements(by);
        }

        public static void WaitUntilElementClickable(this IWebDriver driver, IWebElement element, int timeoutInSeconds = 20)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds)).Until(d =>
            {
                Boolean elementClicked = false;
                try
                {
                    element.Click();
                    elementClicked = true;
                }
                catch (Exception) { }

                return elementClicked;
            });
        }
        public static void WaitUntilVisible(this IWebDriver driver, By by, int timeoutInSeconds = 60)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));
        }
        public static void WaitUntilInvisible(this IWebDriver driver, By by, int timeoutInSeconds = 20)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (WebDriverTimeoutException)
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
        }
    }
}

