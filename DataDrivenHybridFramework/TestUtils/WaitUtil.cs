using System;
using DataDrivenHybridFramework.TestSetup;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenHybridFramework.TestUtils
{
    public class WaitUtil:Base
    {



        public static void WaitForElementTOBeDisplayed(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));

        }

        public static void WaitForElementTOBeClickable(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));

        }

        public static void WaitForElementTOBePresent(By element)
        {
            WebDriverWait wait = new WebDriverWait(GetDriver(), TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(element));
        }







    }
}

