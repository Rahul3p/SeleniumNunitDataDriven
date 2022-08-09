using System;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DataDrivenHybridFramework.TestUtils;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace DataDrivenHybridFramework.TestSetup
{
    public class Base
    {
        // public static IWebDriver driver;
        public static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();
        public ExtentReports extent;
        public ExtentTest test;

        [OneTimeSetUp]
        public void TestSuiteSetup()
        {
           string workingDirectory= Environment.CurrentDirectory;//Get path of Base.cs
           string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
           string reportPath = projectDirectory + "/index.html";

           ExtentHtmlReporter htmlReporter=new ExtentHtmlReporter(reportPath);
           extent = new ExtentReports();
           extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Username", "Way2Automation");



        }





        [SetUp]
        public void Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            string browser = ConfigurationManager.AppSettings["browser"];
            this.InitBrowser(browser);
            driver.Value.Url = ConfigurationManager.AppSettings["testURL"];
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if(status== TestStatus.Failed)
            {
                test.Fail("Test Case Failed");
            }
            else if(status== TestStatus.Passed)
            {
                test.Pass("Test Case Passed");
            }
           

            if (driver != null)
            {
                driver.Value.Quit();
            }

        }

        [OneTimeTearDown]
        public void TestSuiteTearDown()
        {
            extent.Flush();
        }

        public static JsonReader getDataReader()
        {
            return new JsonReader();
        }


        public  static IWebDriver GetDriver()
        {
            return driver.Value;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName.ToLower())
            {

                case "chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.LeaveBrowserRunning = true;
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver(options);
                    driver.Value.Manage().Window.Maximize();
                    break;
                case "firefox":

                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver.Value = new FirefoxDriver();
                    driver.Value.Manage().Window.Maximize();
                    break;
                case "safari":

                    SafariOptions sOption = new SafariOptions();
                    sOption.AddAdditionalOption("--lang", "de-DE");
                    driver.Value = new SafariDriver();
                    driver.Value.Manage().Window.Maximize();
                    break;
                default:
                    ChromeOptions options1 = new ChromeOptions();
                    options1.LeaveBrowserRunning = true;
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver.Value = new ChromeDriver(options1);
                    driver.Value.Manage().Window.Maximize();
                    break;
            }
        }
    }
}

