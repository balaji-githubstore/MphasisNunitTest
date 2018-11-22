using AventStack.ExtentReports;
using NUnit.Framework;
using NUnitFramework.DataAccessLayer;
using NUnitFramework.MagentoPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace NunitFramework
{
    public class BaseTest : SetUp
    {
        [Test,Order(1)]
        public void PositiveCredential()
        {
            test = extent.CreateTest("PositiveCredential");

            var data= fileRead.XmlToDic(xmlDir);
             
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = data["url"]; //wait for infinite time

            HomePage home = new HomePage(driver);
            home.ClickOnMyAccount();

            LoginPage login = new LoginPage(driver);

            login.EnterEmailAddress(data["username"]);
            login.EnterPassword(data["password"]);
            login.ClickOnLogin();

            MainPage main = new MainPage(driver, wait);

            String actualTitle = main.GetTitle();

            Assert.AreEqual("My Account", actualTitle);
            main.ClickOnLogOut();

            test.Log(Status.Pass, "Positive test passed!!!");
        }
        [Test,Order(2)]
        public void NegativeCredential()
        {
            test = extent.CreateTest("NegativeCredential");
            Assert.Fail();
            var data = fileRead.XmlToDic(xmlDir);
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(90));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = data["url"]; //wait for infinite time

            HomePage home = new HomePage(driver);
            home.ClickOnMyAccount();

            LoginPage login = new LoginPage(driver);

            login.EnterEmailAddress("kkk"+data["username"]);
            login.EnterPassword(data["password"]);
            login.ClickOnLogin();

            MainPage main = new MainPage(driver, wait);

            String actualTitle = main.GetTitle();

            Assert.AreEqual("My Account", actualTitle);
            main.ClickOnLogOut();
            test.Log(Status.Pass, "Negative test passed!!!");
            try
            {

            }
            catch(Exception ex)
            {
                //test.Log()
                Assert.Fail();
            }
        }



        [Test,Repeat(5),Ignore("Not req",Until ="2018-12-12"),Category("B")]
        public void Test()
        {
            Console.WriteLine("a");
        }
        [Test, Category("A")]
        public void Test1()
        {
            Console.WriteLine("a");
        }

        [TestCase("ff"),Category("A"),Category("B")]
        [TestCase("ch")]
        [TestCase("Ie")]
        public void Test2(String browser)
        {
            Console.WriteLine(browser);
        }

        [Test]
        public void Test3([Random(1,100,25)] int number)
        {
            Console.WriteLine(number);
        }
        [Test,MaxTime(5000)]
        public void Test31([Range(1, 10,2)] int number)
        {

        }
        [Test, Timeout(5000)]
        public void Test4([Range(1, 10)] int number)
        {

        }

        [Test]
        public void test45([Values("j","k","l")]String browser)
        {

        }
    }
}
