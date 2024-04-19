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
        private IWebDriver driver_58_Son;
        private string url_58_Son = "https://divui.com/";
        private ChromeOptions options_58_Son = new ChromeOptions();
        private string lastname_58_Son = "testest";
        private string email_58_Son = "testtest22@yopmail.com";
        private string password_58_Son = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath_58_Son = "chromedriver.exe";
            options_58_Son.AddArgument("--start-maximized");
            driver_58_Son = new ChromeDriver(chromeDriverPath_58_Son, options_58_Son);
            driver_58_Son.Navigate().GoToUrl(url_58_Son);
        }

        [TestMethod]
        public void RegisterSucces()
        {
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(500);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement newsletter = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter.Selected)
                newsletter.Click();

            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            Thread.Sleep(2000);

            IWebElement registerMessage_58_Son = driver_58_Son.FindElement(By.ClassName("login-intro"));
            Assert.IsNotNull(registerMessage_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Quá trình đăng ký tài khoản đã hoàn tất.",
                registerMessage_58_Son.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void RegisterFail()
        {
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(500);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();

            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();

            IWebElement errorMessage_58_Son = driver_58_Son.FindElement(By.ClassName("validation-summary-errors"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Địa chỉ email này đã được sử dụng",
                errorMessage_58_Son.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckPassword()
        {
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(1000);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys("test1");

            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys("test");

            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();

            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();

            IWebElement errorMessage1_58_Son = driver_58_Son.FindElement(By.XPath("//span[@for='Password']"));
            Assert.IsNotNull(errorMessage1_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu nên có ít nhất 6 kí tự.", errorMessage1_58_Son.Text,
                "The error message does not match the expected message.");

            IWebElement errorMessage2_58_Son = driver_58_Son.FindElement(By.XPath("//span[@for='ConfirmPassword']"));
            Assert.IsNotNull(errorMessage2_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu và mật khẩu nhập lại không khớp", errorMessage2_58_Son.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckEmailInvalid()
        {
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest123@");
            Thread.Sleep(500);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);

            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();

            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            Thread.Sleep(2000);

            IWebElement errorMessage_58_Son =
                 driver_58_Son.FindElement(By.ClassName("field-validation-error"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Login failed.");
            Assert.AreEqual("Wrong email", errorMessage_58_Son.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckEmpty()
        {
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);

            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);

            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            Thread.Sleep(500);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            Thread.Sleep(1000);

            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();

            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();

            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();

            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();

            IWebElement errorMessageLastName_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(4) > span"));
            Assert.IsNotNull(errorMessageLastName_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập họ và tên", errorMessageLastName_58_Son.Text,
                "The error message does not match the expected message.");

            IWebElement errorMessageEmail_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(5) > span > span"));
            Assert.IsNotNull(errorMessageEmail_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập email", errorMessageEmail_58_Son.Text,
                "The error message does not match the expected message.");

            IWebElement errorMessagePassowrd_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(6) > span > span"));
            Assert.IsNotNull(errorMessagePassowrd_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập mật khẩu", errorMessagePassowrd_58_Son.Text,
                "The error message does not match the expected message.");

            IWebElement errorMessageConfirmPassowrd_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(7) > span > span"));
            Assert.IsNotNull(errorMessageConfirmPassowrd_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập mật khẩu", errorMessageConfirmPassowrd_58_Son.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver_58_Son.Quit();
        }
    }
}
