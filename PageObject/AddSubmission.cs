using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit.PageObject
{
    public class AddSubmission
    {

        private EdgeDriver _driver;
        private CheckElement checkElement;
        private By clickNode;
        private By clickDocumentmenu = By.XPath("//span[text()='Document']//parent::div//parent::div");
        private By AddtoSubmission = By.XPath("//span[text()='Add to Submission']//parent::span");
        public AddSubmission(EdgeDriver driver)
        {
            _driver = driver;
            checkElement = new CheckElement(_driver);

        }
        public void AddLeaf(string nameNode)
        {
            clickNode = By.XPath("//span[text()='"+ nameNode + "']//parent::div");
            checkElement.check(clickNode);
            _driver.FindElement(clickNode).Click();
            _driver.FindElement(clickDocumentmenu).Click();
            Thread.Sleep(1000);
            _driver.FindElement(AddtoSubmission).Click();
        }
        //_driver.FindElement(By.XPath("//span[text()='1.2 Cover letters']//parent::div")).Click();

        //_driver.FindElement(By.XPath("//span[text()='Document']//parent::div//parent::div")).Click();
        //Thread.Sleep(1000);
        //_driver.FindElement(By.XPath("//span[text()='Add to Submission']//parent::span")).Click();

    }
}
