using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.MagentoPages
{
    class HomePage
    {
        // static By myAccountLoc = By.LinkText("My Account");

        [FindsBy(How =How.LinkText,Using ="My Account")]
        IWebElement myAccountEle;


        IWebDriver driver;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void ClickOnMyAccount()
        {
            myAccountEle.Click();
        }

    }
}
