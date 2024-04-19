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
        private static IWebDriver driver_58_Son;
        private string url_58_Son = "https://divui.com/";
        private ChromeOptions options_58_Son = new ChromeOptions();
        private string username = "testtest123@yopmail.com";
        private string password = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath_58_Son = "chromedriver.exe";
            options_58_Son.AddArgument("--start-maximized");
            driver_58_Son = new ChromeDriver(chromeDriverPath_58_Son, options_58_Son);
            driver_58_Son.Navigate().GoToUrl(url_58_Son);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            IWebElement userLogin_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/login']"));
            userLogin_58_Son.Click();

            IWebElement usernameInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            usernameInput_58_Son.Clear();
            usernameInput_58_Son.SendKeys(username);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password);

            IWebElement rememberPassword_58_Son = driver_58_Son.FindElement(By.Id("RememberMe"));
            if (!rememberPassword_58_Son.Selected)
                rememberPassword_58_Son.Click();

            IWebElement btnLogin_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            btnLogin_58_Son.Click();
            Thread.Sleep(2000);
          
            IWebElement currentUser_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[2]/li[3]/a"));
            Assert.IsNotNull(currentUser_58_Son, "Login fail");
            Assert.AreEqual(username, currentUser_58_Son.Text, 
                "The username does not match after logging in.");
            Console.WriteLine(currentUser_58_Son.Text);
        }

        [TestMethod]
        public void LoginFail()
        {
            IWebElement userLogin_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/login']"));
            userLogin_58_Son.Click();

            IWebElement usernameInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            usernameInput_58_Son.Clear();
            usernameInput_58_Son.SendKeys(username);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys("testtest@1234");

            IWebElement rememberPassword_58_Son = driver_58_Son.FindElement(By.Id("RememberMe"));
            if (!rememberPassword_58_Son.Selected)
                rememberPassword_58_Son.Click();

            IWebElement btnLogin_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            btnLogin_58_Son.Click();

            IWebElement errorMessage_58_Son = driver_58_Son.FindElement(By.ClassName("validation-summary-errors"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Login failed.");
            Assert.AreEqual("Vui lòng kiểm tra lại thông tin đăng nhập\r\nThông tin đăng nhập chưa đúng",
                errorMessage_58_Son.Text, "Error message is incorrect.");
            Console.WriteLine(errorMessage_58_Son.Text);
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void CheckEmailInvalid()
        {
            IWebElement userLogin_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/login']"));
            userLogin_58_Son.Click();

            IWebElement usernameInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            usernameInput_58_Son.Clear();
            usernameInput_58_Son.SendKeys("testtest123@");

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password);

            IWebElement errorMessage_58_Son =
                driver_58_Son.FindElement(By.ClassName("field-validation-error"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Login failed.");
            Assert.AreEqual("Wrong email", errorMessage_58_Son.Text,
                "The error message does not match the expected message.");
            Console.WriteLine(errorMessage_58_Son.Text);
            Thread.Sleep(3000);
        }

        [TestMethod]
        public void CheckEmpty()
        {
            IWebElement userLogin_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/login']"));
            userLogin_58_Son.Click();

            IWebElement usernameInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            usernameInput_58_Son.Clear();
            usernameInput_58_Son.SendKeys("");

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys("");

            IWebElement rememberPassword_58_Son = driver_58_Son.FindElement(By.Id("RememberMe"));
            if (!rememberPassword_58_Son.Selected)
                rememberPassword_58_Son.Click();

            IWebElement btnLogin_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            btnLogin_58_Son.Click();

            IWebElement errorMessage_58_Son = driver_58_Son.FindElement(By.ClassName("field-validation-error"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Login failed.");
            Assert.AreEqual("Nhập email", errorMessage_58_Son.Text,
                "The error message does not match the expected message.");
            Console.WriteLine(errorMessage_58_Son.Text);
            Thread.Sleep(3000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver_58_Son.Quit();
        }

        public IWebDriver GetDriver()
        {
            return driver_58_Son;
        }
    }
}
