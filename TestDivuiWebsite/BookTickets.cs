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
        private IWebDriver driver_58_Son;
        private Login login_58_Son = new Login();

        [TestInitialize]
        public void SetUp()
        {
            login_58_Son.SetUp();
            driver_58_Son = login_58_Son.GetDriver();
            login_58_Son.LoginSuccess();
        }

        [TestMethod]
        public void BookTicketsSuccess()
        {
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            fullname_58_Son.SendKeys("testtest");
            Thread.Sleep(1000);

            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            phoneNumber_58_Son.SendKeys("0123456789");
            Thread.Sleep(1000);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest@yopmail.com");

            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            shippingAddress_58_Son.SendKeys("Đại học Mở");
            Thread.Sleep(1000);

            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Name("newsletter_subcribed"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();

            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);

            IWebElement message_58_Son = driver_58_Son.FindElement(By.XPath("/html/body/main/div/div/div/div[1]/div[1]/div/div[1]/h1"));
            Assert.IsNotNull(message_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Đặt vé hoàn tất!", message_58_Son.Text, "Error message is incorrect.");
        }

        [TestMethod]
        public void CheckEmptyCustomerInformation()
        {
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            Thread.Sleep(1000);

            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            Thread.Sleep(1000);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
       
            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            Thread.Sleep(1000);

            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);

            IWebElement nameErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[2]/div[2]/span/span"));
            Assert.IsNotNull(nameErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập họ và tên", nameErrorMessage_58_Son.Text, "Error message is incorrect.");

            IWebElement phoneErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[3]/div[2]/span/span"));
            Assert.IsNotNull(phoneErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập số điện thoại", phoneErrorMessage_58_Son.Text, "Error message is incorrect.");

            IWebElement emailErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[4]/div[2]/span"));
            Assert.IsNotNull(emailErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập địa chỉ email.", emailErrorMessage_58_Son.Text, "Error message is incorrect.");
        }

        [TestMethod]
        public void CheckEmptyDeliveryAddress()
        {
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            fullname_58_Son.SendKeys("testtest");
            Thread.Sleep(1000);

            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            phoneNumber_58_Son.SendKeys("0123456789");
            Thread.Sleep(1000);

            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest@yopmail.com");

            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            Thread.Sleep(1000);

            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);

            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);

            IWebElement addressErrorMessage_58_Son = driver_58_Son.FindElement(By.CssSelector("#product_attribute_input_17862 > div"));
            Assert.IsNotNull(addressErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập địa chỉ giao hàng", addressErrorMessage_58_Son.Text, "Error message is incorrect.");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver_58_Son.Quit();
        }
    }
}
