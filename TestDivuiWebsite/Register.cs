using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Register
    {
        private IWebDriver driver;
        private string url = "https://divui.com/";
        private ChromeOptions options = new ChromeOptions();
        private string lastname = "testest";
        private string email = "testtest123@yopmail.com";
        private string password = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath = "chromedriver.exe";
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(chromeDriverPath, options);
            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void RegisterSucces()
        {
            IWebElement userRegister = driver.FindElement(By.XPath("//a[@href='/register']"));
            userRegister.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown = driver.FindElement(By.Id("FirstName"));
            firstnameDropdown.Click();
            SelectElement firstNameSelect = new SelectElement(firstnameDropdown);
            firstNameSelect.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput = driver.FindElement(By.Id("LastName"));
            lastnameInput.Clear();
            lastnameInput.SendKeys(lastname);
            Thread.Sleep(500);

            IWebElement emailInput = driver.FindElement(By.Id("Email"));
            emailInput.Clear();
            emailInput.SendKeys(email);
            Thread.Sleep(500);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            Thread.Sleep(500);

            IWebElement confirmpasswordInput = driver.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput.Clear();
            confirmpasswordInput.SendKeys(password);
            Thread.Sleep(500);

            IWebElement newsletter = driver.FindElement(By.Id("Newsletter"));
            if (!newsletter.Selected)
                newsletter.Click();

            IWebElement btnRegister = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister.Click();
            Thread.Sleep(2000);

            IWebElement registerMessage = driver.FindElement(By.ClassName("login-intro"));
            Assert.IsNotNull(registerMessage, "Error message element not found. Register failed.");
            Assert.AreEqual("Quá trình đăng ký tài khoản đã hoàn tất.",
                registerMessage.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void RegisterFail()
        {
            IWebElement userRegister = driver.FindElement(By.XPath("//a[@href='/register']"));
            userRegister.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown = driver.FindElement(By.Id("FirstName"));
            firstnameDropdown.Click();
            SelectElement firstNameSelect = new SelectElement(firstnameDropdown);
            firstNameSelect.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput = driver.FindElement(By.Id("LastName"));
            lastnameInput.Clear();
            lastnameInput.SendKeys(lastname);
            Thread.Sleep(500);

            IWebElement emailInput = driver.FindElement(By.Id("Email"));
            emailInput.Clear();
            emailInput.SendKeys(email);
            Thread.Sleep(500);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            Thread.Sleep(500);

            IWebElement confirmpasswordInput = driver.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput.Clear();
            confirmpasswordInput.SendKeys(password);
            Thread.Sleep(500);

            IWebElement newsletter = driver.FindElement(By.Id("Newsletter"));
            if (!newsletter.Selected)
                newsletter.Click();

            IWebElement btnRegister = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister.Click();

            IWebElement errorMessage = driver.FindElement(By.ClassName("validation-summary-errors"));
            Assert.IsNotNull(errorMessage, "Error message element not found. Register failed.");
            Assert.AreEqual("Địa chỉ email này đã được sử dụng",
                errorMessage.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckPassword()
        {
            IWebElement userRegister = driver.FindElement(By.XPath("//a[@href='/register']"));
            userRegister.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown = driver.FindElement(By.Id("FirstName"));
            firstnameDropdown.Click();
            SelectElement firstNameSelect = new SelectElement(firstnameDropdown);
            firstNameSelect.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput = driver.FindElement(By.Id("LastName"));
            lastnameInput.Clear();
            lastnameInput.SendKeys(lastname);
            Thread.Sleep(500);

            IWebElement emailInput = driver.FindElement(By.Id("Email"));
            emailInput.Clear();
            emailInput.SendKeys(email);
            Thread.Sleep(1000);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys("test1");

            IWebElement confirmpasswordInput = driver.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput.Clear();
            confirmpasswordInput.SendKeys("test");

            IWebElement newsletter = driver.FindElement(By.Id("Newsletter"));
            if (!newsletter.Selected)
                newsletter.Click();

            IWebElement btnRegister = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister.Click();

            IWebElement errorMessage1 = driver.FindElement(By.XPath("//span[@for='Password']"));
            Assert.IsNotNull(errorMessage1, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu nên có ít nhất 6 kí tự.", errorMessage1.Text,
                "The error message does not match the expected message.");

            IWebElement errorMessage2 = driver.FindElement(By.XPath("//span[@for='ConfirmPassword']"));
            Assert.IsNotNull(errorMessage2, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu và mật khẩu nhập lại không khớp", errorMessage2.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
