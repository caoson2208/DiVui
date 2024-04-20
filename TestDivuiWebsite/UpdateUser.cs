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
        private static IWebDriver driverThang_63;
        private Login loginThang_63 = new Login();

        [TestInitialize]
        public void SetUpThang_63()
        {
            loginThang_63.SetUp();
            driverThang_63 = loginThang_63.GetDriver();
            loginThang_63.LoginSuccess();
            IWebElement userBtnThang_63 = driverThang_63.FindElement(By.CssSelector("li.dropdown:nth-child(3)"));
            userBtnThang_63.Click();
            Thread.Sleep(1000);
            IWebElement userCustomThang_63 = driverThang_63.FindElement(By.XPath("//a[@href='/customer/info']"));
            userCustomThang_63.Click();
            Thread.Sleep(1000);
        }

        private void inputValueThang_63 (string dataFirstNameThang_63,string dataLastNameThang_63,string dataPhoneThang_63 ,string dataEmailThang_63) 
        {
            IWebElement selectFirstNameThang_63 = driverThang_63.FindElement(By.Id("FirstName"));
            selectFirstNameThang_63.Click();
            SelectElement firstNameSelectThang_63 = new SelectElement(selectFirstNameThang_63);
            firstNameSelectThang_63.SelectByText(dataFirstNameThang_63);
            Thread.Sleep(500);
            IWebElement inputLastNameThang_63 = driverThang_63.FindElement(By.Id("LastName"));
            inputLastNameThang_63.Clear();
            inputLastNameThang_63.SendKeys(dataLastNameThang_63);
            IWebElement inputPhoneThang_63 = driverThang_63.FindElement(By.Id("Phone"));
            inputPhoneThang_63.Clear();
            inputPhoneThang_63.SendKeys(dataPhoneThang_63);
            IWebElement inputEmailThang_63 = driverThang_63.FindElement(By.Id("Email"));
            inputEmailThang_63.Clear();
            inputEmailThang_63.SendKeys(dataEmailThang_63);
            Thread.Sleep(1000);
            IWebElement submitBtnThang_63 = driverThang_63.FindElement(By.CssSelector("input[type=submit]"));
            submitBtnThang_63.Click();
        }

        private void ResetUserThang_63()
        {
                string dataFirstNameThang_63 = "Ông";
                string dataLastNameThang_63 = "Cao Ngọc Sơn";
                string dataPhoneThang_63 = "";
                string dataEmailThang_63 = "testtest123@yopmail.com";
                inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);
        }

        [TestMethod]
        public void updateUserSuccessThang_63()
        {
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            string dataPhoneThang_63 = "0385998378";
            string dataEmailThang_63 = "thangdt61203@gmail.com";
            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);


            IWebElement selectFirstNameThang_63 = driverThang_63.FindElement(By.Id("FirstName"));
            SelectElement firstNameSelectThang_63 = new SelectElement(selectFirstNameThang_63);
            Assert.AreEqual(dataFirstNameThang_63, firstNameSelectThang_63.SelectedOption.GetAttribute("innerText"));
            IWebElement inputLastNameThang_63 = driverThang_63.FindElement(By.Id("LastName"));
            Assert.AreEqual(dataLastNameThang_63, inputLastNameThang_63.GetAttribute("value"));
            IWebElement inputEmailThang_63 = driverThang_63.FindElement(By.Id("Email"));
            Assert.AreEqual(dataEmailThang_63, inputEmailThang_63.GetAttribute("value"));
            IWebElement inputPhoneThang_63 = driverThang_63.FindElement(By.Id("Phone"));
            Assert.AreEqual(dataPhoneThang_63, inputPhoneThang_63.GetAttribute("value"));
        }

        [TestMethod]
        public void updatePhoneInvalidThang_63()
        {
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            string dataPhoneThang_63 = "123";
            string dataEmailThang_63 = "thangdt61203@gmail.com";

            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);

            IWebElement erorrThang_63 = driverThang_63.FindElement(By.CssSelector("span.field-validation-error>span"));
            Assert.IsNotNull(erorrThang_63, "Error message not found, Test Case fail ");
        }

        [TestMethod]
        public void updateEmailInvalidThang_63()
        {
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            string dataPhoneThang_63 = "0385998378";
            string dataEmailThang_63 = "thangdt61203@gmail";

            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);

            IWebElement erorrThang_63 = driverThang_63.FindElement(By.CssSelector("span.field-validation-error>span"));
            Assert.IsNotNull(erorrThang_63, "Error message not found, Test Case fail ");
        }

        [TestCleanup]
        public void TearDownThang_63()
        {
            if (driverThang_63 != null)
            {
                ResetUserThang_63();
                driverThang_63.Quit();
            }
        }
    }
}
