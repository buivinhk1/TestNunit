using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestNunit.PageObject
{
    public class LoadingDMS
    {

        private EdgeDriver _driver;

        private By clickOK = By.XPath("//span[text()='OK']//parent::button");
        private By checkLoading = By.XPath("//kendo-window//div[@kendogridloading]//span");
        private By clickCancer = By.XPath("//span[text()='Cancel']//parent::button");

        public LoadingDMS(EdgeDriver driver)
        {
            _driver = driver;

        }

        public void clickbtnOK()
        {
            Thread.Sleep(2000);
            _driver.FindElement(clickOK).Click();
           
        }
        /// <summary>
        /// wait 5s to run try catch if Xpath checkLoading was found then condition (buttonloading != null) not null do-while will keep run to find that Xpath if Xpath found we wait 5s and check condittion again utill Xpath visbile then buttonloading == null get out do-while
        /// </summary>
        public void CheckLoadingDMS()
        {
            Thread.Sleep(3000);
            IWebElement buttonloading = null;
            //buttonloading = _driver.FindElement(checkLoading);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            do
            {
                try
                {
                    wait.Until(driver =>
                    {
                        try
                        {
                            return buttonloading = _driver.FindElement(checkLoading);
                        }
                        catch
                        {
                            return buttonloading=null;
                        }
                    });
                }
                catch (WebDriverTimeoutException)
                {
                    buttonloading = null;
                }
                catch (TimeoutException)
                {
                
                }
            } while (buttonloading != null);
        }
        public void clickbtnCancer()
        {
            _driver.FindElement(clickCancer).Click();
        }
        public void checkLoadingDMS()
        {
            clickbtnOK();
            CheckLoadingDMS();
            clickbtnCancer();
            Console.WriteLine("Loading Done");
        }
        //Thread.Sleep(2000);
        //_driver.FindElement(By.XPath("//span[text()='OK']//parent::button")).Click();
        //Thread.Sleep(4000);         
        //By loadingButtonLocator = By.XPath("//kendo-window//div[@kendogridloading]//span");
        //IWebElement buttonloading = null;
        //buttonloading = _driver.FindElement(loadingButtonLocator);
        //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
        //do
        //{
        //    try
        //    {
        //        wait.Until(driver =>
        //        {
        //            try
        //            {                        
        //                return _driver.FindElement(loadingButtonLocator);
        //            }
        //            catch
        //            {
        //                return null;
        //            }
        //        });
        //    }
        //    catch (WebDriverTimeoutException)
        //    {
        //        buttonloading = null;

        //    }
        //    catch (TimeoutException)
        //    {
        //        buttonloading = null;
        //    }
        //} while (buttonloading != null);

        //_driver.FindElement(By.XPath("//span[text()='Cancel']//parent::button")).Click();
    }
}
