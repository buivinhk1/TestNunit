using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Input;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNunit.TestDataAccess;
namespace TestNunit.PageObject
{
    public class Login
    {
        private EdgeDriver _driver;

        private By UserName = By.XPath("//div//input[@data-placeholder='Username']");
        private By Password = By.XPath("//input[@data-placeholder='Password']");
        private By Continue = By.XPath("//span[text()=' Continue ']//parent::button");
        private By Loginn = By.XPath("//span[text()=' Login ']//parent::button");
        private By No = By.XPath("//span[text()='No']//parent::button");
        public Login(EdgeDriver driver)
        {
            _driver = driver;
        }
        // Enter UserName
        public void EnterUserName(string username)
        {
            _driver.FindElement(UserName).SendKeys(username);
            Thread.Sleep(1500);
        }
        // Enter Password
        public void EnterPassword(string password)
        {
            _driver.FindElement(Password).SendKeys(password);
            Thread.Sleep(1000);
        }
        // Continue
        public void EnterContinue()
        {
            _driver.FindElement(Continue).Click();
            Thread.Sleep(1000);
        }
        // Buton Login
        public void ClickLoginButton()
        {
            _driver.FindElement(Loginn).Click();
            Thread.Sleep(5000);
        }
        public void ClickNo()
        {
            _driver.FindElement(No).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("document.exitFullscreen();");
        }

        // Method Login
        public void LoginPage(string username, string password)
        {
            //var userData = ExcelDataAccess.GetTestData(testName);
            EnterUserName(username);
            EnterContinue();
            EnterPassword(password);
            ClickLoginButton();
            ClickNo();
            Console.WriteLine("Login successfully");
        }
        //public void testLogin()
        //{
        //    // fill login data on sign-in page
        //    IWebElement inputUserName = _driver.FindElement(By.XPath("//div//input[@data-placeholder='Username']"));
        //    inputUserName.SendKeys("autouser5");
        //    Thread.Sleep(500);
        //    // Click Continue
        //    _driver.FindElement(By.XPath("//span[text()=' Continue ']//parent::button")).Click();
        //    Thread.Sleep(500);
        //    //Find Input Password then set Text
        //    IWebElement inputPassWord = _driver.FindElement(By.XPath("//input[@data-placeholder='Password']"));
        //    inputPassWord.SendKeys("Test123456789");
        //    Thread.Sleep(500);
        //    //click Login
        //    _driver.FindElement(By.XPath("//span[text()=' Login ']//parent::button")).Click();
        //    Thread.Sleep(5000);
        //    //click 'No' when login
        //    _driver.FindElement(By.XPath("//span[text()='No']//parent::button")).Click();
        //    // Exit FullScreen
        //    //not use yet
        //    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        //    js.ExecuteScript("document.exitFullscreen();");

        //    //string strCopyRight = "login-copy-right";
        //    // loginPage = new LoginPage(chromeDriver);
        //    //loginPage.LoginPageAction("admin", "Test123");
        //    // Thread.Sleep(5000);
        //    Console.WriteLine("Login successfully");
        //    // verify h1 tag is "Hello userName" after login
        //   // _driver.FindElement(By.XPath("h1")).isDisplayed();
        //    //((_driver.FindElement(By.XPath("//title[text()='TRS Suite - DXC.technology']"));
        //}
    }
}
