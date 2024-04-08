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
        private IWebDriver driver;
        private string url = "https://divui.com/blog";
        private ChromeOptions options = new ChromeOptions();


        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath = "chromedriver.exe";
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromeDriverPath, options);
            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void checkEmpty()
        {
            IWebElement btnSearch = driver.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearch.Click();
            Thread.Sleep(1000);

            IWebElement searchInput = driver.FindElement(By.Id("td-header-search"));
            searchInput.Clear();
            searchInput.SendKeys("");
            Thread.Sleep(1000);

            IWebElement btnInput = driver.FindElement(By.Id("td-header-search-top"));
            btnInput.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogs = driver.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsNotNull(blogs);

        }

        [TestMethod]
        public void checkTextFail()
        {
            IWebElement btnSearch = driver.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearch.Click();
            Thread.Sleep(1000);

            IWebElement searchInput = driver.FindElement(By.Id("td-header-search"));
            searchInput.Clear();
            searchInput.SendKeys("A@!#*123d");
            Thread.Sleep(1000);

            IWebElement btnInput = driver.FindElement(By.Id("td-header-search-top"));
            btnInput.Click();
            Thread.Sleep(5000);

            IWebElement result = driver.FindElement(By.CssSelector(".no-results>h2"));
            Assert.IsNotNull(result, "Element message not found. Testcase fail");
            Assert.AreEqual(result.Text, "No results for your search");

        }

        [TestMethod]
        public void checkTextSuccess()
        {
            IWebElement btnSearch = driver.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearch.Click();
            Thread.Sleep(1000);

            IWebElement searchInput = driver.FindElement(By.Id("td-header-search"));
            searchInput.Clear();
            searchInput.SendKeys("Biển");
            Thread.Sleep(1000);

            IWebElement btnInput = driver.FindElement(By.Id("td-header-search-top"));
            btnInput.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogs = driver.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsNotNull(blogs);

        }

        public void checkNumberSuccess()
        {
            IWebElement btnSearch = driver.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearch.Click();
            Thread.Sleep(1000);

            IWebElement searchInput = driver.FindElement(By.Id("td-header-search"));
            searchInput.Clear();
            searchInput.SendKeys("Biển");
            Thread.Sleep(1000);

            IWebElement btnInput = driver.FindElement(By.Id("td-header-search-top"));
            btnInput.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogs = driver.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsNotNull(blogs);

        }

        [TestMethod]
        public void checkSpecialSuccess()
        {
            IWebElement btnSearch = driver.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearch.Click();
            Thread.Sleep(1000);

            IWebElement searchInput = driver.FindElement(By.Id("td-header-search"));
            searchInput.Clear();
            searchInput.SendKeys("@");
            Thread.Sleep(1000);

            IWebElement btnInput = driver.FindElement(By.Id("td-header-search-top"));
            btnInput.Click();
            Thread.Sleep(5000);

            IList<IWebElement> blogs = driver.FindElements(By.CssSelector(".td_module_16"));
            Assert.IsNotNull(blogs);
        }



        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
