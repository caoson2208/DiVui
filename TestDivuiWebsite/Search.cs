using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace TestDivuiWebsite
{
    /// <summary>
    /// Summary description for Search
    /// </summary>
    [TestClass]
    public class Search
    {
        // Khai báo một biến driver để sử dụng cho việc điều khiển của trình duyệt web
        private IWebDriver driverThang_63;
        // Khai báo url của trang web chứa chức năng cần test
        private string urlThang_63 = "https://divui.com/blog";
        //Khai báo một biến các cấu hình của Chrome 
        private ChromeOptions optionsThang_63 = new ChromeOptions();

        // Phương thức thiết lập trước mỗi bài kiểm tra (test) để chuẩn bị môi trường và dữ liệu cần thiết
        //Phương thức này dùng để truy cập vào các bước đầu tiên chung của các test case 
        [TestInitialize]
        public void SetUp()
        {
            // Đường dẫn đến file chromedriver.exe
            string chromeDriverPath = "chromedriver.exe";

            // Thêm tùy chọn để khởi động trình duyệt Chrome với cửa sổ lớn nhất
            optionsThang_63.AddArgument("--start-maximized");

            // Tạo một phiên làm việc với trình duyệt Chrome sử dụng chromedriver và các tùy chọn đã cấu hình
            driverThang_63 = new ChromeDriver(chromeDriverPath, optionsThang_63);

            // Mở trình duyệt và điều hướng đến URL cụ thể
            driverThang_63.Navigate().GoToUrl(urlThang_63);
        }

        //Phương thức này dùng để kiểm tra tìm kiểm với dữ liệu rỗng
        [TestMethod]
        public void checkEmptyThang_63()
        {
            //Tìm element biểu tượng tìm kím và tiến hành nhấn để hiển thị ô input của tìm kiếm
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của ô input tìm kiếm và tíến hành gửi dữ liệu 
            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            //Gửi dữ liệu rỗng để tiến hành kiếm tra
            searchInputThang_63.SendKeys("");
            Thread.Sleep(1000);

            //Lấy element của button tìm kiếm để tiến hành tìm kiếm với gía trị 
            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            //Láy danh sách các element blog bằng Class 
            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            //Kiểm tra danh sách trên có nhiều hơn 0 hay không nêú hơn thì blog đã được tìm kiếm và ngược lại 
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }

        [TestMethod]
        public void checkTextFailThang_63()
        {
            //Tìm element biểu tượng tìm kím và tiến hành nhấn để hiển thị ô input của tìm kiếm
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của ô input tìm kiếm và tíến hành gửi dữ liệu 
            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            //Gửi dữ liệu số để tiến hành kiếm tra
            searchInputThang_63.SendKeys("A@!#*123fd");
            Thread.Sleep(1000);

            //Lấy element của button tìm kiếm để tiến hành tìm kiếm với gía trị 
            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            //Lấy thông báo hiển thị thông báo không tìm thấy blog 
            IWebElement resultThang_63 = driverThang_63.FindElement(By.CssSelector(".no-results>h2"));
            //Nếu có thông báo thì test case thành công và ngược lại
            Assert.IsNotNull(resultThang_63, "Element message not found. Testcase fail");
            //Kiểm tra nội dung thông báo
            Assert.AreEqual(resultThang_63.Text, "No results for your search");
            //Lấy danh sách các element blog bằng Class 
            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            //Kiểm tra danh sách trên có bằng 0 hay không nêú hơn thì blog đã được tìm kiếm và ngược lại 
            Assert.IsTrue(blogsThang_63.Count == 0, "No blogs found.");
        }

        [TestMethod]
        public void checkTextSuccessThang_63()
        {
            //Tìm element biểu tượng tìm kím và tiến hành nhấn để hiển thị ô input của tìm kiếm
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của ô input tìm kiếm và tíến hành gửi dữ liệu 
            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            //Gửi dữ liệu chuỗi để tiến hành kiếm tra
            searchInputThang_63.SendKeys("Biển");
            Thread.Sleep(1000);

            //Lấy element của button tìm kiếm để tiến hành tìm kiếm với gía trị 
            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            //Lấy danh sách các element blog bằng Class 
            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            //Kiểm tra danh sách trên có nhiều hơn 0 hay không nêú hơn thì blog đã được tìm kiếm và ngược lại 
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");

        }

        [TestMethod]
        public void checkNumberSuccessThang_63()
        {
            //Tìm element biểu tượng tìm kím và tiến hành nhấn để hiển thị ô input của tìm kiếm
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của ô input tìm kiếm và tíến hành gửi dữ liệu 
            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            //Gửi dữ liệu số để tiến hành kiếm tra
            searchInputThang_63.SendKeys("2018");
            Thread.Sleep(1000);

            //Lấy element của button tìm kiếm để tiến hành tìm kiếm với gía trị 
            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            //Lấy danh sách các element blog bằng Class 
            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            //Kiểm tra danh sách trên có nhiều hơn 0 hay không nêú hơn thì blog đã được tìm kiếm và ngược lại 
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }

        [TestMethod]
        public void checkSpecialSuccessThang_63()
        {
            //Tìm element biểu tượng tìm kím và tiến hành nhấn để hiển thị ô input của tìm kiếm
            IWebElement btnSearchThang_63 = driverThang_63.FindElement(By.CssSelector("i.td-icon-search:first-child"));
            btnSearchThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của ô input tìm kiếm và tíến hành gửi dữ liệu 
            IWebElement searchInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search"));
            searchInputThang_63.Clear();
            //Gửi dữ liệu số để tiến hành kiếm tra
            searchInputThang_63.SendKeys("@");
            Thread.Sleep(1000);

            //Lấy element của button tìm kiếm để tiến hành tìm kiếm với gía trị 
            IWebElement btnInputThang_63 = driverThang_63.FindElement(By.Id("td-header-search-top"));
            btnInputThang_63.Click();
            Thread.Sleep(5000);

            //Lấy danh sách các element blog bằng Class 
            IList<IWebElement> blogsThang_63 = driverThang_63.FindElements(By.CssSelector(".td_module_16"));
            //Kiểm tra danh sách trên có nhiều hơn 0 hay không nêú hơn thì blog đã được tìm kiếm và ngược lại 
            Assert.IsTrue(blogsThang_63.Count > 0, "No blogs found.");
        }



        // Phương thức dọn dẹp sau mỗi bài kiểm tra (test) để giải phóng tài nguyên và đóng trình duyệt
        [TestCleanup]
        public void TearDownThang_63()
        {
            // Kiểm tra xem trình điều khiển trình duyệt có tồn tại không trước khi thực hiện dọn dẹp
            if (driverThang_63 != null)
            {
                // Đóng trình duyệt
                driverThang_63.Quit();
            }
        }
    }
}
