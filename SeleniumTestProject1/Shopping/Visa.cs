using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Windows.Forms;
using System.Threading;
using System.Text.RegularExpressions;



namespace ShoppingVisa
{
    [TestClass]
    public class Visa
    {

        static IWebDriver driver;
        

        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driver = new FirefoxDriver();
         }


        [TestMethod]
        public void OrdenVisa()
        {
            driver.Navigate().GoToUrl("http://juntoz-qa.com/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Name("userEmail")).Clear();
            driver.FindElement(By.Name("userEmail")).SendKeys("silviamarroquin1402@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("denisse");
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).Clear();
            driver.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).SendKeys("wawitas");
            SendKeys.SendWait("{ENTER}");
            driver.Navigate().GoToUrl("http://juntoz-qa.com/catalogo?keywords=wawitas&allStore=true&specialPrice=false");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("img.img-responsive.catalog-products-body__product-img-big"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive.catalog-products-body__product-img-big")));
            driver.FindElement(By.CssSelector("img.img-responsive.catalog-products-body__product-img-big")).Click();
            driver.Navigate().GoToUrl("http://juntoz-qa.com/producto/wawitas-andador-musical-72w1120pb8-ros?ref=1&keywords=wawitas&variationThumb=71");
            Thread.Sleep(1000);
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
            Assert.AreEqual("Juguetes, Niños y Bebés", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/header/section/div[2]/ul/li/a/p")).Text);
            Assert.AreEqual("Ver Todo", driver.FindElement(By.LinkText("Ver Todo")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.ng-binding.ng-scope")));
            Assert.AreEqual("Juguetes, Niños y Bebés", driver.FindElement(By.CssSelector("a.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Bebés", driver.FindElement(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Coches para Bebés", driver.FindElement(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Wawitas", driver.FindElement(By.XPath("//a[contains(text(),'Wawitas')]")).Text);
            Assert.AreEqual("/ Wawitas- Andador Musical", driver.FindElement(By.CssSelector("span.name-product-breadcrumb.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.zoomWindow")));
            Assert.AreEqual("Wawitas- Andador Musical", driver.FindElement(By.CssSelector("h1.single-product-name.ng-binding")).Text);
            Assert.AreEqual("Por", driver.FindElement(By.CssSelector("div.single-product-brand-name.ng-scope > span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.single-product-brand-name.ng-scope > a.ng-binding")));
            Assert.AreEqual("Wawitas", driver.FindElement(By.CssSelector("div.single-product-brand-name.ng-scope > a.ng-binding")).Text);
            Assert.AreEqual("0 Calificaciones", driver.FindElement(By.CssSelector("div.single-product-rating > a > span.ng-binding")).Text);
            Assert.AreEqual("Vendido y enviado por", driver.FindElement(By.CssSelector("div.single-product-store > span")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("img.img-representative")).Text);
            Assert.AreEqual("S/ 240.00", driver.FindElement(By.CssSelector("strong.specialPriceProduct.ng-binding")).Text);
            Assert.AreEqual("Color:", driver.FindElement(By.CssSelector("span.variation-name.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='select-control-variation']/div/select")));
            StringAssert.Equals("SeleccionarCelesteRosadoVerde", driver.FindElement(By.XPath("//div[@id='select-control-variation']/div/select")).Text);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='select-control-variation']/div/select"))).SelectByText("Celeste");
            driver.FindElement(By.XPath("//option[2]")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("btn-append-to-to-body")));
            Assert.AreEqual("1", driver.FindElement(By.Id("btn-append-to-to-body")).Text);
            Assert.AreEqual("Especificaciones:", driver.FindElement(By.CssSelector("li.active > a > span")).Text);
            Assert.AreEqual("- Andador musical", driver.FindElement(By.CssSelector("li.ng-scope > span.ng-binding.ng-scope")).Text);
            Assert.AreEqual("- estilo pianito", driver.FindElement(By.XPath("//div[@id='home']/ul/li[2]/span")).Text);
            Assert.AreEqual("- Tiene una bandeja de juegos", driver.FindElement(By.XPath("//div[@id='home']/ul/li[3]/span")).Text);
            Assert.AreEqual("- Ocho ruedas giratorias de silicona", driver.FindElement(By.XPath("//div[@id='home']/ul/li[4]/span")).Text);
            Assert.AreEqual("- Asiento acolchado y graduable", driver.FindElement(By.XPath("//div[@id='home']/ul/li[5]/span")).Text);
            Assert.AreEqual("- Plegable", driver.FindElement(By.XPath("//div[@id='home']/ul/li[6]/span")).Text);
            Assert.AreEqual("- Tres niveles de altura", driver.FindElement(By.XPath("//div[@id='home']/ul/li[7]/span")).Text);
            Assert.AreEqual("- Para edades entre 6 meses a 18 meses", driver.FindElement(By.XPath("//div[@id='home']/ul/li[8]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.view-more-description")));
            Assert.AreEqual("Ver más", driver.FindElement(By.CssSelector("a.view-more-description")).Text);
            Assert.AreEqual("Comparte:", driver.FindElement(By.CssSelector("span.text-information-zoom")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn-facebook")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-twitter")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("button.btn-facebook")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-twitter")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.panel-body")));

            try
                {
                    if (IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")))
                        try
                        {
                            driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
                            driver.FindElement(By.XPath("//li[2]/button")).Click();

                        }
                        catch (Exception)
                        { }
                    Thread.Sleep(1000);
                }
                catch (AssertFailedException) { }
            
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250, 0)");

            driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
            driver.FindElement(By.XPath("//li[2]/button")).Click();
            driver.FindElement(By.Id("btncartitem")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.popover-cart-header__content.ng-scope"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            Assert.IsTrue(IsElementPresent(By.CssSelector("div.popover-cart-header__content.ng-scope")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("b > i.fa.fa-shopping-cart")));
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("b > span.ng-binding")).Text);
            Assert.AreEqual("en tu carrito", driver.FindElement(By.CssSelector("h3 > a > span.ng-scope")).Text);
            Assert.AreEqual("Wawitas- Andador Musical", driver.FindElement(By.CssSelector("span.item-name.col-md-10 > a.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
            Assert.AreEqual("S/ 240.00", driver.FindElement(By.CssSelector("h5.product-price > span.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[6]")));
            Assert.AreEqual("1", driver.FindElement(By.XPath("(//button[@type='button'])[6]")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tbody/tr/td[2]/h5/span[2]/span")));
            Assert.AreEqual("Subtotal:", driver.FindElement(By.CssSelector("span > b")).Text);
            Assert.AreEqual("S/ 240.00", driver.FindElement(By.CssSelector("span.subtotal-amount.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")));
            Assert.AreEqual("Comprar todo", driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")).Text);
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")).Click();
            driver.FindElement(By.Id("btncartitem")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Checkout", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/h1/small")).Text);
            Assert.AreEqual("Por favor, ingresa la información solicitada para completar su compra", driver.FindElement(By.CssSelector("small.text-navy.ng-scope")).Text);
            driver.FindElement(By.Id("btncartitem")).Click();
            Assert.AreEqual("1. Información de Contacto", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/h2/small")).Text);
            Assert.AreEqual("Datos del destinatario", driver.FindElement(By.CssSelector("h4")).Text);
            //Modificar; 
            StringAssert.Equals("Nombres", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Silvia", driver.FindElement(By.XPath("//div[2]/div[2]/div/span")).Text);
            Assert.AreEqual("Alcalde", driver.FindElement(By.XPath("//div[2]/div/span[2]")).Text);

            Assert.AreEqual("Dirección:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[3]/div/label")).Text);
            Assert.AreEqual("los fresnos 324", driver.FindElement(By.CssSelector("div.col-md-9.no-padding-left > span.ng-binding")).Text);
            Assert.AreEqual("Teléfono:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[5]/div/label")).Text);
            Assert.AreEqual("992485140", driver.FindElement(By.CssSelector("div.text-darkgray.ng-binding")).Text);
            Assert.AreEqual("Cambiar la dirección de envío", driver.FindElement(By.CssSelector("h4.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("otheraddresscheckout")));
            Assert.AreEqual("Javier prado", driver.FindElement(By.CssSelector("label > small.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[7]/div[2]/a/small")));
            Assert.AreEqual("Agregar nueva dirección de envío", driver.FindElement(By.LinkText("Agregar nueva dirección de envío")).Text);
            Assert.AreEqual("Datos de Facturación", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/h4[3]")).Text);
            Assert.AreEqual("Tipo:", driver.FindElement(By.CssSelector("div.col-md-4 > label.ng-scope")).Text);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select")));
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select")).Text);
            Assert.AreEqual("2. Método de Pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/h2/small")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("payMethodOptionRadio")));
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("b.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("#lb_pm2 > input[name=\"payMethodOptionRadio\"]")));
            Assert.AreEqual("Banca por internet, Agentes y Agencias", driver.FindElement(By.XPath("//label[@id='lb_pm2']/span/span[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("#lb_pm3 > input[name=\"payMethodOptionRadio\"]")));
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-banks.bank-bcp")).Text);
            Assert.AreEqual("Pago en bancos", driver.FindElement(By.CssSelector("#lb_pm3 > b.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("#lb_pm4 > input[name=\"payMethodOptionRadio\"]")));
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.CssSelector("#lb_pm4 > b.ng-binding.ng-scope")).Text);
            driver.FindElement(By.Name("payMethodOptionRadio")).Click();
            Assert.AreEqual("Nombre del titular", driver.FindElement(By.CssSelector("div.validation-section > div.row > div.col-md-12 > label")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[19]")));
            // Modificar
            driver.FindElement(By.XPath("(//input[@type='text'])[19]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[19]")).SendKeys("Silvia Alcalde");
            Assert.AreEqual("Número de tarjeta", driver.FindElement(By.CssSelector("div.validation-section > div.row > div.col-md-12 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[20]")));
            //Modificar
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("1274582412459874");
            Assert.AreEqual("Soporta Visa, MasterCard y American Express.", driver.FindElement(By.CssSelector("div.col-md-12 > small")).Text);
            Assert.AreEqual("Monto mínimo de compra: S/ 10.00", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[3]/div/small[2]")).Text);
            Assert.AreEqual("Fecha de vecimiento", driver.FindElement(By.CssSelector("div.col-md-9 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div/select")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div[3]/select")));
            Assert.AreEqual("CVV", driver.FindElement(By.CssSelector("div.row.vertical > div.col-md-3 > label")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[22]")));
            StringAssert.Equals("EneroFebreroMarzoAbrilMayoJunioJulioAgostoSeptiembreOctubreNoviembreDiciembre", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div/select")).Text);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div/select"))).SelectByText("Julio");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div[3]/select"))).SelectByText("2021");
            driver.FindElement(By.XPath("(//input[@type='text'])[22]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[22]")).SendKeys("245");
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.text-maroon > small.ng-scope")));
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("a.text-maroon > small.ng-scope")).Text, "^exact:¿Qué es esto[\\s\\S]$")); } catch (AssertFailedException) { }
            Assert.AreEqual("Guardar esta tarjeta para mis próximas compras", driver.FindElement(By.CssSelector("label > span.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//input[@type='checkbox']")));
            driver.FindElement(By.XPath("(//input[@type='text'])[20]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[20]")).SendKeys("4380039943528067");
            Assert.IsTrue(IsElementPresent(By.CssSelector("input.eagleCardValidator.visa")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            Assert.AreEqual("Finalizar compra", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("3. Resumen de orden", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/h2/small")).Text);
            Assert.AreEqual("Producto", driver.FindElement(By.CssSelector("th.text-center.ng-scope")).Text);
            Assert.AreEqual("Cantidad", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[3]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("td.text-darkgray.text-center > span.ng-binding")).Text);
            StringAssert.Equals("S/.240.00", driver.FindElement(By.XPath("//tr[@id='item_72']/td[3]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.close")));
            Assert.AreEqual("Subtotal", driver.FindElement(By.CssSelector("tfoot.chkout-table-footer > tr > td")).Text);
            Assert.AreEqual("(1 Productos)", driver.FindElement(By.CssSelector("tfoot.chkout-table-footer > tr > td.text-right.ng-binding")).Text);
            Assert.AreEqual("S/ 240.00", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr/td[3]")).Text);
            Assert.AreEqual("Envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[3]/td[2]")).Text);
            Assert.AreEqual("S/ 19.82", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[3]/td[3]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[4]/td[2]")).Text);
            Assert.AreEqual("S/ 259.82", driver.FindElement(By.CssSelector("td.text-right > b.ng-binding")).Text);
            Assert.AreEqual("Tiempo de envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[5]/td[2]")).Text);
            Assert.AreEqual("6 días utiles", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[5]/td[3]")).Text);
            Assert.AreEqual("Código de cupón:", driver.FindElement(By.CssSelector("div.padding-left-20.text-navy > div.row > div.col-md-12 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("name")));
            Assert.AreEqual("Comentarios:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div[5]/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("comentarios")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[11]")));

            Assert.AreEqual("Finalizar compra", driver.FindElement(By.XPath("(//button[@type='button'])[11]")).Text);
            //Modificar
            driver.FindElement(By.Name("comentarios")).Clear();
            driver.FindElement(By.Name("comentarios")).SendKeys("Test");
            driver.FindElement(By.XPath("(//button[@type='button'])[11]")).Click();
            Thread.Sleep(3000);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("h1.text-center.chk-title > b"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.media-body.chk-item > p"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            Assert.IsTrue(IsElementPresent(By.XPath("//body/div[5]/div[2]/div")));
            StringAssert.Equals("Wawitas", driver.FindElement(By.CssSelector("h4.media-heading.ng-binding")).Text);
            Assert.AreEqual("Wawitas- Andador Musical", driver.FindElement(By.CssSelector("b.ng-binding")).Text);
            Assert.AreEqual("S/ 240", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div[3]/div/div/div/div/div/div/div[2]/p[2]/b")).Text);
            Assert.AreEqual("Cantidad: 1", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div[3]/div/div/div/div/div/div/div[2]/p[3]")).Text);
            Assert.AreEqual("Costos de envío: S/ 19.82", driver.FindElement(By.CssSelector("h4.total-amount")).Text);
            Assert.AreEqual("Total facturado: S/ 259.82", driver.FindElement(By.CssSelector("h3.total-amount.no-margin-top")).Text);
            Assert.AreEqual("Te enviaremos un email de confirmación", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div[3]/div/div/div[2]/h4[2]")).Text);
        }
        [TestMethod]
        public void ValidarOrden()
        {
            driver.Navigate().GoToUrl("http://juntoz-qa.com/");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("userEmail")).Clear();
            driver.FindElement(By.Name("userEmail")).SendKeys("silviamarroquin1402@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("denisse");
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            StringAssert.Equals("Mi Carrito", driver.FindElement(By.Id("btncartitem")).Text);
            driver.FindElement(By.Id("btnaccount")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("logoutForm")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Mis Órdenes")));
            driver.FindElement(By.LinkText("Mis Órdenes")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(3000);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("div.tab-content"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            StringAssert.Equals("Mi cuenta", driver.FindElement(By.CssSelector("b.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Resumen")));
            Assert.AreEqual("Resumen", driver.FindElement(By.LinkText("Resumen")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Ajustes de cuenta")));
                StringAssert.Equals("Ajustes de cuenta", driver.FindElement(By.LinkText("Ajustes de cuenta")).Text);
            }
            catch (AssertFailedException) { }
            try {
                Assert.IsTrue(IsElementPresent(By.LinkText("Administrar direcciones")));
                Assert.AreEqual("Administrar direcciones", driver.FindElement(By.LinkText("Administrar direcciones")).Text);
            }catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Mis órdenes")));
                Assert.AreEqual("Mis órdenes", driver.FindElement(By.LinkText("Mis órdenes")).Text);
             }catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Cupón")));
                Assert.AreEqual("Cupón", driver.FindElement(By.LinkText("Cupón")).Text);
            }catch (AssertFailedException) { }
            Assert.AreEqual("Mis órdenes", driver.FindElement(By.CssSelector("h3.text-navy.text-bold")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[7]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select")));
            StringAssert.Equals("Última semana Últimos 15 días Último mes", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select[2]")));
            StringAssert.Equals("Todas las Órdenes Órdenes completadasÓrdenes abiertasÓrdenes canceladas", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.bg-navy")));
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.bg-navy")).Text);
            Assert.AreEqual("Órdenes de juntoz", driver.FindElement(By.LinkText("Órdenes de juntoz")).Text);
            Assert.AreEqual("# de orden", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[2]")).Text);
            Assert.AreEqual("Fecha", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[3]")).Text);
            Assert.AreEqual("Sub total", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[4]")).Text);
            Assert.AreEqual("Costo de envío", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[5]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[6]")).Text);
            Assert.AreEqual("S/ 240.00", driver.FindElement(By.CssSelector("td.text-right.ng-binding")).Text);
            Assert.AreEqual("S/ 19.82", driver.FindElement(By.XPath("//table[@id='accordion']/tbody[3]/tr/td[5]")).Text);
            Assert.AreEqual("S/ 259.82", driver.FindElement(By.XPath("//table[@id='accordion']/tbody[3]/tr/td[6]")).Text);
            Assert.AreEqual("Órdenes de White Label", driver.FindElement(By.LinkText("Órdenes de White Label")).Text);
            Assert.AreEqual("# de orden", driver.FindElement(By.XPath("(//table[@id='accordion']/thead/tr/th[2])[2]")).Text);
            Assert.AreEqual("Fecha", driver.FindElement(By.XPath("(//table[@id='accordion']/thead/tr/th[3])[2]")).Text);
            Assert.AreEqual("Sub total", driver.FindElement(By.XPath("(//table[@id='accordion']/thead/tr/th[4])[2]")).Text);
            Assert.AreEqual("Costo de envío", driver.FindElement(By.XPath("(//table[@id='accordion']/thead/tr/th[5])[2]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("(//table[@id='accordion']/thead/tr/th[6])[2]")).Text);
            //Numero de la orden : INGRESAR
            driver.FindElement(By.Id("160928193803")).Click();
            Thread.Sleep(500);
            Assert.AreEqual("Pedidos por Orden", driver.FindElement(By.CssSelector("h4")).Text);
            StringAssert.Equals("# de orden", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/thead/tr/th")).Text);
            StringAssert.Equals("Tienda", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/thead/tr/th[2]")).Text);
            StringAssert.Equals("Status", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/thead/tr/th[3]")).Text);
            StringAssert.Equals("Total", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/thead/tr/th[4]")).Text);
            StringAssert.Equals("Opciones", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/thead/tr/th[5]")).Text);
            //modificar orden
            Assert.AreEqual("160928193803-001", driver.FindElement(By.CssSelector("tr.ng-scope > td.text-center.ng-binding")).Text);
            StringAssert.Equals("Wawitas", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/tbody/tr/td[2]")).Text);
            StringAssert.Equals("Nuevo", driver.FindElement(By.XPath("//tr[@id='c160926213709']/td/table/tbody/tr/td[3]/span")).Text);
            Assert.AreEqual("S/. 259.82", driver.FindElement(By.CssSelector("tr.ng-scope > td.text-right.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-eye")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-times")));
            driver.FindElement(By.CssSelector("i.fa.fa-eye")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Orden N°: 160928193803", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div/h3")).Text);
           
            Assert.AreEqual("Pedido", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li/div/div/span[2]")).Text);
            Assert.AreEqual("Recibido", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[2]/div/div/span[2]")).Text);
            Assert.AreEqual("Confirmado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[3]/div/div/span[2]")).Text);
            StringAssert.Equals("Pedido en\n Camino", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[4]/div/div")).Text);
            Assert.AreEqual("Pedido", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[5]/div/div/span")).Text);
            Assert.AreEqual("Cerrado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[6]/div/div/span[2]")).Text);
            Assert.AreEqual("Cancelado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[2]/div/ol/li[7]/div/div/span[2]")).Text);
            Assert.AreEqual("Artículos de la orden", driver.FindElement(By.CssSelector("li > div.list-category-left-bar > span.parent-category-filters > b")).Text);
            Assert.AreEqual("Artículo 1", driver.FindElement(By.CssSelector("th > div.ng-binding")).Text);
            Assert.AreEqual("SKU", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Cantidad", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[3]")).Text);
            Assert.AreEqual("Precio unitario", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[4]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[5]")).Text);
            Assert.AreEqual("Estado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[6]")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Wawitas- Andador Musical - Color : Celeste")));
            Assert.AreEqual("Wawitas- Andador Musical - Color : Celeste", driver.FindElement(By.LinkText("Wawitas- Andador Musical - Color : Celeste")).Text);
            Assert.AreEqual("W1120PB8-cel", driver.FindElement(By.CssSelector("td.text-center.ng-binding")).Text);
            Assert.AreEqual("1", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[4]")).Text);
            Assert.AreEqual("S/. 240.00", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[5]")).Text);
            Assert.AreEqual("S/. 240.00", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[6]")).Text);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[7]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[8]/button")));
            Assert.AreEqual("Descuento: S/. 0.00", driver.FindElement(By.CssSelector("div.col-md-12.text-right > h5")).Text);
            Assert.AreEqual("S/. 19.82", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div[2]/div/h5[2]/span")).Text);
            Assert.AreEqual("Subtotal (1) artículos: S/. 259.82", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div[2]/div/h4")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Regresar a Mis Órdenes")));
                Assert.AreEqual("Regresar a Mis Órdenes", driver.FindElement(By.LinkText("Regresar a Mis Órdenes")).Text);
            }
            catch (AssertFailedException) { }
            Assert.AreEqual("Dirección de envío", driver.FindElement(By.CssSelector("div.col-md-6 > ul.category-list.list-unstyled > li > div.list-category-left-bar > span.parent-category-filters > b")).Text);
            Assert.AreEqual("Silvia Alcalde", driver.FindElement(By.CssSelector("b.ng-binding")).Text);
            Assert.AreEqual("los fresnos 324", driver.FindElement(By.CssSelector("li.padding-left-10.ng-binding")).Text);
            Assert.AreEqual("992485140", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/div/div/ul/li/div/ul/li[4]")).Text);
            Assert.AreEqual("Método de pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/div/div[2]/ul/li/div/span/b")).Text);
            Assert.AreEqual("VISA", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/div/div[2]/ul/li/div/ul/li")).Text);

            
        }
        [TestMethod]
        public void EstadosOrden()
        {

            // open first page in first tab
            string firstPageUrl = "http://juntoz-qa.com/";
            driver.Navigate().GoToUrl(firstPageUrl);

            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Name("userEmail")).Clear();
            driver.FindElement(By.Name("userEmail")).SendKeys("silviamarroquin1402@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("denisse");
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.LinkText("Mis Órdenes")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(3000);
            //Modificar Orden
            driver.FindElement(By.Id("160928193803")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("i.fa.fa-eye")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//td[7]/span")).Text);
        
            string firstTabHandle = driver.CurrentWindowHandle;
            Actions action = new Actions(driver);
            action.SendKeys(OpenQA.Selenium.Keys.Control + "t").Build().Perform();
            string secondTabHandle = driver.CurrentWindowHandle;
            driver.SwitchTo().Window(secondTabHandle);


            string secondPageUrl = "http://juntoz-web-login-qa.azurewebsites.net/";
            driver.Navigate().GoToUrl(secondPageUrl);
            driver.Navigate().GoToUrl("http://juntoz-web-login-qa.azurewebsites.net/auth/login?client_id=a2912434ae844eb48be398d5bfa77c3806c7a1bcc1bf44ee8acd8cdbf7e1d5e3&formView=login&returnUrl=http://juntoz-web-admin-qa.azurewebsites.net&actionName=");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("denisse@ieholding.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("denissita");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();

            driver.FindElement(By.XPath("//section/ul/li[4]/a/span")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("ul.treeview-menu.menu-open > li > a > span.ng-scope"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            driver.FindElement(By.CssSelector("ul.treeview-menu.menu-open > li > a > span.ng-scope")).Click();
            driver.Navigate().GoToUrl("http://juntoz-web-admin-qa.azurewebsites.net/#/orders");
          
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("i.fa.fa-cubes"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("h3.box-title > span"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }
            Thread.Sleep(5000);
            Assert.IsTrue(IsElementPresent(By.CssSelector("h3.box-title > span")));
            Assert.AreEqual("Ordenes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            driver.FindElement(By.XPath("//input[@type='text']")).Clear();
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("160928193803");
            SendKeys.SendWait("{ENTER}");
            driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();
            Thread.Sleep(15000);
            driver.FindElement(By.Id("160928193803")).Click();
            driver.FindElement(By.LinkText("160928193803-001")).Click();
            Thread.Sleep(10000);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='right-sidebar']/div/div[2]/div/div")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.content")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.sa-header-options.pull-right > button.btn.btn-primary")));
            Assert.AreEqual("Confirmar Order", driver.FindElement(By.CssSelector("div.sa-header-options.pull-right > button.btn.btn-primary")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='submit'])[10]")));
            Assert.AreEqual("Cancelar Order", driver.FindElement(By.XPath("(//button[@type='submit'])[10]")).Text);
            Thread.Sleep(2000);
            //Assert.AreEqual("Confirmar Order", driver.FindElement(By.CssSelector("div.sa-header-options.pull-right > button.btn.btn-primary")).Text);
            //driver.FindElement(By.CssSelector("div.sa-header-options.pull-right > button.btn.btn-primary")).Click();

            action.SendKeys(OpenQA.Selenium.Keys.Control + "2").Build().Perform();
            driver.SwitchTo().Window(secondTabHandle);
            Thread.Sleep(1000);
            driver.Navigate().Refresh();
            //Assert.AreEqual("Confirmado", driver.FindElement(By.XPath("//td[7]/span")).Text);
            action.SendKeys(OpenQA.Selenium.Keys.Control + "1").Build().Perform();



        }
        [TestMethod]
        public void CancelarOrden()
        {
            driver.Navigate().GoToUrl("http://juntoz-qa.com/");

            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Name("userEmail")).Clear();
            driver.FindElement(By.Name("userEmail")).SendKeys("silviamarroquin1402@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("denisse");
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.LinkText("Mis Órdenes")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(3000);
            //Modificar Orden
            driver.FindElement(By.Id("160928193803")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.CssSelector("i.fa.fa-eye")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//td[7]/span")).Text);

            Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.bg-navy")));
            Assert.AreEqual("Cancelar orden", driver.FindElement(By.CssSelector("button.btn.bg-navy")).Text);
            driver.FindElement(By.CssSelector("button.btn.bg-navy")).Click();
            Assert.IsTrue(IsElementPresent(By.CssSelector("h3.modal-title.ng-binding")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("h3.modal-title.ng-binding")));
            Assert.AreEqual("Cancelar orden", driver.FindElement(By.CssSelector("h3.modal-title.ng-binding")).Text);
            Assert.AreEqual("Lamentamos tu decisión.", driver.FindElement(By.CssSelector("small")).Text);
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("h4 > small")).Text, "^exact:¿Cuál es el motivo de tu cancelación[\\s\\S]$")); } catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.XPath("//select")));
            StringAssert.Equals("Cambio de direcciónNo podré esperar el tiempo de entregaCambio de productoYa no tengo dinero para pagarLo encontré mas barato en otra tiendaTengo un cupón de descuentoCambiar método de pagoLo compre en otra tiendaQuiero aprovechar promoción vigenteNo reconozco la compra realizada", driver.FindElement(By.XPath("//select")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[3]/button")));
            Assert.AreEqual("Cerrar", driver.FindElement(By.XPath("//div[3]/button")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.close")));
            Assert.AreEqual("x", driver.FindElement(By.CssSelector("button.close")).Text);
            new SelectElement(driver.FindElement(By.XPath("//select"))).SelectByText("Cambio de dirección");
            Assert.IsTrue(IsElementPresent(By.XPath("//div[3]/button[2]")));
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//div[3]/button[2]")).Text);
            driver.FindElement(By.XPath("//div[3]/button[2]")).Click();
            Assert.AreEqual("Cancelado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[7]/span")).Text);
            driver.Navigate().Refresh();
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
        public bool TryFindElement(By by,  IWebElement element)
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
