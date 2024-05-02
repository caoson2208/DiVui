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
        private string email_58_Son = "testtest30@yopmail.com";
        private string password_58_Son = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath_58_Son = "chromedriver.exe";
            options_58_Son.AddArgument("--start-maximized");
            // Mở to trình duyệt
            driver_58_Son = new ChromeDriver(chromeDriverPath_58_Son, options_58_Son);
            // Truy cập vào website
            driver_58_Son.Navigate().GoToUrl(url_58_Son);
        }

        [TestMethod]
        public void RegisterSucces()
        {
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);
            // Lấy dropdown quý danh theo Id sau đó tiến hành nhấn và chọn option là Bà
            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Họ và tên theo Id và tiến hành nhập liệu
            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Email theo Id và tiến hành nhập liệu
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Mật khẩu theo Id và tiến hành nhập liệu
            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Xác nhận mật khẩy theo Id và tiến hành nhập liệu
            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô Đăng ký nhận thông tin theo Id và tiến nhấn
            IWebElement newsletter = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter.Selected)
                newsletter.Click();
            // Lấy nút Đăng ký theo XPath và tiến hành nhấn
            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            Thread.Sleep(2000);
            // Lấy message theo ClassName và so sánh với message hiển thị trên website
            IWebElement registerMessage_58_Son = driver_58_Son.FindElement(By.ClassName("login-intro"));
            Assert.IsNotNull(registerMessage_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Quá trình đăng ký tài khoản đã hoàn tất.",
                registerMessage_58_Son.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void RegisterFail()
        {
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);
            // Lấy dropdown quý danh theo Id sau đó tiến hành nhấn và chọn option là Bà
            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Họ và tên theo Id và tiến hành nhập liệu
            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Email theo Id và tiến hành nhập liệu
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Mật khẩu theo Id và tiến hành nhập liệu
            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Xác nhận mật khẩy theo Id và tiến hành nhập liệu
            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô Đăng ký nhận thông tin theo Id và tiến nhấn
            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();
            // Lấy nút Đăng ký theo XPath và tiến hành nhấn
            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            // Lấy message lỗi theo ClassName và so sánh với message hiển thị trên website
            IWebElement errorMessage_58_Son = driver_58_Son.FindElement(By.ClassName("validation-summary-errors"));
            Assert.IsNotNull(errorMessage_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Địa chỉ email này đã được sử dụng",
                errorMessage_58_Son.Text, "Error message is incorrect.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckPassword()
        {
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);
            // Lấy dropdown quý danh theo Id sau đó tiến hành nhấn và chọn option là Bà
            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Họ và tên theo Id và tiến hành nhập liệu
            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Email theo Id và tiến hành nhập liệu
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys(email_58_Son);
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Mật khẩu theo Id và tiến hành nhập liệu
            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys("test1");
            // Lấy ô nhập liệu Xác nhận mật khẩy theo Id và tiến hành nhập liệu
            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys("test");
            // Lấy ô Đăng ký nhận thông tin theo Id và tiến nhấn
            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();
            // Lấy nút Đăng ký theo XPath và tiến hành nhấn
            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            // Lấy message của Mật khẩu theo ClassName và so sánh với message hiển thị trên website
            IWebElement errorMessage1_58_Son = driver_58_Son.FindElement(By.XPath("//span[@for='Password']"));
            Assert.IsNotNull(errorMessage1_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu nên có ít nhất 6 kí tự.", errorMessage1_58_Son.Text,
                "The error message does not match the expected message.");
            // Lấy message của Xác nhận mật khẩu theo ClassName và so sánh với message hiển thị trên website
            IWebElement errorMessage2_58_Son = driver_58_Son.FindElement(By.XPath("//span[@for='ConfirmPassword']"));
            Assert.IsNotNull(errorMessage2_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Mật khẩu và mật khẩu nhập lại không khớp", errorMessage2_58_Son.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestMethod]
        public void CheckEmailInvalid()
        {
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);
            // Lấy dropdown quý danh theo Id sau đó tiến hành nhấn và chọn option là Bà
            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Họ và tên theo Id và tiến hành nhập liệu
            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            lastnameInput_58_Son.SendKeys(lastname_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Email theo Id và tiến hành nhập liệu
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest123@");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Mật khẩu theo Id và tiến hành nhập liệu
            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            passwordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô nhập liệu Xác nhận mật khẩy theo Id và tiến hành nhập liệu
            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            confirmpasswordInput_58_Son.SendKeys(password_58_Son);
            Thread.Sleep(500);
            // Lấy ô Đăng ký nhận thông tin theo Id và tiến nhấn
            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();
            // Lấy nút Đăng ký theo XPath và tiến hành nhấn
            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            Thread.Sleep(2000);
            // Lấy message của Email ClassName và so sánh với message hiển thị trên website
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
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement userRegister_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/register']"));
            userRegister_58_Son.Click();
            Thread.Sleep(500);
            // Lấy dropdown quý danh theo Id sau đó tiến hành nhấn và chọn option là Bà
            IWebElement firstnameDropdown_58_Son = driver_58_Son.FindElement(By.Id("FirstName"));
            firstnameDropdown_58_Son.Click();
            SelectElement firstNameSelect_58_Son = new SelectElement(firstnameDropdown_58_Son);
            firstNameSelect_58_Son.SelectByText("Bà");
            Thread.Sleep(500);
            // Lấy ô nhập liệu Họ và tên theo Id và tiến hành nhập liệu
            IWebElement lastnameInput_58_Son = driver_58_Son.FindElement(By.Id("LastName"));
            lastnameInput_58_Son.Clear();
            Thread.Sleep(500);
            // Lấy ô nhập liệu Email theo Id và tiến hành nhập liệu
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Id("Email"));
            emailInput_58_Son.Clear();
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Mật khẩu theo Id và tiến hành nhập liệu
            IWebElement passwordInput_58_Son = driver_58_Son.FindElement(By.Id("Password"));
            passwordInput_58_Son.Clear();
            // Lấy ô nhập liệu Xác nhận mật khẩy theo Id và tiến hành nhập liệu
            IWebElement confirmpasswordInput_58_Son = driver_58_Son.FindElement(By.Id("ConfirmPassword"));
            confirmpasswordInput_58_Son.Clear();
            // Lấy ô Đăng ký nhận thông tin theo Id và tiến nhấn
            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Id("Newsletter"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();
            // Lấy nút Đăng ký theo XPath và tiến hành nhấn
            IWebElement btnRegister_58_Son = driver_58_Son.FindElement(By.XPath("//button[contains(text(), 'Đăng ký')]"));
            btnRegister_58_Son.Click();
            // Lấy message của Họ và tên theo CssSelector và so sánh với message hiển thị trên website
            IWebElement errorMessageLastName_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(4) > span"));
            Assert.IsNotNull(errorMessageLastName_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập họ và tên", errorMessageLastName_58_Son.Text,
                "The error message does not match the expected message.");
            // Lấy message của Email theo CssSelector và so sánh với message hiển thị trên website
            IWebElement errorMessageEmail_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(5) > span > span"));
            Assert.IsNotNull(errorMessageEmail_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập email", errorMessageEmail_58_Son.Text,
                "The error message does not match the expected message.");
            // Lấy message của Mật khẩu theo CssSelector và so sánh với message hiển thị trên website
            IWebElement errorMessagePassowrd_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(6) > span > span"));
            Assert.IsNotNull(errorMessagePassowrd_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập mật khẩu", errorMessagePassowrd_58_Son.Text,
                "The error message does not match the expected message.");
            // Lấy message của Xác nhận mật khẩu theo CssSelector và so sánh với message hiển thị trên website
            IWebElement errorMessageConfirmPassowrd_58_Son = driver_58_Son.FindElement(By.CssSelector("form.login-data > div:nth-child(7) > span > span"));
            Assert.IsNotNull(errorMessageConfirmPassowrd_58_Son, "Error message element not found. Register failed.");
            Assert.AreEqual("Vui lòng nhập mật khẩu", errorMessageConfirmPassowrd_58_Son.Text,
                "The error message does not match the expected message.");
            Thread.Sleep(2000);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Đóng trình duyệt
            driver_58_Son.Quit();
        }
    }
}
