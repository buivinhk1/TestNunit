using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNunit.PageObject
{
    public class OpenApplication
    {
        private EdgeDriver _driver;
        private By btnApp = By.XPath("//i[text()='apps']//parent::span//parent::button");
        private By btneCTDXPress = By.XPath("//span[text()='eCTDXPress']//parent::button");
        private By btnApplication = By.XPath("//span[text()='Application']//parent::div//parent::div");
        private By OpenIconApp = By.XPath("//mat-icon[text()='open_in_new']//parent::section//parent::span//parent::button");
        private By pin = By.ClassName("k-i-unpin");
        private By checkApplication = By.XPath("//div[text()='Open Application']//parent::kendo-window-titlebar//parent::kendo-window");


        public OpenApplication(EdgeDriver driver)
        {
            _driver = driver;
        }
        public void checkPin()
        {
            try
            {
                var unpin = _driver.FindElement(pin);
                if (unpin != null)
                    unpin.Click();
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void checkApp()
        {
            IWebElement element = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalSeconds < 5) // Wait maximum 5 second
            {
                try
                {
                    element = _driver.FindElement(checkApplication);
                    if (element.Displayed)
                    {
                        break; // Application show up, break out loop
                    }
                }
                catch (NoSuchElementException)
                {
                    element = null;// Not show up, keep continute to wait
                }
            }
            stopwatch.Stop();
            if (element != null)
            {
                Console.WriteLine("Dialog App Open successfull");
            }
            else
            {
                Console.WriteLine("Dialog App Open fail");
            }
        }
        public void OpenApp()
        {
            //In Home Page click TRS Product
            _driver.FindElement(btnApp).Click();
            //In TRS Product click eCTDXPress
            _driver.FindElement(btneCTDXPress).Click();
            Thread.Sleep(5000);
            //Click Application when in Ectdxpress
            _driver.FindElement(btnApplication).Click();
            Thread.Sleep(5000);
            //Check pin when click eCTDXPress
            checkPin();
            //Click Open Application
            _driver.FindElement(OpenIconApp).Click();
            checkApp();
            Thread.Sleep(4000);
        }

    }
}
