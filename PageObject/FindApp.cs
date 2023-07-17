using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit.PageObject
{
    public class FindApp
    {

        private EdgeDriver _driver;
        private CheckElement checkElement;
        private By inputApp = By.XPath("//input[@data-placeholder='Application ID']");
        private By clickApp;
        private By OpenApp = By.XPath("//span[text()='Open']//parent::button");
        private By structureApp = By.XPath("//tbody[@kendotreelisttablebody]");
        public FindApp(EdgeDriver driver)
        {
            _driver = driver;
            checkElement = new CheckElement(_driver);
        }
        public void EnterApp(string nameAPP)
        {
            _driver.FindElement(inputApp).SendKeys(nameAPP);
            Thread.Sleep(2000);
            clickApp = By.XPath("//td[text()='" + nameAPP + "']");
            //try
            //{
            //    var app = _driver.FindElement(clickApp);
            //    if (app.Displayed) 
            //        app.Click();
            //}
            //catch (NoSuchElementException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //_driver.FindElement(clickApp).Click();
            checkElement.check(clickApp);
            _driver.FindElement(clickApp).Click();
            Thread.Sleep(500);
            _driver.FindElement(OpenApp).Click();
            Thread.Sleep(1000);
            checkElement.check(structureApp);


        }
        public void FindingApp(string nameAPP)
        {
            EnterApp(nameAPP);
        }
        
    }
}
