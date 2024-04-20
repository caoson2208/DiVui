using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestDivuiWebsite
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    [TestClass]
    public class Search
    {
        private IWebDriver driverThang_63;
        private string urlThang_63 = "https://divui.com/blog";
        private ChromeOptions optionsThang_63 = new ChromeOptions();


        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath = "chromedriver.exe";
            optionsThang_63.AddArgument("--start-maximized");
            driverThang_63 = new ChromeDriver(chromeDriverPath, optionsThang_63);
            driverThang_63.Navigate().GoToUrl(urlThang_63);
        }

        [TestMethod]
        public void checkEmptyThang_63()
        {
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            searchInputThang_63.SendKeys("");
            Thread.Sleep(1000);

            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }

        [TestMethod]
        public void checkTextFailThang_63()
        {
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            searchInputThang_63.SendKeys("A@!#*123fd");
            Thread.Sleep(1000);

            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(10000);

            IWebElement resultThang_63 = driverThang_63.FindElement(By.CssSelector(".no-results>h2"));
            Assert.IsNotNull(resultThang_63, "Element message not found. Testcase fail");
            Assert.AreEqual(resultThang_63.Text, "No results for your search");

        }

        [TestMethod]
        public void checkTextSuccessThang_63()
        {
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            searchInputThang_63.SendKeys("Biển");
            Thread.Sleep(1000);

            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }

        [TestMethod]
        public void checkNumberSuccessThang_63()
        {
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            searchInputThang_63.SendKeys("2018");
            Thread.Sleep(1000);

            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }

        [TestMethod]
        public void checkSpecialSuccessThang_63()
        {
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            searchInputThang_63.SendKeys("@");
            Thread.Sleep(1000);

            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }



        [TestCleanup]
        public void TearDownThang_63()
        {
            if (driverThang_63 != null)
            {
                driverThang_63.Quit();
            }
        }
    }
}
