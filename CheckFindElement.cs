using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TestNunit
{
    public static class WebDriverExtensions
    {
        public static IWebElement FindElement(IWebDriver driver, By by, int disPlay)
        {
            if (disPlay > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(disPlay));
                try
                {
                    return wait.Until(drv =>
                    {
                        try
                        {
                            return drv.FindElement(by);
                        }
                        catch
                        {
                            return null;
                        }
                    });
                }
                catch (WebDriverTimeoutException)
                {
                    return null;
                }
                catch (TimeoutException)
                {
                    return null;
                }
            }
            return driver.FindElement(by);
        }
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }
        public static bool elexists(By by, WebDriver driver)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static void waitforelement(WebDriver driver, By by)
        {
            for (int i = 0; i < 30; i++)
            {
                System.Threading.Thread.Sleep(1000);
                if (elexists(by, driver))
                {
                    break;
                }
            }
        }
    }
}
