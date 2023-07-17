using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestNunit.PageObject
{
    public class CheckProductLoadingDone
    {

        private EdgeDriver _driver;
        private By checkLoadingProduct = By.XPath("//div//input[@data-placeholder='Username']");
        public CheckProductLoadingDone(EdgeDriver driver)
        {
            _driver = driver;
        }
        public void checkProduct()
        {
            IWebElement element = null;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.Elapsed.TotalSeconds < 10) // Wait maximum 10 second
            {
                try
                {
                    element = _driver.FindElement(checkLoadingProduct);
                    if (element.Displayed)
                    {
                        break; // Page Loading show up, break out loop
                    }
                }
                catch (NoSuchElementException ex)
                {
                    Console.WriteLine(ex.Message);// Not show up, keep continute to wait
                }
            }
            stopwatch.Stop();
            if (element != null)
            {
                Console.WriteLine("Website Loading successfull");
            }
            else
            {
                Console.WriteLine("Website Loading fail");
            }
            Thread.Sleep(2000);
            //string pageTitle = _driver.Title;
            //Assert.AreEqual("Expected Title", pageTitle);

        }
        //By elementLocator = By.XPath("//div//input[@data-placeholder='Username']");
        //   IWebElement element = null;
        //   Stopwatch stopwatch = new Stopwatch();
        //   stopwatch.Start();
        //   while (stopwatch.Elapsed.TotalSeconds < 10) // Wait maximum 10 second
        //   {
        //       try
        //       {
        //           element = _driver.FindElement(elementLocator);
        //           if (element.Displayed)
        //           {
        //               break; // Page Loading show up, break out loop
        //           }
        //       }
        //       catch (NoSuchElementException)
        //       {
        //           // Not show up, keep continute to wait
        //       }
        //   }
        //   stopwatch.Stop();
        //   if (element != null)
        //   {
        //       Console.WriteLine("Website Loading successfull");
        //   }
        //   else
        //   {
        //       Console.WriteLine("Website Loading fail");
        //   }
        //   Thread.Sleep(2000);
    }
}
