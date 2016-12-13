using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SuperAdmin
{
    [TestClass]
    public class SuperAdmin
    {
        static IWebDriver driver;
        static StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [AssemblyInitialize]
        public static void SetUp(TestContext Context)
        {
            driver = new FirefoxDriver();
           
        }

        [AssemblyCleanup]
        public static void Teardown()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }


        [TestMethod]
        public void Login()
        {
            driver.Navigate().GoToUrl("https://login.juntoz.com/auth/login?client_id=a2912434ae844eb48be398d5bfa77c3806c7a1bcc1bf44ee8acd8cdbf7e1d5e3&formView=login&returnUrl=http://admin.juntoz.com&actionName=");
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("denisse@ieholding.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("43445093");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Assert.AreEqual("SuperAdmin", driver.FindElement(By.CssSelector("span.logo-lg")).Text);
            Assert.AreEqual("Inicio", driver.FindElement(By.CssSelector("li.active.treeview > a > span")).Text);
            Assert.AreEqual("Dashboard", driver.FindElement(By.LinkText("Dashboard")).Text);
            Assert.AreEqual("Merchants", driver.FindElement(By.XPath("//section/ul/li[3]/a/span")).Text);
            Assert.AreEqual("Ventas", driver.FindElement(By.XPath("//section/ul/li[4]/a/span")).Text);
            Assert.AreEqual("Finanzas", driver.FindElement(By.XPath("//li[5]/a/span")).Text);
            Assert.AreEqual("Logistica", driver.FindElement(By.XPath("//li[6]/a/span")).Text);
            Assert.AreEqual("Catalogo", driver.FindElement(By.XPath("//li[7]/a/span")).Text);
            Assert.AreEqual("CMS", driver.FindElement(By.XPath("//li[8]/a/span")).Text);
            Assert.AreEqual("Seguridad", driver.FindElement(By.XPath("//li[9]/a/span")).Text);
            driver.FindElement(By.XPath("//section/ul/li[3]/a/span")).Click();
            Thread.Sleep(500);
            StringAssert.Equals("Merchants", driver.FindElement(By.CssSelector("li > a > span.ng-scope")).Text);
            Assert.AreEqual("Tiendas", driver.FindElement(By.LinkText("Tiendas")).Text);
            driver.FindElement(By.CssSelector("li > a > span.ng-scope")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.AreEqual("Merchants", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//input[@type='text']")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtroz", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.CssSelector("div.sa-body > div.col-md-12.sa-bordered > h4")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.CssSelector("th.ng-scope")).Text);
            Assert.AreEqual("Teléfono", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Tax", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Acciones", driver.FindElement(By.XPath("//th[4]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("li > a.btn.btn-default")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.btn-danger")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Administrar usuarios", driver.FindElement(By.LinkText("Administrar usuarios")).Text);
            
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("TRECA");
            driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.CssSelector("div.sa-body > div.col-md-12.sa-bordered > h4")).Text);
            Assert.AreEqual("Treca S.A.C.", driver.FindElement(By.CssSelector("td.ng-binding")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.btn-primary")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Crear Merchant", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);


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

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

    }
}
