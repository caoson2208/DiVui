using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Security.Policy;
using System.Net.NetworkInformation;
using TestDivuiWebsite;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestDivuiWebsite
{
    [TestClass]
    public class Cart
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
        public void AddToCartSuccess()
        {
            // Lấy nút Chọn điểm theo XPath và tiến hành nhấn
            IWebElement searchLocation_58_Son = driver_58_Son.FindElement(By.XPath("//*[@id=\"small-search-box-form\"]/button/i"));
            searchLocation_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy chọn địa điểm đến theo XPath có text là Hồ Chí Minh và tiến hành nhấn
            IWebElement nameCity_58_Son = driver_58_Son.FindElement(By.XPath("//a[contains(text(), 'Hồ Chí Minh')]"));
            nameCity_58_Son.Click();
            // Lấy dropdown Quốc gia theo Id sau đó nhân và chọn option ở vị trí thứ 1
            IWebElement dropdownCountry_58_Son = driver_58_Son.FindElement(By.Id("countryId"));
            dropdownCountry_58_Son.Click();
            SelectElement selectCountry_58_Son = new SelectElement(dropdownCountry_58_Son);
            selectCountry_58_Son.SelectByIndex(1);
            Thread.Sleep(1000);
            // Lấy dropdown Tình/thành theo Id sau đó nhân và chọn option ở vị trí thứ 1
            IWebElement dropdownCity_58_Son = driver_58_Son.FindElement(By.Id("cityId"));
            dropdownCity_58_Son.Click();
            SelectElement selectCity_58_Son = new SelectElement(dropdownCity_58_Son);
            selectCity_58_Son.SelectByIndex(1);
            Thread.Sleep(1000);
            // Lấy item theo XPath và tiến hành nhấn nhưng trước khi nhấn ta loại bỏ thuộc tính 'target' trước
            IWebElement productCart_58_Son = driver_58_Son.FindElement(By.XPath("//article[1]/a"));
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver_58_Son;
            js.ExecuteScript("arguments[0].removeAttribute('target');", productCart_58_Son);
            Thread.Sleep(1000);
            productCart_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút Đặt online 1 theo XPath và tiến hành nhấn
            IWebElement btnOrderOnl_58_Son = driver_58_Son.FindElement(By.XPath("//div[3]/a"));
            btnOrderOnl_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy nút Kiểm tra giá theo XPath và tiến hành nhấn
            IWebElement checkPrice_58_Son = driver_58_Son.FindElement(By.Id("btncheckprice"));
            checkPrice_58_Son.Click();
            Thread.Sleep(1000);
            // Lấy dropdown Số lượng theo Id sau đó nhân và chọn option ở vị trí thứ 2
            IWebElement dropdownQuantity_58_Son = driver_58_Son.FindElement(By.Id("addtocart_20237_EnteredQuantity"));
            dropdownQuantity_58_Son.Click();
            SelectElement selectQuantity_58_Son = new SelectElement(dropdownQuantity_58_Son);
            selectQuantity_58_Son.SelectByIndex(2);
            Thread.Sleep(1000);
            // Lấy dropdown Chọn mẫu theo Id sau đó nhân và chọn option ở vị trí thứ 2
            IWebElement dropdownSampling_58_Son = driver_58_Son.FindElement(By.Id("product_attribute_17860"));
            dropdownSampling_58_Son.Click();
            SelectElement selectSampling_58_Son = new SelectElement(dropdownSampling_58_Son);
            selectSampling_58_Son.SelectByIndex(2);
            Thread.Sleep(1000);
            // Lấy nút Đặt online 2 theo Id và tiến hành nhấn
            IWebElement btnOrderOnl2_58_Son = driver_58_Son.FindElement(By.Id("addtocartproduct-option-7718"));
            btnOrderOnl2_58_Son.Click();
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



