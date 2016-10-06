using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;
using System.Threading;

namespace ShoppingDiners
{
    [TestClass]
    public class Diners
    {

        static IWebDriver driver;

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new FirefoxDriver();
        }

        [TestMethod]
        public void OrdenDiners()
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
    }
}
