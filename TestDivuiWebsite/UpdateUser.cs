using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace TestDivuiWebsite
{
    [TestClass]
    public class UpdateUser
    {
        // Khai báo một biến driver để sử dụng cho việc điều khiển của trình duyệt web
        private IWebDriver driverThang_63;
        //Khai báo một thể hiện của lớp Login đã được viết trước đó để thực hiện việc đăng nhập
        private Login loginThang_63 = new Login();

        // Phương thức thiết lập trước mỗi bài kiểm tra (test) để chuẩn bị môi trường và dữ liệu cần thiết
        //Phương thức này dùng để truy cập vào các bước đầu tiên chung của các test case 
        [TestInitialize]
        public void SetUpThang_63()
        {
            //Gọi của phương thức của login để tiến hành đăng nhập 
            loginThang_63.SetUp();
            driverThang_63 = loginThang_63.GetDriver();
            loginThang_63.LoginSuccess();
            //Lấy element dropdown của biểu tượng tài khoản để hiển thị các chức năng của tài khoản 
            IWebElement userBtnThang_63 = driverThang_63.FindElement(By.CssSelector("li.dropdown:nth-child(3)"));
            //Tíến hành tương tác với element
            userBtnThang_63.Click();
            Thread.Sleep(1000);

            //Lấy element của liên kết "cấu hình tài khoản" và truy cập vào trang cấu hình để tiến hành test chức năng 
            IWebElement userCustomThang_63 = driverThang_63.FindElement(By.XPath("//a[@href='/customer/info']"));
            userCustomThang_63.Click();
            Thread.Sleep(1000);
        }

        //Phương thức này dùng để nhập các gía trị của thông tin người dùng 
        private void inputValueThang_63 (string dataFirstNameThang_63,string dataLastNameThang_63,string dataPhoneThang_63 ,string dataEmailThang_63) 
        {
            //Lấy ô selectbox của ô danh tính bằng Id 
            IWebElement selectFirstNameThang_63 = driverThang_63.FindElement(By.Id("FirstName"));
            selectFirstNameThang_63.Click();
            //Lấy các select của ô danh tính bằng đối tượng SelectElement của Selenium
            SelectElement firstNameSelectThang_63 = new SelectElement(selectFirstNameThang_63);
            firstNameSelectThang_63.SelectByText(dataFirstNameThang_63);
            Thread.Sleep(500);
            //Lấy element của ô tên người dùng và nhập dữ liệu cần kiểm tra
            IWebElement inputLastNameThang_63 = driverThang_63.FindElement(By.Id("LastName"));
            inputLastNameThang_63.Clear();
            inputLastNameThang_63.SendKeys(dataLastNameThang_63);
            //Lấy element của ô số điện thoại và nhập dữ liệu số điện thoại cần kiểm tra 
            IWebElement inputPhoneThang_63 = driverThang_63.FindElement(By.Id("Phone"));
            inputPhoneThang_63.Clear();
            inputPhoneThang_63.SendKeys(dataPhoneThang_63);
            //Lấy element của ô số email và nhập dữ liệu số email cần kiểm tra 
            IWebElement inputEmailThang_63 = driverThang_63.FindElement(By.Id("Email"));
            inputEmailThang_63.Clear();
            inputEmailThang_63.SendKeys(dataEmailThang_63);
            Thread.Sleep(1000);
            //Lấy element của nút submit và click để tiến hành cập nhật thông tin của người dùng
            IWebElement submitBtnThang_63 = driverThang_63.FindElement(By.CssSelector("input[type=submit]"));
            submitBtnThang_63.Click();
        }

        //Phương thức này dùng để cập nhật lại thông tin của người dùng như dữ liệu ban đầu
        //tiến hành thực hiện các test case khác
        private void ResetUserThang_63()
        {
            //Các dữ liệu ban đầu
                string dataFirstNameThang_63 = "Ông";
                string dataLastNameThang_63 = "Cao Ngọc Sơn";
                string dataPhoneThang_63 = "";
                string dataEmailThang_63 = "testtest25@yopmail.com";
            //Truyền dữ liệu vào hàm cập nhật thông tin đã viết bên trên để tiến hành cập nhật 
                inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);
        }

        //Phương thức này dùng để kiểm tra dữ liệu có được cập nhật với các dữ liệu đúng
        [TestMethod]
        public void updateUserSuccessThang_63()
        {
            //Các dữ liệu cần kiểm tra 
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            string dataPhoneThang_63 = "0385998378";
            string dataEmailThang_63 = "thangdt061203@gmail.com";
            //Truyền dữ liệu vào hàm cập nhật thông tin đã viết bên trên để tiến hành cập nhật 
            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);

            //Lấy element của các ô đã cập nhật để kiểm tra dữ liệu có được cập nhật thành công hay không 
            //Nếu dữ liệu sau khi cập nhật và dữ liệu cần cập nhật giống nhau thì testcase thành công và ngược lại thì thất bại
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

        //Phương thức này dùng để kiểm tra chức năng có kiểm tra với dữ liệu số điện thoại không đúng định dạng 
        [TestMethod]
        public void updatePhoneInvalidThang_63()
        {
            //Các dữ liệu cần kiểm tra 
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            //Dữ liệu phone truyền vào được viết sai định dạng 
            string dataPhoneThang_63 = "123dd";
            string dataEmailThang_63 = "thangdt061203@gmail.com";
            //Truyền dữ liệu vào hàm cập nhật thông tin đã viết bên trên để tiến hành cập nhật 
            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);

            //Lấy element thông báo lỗi của web bằng CssSelector 
            IWebElement erorrThang_63 = driverThang_63.FindElement(By.CssSelector("span.field-validation-error>span"));
            //Kiểm tra thông báo lỗi có xuất hiện hay không nếu có thì test case thành công và ngược lại thì thất bại 
            Assert.IsNotNull(erorrThang_63, "Error message not found, Test Case fail ");
        }

        //Phương thức này dùng để kiểm tra chức năng có kiểm tra với dữ liệu email không đúng định dạng 
        [TestMethod]
        public void updateEmailInvalidThang_63()
        {
            //Các dữ liệu cần kiểm tra 
            string dataFirstNameThang_63 = "Bà";
            string dataLastNameThang_63 = "Đặng Trung Thắng";
            string dataPhoneThang_63 = "0385998378";
            //Dữ liệu email truyền vào được viết sai định dạng
            string dataEmailThang_63 = "thangdt061203@gmail";
            //Truyền dữ liệu vào hàm cập nhật thông tin đã viết bên trên để tiến hành cập nhật 
            inputValueThang_63(dataFirstNameThang_63, dataLastNameThang_63, dataPhoneThang_63, dataEmailThang_63);
            
            //Lấy element thông báo lỗi của web bằng CssSelector 
            IWebElement erorrThang_63 = driverThang_63.FindElement(By.CssSelector("span.field-validation-error>span"));
            //Kiểm tra thông báo lỗi có xuất hiện hay không nếu có thì test case thành công và ngược lại thì thất bại 
            Assert.IsNotNull(erorrThang_63, "Error message not found, Test Case fail ");
        }

        // Phương thức dọn dẹp sau mỗi bài kiểm tra (test) để giải phóng tài nguyên và đóng trình duyệt
        [TestCleanup]
        public void TearDownThang_63()
        {
            // Kiểm tra xem trình điều khiển trình duyệt có tồn tại không trước khi thực hiện dọn dẹp
            if (driverThang_63 != null)
            {
                // Thiết lập lại người dùng trước khi đóng trình duyệt
                ResetUserThang_63();

                // Đóng trình duyệt
                driverThang_63.Quit();
            }
        }
    }
}
