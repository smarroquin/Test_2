using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace TCompras
{
    [TestClass]
    public class Compra
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
        public void SeleccionProducto()
        {
            
            driver.Navigate().GoToUrl("http://juntoz.com/catalogo?allStore=true&specialPrice=false");
            Thread.Sleep(500);
            Assert.AreEqual("Ordenar por:", driver.FindElement(By.CssSelector("div.catalog-search-by.pull-left > span")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//section[@id='filters__and__products']/section[2]/div/div/div/select")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Relevancia", driver.FindElement(By.CssSelector("option[value=\"rating-desc\"]")).Text);
            driver.FindElement(By.CssSelector("img.img-responsive.catalog-products-body__product-img-big")).Click();
            Thread.Sleep(500);
            //driver.FindElement(By.XPath("//div[@id='thumbnail-control-variation']/div/ul/li/a")).Click();
            //Assert.AreEqual("Hogar, Jardín y Herramientas", driver.FindElement(By.CssSelector("a.ng-binding.ng-scope")).Text);
            //Assert.AreEqual("Cocina y Sobremesa", driver.FindElement(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")).Text);
            //Assert.AreEqual("Ollas Y Sartenes", driver.FindElement(By.LinkText("Ollas Y Sartenes")).Text);
            //Assert.AreEqual("Juego de Ollas", driver.FindElement(By.LinkText("Juego de Ollas")).Text);
            //Assert.AreEqual("Magefesa", driver.FindElement(By.LinkText("Magefesa")).Text);
            //Assert.AreEqual("/ Magefesa - Juego de Ollas Antártida Aluminio Antiadherente", driver.FindElement(By.CssSelector("span.name-product-breadcrumb.ng-binding")).Text);
            //try
            //{
            //    Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntoz.com/images/blobs/c964c35be6594fa083403afdc0a88a24.png?w=40&h=40')]")));
            //}
            //catch (AssertFailedException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            //Assert.AreEqual("Pase el cursor sobre la imagen para ampliarla.", driver.FindElement(By.CssSelector("p.text-information-zoom.ng-scope")).Text);
            //Assert.AreEqual("Magefesa - Juego de Ollas Antártida Aluminio Antiadherente", driver.FindElement(By.CssSelector("h1.single-product-name.ng-binding")).Text);
            //Assert.AreEqual("S/ 449.00", driver.FindElement(By.CssSelector("strong.specialPriceProduct.ng-binding")).Text);
            //Assert.AreEqual("Color: Blanco", driver.FindElement(By.CssSelector("span.variation-name.ng-binding")).Text);
            //Assert.AreEqual("Número de Piezas:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[2]/div[6]/div/div/div/div[3]/div/span")).Text);
            //try
            //{
            //    Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[2]/div[6]/div/div/div/div[3]/div/select")));
            //}
            //catch (AssertFailedException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            Assert.AreEqual("Cantidad:", driver.FindElement(By.CssSelector("div.row > div.col-md-5.ng-scope > span.variation-name")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btn-append-to-to-body")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Especificaciones:", driver.FindElement(By.CssSelector("li.active > a > span")).Text);
            //Assert.AreEqual("- Juego de Ollas fabricado en aluminio para una óptima distribución del calor.", driver.FindElement(By.CssSelector("li.ng-scope > span.ng-binding.ng-scope")).Text);
            //Assert.AreEqual("- Acabado exterior elaborado a alta temperatura.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[2]/span")).Text);
            //Assert.AreEqual("- Aplicación interior antiadherente cerámico.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[3]/span")).Text);
            //Assert.AreEqual("- Tapas de vidrio termo-resistente con cerquillo de acero inoxidable y chimenea.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[4]/span")).Text);
            //Assert.AreEqual("- Asas y mangos de toque \"soft\" con salvallamas.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[5]/span")).Text);
            //Assert.AreEqual("- Fácil limpieza.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[6]/span")).Text);
            //Assert.AreEqual("- Incluye: Olla con tapa (24cm) + Olla con tapa (18cm) + Cacerola con tapa (16cm) + Sartén (24 cm).", driver.FindElement(By.XPath("//div[@id='home']/ul/li[7]/span")).Text);
            Assert.AreEqual("Ver más", driver.FindElement(By.CssSelector("a.view-more-description")).Text);
            Assert.AreEqual("Los clientes que vieron este producto también vieron", driver.FindElement(By.CssSelector("h3.section-title.ng-scope > b")).Text);
            Assert.AreEqual("Descripción del Producto", driver.FindElement(By.LinkText("Descripción del Producto")).Text);
            Assert.AreEqual("Sobre la Marca", driver.FindElement(By.LinkText("Sobre la Marca")).Text);
            Assert.AreEqual("Ficha Técnica", driver.FindElement(By.LinkText("Ficha Técnica")).Text);
            Assert.AreEqual("Garantías", driver.FindElement(By.LinkText("Garantías")).Text);
            Assert.AreEqual("Nuevos productos de esta marca", driver.FindElement(By.CssSelector("div.hidden-xs.single-product-detail > h3.section-title.ng-scope > b")).Text);
            Assert.AreEqual("Comparte:", driver.FindElement(By.CssSelector("span.text-information-zoom")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("button.btn-facebook")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn-facebook")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-twitter")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
            driver.FindElement(By.Id("btncartitem")).Click();
        }

        //[TestMethod]
        //public void Checkout()
        //{
        //    driver.Navigate().GoToUrl("https://juntoz.com/producto/magefesa-juego-de-ollas-antartida-aluminio-antiadherente-12-031817?ref=1&variationThumb=31817");
        //    driver.FindElement(By.Id("btnaccount")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.XPath("//div[@id='thumbnail-control-variation']/div/ul/li/a")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.Id("btnaccount")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.Id("btnaccount")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.Id("btnaccount")).Click();
        //    Thread.Sleep(100);
        //    driver.FindElement(By.Id("btncartitem")).Click();
        //    Thread.Sleep(500);
        //    //driver.FindElement(By.XPath("//h5/span[2]/span")).Click();
        //    Thread.Sleep(500);
        //    // driver.FindElement(By.CssSelector("button.close.exclude")).Click();
        //    Thread.Sleep(500);
        //    driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div[2]")).Click();
        //    driver.FindElement(By.Id("btncartitem")).Click();
        //    Thread.Sleep(500);
        //    IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
        //    jse.ExecuteScript("scroll(250, 0)");
        //    //driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
        //    driver.FindElement(By.Id("btncartitem")).Click();
            
        //    driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")).Click();
        //    driver.FindElement(By.Id("btncartitem")).Click();
        //    Thread.Sleep(500);
        //    driver.FindElement(By.LinkText("Iniciar Sesión")).Click();
        //    Thread.Sleep(500);
        //    driver.FindElement(By.Name("userEmail")).Clear();
        //    driver.FindElement(By.Name("userEmail")).SendKeys("denisse@ieholding.com");
        //    driver.FindElement(By.Name("password")).Clear();
        //    driver.FindElement(By.Name("password")).SendKeys("43445093");
        //    driver.FindElement(By.XPath("//input[@type='checkbox']")).Click();
        //    driver.FindElement(By.Id("btnLogin")).Click();
        //    Thread.Sleep(1000);
        //    jse.ExecuteScript("scroll(50, 0)");
        //    driver.FindElement(By.XPath("//div[@id='thumbnail-control-variation']/div/ul/li/a")).Click();
        //    driver.FindElement(By.Id("btncartitem")).Click();
        //    driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")).Click();
        //    driver.FindElement(By.Id("btncartitem")).Click();
        //    Thread.Sleep(500);
        //    Assert.AreEqual("Checkout", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/h1/small")).Text);
        //    Assert.AreEqual("Por favor ingresa la información solicitada para completar tu compra.", driver.FindElement(By.CssSelector("small.text-navy")).Text);
        //    Assert.AreEqual("1. Información de Contacto", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/h2/small")).Text);
        //    Assert.AreEqual("Datos del destinatario", driver.FindElement(By.CssSelector("h4")).Text);
        //    StringAssert.Equals("Nombres", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
        //    Assert.AreEqual("Marroquin", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[2]/div[2]/div/span[2]")).Text);
        //    Assert.AreEqual("Dirección:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[3]/div/label")).Text);
        //    Assert.AreEqual("Calles Los Olivos 215", driver.FindElement(By.CssSelector("div.col-md-9.no-padding-left > span.ng-binding")).Text);
        //    Assert.AreEqual("Teléfono:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[5]/div/label")).Text);
        //    Assert.AreEqual("992781330", driver.FindElement(By.CssSelector("div.text-darkgray.ng-binding")).Text);
        //    Assert.AreEqual("Cambiar la dirección de envío", driver.FindElement(By.CssSelector("h4.ng-scope")).Text);
        //    Assert.AreEqual("Calles Los Olivos 215", driver.FindElement(By.CssSelector("label > span.ng-binding")).Text);
        //    try
        //    {
        //        Assert.IsTrue(IsElementPresent(By.LinkText("Agregar nueva dirección de envío")));
        //    }
        //    catch (AssertFailedException e)
        //    {
        //        verificationErrors.Append(e.Message);
        //    }
        //    Assert.AreEqual("Agregar nueva dirección de envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[7]/div[2]/a/small")).Text);
        //    Assert.AreEqual("Datos de Facturación", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/h4[3]")).Text);
        //    Assert.AreEqual("Tipo:", driver.FindElement(By.CssSelector("div.col-md-4 > label.ng-scope")).Text);
        //    StringAssert.Equals("Boleta Factura", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select")).Text);
        //    Assert.AreEqual("2. Método de Pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/h2/small")).Text);
        //    Assert.AreEqual("Tarjeta de crédito o débito", driver.FindElement(By.CssSelector("b.ng-binding.ng-scope")).Text);
        //    Assert.AreEqual("Banca por internet, Agentes y Agencias", driver.FindElement(By.XPath("//label[@id='lb_pm2']/span/span[2]")).Text);
        //    Assert.AreEqual("Pago en bancos", driver.FindElement(By.CssSelector("#lb_pm3 > b.ng-scope")).Text);
        //    Assert.AreEqual("Pago contra entrega", driver.FindElement(By.CssSelector("#lb_pm4 > b.ng-binding.ng-scope")).Text);
        //    driver.FindElement(By.Name("payMethodOptionRadio")).Click();
        //    Assert.AreEqual("Nombre del titular", driver.FindElement(By.CssSelector("div.validation-section > div.row > div.col-md-12 > label")).Text);
        //    driver.FindElement(By.CssSelector("#lb_pm2 > input[name=\"payMethodOptionRadio\"]")).Click();
        //    Assert.AreEqual("Banca por Internet, Agentes y Agencias INTERBANK, BANBIF, BCP, BBVA y SCOTIABANK. WESTERN UNION (Pago de Servicios), KASNET y FULLCARGA.", driver.FindElement(By.CssSelector("p.text-darkgray.text-justify")).Text);
        //    try
        //    {
        //        Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Cómo funciona PagoEfectivo?")).Text, "^exact:¿Cómo funciona PagoEfectivo[\\s\\S]$"));
        //    }
        //    catch { };
        //        driver.FindElement(By.CssSelector("#lb_pm3 > input[name=\"payMethodOptionRadio\"]")).Click();
        //    Assert.AreEqual("Compra rápido, fácil y seguro, y paga en efectivo o vía internet en la red de agencias de nuestros bancos afiliados con SafetyPay", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div[3]/div/div/div/div/p")).Text);
        //    try
        //    {
        //        Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Qué es SafetyPay?")).Text, "^exact:¿Qué es SafetyPay[\\s\\S]$"));
        //    }
        //    catch { };
        //    driver.FindElement(By.CssSelector("#lb_pm4 > input[name=\"payMethodOptionRadio\"]")).Click();
        //    driver.FindElement(By.Id("lb_pm4")).Click();
        //    try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div[4]/div/div/div/div/div/p")).Text, "^exact:!Los envíos a centros de trabajo tienen 95% de entregas a tiempo! ¿Por qué no eliges la dirección de tu trabajo para la entrega[\\s\\S] Para este medio de pago, el monto de tu compra no debe exceder S/\\.2000 y el peso de los productos no debe exceder los 20 kg \\(peso volumétrico\\)\\. Si tu compra es de un monto superior, por favor, debes elegir entre los otros medios de pago que tenemos disponibles\\. Este método de pago está disponible sólo para ciudades principales\\.$"));
        //        Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Qué es... Pago contra entrega?")).Text, "^exact:¿Qué es\\.\\.\\. Pago contra entrega[\\s\\S]$"));
        //    }
        //    catch { };
        //        Assert.AreEqual("3. Resumen de orden", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/h2/small")).Text);
        //    Assert.AreEqual("Producto", driver.FindElement(By.CssSelector("th.text-center.ng-scope")).Text);
        //    Assert.AreEqual("Cantidad", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[2]")).Text);
        //    Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[3]")).Text);
        //    Assert.AreEqual("Subtotal", driver.FindElement(By.CssSelector("tfoot.chkout-table-footer > tr > td")).Text);
        //    Assert.AreEqual("Envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[3]/td[2]")).Text);
        //    Assert.AreEqual("Total", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[4]/td[2]")).Text);
        //    Assert.AreEqual("Tiempo de envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[5]/td[2]")).Text);
        //    Assert.AreEqual("Código de cupón:", driver.FindElement(By.CssSelector("div.row.ng-scope > div.col-md-12 > label.ng-scope")).Text);
        //    Assert.AreEqual("Comentarios:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div[5]/div/label")).Text);
        //    try
        //    {
        //        Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
        //    }
        //    catch (AssertFailedException e)
        //    {
        //        verificationErrors.Append(e.Message);
        //    }
        //    try
        //    {
        //        Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[9]")));
        //    }
        //    catch (AssertFailedException e)
        //    {
        //        verificationErrors.Append(e.Message);
        //    }
        //    Assert.AreEqual("Finalizar compra", driver.FindElement(By.XPath("(//button[@type='button'])[9]")).Text);
        //}

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
