using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit.PageObject
{
    public class SelectSequence
    {
        private EdgeDriver _driver;
        private CheckElement checkElement;
        private By clickApp;
        private By selectCombobox= By.XPath("//mat-select[@role='combobox']");
        private By selectOption;
        private By rootFolderM1 = By.XPath("//span[text()='1 Administrative Information and Prescribing Information']//parent::span");     
        public SelectSequence(EdgeDriver driver)
        {
            _driver = driver;
            checkElement =new CheckElement(_driver);

        }
        public void ChosenSequence(string appname,string sequence)
        {
            clickApp = By.XPath("//mat-panel-title[text()=' Application: "+ appname + " ']");
            _driver.FindElement(clickApp).Click();
            _driver.FindElement(selectCombobox).Click();
            selectOption = By.XPath("//span[text()=' "+ sequence + " ']//parent::mat-option");
            checkElement.check(selectOption);
            _driver.FindElement(selectOption).Click();      
            Thread.Sleep(2000);
            _driver.FindElement(rootFolderM1).Click();
        }
        //_driver.FindElement(By.XPath("//mat-panel-title[text()=' Application: 226226 ']")).Click();

        //_driver.FindElement(By.XPath("//mat-select[@role='combobox']")).Click();

        //_driver.FindElement(By.XPath("//span[text()=' 0001 ']//parent::mat-option")).Click();
        //Thread.Sleep(2000);

        //_driver.FindElement(By.XPath("//span[text()='1 Administrative Information and Prescribing Information']//parent::span")).Click();
    }
}
