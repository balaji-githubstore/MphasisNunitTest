using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.MagentoPages
{
    class MainPage
    {
        //static By logOutLoc = By.PartialLinkText("Out");

        [FindsBy(How =How.LinkText,Using ="Log Out")]
        IWebElement logOut;

        [FindsBy(How = How.TagName, Using = "a")]
        IList<IWebElement> links;

        IWebDriver driver;
        WebDriverWait wait;
        public MainPage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;
            PageFactory.InitElements(driver, this);
        }

        public String GetTitle()
        {
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.PartialLinkText("Out")));
            return driver.Title;
        }


        public void ClickOnLogOut()
        {
            logOut.Click();
        }
    }
}
