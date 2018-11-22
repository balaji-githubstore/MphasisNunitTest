using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.MagentoPages
{
    class LoginPage
    {
        //static By emailLoc = By.Id("email");
        //By passLoc = By.Name("login[password]");
        //static By loginLoc = By.Id("send2");

        [FindsBy(How =How.Id,Using = "email")]
        IWebElement emailEle;

        [FindsBy(How = How.Id, Using = "pass")]
        IWebElement passEle;

        [FindsBy(How = How.Id, Using = "send2")]
        IWebElement loginEle;

        IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void EnterEmailAddress(String emailAddress)
        {
            emailEle.SendKeys(emailAddress);
        }
        public void EnterPassword(String password)
        {
            passEle.SendKeys(password);
        }
        public void ClickOnLogin()
        {
            loginEle.Click();
        }
    }
}
