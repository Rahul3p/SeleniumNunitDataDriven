using System;
using DataDrivenHybridFramework.TestSetup;
using OpenQA.Selenium;

namespace DataDrivenHybridFramework.TestUtils
{
    public class BrowserActions:Base
    {
        public static void Type(By field,string value)
        {
            WaitUtil.WaitForElementTOBeDisplayed(field);
           GetDriver().FindElement(field).SendKeys(value);
        }

        public static void Click(By field)
        {
            WaitUtil.WaitForElementTOBeClickable(field);
            GetDriver().FindElement(field).Click();
        }
    }
}

