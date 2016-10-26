using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoadPage
{
    [TestClass]
    public class LoadPage
    {

        static IWebDriver driver;

        [AssemblyInitialize]

        public static void Setup(TestContext Context)
        {
            driver = new FirefoxDriver();
        }

        [TestMethod]
        public void THome()
        {
            driver.Navigate().GoToUrl("http://juntoz.com");

        }
    }
}
