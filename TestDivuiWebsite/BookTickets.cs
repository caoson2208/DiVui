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
        public void BookTicketSuccess()
        {
            IWebElement userCart = driver.FindElement(By.XPath("//a[@href='/cart']"));
            userCart.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue = driver.FindElement(By.Id("checkout"));
            btnContinue.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown = driver.FindElement(By.Id("BillingAddress_NewAddress_Title"));
            nameDropdown.Click();
            SelectElement nameSelect = new SelectElement(nameDropdown);
            nameSelect.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname = driver.FindElement(By.Id("BillingAddress_NewAddress_FullName"));
            fullname.Clear();
            fullname.SendKeys("testtest");
            Thread.Sleep(1000);

            IWebElement phoneNumber = driver.FindElement(By.Id("BillingAddress_NewAddress_PhoneNumber"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("0123456789");
            Thread.Sleep(1000);

            IWebElement emailInput = driver.FindElement(By.Id("BillingAddress_NewAddress_Email"));
            emailInput.Clear();
            emailInput.SendKeys("testtest@yopmail.com");

            IWebElement shippingAddress = driver.FindElement(By.Id("product_attribute_17862"));
            shippingAddress.Clear();
            shippingAddress.SendKeys("Đại học Mở");
            Thread.Sleep(1000);

            IWebElement paymentType = driver.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType.Click();
            Thread.Sleep(1000);

            IWebElement newsletter = driver.FindElement(By.Name("newsletter_subcribed"));
            if (!newsletter.Selected)
                newsletter.Click();

            IWebElement btnFinishBooking = driver.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking.Click();
            Thread.Sleep(2000);

            IWebElement message = driver.FindElement(By.XPath("/html/body/main/div/div/div/div[1]/div[1]/div/div[1]/h1"));
            Assert.IsNotNull(message, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Đặt vé hoàn tất!", message.Text, "Error message is incorrect.");
        }

        [TestMethod]
        public void CheckEmptyCustomerInformation()
        {
            IWebElement userCart = driver.FindElement(By.XPath("//a[@href='/cart']"));
            userCart.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue = driver.FindElement(By.Id("checkout"));
            btnContinue.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown = driver.FindElement(By.Id("BillingAddress_NewAddress_Title"));
            nameDropdown.Click();
            SelectElement nameSelect = new SelectElement(nameDropdown);
            nameSelect.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname = driver.FindElement(By.Id("BillingAddress_NewAddress_FullName"));
            fullname.Clear();
            Thread.Sleep(1000);

            IWebElement phoneNumber = driver.FindElement(By.Id("BillingAddress_NewAddress_PhoneNumber"));
            phoneNumber.Clear();
            Thread.Sleep(1000);

            IWebElement emailInput = driver.FindElement(By.Id("BillingAddress_NewAddress_Email"));
            emailInput.Clear();
       
            IWebElement shippingAddress = driver.FindElement(By.Id("product_attribute_17862"));
            shippingAddress.Clear();
            Thread.Sleep(1000);

            IWebElement paymentType = driver.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType.Click();
            Thread.Sleep(1000);

            IWebElement btnFinishBooking = driver.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking.Click();
            Thread.Sleep(2000);

            IWebElement nameErrorMessage = driver.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[2]/div[2]/span/span"));
            Assert.IsNotNull(nameErrorMessage, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập họ và tên", nameErrorMessage.Text, "Error message is incorrect.");

            IWebElement phoneErrorMessage = driver.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[3]/div[2]/span/span"));
            Assert.IsNotNull(phoneErrorMessage, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập số điện thoại", phoneErrorMessage.Text, "Error message is incorrect.");

            IWebElement emailErrorMessage = driver.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[4]/div[2]/span"));
            Assert.IsNotNull(emailErrorMessage, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập địa chỉ email.", emailErrorMessage.Text, "Error message is incorrect.");
        }

        [TestMethod]
        public void CheckEmptyDeliveryAddress()
        {
            IWebElement userCart = driver.FindElement(By.XPath("//a[@href='/cart']"));
            userCart.Click();
            Thread.Sleep(1000);

            IWebElement btnContinue = driver.FindElement(By.Id("checkout"));
            btnContinue.Click();
            Thread.Sleep(1000);

            IWebElement nameDropdown = driver.FindElement(By.Id("BillingAddress_NewAddress_Title"));
            nameDropdown.Click();
            SelectElement nameSelect = new SelectElement(nameDropdown);
            nameSelect.SelectByIndex(0);
            Thread.Sleep(1000);

            IWebElement fullname = driver.FindElement(By.Id("BillingAddress_NewAddress_FullName"));
            fullname.Clear();
            fullname.SendKeys("testtest");
            Thread.Sleep(1000);

            IWebElement phoneNumber = driver.FindElement(By.Id("BillingAddress_NewAddress_PhoneNumber"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("0123456789");
            Thread.Sleep(1000);

            IWebElement emailInput = driver.FindElement(By.Id("BillingAddress_NewAddress_Email"));
            emailInput.Clear();
            emailInput.SendKeys("testtest@yopmail.com");

            IWebElement shippingAddress = driver.FindElement(By.Id("product_attribute_17862"));
            shippingAddress.Clear();
            Thread.Sleep(1000);

            IWebElement paymentType = driver.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType.Click();
            Thread.Sleep(1000);

            IWebElement btnFinishBooking = driver.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking.Click();
            Thread.Sleep(2000);

            IWebElement addressErrorMessage = driver.FindElement(By.CssSelector("#product_attribute_input_17862 > div"));
            Assert.IsNotNull(addressErrorMessage, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập địa chỉ giao hàng", addressErrorMessage.Text, "Error message is incorrect.");
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
