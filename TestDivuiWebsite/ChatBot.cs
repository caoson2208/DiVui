using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestDivuiWebsite
{
    public class ChatBot
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
        public void SendMessage()
        {
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
