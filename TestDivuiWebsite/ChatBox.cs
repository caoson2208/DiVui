using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace TestDivuiWebsite
{
    public class ChatBot
    {
        private IWebDriver driver;
        private string url = "https://divui.com/";
        private string username = "ngocson@yopmail.com";
        private string password = "testtest@123";

        [TestInitialize]
        public void SetUp()
        {
            string chromeDriverPath = "chromedriver.exe";
            driver = new ChromeDriver(chromeDriverPath);
            driver.Navigate().GoToUrl(url);
        }

        [TestMethod]
        public void SendMessage()
        {
            IWebElement login = driver.FindElement(By.XPath("//a[@href='/login']"));
            login.Click();

            IWebElement usernameInput = driver.FindElement(By.Id("Email"));
            usernameInput.Clear();
            usernameInput.SendKeys(username);

            IWebElement passwordInput = driver.FindElement(By.Id("Password"));
            passwordInput.Clear();
            passwordInput.SendKeys(password);

            IWebElement rememberPassword = driver.FindElement(By.Id("RememberMe"));
            rememberPassword.Click();

            IWebElement loginButton = driver.FindElement(By.XPath("//button[contains(text(), 'Đăng nhập')]"));
            loginButton.Click();

            Thread.Sleep(10000);

            IWebElement dialogFrame = driver.FindElement(By.XPath("//*[@data-testid='dialog_iframe']"));
            driver.SwitchTo().Frame(dialogFrame);

            driver.SwitchTo().ParentFrame();

            IWebElement bubbleFrame = driver.FindElement(By.XPath("//*[@data-testid='bubble_iframe']"));
            driver.SwitchTo().Frame(bubbleFrame);


            IWebElement svgElement = driver.FindElement(By.TagName("svg"));
            var actions = new Actions(driver);
            // Move the mouse cursor to the svg element and perform a click action
            actions.MoveToElement(svgElement).Click().Perform();
            Thread.Sleep(10000);

            IWebElement startChat = driver.FindElement(By.XPath("//div[@class='_a6s9']//div[@class='_a2zm' and @role='button']//span[contains(text(), 'Bắt đầu chat')]"));
            Console.WriteLine(startChat);

            Thread.Sleep(5000);
        }

        //DateTime now = DateTime.Now;
        //string messageText = "This is message from Selenium at " + DateTime.Now;
        //IWebElement messageInput = driver.FindElement(By.XPath("//*[@id=\"u_0_0_Vx\"]/div/div/div/div[3]/div/div/div[1]/label"));
        //messageInput.Clear();
        //messageInput.SendKeys(messageText);

        [TestCleanup]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}
