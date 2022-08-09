
using DataDrivenHybridFramework.TestSetup;
using DataDrivenHybridFramework.TestUtils;
using OpenQA.Selenium;


namespace DataDrivenHybridFramework.PageObjects
{
    public class FacebookLandingPage :Base
    {
        By Email = By.Id("email");
        By Password = By.Id("pass");
        By LoginButton = By.Name("login");
        By CreateAccount = By.XPath("//a[text()='Create New Account']");
        By FirstName = By.Name("firstname");
        By SurName = By.Name("lastname");


        public void Login(string email, string pass)
        {
            //driver.FindElement(Email).SendKeys(email);//typing
            BrowserActions.Type(Email, email);
            // driver.FindElement(Password).SendKeys(pass);
            BrowserActions.Type(Password, pass);
            //driver.FindElement(LoginButton).Click();
            BrowserActions.Click(LoginButton);
            //Assert home page is displayed
        }

        public void InvalidLogin(string email, string pass)
        {
            //driver.FindElement(Email).SendKeys(email);//typing
            BrowserActions.Type(Email, email);
            // driver.FindElement(Password).SendKeys(pass);
            BrowserActions.Type(Password, pass);
            //driver.FindElement(LoginButton).Click();
            BrowserActions.Click(LoginButton);
            //Assert Error message has occured
        }


        public void SignUp(string firstName,string lastName)
        {
            BrowserActions.Click(CreateAccount);
            BrowserActions.Type(FirstName, firstName);
            BrowserActions.Type(SurName, lastName);

        }

    }
}

