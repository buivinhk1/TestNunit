using OpenQA.Selenium;

namespace TestNunit
{
    public class CheckFindElement
    {
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
        //WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        //wait.Until(_driver =>
        //{
        //    try
        //    {
        //        // Check if the next screen element is displayed or any other condition you want to use
        //        return _driver.FindElement(By.XPath("//div//input[@data-placeholder='Username']")).Displayed;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //});



        // _driver.FindElement(By.XPath("//kendo-window//div[@kendogridloading]"));
        // Apply explicit wait
        //var loadingButtonLocator = By.XPath("//kendo-window//div[@kendogridloading]//span");
        //bool isButtonDisplayed = true;
        //int maxAttempts = 10;
        //int delayInSeconds = 1;
        //int attempt = 0;
        //while (isButtonDisplayed && attempt < maxAttempts)
        //{
        //    try
        //    {
        //        IWebElement loadingButton = _driver.FindElement(loadingButtonLocator);
        //        isButtonDisplayed = loadingButton.Displayed;
        //        if (!isButtonDisplayed)
        //        {
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Waiting...");
        //        }
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        isButtonDisplayed = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        isButtonDisplayed = false;
        //        Console.WriteLine(ex.ToString());
        //    }
        //    Thread.Sleep(TimeSpan.FromSeconds(delayInSeconds));
        //    attempt++;
        //}
    }
}