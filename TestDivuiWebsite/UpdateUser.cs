using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDivuiWebsite
{
    [TestClass]
    public class UpdateUser
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

        private void ResetUser()
        {
                string dataFirstName = "Ông";
                string dataLastName = "Cao Ngọc Sơn";
                string dataPhone = "";
                string dataEmail = "testtest123@yopmail.com";
                IWebElement selectFirstName = driver.FindElement(By.Id("FirstName"));
                selectFirstName.Click();
                SelectElement firstNameSelect = new SelectElement(selectFirstName);
                firstNameSelect.SelectByText(dataFirstName);
                Thread.Sleep(500);
                IWebElement inputLastName = driver.FindElement(By.Id("LastName"));
                inputLastName.Clear();
                inputLastName.SendKeys(dataLastName);
                IWebElement inputPhone = driver.FindElement(By.Id("Phone"));
                inputPhone.Clear();
                inputPhone.SendKeys(dataPhone);
                IWebElement inputEmail = driver.FindElement(By.Id("Email"));
                inputEmail.Clear();
                inputEmail.SendKeys(dataEmail);
                Thread.Sleep(1000);
                IWebElement submitBtn = driver.FindElement(By.CssSelector("input[type=submit]"));
                submitBtn.Click();
        }

        [TestMethod]
        public void updateUserSuccess()
        {
            string dataFirstName = "Bà";
            string dataLastName = "Đặng Trung Thắng";
            string dataPhone = "0385998378";
            string dataEmail = "thangdt61203@gmail.com";
            IWebElement userBtn = driver.FindElement(By.CssSelector("li.dropdown:nth-child(3)"));
            userBtn.Click();
            Thread.Sleep(1000);
            IWebElement userCustom = driver.FindElement(By.XPath("//a[@href='/customer/info']"));
            userCustom.Click();
            Thread.Sleep(1000);
            IWebElement selectFirstName = driver.FindElement(By.Id("FirstName"));
            selectFirstName.Click();
            SelectElement firstNameSelect = new SelectElement(selectFirstName);
            firstNameSelect.SelectByText(dataFirstName);
            Thread.Sleep(500);
            IWebElement inputLastName = driver.FindElement(By.Id("LastName"));
            inputLastName.Clear();
            inputLastName.SendKeys(dataLastName);
            IWebElement inputPhone = driver.FindElement(By.Id("Phone"));
            inputPhone.Clear();
            inputPhone.SendKeys(dataPhone);
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.Clear();
            inputEmail.SendKeys(dataEmail);
            Thread.Sleep(1000);
            IWebElement submitBtn = driver.FindElement(By.CssSelector("input[type=submit]"));
            submitBtn.Click();

            selectFirstName = driver.FindElement(By.Id("FirstName"));
            firstNameSelect = new SelectElement(selectFirstName);
            Assert.AreEqual(dataFirstName, firstNameSelect.SelectedOption.GetAttribute("innerText"));
            inputLastName = driver.FindElement(By.Id("LastName"));
            Assert.AreEqual(dataLastName, inputLastName.GetAttribute("value"));
            inputEmail = driver.FindElement(By.Id("Email"));
            Assert.AreEqual(dataEmail, inputEmail.GetAttribute("value"));
            inputPhone = driver.FindElement(By.Id("Phone"));
            Assert.AreEqual(dataPhone, inputPhone.GetAttribute("value"));
        }

        [TestMethod]
        public void updatePhoneInvalid()
        {
            string dataFirstName = "Bà";
            string dataLastName = "Đặng Trung Thắng";
            string dataPhone = "123";
            string dataEmail = "thangdt61203@gmail.com";
            IWebElement userBtn = driver.FindElement(By.CssSelector("li.dropdown:nth-child(3)"));
            userBtn.Click();
            Thread.Sleep(1000);
            IWebElement userCustom = driver.FindElement(By.XPath("//a[@href='/customer/info']"));
            userCustom.Click();
            Thread.Sleep(1000);
            IWebElement selectFirstName = driver.FindElement(By.Id("FirstName"));
            selectFirstName.Click();
            SelectElement firstNameSelect = new SelectElement(selectFirstName);
            firstNameSelect.SelectByText(dataFirstName);
            Thread.Sleep(500);
            IWebElement inputLastName = driver.FindElement(By.Id("LastName"));
            inputLastName.Clear();
            inputLastName.SendKeys(dataLastName);
            IWebElement inputPhone = driver.FindElement(By.Id("Phone"));
            inputPhone.Clear();
            inputPhone.SendKeys(dataPhone);
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.Clear();
            inputEmail.SendKeys(dataEmail);
            Thread.Sleep(1000);
            IWebElement submitBtn = driver.FindElement(By.CssSelector("input[type=submit]"));
            submitBtn.Click();

            IWebElement erorr = driver.FindElement(By.CssSelector("span.field-validation-error>span"));
            Assert.IsNotNull(erorr, "Error message not found, Test Case fail ");
        }

        [TestMethod]
        public void updateEmailInvalid()
        {
            string dataFirstName = "Bà";
            string dataLastName = "Đặng Trung Thắng";
            string dataPhone = "0385998378";
            string dataEmail = "thangdt61203@gmail";
            IWebElement userBtn = driver.FindElement(By.CssSelector("li.dropdown:nth-child(3)"));
            userBtn.Click();
            Thread.Sleep(1000);
            IWebElement userCustom = driver.FindElement(By.XPath("//a[@href='/customer/info']"));
            userCustom.Click();
            Thread.Sleep(1000);
            IWebElement selectFirstName = driver.FindElement(By.Id("FirstName"));
            selectFirstName.Click();
            SelectElement firstNameSelect = new SelectElement(selectFirstName);
            firstNameSelect.SelectByText(dataFirstName);
            Thread.Sleep(500);
            IWebElement inputLastName = driver.FindElement(By.Id("LastName"));
            inputLastName.Clear();
            inputLastName.SendKeys(dataLastName);
            IWebElement inputPhone = driver.FindElement(By.Id("Phone"));
            inputPhone.Clear();
            inputPhone.SendKeys(dataPhone);
            IWebElement inputEmail = driver.FindElement(By.Id("Email"));
            inputEmail.Clear();
            inputEmail.SendKeys(dataEmail);
            Thread.Sleep(1000);
            IWebElement submitBtn = driver.FindElement(By.CssSelector("input[type=submit]"));
            submitBtn.Click();

            IWebElement erorr = driver.FindElement(By.CssSelector("span.field-validation-error>span"));
            Assert.IsNotNull(erorr, "Error message not found, Test Case fail ");
        }

        [TestCleanup]
        public void TearDown()
        {
            if (driver != null)
            {
                ResetUser();
                driver.Quit();
            }
        }
    }
}
