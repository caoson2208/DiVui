using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Logout
    {
        private static IWebDriver driver_58_Son;
        private Login login_58_Son = new Login();

        [TestInitialize]
        public void SetUp()
        {
            // Gọi phương thức SetUp, GetDriver và LoginSuccess của lớp Login 
            login_58_Son.SetUp();
            driver_58_Son = login_58_Son.GetDriver();
            login_58_Son.LoginSuccess();
        }

        [TestMethod]
        public void LogoutSuccess()
        {
            // Lấy tài khoản đăng nhập hiện theo XPath và tiến hành nhấn
            IWebElement profile_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"navbar\"]/ul[2]/li[3]/a"));
            profile_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút đăng ký theo XPath và tiến hành nhấn
            IWebElement btnLogout_58_Son = driver_58_Son.FindElement(By.XPath("//a[@href='/logout']"));
            btnLogout_58_Son.Click();
            Thread.Sleep(1000);
        }

        [TestCleanup]
        public void TearDown()
        {
            // Đóng trình duyệt
            driver_58_Son.Quit();
        }
    }
}
