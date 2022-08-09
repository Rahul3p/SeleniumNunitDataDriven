using System;
using DataDrivenHybridFramework.PageObjects;
using DataDrivenHybridFramework.TestSetup;
using NUnit.Framework;

namespace DataDrivenHybridFramework.TestCases
{
    [Parallelizable(ParallelScope.Self)]
    public class TestSignUp:Base
    {
        [Test, TestCaseSource(nameof(GetTestData))]
        
        public void VerifySignUp(string firstName, string lastName)
        {
            FacebookLandingPage LandingPage = new FacebookLandingPage();
            LandingPage.SignUp(firstName, lastName);
            Thread.Sleep(10000);

        }

        public static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(getDataReader().GetTestData("firstName"), getDataReader().GetTestData("lastName"));

        }


    }
}

