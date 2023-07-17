using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using TestNunit.PageObject;
using TestNunit.TestDataAccess;

namespace TestNunit
{

    public class Tests
    {
        private EdgeDriver _driver;
        public CheckFindElement check;
        string appName = "";
        string sq = "";
        string userName = "";
        string passWord = "";
        string nodeName = "";
        [OneTimeSetUp]
        public void Setup()
        {
            // Initialize edge driver 
            var options = new EdgeOptions
            {
                PageLoadStrategy = PageLoadStrategy.Normal
            };
            _driver = new EdgeDriver(options);
            check = new CheckFindElement();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://10.3.23.173/TRS/");
            _driver.FindElement(By.XPath("//*[@id='details-button']")).Click();
            _driver.FindElement(By.XPath("//*[@id='proceed-link']")).Click();
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            // Apply explicit wait
            CheckProductLoadingDone checkProduct = new CheckProductLoadingDone(_driver);
            checkProduct.checkProduct();
        }
        /// <summary>
        /// Login Product
        /// </summary>     
        [Test]
        public void Step1()
        {
           User();
           // User2();
            Login loginPage = new Login(_driver);
            loginPage.LoginPage(userName, passWord);
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Click Application in Ribbon menu
        /// </summary>
        [Test]
        public void Step2()
        {
            OpenApplication openApplication = new OpenApplication(_driver);
            openApplication.OpenApp();
        }
        /// <summary>
        /// We Find App then Open
        /// </summary>
        [Test]
        public void Step3()
        {        
            FindApp findApp = new FindApp(_driver);        
            findApp.FindingApp(appName);
            Thread.Sleep(2000);
        }
        /// <summary>
        /// Select sequence with appName and sequence by set up
        /// </summary>
        [Test]
        public void Step4()
        {        
            SelectSequence selectSequence =new SelectSequence(_driver);                
            selectSequence.ChosenSequence(appName, sq);

        }
        #region Comment
        //[Test] public void Step5()
        //{

        //    _driver.FindElement(By.XPath("//span[text()='Edit']//parent::div//parent::div")).Click();
        //    Thread.Sleep(1000);
        //    _driver.FindElement(By.XPath("//span[text()='Lock']//parent::span")).Click();
        //    Thread.Sleep(2000);
        //}
        //[Test]
        //public void Step6()
        //{
        //    _driver.FindElement(By.XPath("//span[text()='Submission']//parent::div//parent::div")).Click();

        //    _driver.FindElement(By.XPath("//mat-icon[text()='ios_share']//parent::section//parent::span//parent::button")).Click();
        //    Thread.Sleep(2000);
        //}
        //[Test] public void Step7()
        //{ 
        //    _driver.FindElement(By.XPath("//span[text()='Select All']//parent::button")).Click();

        //    IList<IWebElement> list = _driver.FindElements(By.XPath("//ectd-compile-options-step//mat-checkbox"));
        //    Console.WriteLine(list);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        if (list[i].Text != " Only Update XML and Leaf Status " &&
        //            list[i].Text != " Do Not Update Regional.xml File (Applicable to JP Region Only)" &&
        //            list[i].Text != " Delete Files and Folders from the Output before Compiling ")
        //        {
        //            bool isChecked = list[i].GetAttribute("class").Contains("mat-checkbox-checked");
        //            if (!isChecked)
        //                Console.WriteLine("Checkbox is not Selected " + list[i].Text);
        //            else Console.WriteLine("Checkbox is Selected "+list[i].Text);
        //        }
        //    }


        //}
        //[Test]
        //public void Step8()
        //{
        //    _driver.FindElement(By.XPath("//span[text()='Next']//parent::button")).Click();
        //}
        //[Test]
        //public void Step9()
        //{
        //    _driver.FindElement(By.XPath("//ectd-compile-dms-options-step//mat-select[@role='combobox']")).Click();
        //    Thread.Sleep(500);
        //    _driver.FindElement(By.XPath("//span[text()='FSOutputFolder']//parent::mat-option")).Click();
        //    _driver.FindElement(By.XPath("//ectd-compile-options-step//span[text()='Next']//parent::button")).Click();
        //    Thread.Sleep(500);

        //}
        //[Test] 
        //public void Step10()
        //{
        //    _driver.FindElement(By.XPath("//ectd-compile-options-step//span[text()='Next']//parent::button")).Click();
        //    Thread.Sleep(2000);
        //}
        //[Test]
        //public void Step11()
        //{
        //    IList<IWebElement> list = _driver.FindElements(By.XPath("//mat-selection-list//mat-list-option"));
        //    Console.WriteLine(list);
        //    for(int i=0; i<list.Count; i++)
        //    {
        //        bool isChecked = list[i].GetAttribute("aria-selected").Contains("true");
        //        if (!isChecked)
        //        {
        //            //list.
        //        }
        //    }
        //    //mat-selection-list//mat-list-option
        //}
        #endregion
        /// <summary>
        /// Go to add new aleaf
        /// </summary>
        [Test]
        public void Step5()
        {
            AddSubmission addSubmission= new AddSubmission(_driver);         
            addSubmission.AddLeaf(nodeName);
        }
        /// <summary>
        /// Checking Loading DMS until done
        /// </summary>
        [Test]
        public void Step6()
        {
            LoadingDMS loadingDMS=new LoadingDMS(_driver);
            loadingDMS.checkLoadingDMS();         
        }
        /// <summary>
        /// Test done
        /// </summary>
        [OneTimeTearDown]
        public void CleanUp()
        {
            Thread.Sleep(2000);
            _driver.Close();
            Console.WriteLine("Closed the browser");
        }
        public void User2()
        {
            ReadExcel readExcel = new ReadExcel();
            readExcel.ReadDataFromExcel();
        }
        public void User()
        {
            ExcelDataAccess dataAccess = new ExcelDataAccess();
            var dt = dataAccess.ReadData();
            if (dt != null)
            {
                // Convert to string
                this.userName = Convert.ToString(dt.Rows[0][1]);
                this.passWord = Convert.ToString(dt.Rows[0][2]);
                this.appName = Convert.ToString(dt.Rows[0][3]);
                this.sq = Convert.ToString(dt.Rows[0][4]);
                this.nodeName = Convert.ToString(dt.Rows[0][5]);
            }
        }
    }
}