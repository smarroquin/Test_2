using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;

namespace ShoppingMasterCard
{
    [TestClass]
    public class MasterCard
    {
        static IWebDriver driver;
        
        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new FirefoxDriver();
        }

        [TestMethod]
        public void OrdenMasterCard()
        {
        }

        private bool IsElementPresent(By by)
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
        public bool TryFindElement(By by, IWebElement element)
        {
            try
            {
                element = driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }
        public bool IsElementVisible(IWebElement element)
        {
            return element.Enabled;
        }
    }
}
