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
        // Khai báo một biến driver để sử dụng cho việc điều khiển của trình duyệt web
        private IWebDriver driver_58_Son;
        //Khai báo một thể hiện của lớp Login đã được viết trước đó để thực hiện việc đăng nhập
        private Login login_58_Son = new Login();

        // Phương thức thiết lập trước mỗi bài kiểm tra (test) để chuẩn bị môi trường và dữ liệu cần thiết
        //Phương thức này dùng để truy cập vào các bước đầu tiên chung của các test case 
        [TestInitialize]
        public void SetUp()
        {
            // Gọi phương thức SetUp, GetDriver và LoginSuccess của lớp Login 
            login_58_Son.SetUp();
            driver_58_Son = login_58_Son.GetDriver();
            login_58_Son.LoginSuccess();
        }

        // Phương thức kiểm tra đặt vé thành công
        [TestMethod]
        public void BookTicketsSuccess()
        {
            // Lấy nút giỏ hàng theo XPath và tiến hành nhấn
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút tiếp tục theo Id và tiến hành nhấn
            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy dropdown quý danh theo Name sau đó nhấn và chọn option số 0
            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Họ và tên theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            fullname_58_Son.SendKeys("testtest");
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Số điện thoại theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            phoneNumber_58_Son.SendKeys("0123456789");
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Eamil theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest@yopmail.com");
            // Lấy ô nhập liệu Địa chỉ giao hàng theo Id sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            shippingAddress_58_Son.SendKeys("Đại học Mở");
            Thread.Sleep(1000);
            // Lấy phương thức thanh toán theo XPath và tiến hành nhấn
            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy "Tôi đồng" ý theo Name và kiểm tra nếu chưa được chọn thì mình sẽ nhấn vào
            IWebElement newsletter_58_Son = driver_58_Son.FindElement(By.Name("newsletter_subcribed"));
            if (!newsletter_58_Son.Selected)
                newsletter_58_Son.Click();
            // Lấy nút đặt vé theo Id và tiến hành nhấn
            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);
            // Lấy message lỗi theo XPath và so sánh với message hiển thị trên website
            IWebElement message_58_Son = driver_58_Son.FindElement(By.XPath("/html/body/main/div/div/div/div[1]/div[1]/div/div[1]/h1"));
            Assert.IsNotNull(message_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Đặt vé hoàn tất!", message_58_Son.Text, "Error message is incorrect.");
        }

        //Phương thức kiểm tra thông tin khác hàng rỗng
        [TestMethod]
        public void CheckEmptyCustomerInformation()
        {
            // Lấy nút giỏ hàng theo XPath và tiến hành nhấn
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút tiếp tục theo Id và tiến hành nhấn
            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy dropdown quý danh theo Name sau đó nhấn và chọn option số 0
            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Họ và tên theo Name sau đó xoá dữ liệu 
            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Số điện thoại theo Name sau đó xoá dữ liệu 
            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Eamil theo Name sau đó xoá dữ liệu 
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
            // Lấy ô nhập liệu Địa chỉ giao hàng theo Id sau đó xoá dữ liệu 
            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            Thread.Sleep(1000);
            // Lấy phương thức thanh toán theo XPath và tiến hành nhấn
            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút đặt vé theo Id và tiến hành nhấn
            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);
            // Lấy message của Họ và tên theo XPath và so sánh với message hiển thị ở dưới ô nhập liệu họ và tên trên website
            IWebElement nameErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[2]/div[2]/span/span"));
            Assert.IsNotNull(nameErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập họ và tên", nameErrorMessage_58_Son.Text, "Error message is incorrect.");
            // Lấy message của Số điện thoại theo XPath và so sánh với message hiển thị ở dưới ô nhập liệu họ và tên trên website
            IWebElement phoneErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[3]/div[2]/span/span"));
            Assert.IsNotNull(phoneErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập số điện thoại", phoneErrorMessage_58_Son.Text, "Error message is incorrect.");
            // Lấy message của Email theo XPath và so sánh với message hiển thị ở dưới ô nhập liệu họ và tên trên website
            IWebElement emailErrorMessage_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"billing-new-address-form\"]/div[4]/div[2]/span"));
            Assert.IsNotNull(emailErrorMessage_58_Son, "Error message element not found. Book Ticket failed.");
            Assert.AreEqual("Vui lòng nhập địa chỉ email.", emailErrorMessage_58_Son.Text, "Error message is incorrect.");
        }

        //Phương thức kiểm tra thông tin giao hàng rỗng
        [TestMethod]
        public void CheckEmptyDeliveryAddress()
        {
            // Lấy nút giỏ hàng theo XPath và tiến hành nhấn
            IWebElement userCart_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/cart']"));
            userCart_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút tiếp tục theo Id và tiến hành nhấn
            IWebElement btnContinue_58_Son = driver_58_Son.FindElement(By.Id("checkout"));
            btnContinue_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy dropdown quý danh theo Name sau đó nhấn và chọn option số 0
            IWebElement nameDropdown_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Title"));
            nameDropdown_58_Son.Click();
            SelectElement nameSelect_58_Son = new SelectElement(nameDropdown_58_Son);
            nameSelect_58_Son.SelectByIndex(0);
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Họ và tên theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement fullname_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.FullName"));
            fullname_58_Son.Clear();
            fullname_58_Son.SendKeys("testtest");
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Số điện thoại theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement phoneNumber_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.PhoneNumber"));
            phoneNumber_58_Son.Clear();
            phoneNumber_58_Son.SendKeys("0123456789");
            Thread.Sleep(1000);
            // Lấy ô nhập liệu Eamil theo Name sau đó xoá dữ liệu và tiến hành nhập dữ liệu mới
            IWebElement emailInput_58_Son = driver_58_Son.FindElement(By.Name("BillingAddress.NewAddress.Email"));
            emailInput_58_Son.Clear();
            emailInput_58_Son.SendKeys("testtest@yopmail.com");
            // Lấy ô nhập liệu Địa chỉ giao hàng theo Id sau đó xoá dữ liệu 
            IWebElement shippingAddress_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17862"));
            shippingAddress_58_Son.Clear();
            Thread.Sleep(1000);
            // Lấy phương thức thanh toán theo XPath và tiến hành nhấn
            IWebElement paymentType_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='#collapse_1']"));
            paymentType_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút đặt vé theo Id và tiến hành nhấn
            IWebElement btnFinishBooking_58_Son = driver_58_Son.FindElement(By.Id("checkoutbtn"));
            btnFinishBooking_58_Son.Click();
            Thread.Sleep(2000);
            // Lấy message của Địa chỉ giao hàng theo CssSelectoer và so sánh với message hiển thị ở trên ô nhập liệu Địa chỉ giao hàng trên website
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
