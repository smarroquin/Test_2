using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Windows.Forms;

namespace HomePage
{
    [TestClass]
    public class LoadPage
    {

        static IWebDriver driver;
        static StringBuilder verificationErrors;
        private bool acceptNextAlert = true;

        [AssemblyInitialize]
        public static void SetUp(TestContext Context) {
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
        public void Home()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("", driver.FindElement(By.CssSelector("img.img-responsive.img-100")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.title-step-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Tiendas\noficiales", driver.FindElement(By.CssSelector("div.title-step-home")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[2]/div/div[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                StringAssert.Equals("Llegamos\na todo el país", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[2]/div/div[2]")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[3]/div/div[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                StringAssert.Equals("Paga con cualquier\nforma de pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[3]/div/div[2]")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[4]/div/div[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                StringAssert.Equals("Fonocompras\n(01) 640-9-640", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[4]/div/div[2]")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div/h2/b")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Tiendas Destacadas", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div/h2/b")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Todas las tiendas", driver.FindElement(By.CssSelector("span.tab-text.ng-binding")).Text);
            Assert.AreEqual("Gran Liquidación", driver.FindElement(By.CssSelector("#tab-2 > a.ng-binding > uib-tab-heading.ng-scope > h3.no-margin.ng-scope > span.tab-text.ng-binding")).Text);
            Assert.AreEqual("Las más populares", driver.FindElement(By.CssSelector("#tab-3 > a.ng-binding > uib-tab-heading.ng-scope > h3.no-margin.ng-scope > span.tab-text.ng-binding")).Text);
            Assert.AreEqual("Tiendas multimarca", driver.FindElement(By.CssSelector("#tab-4 > a.ng-binding > uib-tab-heading.ng-scope > h3.no-margin.ng-scope > span.tab-text.ng-binding")).Text);
            Assert.AreEqual("Nuevas tiendas", driver.FindElement(By.CssSelector("#tab-5 > a.ng-binding > uib-tab-heading.ng-scope > h3.no-margin.ng-scope > span.tab-text.ng-binding")).Text);
            Assert.AreEqual("tienda.juntoz.com", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span.ng-scope")).Text);
            Assert.AreEqual("Productos recomendados para ti", driver.FindElement(By.CssSelector("div.col-md-12 > h2.title-general > b")).Text);
            Assert.AreEqual("Lo más buscado de nuestras tiendas", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div[5]/div/h2/b")).Text);
            Assert.AreEqual("Conoce más sobre Juntoz", driver.FindElement(By.CssSelector("div.col-md-12.text-home-juntoz > h2.title-general > b")).Text);
            Assert.AreEqual("Mi cuenta", driver.FindElement(By.CssSelector("ul.list-unstyled.footer-list > span.ng-scope")).Text);
            Assert.AreEqual("Registro", driver.FindElement(By.LinkText("Registro")).Text);
            Assert.AreEqual("Servicio al cliente", driver.FindElement(By.XPath("//div[@id='footer-juntoz']/div/footer/div/nav[2]/ul/span")).Text);
            Assert.AreEqual("Preguntas frecuentes", driver.FindElement(By.LinkText("Preguntas frecuentes")).Text);
            Assert.AreEqual("Cambios y devoluciones", driver.FindElement(By.LinkText("Cambios y devoluciones")).Text);
            Assert.AreEqual("Términos y condiciones", driver.FindElement(By.LinkText("Términos y condiciones")).Text);
            Assert.AreEqual("Privacidad y confidencialidad", driver.FindElement(By.LinkText("Privacidad y confidencialidad")).Text);
            Assert.AreEqual("Términos legales de Campañas", driver.FindElement(By.LinkText("Términos legales de Campañas")).Text);
            Assert.AreEqual("Mapa del sitio", driver.FindElement(By.LinkText("Mapa del sitio")).Text);
            Assert.AreEqual("Vendamos juntos", driver.FindElement(By.LinkText("Vendamos juntos")).Text);
            Assert.AreEqual("Redes Sociales", driver.FindElement(By.XPath("//div[@id='footer-juntoz']/div/footer/div/nav[3]/ul/span")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-facebook-square")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-twitter-square")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-youtube-square")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-google-plus-square")).Text);
            Assert.AreEqual("Blog", driver.FindElement(By.CssSelector("a.blog-icon > span")).Text);
            Assert.AreEqual("Contáctanos", driver.FindElement(By.XPath("//div[@id='footer-juntoz']/div/footer/div/nav[3]/ul[2]/span")).Text);
            Assert.AreEqual("Teléfono: (511) 640-9-640", driver.FindElement(By.XPath("//div[@id='footer-juntoz']/div/footer/div/nav[3]/ul[2]/li")).Text);
            Assert.AreEqual("Email: hola@juntoz.com", driver.FindElement(By.XPath("//div[@id='footer-juntoz']/div/footer/div/nav[3]/ul[2]/li[2]")).Text);
            Assert.AreEqual("Formas de Pago", driver.FindElement(By.CssSelector("li > span.ng-scope")).Text);
            Assert.AreEqual("Recibe y conoce nuestras promociones", driver.FindElement(By.CssSelector("#subscribeForm > span.ng-scope")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.img-newsletter.pull-left")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("li.cat-nav-link.book-reclamaciones > a > img.img-responsive")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntoz.com/images/blobs/Footer-fabri.jpg_d75b872c20804677861433312fab58ee.png')]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-categories']/a/span[2]/span[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-stores']/a/span[2]/span[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span[2]/span")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btncartitem")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btnaccount")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
        }

        [TestMethod]
        public void MiCuenta()
            {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.LinkText("Registro")).Click();
            Thread.Sleep(1000);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.modal-login-register.ng-scope > div.ng-isolate-scope > ul.nav.nav-tabs")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("i.fa.fa-times")).Click();

        }

        [TestMethod]
        public void PregFrecuentes()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Assert.AreEqual("Preguntas frecuentes", driver.FindElement(By.LinkText("Preguntas frecuentes")).Text);
            driver.FindElement(By.LinkText("Preguntas frecuentes")).Click();
            driver.Navigate().GoToUrl("http://juntoz.com/pages/frequentlyq");
            Thread.Sleep(100);
            Assert.AreEqual("Preguntas Frecuentes", driver.FindElement(By.CssSelector("h3.faq-title.ng-scope")).Text);
            Assert.AreEqual("Registro", driver.FindElement(By.Id("tab-1")).Text);
            Assert.AreEqual("Comprar en Línea", driver.FindElement(By.Id("tab-2")).Text);
            Assert.AreEqual("Formas de Pago y Facturación", driver.FindElement(By.Id("tab-3")).Text);
            Assert.AreEqual("Mi Pedido", driver.FindElement(By.Id("tab-5")).Text);
            Assert.AreEqual("Envío y Entregas", driver.FindElement(By.Id("tab-6")).Text);
            Assert.AreEqual("Devoluciones", driver.FindElement(By.Id("tab-7")).Text);
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("h4.panel-title > a > span.ng-scope")).Text, "^exact:¿Cómo hago para registrarme[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo accedo a mi cuenta[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#headingThree > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo actualizo y/o modifico mis datos[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#headingFour > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo puedo recuperar mi contraseña[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#headingFive > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo elimino mi cuenta[\\s\\S]$")); }
            catch { };
            driver.FindElement(By.CssSelector("h4.panel-title > a > span.ng-scope")).Click();
            StringAssert.Equals("Registrarse en Juntoz.com es muy fácil", driver.FindElement(By.CssSelector("div.col-md-12 > p")).Text);
            driver.FindElement(By.CssSelector("h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab1-h2 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            Thread.Sleep(100);
            StringAssert.Equals("Ingresa aquí.", driver.FindElement(By.CssSelector("div.col-md-4 > ul > li")).Text);
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#tab1-h2 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.CssSelector("#headingThree > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            Thread.Sleep(100);
            StringAssert.Equals("Ingresa a tu cuenta personal aquí.", driver.FindElement(By.CssSelector("ol > li")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#headingThree > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#headingFour > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Para Cambiar Contraseña", driver.FindElement(By.CssSelector("#collapseFour > div.panel-body > div.row > div.col-md-12 > p > strong")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#headingFour > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#headingFive > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Si tomaste la decisión de eliminar tu cuenta, por favor escríbenos un correo electrónico a hola@juntoz.com con el asunto “Eliminar Usuario”. Nuestro equipo de Servicio al Cliente gestionará tu solicitud dentro de las 24 horas hábiles de haberla recibido.", driver.FindElement(By.CssSelector("div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#headingFive > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.Id("tab-2")).Click();
            Thread.Sleep(100);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab2-heading1 > h4.panel-title > a > span.ng-scope")).Text, "^exact:¿Cómo hago para buscar un producto[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab2-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo realizo una compra[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab2-h5 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Los productos son nuevos y originales[\\s\\S]$"));
            }
            catch { };
            driver.FindElement(By.CssSelector("#tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            Assert.AreEqual("Buscar un producto en JUNTOZ en muy fácil!", driver.FindElement(By.CssSelector("#tab2-col1 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab2-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            Thread.Sleep(100);
            StringAssert.Equals("Ingresa con tu cuenta o crea una cuenta nueva si es tu primera compra.", driver.FindElement(By.CssSelector("#tab2-col3 > div.panel-body > div.row > div.col-md-12 > ol > li")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#tab2-h3 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.CssSelector("#tab2-h5 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Todos los productos que se comercializan a través de Juntoz.com son completamente nuevos y originales. Las empresas afiliadas que venden sus productos a través de la web son distribuidores autorizados y ofrecen la protección de garantía de todos sus productos. Ante ello, ten la completa seguridad por los productos que adquieres a través de Juntoz.com son nuevos y de procedencia legal.", driver.FindElement(By.CssSelector("p.ng-scope")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#tab2-h5 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.Id("tab-3")).Click();
            Thread.Sleep(100);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#accordion3 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Text, "^exact:¿Qué métodos de pago tienen disponibles[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab3-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Puedo pagar con tarjetas internacionales[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab3-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Qué hago si mi pago con tarjeta no funciona[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab3-h5 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Puedo solicitar factura para mi compra[\\s\\S]$"));
            }
            catch { };
            driver.FindElement(By.CssSelector("#accordion3 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            StringAssert.Equals("Por tu seguridad y comodidad ponemos a tu disposición los siguientes medios de pagos:", driver.FindElement(By.CssSelector("#tab3-col1 > div.panel-body > p.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#accordion3 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab3-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Absolutamente seguro, en Juntoz.com garantizamos al 100% la seguridad de tus pagos. Al momento de pagar con tu tarjeta de crédito o débito, toda tu información es cifrada mediante el mejor sistema de protección Secure Sockets Layer (SSL) de 256-bit. Así que puedes estar tranquilo, nosotros no guardamos ningún dato de tu tarjeta.", driver.FindElement(By.CssSelector("#tab3-col3 > div.panel-body > p.ng-scope")).Text);
            Thread.Sleep(100);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#tab3-h3 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.CssSelector("#tab3-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Verifica si los datos de la tarjeta han sido ingresados correctamente.", driver.FindElement(By.CssSelector("ol[type=\"a\"] > li.ng-scope")).Text);
            driver.FindElement(By.LinkText("¿Qué hago si mi pago con tarjeta no funciona?")).Click();
            driver.FindElement(By.LinkText("¿Puedo solicitar factura para mi compra?")).Click();
            Thread.Sleep(100);
            jse.ExecuteScript("scroll(250, 0)");
            StringAssert.Equals("Si, al momento de procesar tu pedido debes elegir el tipo de comprobante de pago (Boleta o Factura). Es muy importante que los datos de facturación sean llenados de manera completa y correcta, ya que una vez procesada la compra no serán posibles modificarlos.", driver.FindElement(By.CssSelector("#tab3-col5 > div.panel-body > p.ng-scope")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.CssSelector("#tab3-h5 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            driver.FindElement(By.Id("tab-5")).Click();
            jse.ExecuteScript("scroll(250, 0)");
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Cómo verifico el estado de mi pedido?")).Text, "^exact:¿Cómo verifico el estado de mi pedido[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab5-heading2 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:Ya realicé el pago de mi orden ¿Qué más debo hacer[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab5-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Puedo cambiar los datos de mi pedido[\\s\\S]$"));
            }
            catch { };
            Assert.AreEqual("Deseo cancelar mi pedido", driver.FindElement(By.CssSelector("#tab5-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#accordion5 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            StringAssert.Equals("Si ya realizaste una compra y deseas saber el estado de la misma, ingresa a tu cuenta personal y elige la opción Mis Pedidos; ahí encontrarás todos los pedidos que has realizado con tu cuenta Juntoz.", driver.FindElement(By.CssSelector("#tab5-col1 > div.panel-body > p.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#accordion5 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab5-heading2 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            Thread.Sleep(100);
            StringAssert.Equals("Si elegiste como medio de pago:", driver.FindElement(By.CssSelector("#tab5-col2 > div.panel-body > p.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#tab5-heading2 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab5-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            Thread.Sleep(100);
            StringAssert.Equals("Una vez generado el pedido, nuestro sistema asigna un código único para tu orden de compra y por motivos de seguridad los datos registrados no pueden ser modificados. Por ello, te recomendamos que ingreses de manera correcta todos los datos de tu compra como dirección de envío, datos de facturación, medio de pago, etc.", driver.FindElement(By.CssSelector("#tab5-col3 > div.panel-body > p.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#tab5-h3 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab5-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Ingresa a tu cuenta personal y elige la opción Mis Pedidos. Ubica el pedido que deseas anular y haz click en “Anular Pedido”, selecciona el motivo por el cual decidiste cancelar y haz click en “Enviar”.", driver.FindElement(By.CssSelector("#tab5-col4 > div.panel-body > p.ng-scope")).Text);
            driver.FindElement(By.CssSelector("#tab5-h4 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.Id("tab-6")).Click();
            Thread.Sleep(100);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Hacen entregas a todo el Perú?")).Text, "^exact:¿Hacen entregas a todo el Perú[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab6-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo puedo saber la fecha de entrega de mi pedido[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab6-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Puedo elegir una fecha y hora para la entrega de mi pedido[\\s\\S]$"));
            }
            catch { };
                driver.FindElement(By.CssSelector("#accordion6 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            StringAssert.Equals("Si, gracias a que estamos afiliados a una amplia red de operadores logísticos que nos permiten tener una amplia cobertura a nivel nacional. Sin embargo, cada vendedor puede limitar la entrega de productos a regiones o provincias determinadas.", driver.FindElement(By.CssSelector("#tab6-col1 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#accordion6 > div.panel.panel-default > #tab2-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab6-h3 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Al momento de seleccionar un producto y editar la dirección de entrega el vendedor asigna un tiempo estimado para la entrega del pedido. Este tiempo de entrega es válido y empieza a correr desde el momento en que la orden es Confirmada y se contabilizan a partir de días hábiles.", driver.FindElement(By.CssSelector("#tab6-col3 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#tab6-h3 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab6-h4 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Actualmente, no es posible elegir la fecha y hora para recibir tu pedido. Sin embargo, muy pronto habilitaremos una nueva opción de entrega que te permitirá tener mayor libertad y comodidad para recibir tu pedido.", driver.FindElement(By.CssSelector("#tab6-col4 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#tab6-h4 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.Id("tab-7")).Click();
            Thread.Sleep(100);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab7-heading1 > h4.panel-title > a > span.ng-scope")).Text, "^exact:No estoy satisfecho con el producto recibido\\. ¿Qué puedo hacer[\\s\\S]$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("#tab7-heading2 > h4.panel-title > a.collapsed > span.ng-scope")).Text, "^exact:¿Cómo solicito el reembolso de mi dinero[\\s\\S]$"));
            }
            catch { };
                driver.FindElement(By.CssSelector("#tab7-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            Thread.Sleep(100);
            Assert.AreEqual("Si por alguna razón no te encuentras satisfecho con tu compra, Juntoz.com te ofrece la posibilidad de devolver tu producto dentro de los primeros siete (7) días hábiles después de haberlo recibido.", driver.FindElement(By.CssSelector("#tab7-col1 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#tab7-heading1 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("#tab7-heading2 > h4.panel-title > a.collapsed > span.ng-scope")).Click();
            StringAssert.Equals("Si, haz realizado el cambio o devolución de algún producto y este fue aceptado por el vendedor tienes la opción de solicitar el rembolso de tu dinero. El proceso de reembolso inicia a solicitud del cliente y una vez que haya sido aceptada la solicitud de devolución por parte del vendedor.", driver.FindElement(By.CssSelector("#tab7-col2 > div.panel-body > p")).Text);
            driver.FindElement(By.CssSelector("#tab7-heading2 > h4.panel-title > a > span.ng-scope")).Click();
            driver.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();

        }

        [TestMethod]
        public void Devoluciones()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            Assert.AreEqual("Cambios y devoluciones", driver.FindElement(By.LinkText("Cambios y devoluciones")).Text);
            driver.FindElement(By.LinkText("Cambios y devoluciones")).Click();
            Thread.Sleep(1000);
            StringAssert.Equals("Política General de Devoluciones", driver.FindElement(By.CssSelector("div.container.ng-scope > h2.title-general > b")).Text);
            Assert.AreEqual("Todas las tiendas y/o marcas (en adelante Los Merchants) que venden en www.juntoz.com están comprometidas a que el cliente se encuentre completamente satisfecho durante toda su experiencia de compra. Sin embargo, somos conscientes de que en ciertas ocasiones es posible que quieras devolver o cambiar un producto. En ese sentido, Los Merchants tienen la responsabilidad de publicar sus políticas de cambios, devoluciones y garantías en cada página de información de producto (product page). Asimismo, es responsabilidad de cada comprador/usuario revisar estas políticas antes de realizar la compra de cualquier producto. No obstante, cabe señalar que estas políticas no afectan los derechos del cliente estipulados en la Ley 29571 del Código de Defensa del Consumidor.", driver.FindElement(By.CssSelector("div.container.ng-scope > p")).Text);
            Assert.AreEqual("Las solicitudes de cambios y devoluciones serán recibidas y atendidas por nuestro equipo de Servicio al Cliente, que tiene como principal objetivo garantizar una respuesta rápida y oportuna, velando en todo momento que Los Merchants cumplan con entregar un óptimo servicio de pre y post venta a todos nuestros clientes.", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/p[2]")).Text);
            Assert.AreEqual("A continuación, detallamos las circunstancias (motivos) en las que es posible devolver un producto; así como, los pasos que como cliente debes seguir para hacer efectiva una devolución. Sin embargo, es necesario puntualizar que estos motivos y pasos, no necesariamente aplican para todos los productos o tiendas. Por ello, recomendamos que antes de realizar la compra de un producto, verifiques sus políticas de devolución en la sección de “Devoluciones y Garantías”.", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/p[3]")).Text);
            Assert.AreEqual("Circunstancias para devolver un Producto", driver.FindElement(By.CssSelector("li > strong")).Text);
            Assert.AreEqual("Pasos para Devolver un Producto", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/ol/li[2]/strong")).Text);
            driver.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();
        }

        [TestMethod]
        public void condiciones()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            Assert.AreEqual("Cambios y devoluciones", driver.FindElement(By.LinkText("Cambios y devoluciones")).Text);
            driver.FindElement(By.LinkText("Cambios y devoluciones")).Click();
            Assert.AreEqual("Términos y condiciones", driver.FindElement(By.LinkText("Términos y condiciones")).Text);
            driver.FindElement(By.LinkText("Términos y condiciones")).Click();
            Thread.Sleep(500);
            StringAssert.Equals("Términos y condiciones", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/h2/b")).Text);
            Assert.AreEqual("Privacidad y confidencialidad", driver.FindElement(By.LinkText("Privacidad y confidencialidad")).Text);
            driver.FindElement(By.LinkText("Privacidad y confidencialidad")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Privacidad y confidencialidad", driver.FindElement(By.CssSelector("h4.form-title.ng-scope")).Text);
            Assert.AreEqual("Términos legales de Campañas", driver.FindElement(By.LinkText("Términos legales de Campañas")).Text);
            driver.FindElement(By.LinkText("Términos legales de Campañas")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Términos Legales de Campañas", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/h2/b")).Text);
            Assert.AreEqual("Mapa del sitio", driver.FindElement(By.LinkText("Mapa del sitio")).Text);
            driver.FindElement(By.LinkText("Mapa del sitio")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Tiendas", driver.FindElement(By.CssSelector("h1.text-center.sitemap-title")).Text);
            Assert.AreEqual("Categorías", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/h1[2]")).Text);
            Assert.AreEqual("Salud, Belleza y Cuidado Personal", driver.FindElement(By.CssSelector("h2.text-center > a.ng-binding")).Text);
            Assert.AreEqual("Tecnología y Cómputo", driver.FindElement(By.XPath("//a[contains(text(),'Tecnología y Cómputo')]")).Text);
            Assert.AreEqual("Moda", driver.FindElement(By.XPath("(//a[contains(text(),'Moda')])[7]")).Text);
            Assert.AreEqual("Hogar, Jardín y Herramientas", driver.FindElement(By.XPath("//a[contains(text(),'Hogar, Jardín y Herramientas')]")).Text);
            Assert.AreEqual("Juguetes, Niños y Bebés", driver.FindElement(By.XPath("//a[contains(text(),'Juguetes, Niños y Bebés')]")).Text);
            Assert.AreEqual("Motores", driver.FindElement(By.XPath("//a[contains(text(),'Motores')]")).Text);
            Assert.AreEqual("Deportes y Aventura", driver.FindElement(By.XPath("//a[contains(text(),'Deportes y Aventura')]")).Text);
            Assert.AreEqual("Útiles de Oficina y Escolares", driver.FindElement(By.LinkText("Útiles de Oficina y Escolares")).Text);
            Assert.AreEqual("Instrumentos Musicales", driver.FindElement(By.LinkText("Instrumentos Musicales")).Text);
            Assert.AreEqual("Libros", driver.FindElement(By.LinkText("Libros")).Text);
            Assert.AreEqual("Maletas y Mochilas", driver.FindElement(By.XPath("(//a[contains(text(),'Maletas y Mochilas')])[2]")).Text);
            Assert.AreEqual("Relojes", driver.FindElement(By.XPath("(//a[contains(text(),'Relojes')])[2]")).Text);
            driver.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();

        }

        [TestMethod]
        public void vendamos()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            driver.FindElement(By.LinkText("Vendamos juntos")).Click();
            Thread.Sleep(500);
            StringAssert.Equals("Abre tu tienda en nuestra plataforma de marketplace", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/h4")).Text);
            Assert.AreEqual("Vende a nivel nacional", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[2]/h4")).Text);
            Assert.AreEqual("Posicionamiento", driver.FindElement(By.CssSelector("h4.ng-scope")).Text);
            Assert.AreEqual("Métodos de pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[4]/h4")).Text);
            Assert.AreEqual("Marketing Online", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[5]/h4")).Text);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("div.b2b-title > h2.title-general > b")).Text, "^exact:¿Quieres abrir tu tienda en Juntoz[\\s\\S]$"));
            }
            catch { };
                Assert.AreEqual("Contáctate con nosotros y te ayudaremos a aumentar tus ventas al por mayor usando este nuevo canal online:", driver.FindElement(By.CssSelector("div.sell-section.form-b2b > h4.ng-scope")).Text);
            Assert.AreEqual("Datos de la empresa", driver.FindElement(By.CssSelector("h4.title-form-section.ng-scope")).Text);
            Assert.AreEqual("Número de RUC:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("RUC")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Nombre comercial:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("comercialname")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Categoría:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[3]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("categories")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Representaciones", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[2]")).Text);
            Assert.AreEqual("Marcas que representa:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//input[@type='number']")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("brandsName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Representante de la marca:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("representation")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Distribuidor autorizado:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-5 > div.radio > input[name=\"representation\"]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Distribuidor autorizado:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[2]/label")).Text);
            Assert.AreEqual("Otros:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[3]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[10]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Datos del Contacto", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[3]")).Text);
            Assert.AreEqual("Nombre del Contacto:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("contactName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Email:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("email")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Teléfono:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[3]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("telephone")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();

        }

        [TestMethod]
        public void LReclamaciones()
        {
            driver.Navigate().GoToUrl("http://juntoz.com/");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(0, 250)");
           // driver.FindElement(By.CssSelector("div.row > div.ng-scope")).Click();
            Thread.Sleep(100);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("li.cat-nav-link.book-reclamaciones > a > img.img-responsive")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("li.cat-nav-link.book-reclamaciones > a > img.img-responsive")).Click();
            Thread.Sleep(500);
            Assert.AreEqual("Libro de reclamaciones", driver.FindElement(By.CssSelector("h3.form-title.ng-scope")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("b.ng-binding")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/span[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("p > b")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Juntoz Perú SAC\n RUC: 20600276566\n Avenida Javier Prado Oeste N° 1586 San Isidro - Lima", driver.FindElement(By.CssSelector("p > b")).Text);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("h5.required-fields.ng-scope")).Text, "^exact:[\\s\\S]*Campos obligatorios$"));
            }
            catch { };
                Assert.AreEqual("1. Identificación del Consumidor Reclamante", driver.FindElement(By.CssSelector("div.panel-heading")).Text);

            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[2]/label")).Text, "^exact:Nombre[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[3]/label")).Text, "^exact:Apellido paterno[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[5]/label")).Text, "^exact:Dirección[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[6]/label")).Text, "^exact:Tipo de documento[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[7]/label")).Text, "^exact:Número de documento[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[8]/label")).Text, "^exact:Email[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[9]/label")).Text, "^exact:Celular[\\s\\S]*:$"));
            }
            catch { };
                Assert.AreEqual("Datos del apoderado (En caso la persona que presenta el reclamo sea menor de edad)", driver.FindElement(By.CssSelector("h5.form-subtitle.ng-scope")).Text);
            Assert.AreEqual("Nombres y Apellidos:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[11]/label")).Text);
            Assert.AreEqual("Tipo de documento:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[12]/label")).Text);
            Assert.AreEqual("Número de documento:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[13]/label")).Text);
            Assert.AreEqual("2. Identificación del Bien Contratado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[14]/div/div")).Text);
            Assert.AreEqual("Número de pedido:", driver.FindElement(By.CssSelector("div.form-group > div > label.col-sm-3.control-label")).Text);
            Assert.AreEqual("Monto Reclamado S/:", driver.FindElement(By.CssSelector("label.col-sm-2.control-label")).Text);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[16]/label")).Text, "^exact:Identificación del Bien contratado[\\s\\S]*:$"));
            }
            catch { };
                Assert.AreEqual("Producto", driver.FindElement(By.CssSelector("label.radio-inline > span.ng-scope")).Text);
            Assert.AreEqual("Servicio", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[16]/div/label[2]/span")).Text);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[17]/label")).Text, "^exact:Descripción[\\s\\S]*:$"));
            }
            catch { };
                Assert.AreEqual("3. Detalle de la Reclamación y Pedido del Consumidor", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[18]/div/div")).Text);
            Assert.AreEqual("Reclamo", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[19]/div/label/span")).Text);
            Assert.AreEqual("Queja", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[19]/div/label[2]/span")).Text);

            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[20]/label")).Text, "^exact:Detalle[\\s\\S]*:$"));
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[21]/label")).Text, "^exact:Pedido \\(Cómo te podemos compensar\\)[\\s\\S]*:$"));
            }
            catch { };
                Assert.AreEqual("RECLAMO:", driver.FindElement(By.CssSelector("b.ng-scope")).Text);
            Assert.AreEqual("QUEJA:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/form/div[22]/p[2]/b")).Text);
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
