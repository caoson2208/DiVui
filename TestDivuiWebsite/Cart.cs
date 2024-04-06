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
using TestDivuiWebsite;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Cart
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
        public void AddToCartSuccess()
        {
            IWebElement searchLocation = driver.FindElement(By.XPath("//*[@id=\"small-search-box-form\"]/button/i"));
            searchLocation.Click();
            Thread.Sleep(1000);

            IWebElement nameCity = driver.FindElement(By.XPath("//a[contains(text(), 'Hồ Chí Minh')]"));
            nameCity.Click();

            IWebElement dropdownCountry = driver.FindElement(By.Id("countryId"));
            dropdownCountry.Click();
            SelectElement selectCountry = new SelectElement(dropdownCountry);
            selectCountry.SelectByIndex(1);
            Thread.Sleep(1000);

            IWebElement dropdownCity = driver.FindElement(By.Id("cityId"));
            dropdownCity.Click();
            SelectElement selectCity = new SelectElement(dropdownCity);
            selectCity.SelectByIndex(1);
            Thread.Sleep(1000);

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

            IWebElement dropdownQuantity = driver.FindElement(By.Id("addtocart_20237_EnteredQuantity"));
            dropdownQuantity.Click();
            SelectElement selectQuantity = new SelectElement(dropdownQuantity);
            selectQuantity.SelectByIndex(2);
            Thread.Sleep(1000);

            IWebElement dropdownSampling = driver.FindElement(By.Id("product_attribute_17860"));
            dropdownSampling.Click();
            SelectElement selectSampling = new SelectElement(dropdownSampling);
            selectSampling.SelectByIndex(2);
            Thread.Sleep(1000);

            IWebElement btnOrderOnl2 = driver.FindElement(By.Id("addtocartproduct-option-7718"));
            btnOrderOnl2.Click();
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}



