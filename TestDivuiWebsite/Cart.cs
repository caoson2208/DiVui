using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Security.Policy;
using System.Net.NetworkInformation;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Cart
    {
        private IWebDriver driver;
        private Login login = new Login();

        [TestInitialize]
        public void SetUp()
        {
            login.SetUp();
            driver = login.GetDriver();
            login.LoginSuccess();
        }

        [TestMethod]
        public void AddToCartSucces()
        {
            IWebElement searchLocation = driver.FindElement(By.XPath("//*[@id=\"small-search-box-form\"]/button/i"));
            searchLocation.Click();

            Thread.Sleep(1000);
            IWebElement location = driver.FindElement(By.XPath("//a[contains(text(), 'Hồ Chí Minh')]"));
            location.Click();

            IWebElement productCart = driver.FindElement(By.XPath("//article[1]/a"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].removeAttribute('target');", productCart);
            Thread.Sleep(1000);
            productCart.Click();
            Thread.Sleep(1000);

            IWebElement btnOrderOnl = driver.FindElement(By.XPath("//div[3]/a"));
            btnOrderOnl.Click();
            Thread.Sleep(1000);

            IWebElement checkPrice = driver.FindElement(By.Id("btncheckprice"));
            checkPrice.Click();
            Thread.Sleep(1000);

            IWebElement btnOrderOnl2 = driver.FindElement(By.Id("addtocartproduct-option-7718"));
            btnOrderOnl2.Click();
            Thread.Sleep(2000);

            //IWebElement btnRemove = driver.FindElement(By.ClassName("cart-control"));
            //btnRemove.Click();
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}



