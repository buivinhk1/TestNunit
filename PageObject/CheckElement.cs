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
    public class CheckElement
    {

        private EdgeDriver _driver;
        public CheckElement(EdgeDriver driver)
        {
            _driver = driver;
        }
        public void check(By by)
        {
            IWebElement element = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalSeconds < 10) // Wait maximum 10 second
            {
                try
                {
                    element = _driver.FindElement(by);
                    if (element.Displayed)
                    {
                        break; // Page Loading show up, break out loop
                    }
                }
                catch (NoSuchElementException)
                {
                    // Not show up, keep continute to wait
                }
            }
            stopwatch.Stop();
            if (element != null)
            {
                Console.WriteLine("Element Loading successfull "+ element.Text);
            }
            else
            {
                Console.WriteLine("Element Loading fail");
            }
            Thread.Sleep(2000);
            //string pageTitle = _driver.Title;
            //Assert.AreEqual("Expected Title", pageTitle);
        }
    }
}
