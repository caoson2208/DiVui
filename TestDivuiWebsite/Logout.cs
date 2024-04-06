using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Logout
    {
        private static IWebDriver driver;
        private Login login = new Login();

        [TestInitialize]
        public void SetUp()
        {
            login.SetUp();
            driver = login.GetDriver();
            login.LoginSuccess();
        }

        [TestMethod]
        public void LogoutSuccess()
        {
            IWebElement profile = driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[2]/li[3]/a"));
            profile.Click();
            Thread.Sleep(1000);

            IWebElement btnLogout = driver.FindElement(By.XPath("//a[@href='/logout']"));
            btnLogout.Click();
            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
