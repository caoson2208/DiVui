using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Login
    {
        private IWebDriver driver;
        private string url = "https://divui.com/";
        private string username = "caoson@yopmail.com";
        private string password = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath = "chromedriver.exe";
            driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            IWebElement login = driver.FindElement(By.XPath("//a[@href='/login']"));
            login.Click();

            IWebElement usernameInput = driver.FindElement(By.Id("Email"));
            usernameInput.Clear();
            usernameInput.SendKeys(username);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            IWebElement rememberPassword = driver.FindElement(By.Id("RememberMe"));
            rememberPassword.Click();

            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            loginButton.Click();

            Thread.Sleep(2000);

            IWebElement currentUser = driver.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[2]/li[3]/a"));
            Assert.IsNotNull(currentUser, "Login fail");
            Assert.AreEqual(username, currentUser.Text, "The username does not match after logging in.");
            Console.WriteLine(currentUser.Text);
        }

        [TestMethod]
        public void LoginFail()
        {
            IWebElement login = driver.FindElement(By.XPath("//a[@href='/login']"));
            login.Click();

            IWebElement usernameInput = driver.FindElement(By.Id("Email"));
            usernameInput.Clear();
            usernameInput.SendKeys(username);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys("testtest@1234");

            IWebElement rememberPassword = driver.FindElement(By.Id("RememberMe"));
            rememberPassword.Click();

            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            loginButton.Click();



            IWebElement errorMessage = driver.FindElement(By.ClassName("validation-summary-errors"));
            Assert.IsNotNull(errorMessage, "Error message element not found. Login failed.");

            Assert.AreEqual("Vui lòng kiểm tra lại thông tin đăng nhập\r\nThông tin đăng nhập chưa đúng",
                errorMessage.Text, "Error message is incorrect.");

            Console.WriteLine(errorMessage.Text);
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void CheckEmail()
        {
            IWebElement login = driver.FindElement(By.XPath("//a[@href='/login']"));
            login.Click();

            IWebElement usernameInput = driver.FindElement(By.Id("Email"));
            usernameInput.Clear();
            usernameInput.SendKeys("caoson@");

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            IWebElement errorMessage = driver.FindElement(By.ClassName("field-validation-error"));
            Assert.AreEqual("Wrong email", errorMessage.Text, 
                "The error message does not match the expected message.");
            Console.WriteLine(errorMessage.Text);
            Thread.Sleep(3000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }
    }
}
