using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitFramework.DataAccessLayer;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitFramework
{
    public class SetUp
    {
        protected String xmlDir;
        protected String propDir;
        protected String jsonDir;
        protected String excelDir;
        protected FileReader fileRead;
        protected IWebDriver driver;
        protected WebDriverWait wait;

        protected ExtentReports extent;
        protected ExtentTest test;

        protected string reportDir;
        protected string screenShotDir;
        [OneTimeSetUp]
        public void Initialization()
        {

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string ParentDir = new Uri(actualPath).LocalPath;

            xmlDir = ParentDir + @"\Test Data\magentodata.xml";
            propDir = ParentDir + @"\Test Data\data.properties";
            jsonDir = ParentDir + @"\Test Data\data.json";
            excelDir = ParentDir + @"\Test Data\HybridDemo.xlsx";
            fileRead = new FileReader();

            //Extent report
            String date = DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');

            reportDir = ParentDir + @"Reports\ExtentReport_" + date + ".html";
            screenShotDir=ParentDir+ @"Reports\ScreenShot_" + date + ".png";
            ExtentHtmlReporter reporter = new ExtentHtmlReporter(reportDir);
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }

        [SetUp]
        public void BrowerSetup()
        {
            driver = new ChromeDriver(@"D:\Mine\Company\Maveric\Driver");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Manage().Window.Maximize();
        }


        [TearDown]
        public void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                ss.SaveAsFile(screenShotDir);

                test.Log(Status.Fail, stackTrace + errorMessage);
                test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenShotDir));
            }
            driver.Quit();
        }

        //[TearDown,Order(1)]
        //public void CloseBrowser()
        //{
        //   // driver.Quit();
        //}

        [OneTimeTearDown]
        public void ExtentFlush()
        {
            driver.Quit();
            extent.Flush();
        }
    }
}
