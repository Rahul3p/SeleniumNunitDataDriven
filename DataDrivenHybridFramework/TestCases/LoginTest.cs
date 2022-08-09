using System;
using DataDrivenHybridFramework.PageObjects;
using DataDrivenHybridFramework.TestSetup;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DataDrivenHybridFramework.TestCases
{
    [Parallelizable(ParallelScope.Self)]
    public class LoginTest : Base
    {

        [Test]
        [TestCaseSource(nameof(GetTestData))]
        public void VerifyLogin(string email, string password)
        {
            FacebookLandingPage LandingPage = new FacebookLandingPage();
            LandingPage.Login(email,password);
            Thread.Sleep(10000);

        }

        [Test]
        public void VerifyLoginDummy()
        {
            FacebookLandingPage LandingPage = new FacebookLandingPage();
            LandingPage.Login("sdhfsdf", "sdfsdf");
            Thread.Sleep(10000);

        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
           yield return new TestCaseData(getDataReader().GetTestData("validEmail"),getDataReader().GetTestData("validPassword"));
           
        }
    }
}

