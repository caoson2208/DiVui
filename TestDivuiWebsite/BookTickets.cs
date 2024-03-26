using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDivuiWebsite
{
    [TestClass]
    public class BookTickets
    {
        private IWebDriver driver;
        private Login login = new Login();

        [TestInitialize]
        public void SetUp()
        {
            login.SetUp();
            driver = login.GetDriver();
            login.LoginSuccess();
        }

        [TestMethod]
        public void BookTicket()
        {
            IWebElement userCart = driver.FindElement(By.XPath("//a[@href='/cart']"));
            userCart.Click();

            IWebElement continueButton = driver.FindElement(By.Id("checkout"));
            continueButton.Click();

            IWebElement preciousName = driver.FindElement(By.Id("BillingAddress_NewAddress_Title"));
            preciousName.Click();

            IWebElement grandmaOption = driver.FindElement(By.XPath("//option[contains(text(), 'Bà')]"));
            grandmaOption.Click();

            IWebElement phoneNumber = driver.FindElement(By.Id("BillingAddress_NewAddress_PhoneNumber"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("0123456789");

            IWebElement shippingAddress = driver.FindElement(By.Id("product_attribute_17862"));
            shippingAddress.Clear();
            shippingAddress.SendKeys("41 Yên Thế, P.2, Q.Tân Bình");

            IWebElement paymentType = driver.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType.Click();

            IWebElement finishBookingButton = driver.FindElement(By.Id("checkoutbtn"));
            finishBookingButton.Click();

            Thread.Sleep(10000);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
