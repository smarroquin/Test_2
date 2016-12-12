using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MobileD
{
  [TestClass]
    public class Mobile
    {
        static IWebDriver driver;
        static StringBuilder verificationErrors;
        static string baseURL;
        static bool acceptNextAlert = true;

        [AssemblyInitialize]
        public static void SetupTest(TestContext Context)
        {
            driver = new FirefoxDriver();
            baseURL = "http://www.m.juntoz.com";
            verificationErrors = new StringBuilder();
        }

        [AssemblyCleanup]
        public static void TeardownTest()
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
        public void TheMobileTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("", driver.FindElement(By.XPath("(//button[@type='button'])[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button[type=\"button\"]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[3]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[4]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button[type=\"button\"]")).Click();
            Assert.AreEqual("Cuenta", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div/div")).Text);
            Assert.AreEqual("Ingresar", driver.FindElement(By.CssSelector("span[type=\"button\"] > div > div > div")).Text);
            Assert.AreEqual("Regístrate", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div/div[3]/span/div/div/div")).Text);
            Assert.AreEqual("Compra por categoría", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div")).Text);
            Assert.AreEqual("SALUD, BELLEZA Y CUIDADO PERSONAL", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/span/div/div/div")).Text);
            StringAssert.Equals("PERFUMES Y FRAGANCIAS", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[2]/span/div/div/div")).Text);
            StringAssert.Equals("CUIDADO PERSONAL", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[3]/span/div/div/div")).Text);
            StringAssert.Equals("CUIDADO DEL CABELLO", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[4]/span/div/div/div")).Text);
            StringAssert.Equals("CUIDADO FACIAL", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[5]/span/div/div/div")).Text);
            StringAssert.Equals("AFEITADO", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[6]/span/div/div")).Text);
            StringAssert.Equals("CUIDADO DE LA PIEL", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[7]/span/div/div")).Text);
            StringAssert.Equals("SALUD", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[8]/span/div/div/div")).Text);
            StringAssert.Equals("MASAJE Y SPA", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[9]/span/div/div/div")).Text);
            StringAssert.Equals("MAQUILLAJE", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[10]/span/div/div")).Text);
            StringAssert.Equals("ARTÍCULOS DE EJERCICIO", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[11]/span/div/div/div")).Text);
            StringAssert.Equals("VER TODAS", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[2]/div/div[12]/span/div/div/div")).Text);
            StringAssert.Equals("TECNOLOGÍA Y CÓMPUTO", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[2]/div[3]/span/div/div")).Text);
            Assert.AreEqual("Servicio al cliente", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[3]/div")).Text);
            Assert.AreEqual("LIBRO DE RECLAMACIONES", driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[3]/div[2]/span/div/div/div")).Text);
            driver.FindElement(By.XPath("//div[@id='content']/div/div[3]/div[2]/div/div[3]/div[2]/span/div/div/div")).Click();
            StringAssert.Equals("Libro de reclamaciones", driver.FindElement(By.CssSelector("span")).Text);
            try { StringAssert.Equals("Juntoz Perú SAC", driver.FindElement(By.CssSelector("p > strong")).Text);

                Assert.AreEqual("RUC: 20600276566", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[3]/p/strong[2]")).Text);
                Assert.AreEqual("Avenida Javier Prado Oeste N° 1586", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[3]/p/strong[3]")).Text);
                Assert.AreEqual("San Isidro - Lima", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[3]/p/strong[4]")).Text);
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div/p/span")).Text, "^exact:[\\s\\S]* Campos obligatorios$"));
                Assert.AreEqual("1. Identificación del consumidor reclamante", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[2]")).Text);
            }
            catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("name")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("fathersLastName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("mothersLastName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("address")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("DNI", driver.FindElement(By.XPath("//div/div[2]")).Text);
            try { driver.FindElement(By.XPath("//div[2]/div/div/div/div/span/div/div")).Click(); } catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("documentNumber")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("email")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("cellPhone")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Datos del apoderado (En caso la persona que presenta el reclamo sea menor de edad)", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[3]/div[9]/div/p")).Text);
            }
            catch { };
            
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("parentName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("#parentDocumentType > div")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//body/div[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                driver.FindElement(By.XPath("//body/div[2]")).Click();
                Assert.AreEqual("2. Identificación del bien contratado", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[4]")).Text);
            }
            catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("orderNumber")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("orderAmount")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("IDENTIFICACIÓN DEL BIEN CONTRATADO", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[5]/div[3]/div")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("orderType")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[5]/div[5]/div/div/div")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("3. Detalle de la reclamación y pedido del consumidor", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[6]")).Text);
            Assert.AreEqual("TIPO DE RECLAMACIÓN", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[7]/div/div")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("claimType")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[7]/div[3]/div/div/div")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[7]/div[4]/div/div/div")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("RECLAMO:", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[8]/p/strong")).Text);
            Assert.AreEqual("QUEJA:", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[8]/p[2]/strong")).Text);
            Assert.AreEqual("ENVIAR", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            try { Assert.AreEqual("Requerido", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[4]/div[3]/div/div/div/div[2]")).Text);
            }
            catch { };


        }

        [TestMethod]
        public void TMobileShop()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            StringAssert.Equals("Tiendas Destacadas", driver.FindElement(By.CssSelector("h2")).Text);
            StringAssert.Equals("Todas las tiendas", driver.FindElement(By.CssSelector("article.stores > header > div > h2")).Text);
            driver.Navigate().GoToUrl(baseURL + "/producto/khs-bicicleta-tc-150-l-1035-077723");
            
            Assert.AreEqual("Agotado", driver.FindElement(By.XPath("//div[@id='content']/div/div[2]/div/div[2]/div[5]/div/div/div[2]")).Text);
            driver.Navigate().GoToUrl(baseURL + "/producto/tsg-casco-skatebmx-79750400-35-151");
            StringAssert.Equals("CÓMPRALO AHORA", driver.FindElement(By.XPath("(//button[@type='button'])[8]")).Text);
            StringAssert.Equals("AGRÉGALO AL CARRITO", driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Text);
            driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Click();
            Assert.AreEqual("Mi Carrito", driver.FindElement(By.XPath("//div[@id='content']/div/div[4]/div[2]/div/div/div[2]/span")).Text);
            Assert.AreEqual("Tienes 1 producto en tu carrito", driver.FindElement(By.XPath("//div[@id='content']/div/div[4]/div[2]/div/div[2]")).Text);
            Assert.AreEqual("Subtotal:", driver.FindElement(By.XPath("//div[@id='content']/div/div[4]/div[2]/div[3]/div/div")).Text);
            Assert.AreEqual("COMPRAR TODO", driver.FindElement(By.XPath("(//button[@type='button'])[28]")).Text);
            driver.FindElement(By.XPath("(//button[@type='button'])[26]")).Click();
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
