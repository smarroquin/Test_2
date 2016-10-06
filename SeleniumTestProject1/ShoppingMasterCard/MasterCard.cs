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
            driver.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).SendKeys("bata");
            SendKeys.SendWait("{ENTER}");
            driver.Navigate().GoToUrl("http://juntoz-qa.com/catalogo?keywords=bata&allStore=true&specialPrice=false");
            Thread.Sleep(1000);
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
            driver.Navigate().GoToUrl("http://juntoz-qa.com/producto/zapatos-casual-para-hombre-bata-127853-7885-40?ref=1&keywords=bata&variationThumb=823");
            Thread.Sleep(1000);
            
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.ng-binding.ng-scope")));
            Assert.AreEqual("Moda", driver.FindElement(By.CssSelector("a.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")));
            Assert.AreEqual("Moda Hombre", driver.FindElement(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Calzado Hombre")));
            Assert.AreEqual("Calzado Hombre", driver.FindElement(By.LinkText("Calzado Hombre")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Zapatillas Casual Hombre")));
            Assert.AreEqual("Zapatillas Casual Hombre", driver.FindElement(By.LinkText("Zapatillas Casual Hombre")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//a[contains(text(),'Bata')]")));
            Assert.AreEqual("Bata", driver.FindElement(By.XPath("//a[contains(text(),'Bata')]")).Text);
            Assert.AreEqual("/ Zapatos Casual para Hombre Bata", driver.FindElement(By.CssSelector("span.name-product-breadcrumb.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__2.jpg_2b5549f9a77e486985bb5993755cf5ca.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__5.jpg_f84e3afc59fd4312acd1c9ea141f1dd8.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__3.jpg_d520721eddb242a091fd4a0a45bfdfca.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__4.jpg_425c92cc7f6e44ae9562ef9ec2fbbec3.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__7.jpg_b54ce6f9d6e44fcabcdc005687fa074e.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.zoomWindow")));
            Assert.AreEqual("Zapatos Casual para Hombre Bata", driver.FindElement(By.CssSelector("h1.single-product-name.ng-binding")).Text);
            Assert.AreEqual("S/ 159.90", driver.FindElement(By.CssSelector("strong.specialPriceProduct.ng-binding")).Text);
            Assert.AreEqual("Color: Khaki", driver.FindElement(By.CssSelector("span.variation-name.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/853-7885-40.__2.jpg_c55bb5fd6191452eab745fea173f5dd3.png')]")));
            Assert.AreEqual("Talla:", driver.FindElement(By.XPath("//div[@id='select-control-variation']/div/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='select-control-variation']/div/select")));
            StringAssert.Equals("Seleccionar3940414243", driver.FindElement(By.XPath("//div[@id='select-control-variation']/div/select")).Text);
            driver.FindElement(By.XPath("//div[@id='thumbnail-control-variation']/div/ul/li[2]/a")).Click();
            new SelectElement(driver.FindElement(By.XPath("//div[@id='select-control-variation']/div/select"))).SelectByText("41");
            driver.FindElement(By.XPath("//option[4]")).Click();
            Assert.AreEqual("Especificaciones:", driver.FindElement(By.CssSelector("li.active > a > span")).Text);
            Assert.AreEqual("- Modelo: Mark.", driver.FindElement(By.CssSelector("li.ng-scope > span.ng-binding.ng-scope")).Text);
            Assert.AreEqual("- Estilo: Casual.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[3]/span")).Text);
            Assert.AreEqual("- Materiales Exterior: Capellada de Cuero con Cordones.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[4]/span")).Text);
            Assert.AreEqual("- Material Interiror: Forro de Cuero.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[5]/span")).Text);
            Assert.AreEqual("- Material Suela: Tpr.", driver.FindElement(By.XPath("//div[@id='home']/ul/li[6]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.view-more-description")));
            Assert.AreEqual("Ver más", driver.FindElement(By.CssSelector("a.view-more-description")).Text);
            Assert.AreEqual("Comparte:", driver.FindElement(By.CssSelector("span.text-information-zoom")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn-facebook")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-twitter")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")));
            Assert.AreEqual("Comprar", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Text);


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
            driver.FindElement(By.Id("btncartitem")).Click();
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.popover-cart-header__content.ng-scope")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("b > i.fa.fa-shopping-cart")));
            
            Assert.AreEqual("1 items en tu carrito", driver.FindElement(By.CssSelector("h3")).Text);
            Assert.AreEqual("Zapatos Casual para Hombre Bata", driver.FindElement(By.CssSelector("span.item-name.col-md-10 > a.ng-binding")).Text);
            driver.FindElement(By.Id("btncartitem")).Click();
            Assert.AreEqual("S/ 159.90", driver.FindElement(By.CssSelector("h5.product-price > span.ng-binding")).Text);
            driver.FindElement(By.CssSelector("span.subtotal-amount.ng-binding")).Click();
            
            Assert.AreEqual("S/ 159.90", driver.FindElement(By.CssSelector("span.subtotal-amount.ng-binding")).Text);
            //INGRESAR SEGUNDO PRODUCTO
            driver.FindElement(By.XPath("(//a[contains(text(),'Moda')])[4]")).Click();
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("http://juntoz-qa.com/categorias/moda");
            Thread.Sleep(10000);
            jse.ExecuteScript("scroll(0, 150)");
            Assert.IsTrue(IsElementPresent(By.XPath("//img[@alt='Thaya 925 - Collar Sea Star']")));
            driver.FindElement(By.XPath("//img[@alt='Thaya 925 - Collar Sea Star']")).Click();
            Thread.Sleep(2000);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.ng-binding.ng-scope")));
            Assert.AreEqual("Moda", driver.FindElement(By.CssSelector("a.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")));
            Assert.AreEqual("Moda Mujer", driver.FindElement(By.CssSelector("span.ng-scope > breadcrumb.ng-isolate-scope > a.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Joyería Mujer")));
            Assert.AreEqual("Joyería Mujer", driver.FindElement(By.LinkText("Joyería Mujer")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Collares Mujer")));
            Assert.AreEqual("Collares Mujer", driver.FindElement(By.LinkText("Collares Mujer")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Thaya 925")));
            Assert.AreEqual("Thaya 925", driver.FindElement(By.LinkText("Thaya 925")).Text);
            Assert.AreEqual("/ Thaya 925 - Collar Sea Star", driver.FindElement(By.CssSelector("span.name-product-breadcrumb.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/26960579_696792bf656b4aa98b83cfca2034e91b.png?w=40&h=40')]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//img[contains(@src,'https://juntozqa.blob.core.windows.net/blobs/26960579__2.jpeg_b5dcecfd679644dab8531129f689fae6.png?w=40&h=40')]")));
            Assert.AreEqual("Thaya 925 - Collar Sea Star", driver.FindElement(By.CssSelector("h1.single-product-name.ng-binding")).Text);
            Assert.AreEqual("S/ 95.00", driver.FindElement(By.CssSelector("strong.specialPriceProduct.ng-binding")).Text);
            Assert.AreEqual("Color: Plata", driver.FindElement(By.CssSelector("span.variation-name.ng-binding")).Text);
            Assert.IsTrue(IsElementPresent(By.Id("btn-append-to-to-body")));
            Assert.AreEqual("1", driver.FindElement(By.Id("btn-append-to-to-body")).Text);
            Assert.AreEqual("Especificaciones:", driver.FindElement(By.CssSelector("li.active > a > span")).Text);
            Assert.AreEqual("- Elaborado en plata de Ley 925", driver.FindElement(By.CssSelector("li.ng-scope > span.ng-binding.ng-scope")).Text);
            Assert.AreEqual("- Acabado satinado", driver.FindElement(By.XPath("//div[@id='home']/ul/li[2]/span")).Text);
            Assert.AreEqual("- Entregado en caja de regalo", driver.FindElement(By.XPath("//div[@id='home']/ul/li[3]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.view-more-description")));
            Assert.AreEqual("Ver más", driver.FindElement(By.CssSelector("a.view-more-description")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.panel-body")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")));
            Assert.AreEqual("Comprar", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Text);
            driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div[2]/div/div[3]/div[2]/div/div/div/button")).Click();
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
                Thread.Sleep(2000);
            }
            StringAssert.Equals("2 Mi Carrito", driver.FindElement(By.Id("btncartitem")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.popover-cart-header__content.ng-scope")));
            driver.FindElement(By.Id("btncartitem")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("2 items en tu carrito", driver.FindElement(By.CssSelector("h3")).Text);
            StringAssert.Equals("Zapatos Casual para Hombre Bata", driver.FindElement(By.LinkText("Zapatos Casual para Hombre Bata")).Text);
            StringAssert.Equals("Thaya 925 - Collar Sea Star", driver.FindElement(By.LinkText("Thaya 925 - Collar Sea Star")).Text);
            Assert.AreEqual("S/ 254.90", driver.FindElement(By.CssSelector("span.subtotal-amount.ng-binding")).Text);
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/table/tfoot/tr/td/button")).Click();
            driver.FindElement(By.Id("btncartitem")).Click();
            driver.FindElement(By.Id("btncartitem")).Click();
            Thread.Sleep(3000);
            Assert.AreEqual("Checkout", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/h1/small")).Text);
            Assert.AreEqual("Por favor ingresa la información solicitada para completar tu compra.", driver.FindElement(By.CssSelector("small.text-navy")).Text);
            Assert.AreEqual("1. Información de Contacto", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/h2/small")).Text);
            Assert.AreEqual("Datos del destinatario", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Nombres", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Silvia", driver.FindElement(By.CssSelector("div.text-darkgray > span.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Alcalde", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[2]/div[2]/div/span[2]")).Text);
            Assert.AreEqual("Dirección:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[3]/div/label")).Text);
            Assert.AreEqual("los fresnos 324", driver.FindElement(By.CssSelector("div.col-md-9.no-padding-left > span.ng-binding")).Text);
            Assert.AreEqual("Javier prado", driver.FindElement(By.CssSelector("small.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Teléfono:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[5]/div/label")).Text);
            Assert.AreEqual("992485140", driver.FindElement(By.CssSelector("div.text-darkgray.ng-binding")).Text);
            Assert.AreEqual("Cambiar la dirección de envío", driver.FindElement(By.CssSelector("h4.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("otheraddresscheckout")));
            Assert.AreEqual("Javier prado", driver.FindElement(By.CssSelector("label > small.ng-binding.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[7]/div[2]/a/small")));
            Assert.AreEqual("Datos de Facturación", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/h4[3]")).Text);
            Assert.AreEqual("Tipo:", driver.FindElement(By.CssSelector("div.col-md-4 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select")));
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select")).Text);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select"))).SelectByText("Factura");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select"))).SelectByText("Factura");
            Assert.AreEqual("RUC:", driver.FindElement(By.CssSelector("div.col-md-12 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[11]")));
            Assert.AreEqual("Razon Social:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[9]/div[4]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[12]")));
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select"))).SelectByText("Boleta");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div/div/div[2]/div[8]/div/div/select"))).SelectByText("Boleta");
            Assert.AreEqual("2. Método de Pago", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/h2/small")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("b.ng-binding.ng-scope")).Text);
            Assert.AreEqual("Banca por internet, Agentes y Agencias", driver.FindElement(By.XPath("//label[@id='lb_pm2']/span/span[2]")).Text);
            Assert.AreEqual("Pago en bancos", driver.FindElement(By.CssSelector("#lb_pm3 > b.ng-scope")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.CssSelector("#lb_pm4 > b.ng-binding.ng-scope")).Text);
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.Name("payMethodOptionRadio")).Click();
            driver.FindElement(By.Name("payMethodOptionRadio")).Click();
            Assert.AreEqual("Nombre del titular", driver.FindElement(By.CssSelector("div.validation-section > div.row > div.col-md-12 > label")).Text);
            Assert.AreEqual("Silvia Alcalde", driver.FindElement(By.XPath("(//input[@type='text'])[13]")).GetAttribute("value"));
            Assert.AreEqual("Número de tarjeta", driver.FindElement(By.CssSelector("div.validation-section > div.row > div.col-md-12 > label.ng-scope")).Text);
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5650923980980705");
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5650923980980705");
            Assert.AreEqual("Fecha de vecimiento", driver.FindElement(By.CssSelector("div.col-md-9 > label.ng-scope")).Text);
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5770124587542456");
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5770124587542456");
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5965944367265387");
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).Clear();
            driver.FindElement(By.CssSelector("input.eagleCardValidator")).SendKeys("5965944367265387");
            Assert.AreEqual("Fecha de vecimiento", driver.FindElement(By.CssSelector("div.col-md-9 > label.ng-scope")).Text);
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div/select"))).SelectByText("Noviembre");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div/select"))).SelectByText("Noviembre");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div[3]/select"))).SelectByText("2021");
            new SelectElement(driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[2]/div/div/div/div/div/div/div[7]/div/div/div[3]/select"))).SelectByText("2021");
            driver.FindElement(By.XPath("(//input[@type='text'])[16]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[16]")).SendKeys("245");
            driver.FindElement(By.XPath("(//input[@type='text'])[16]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[16]")).SendKeys("245");
            Assert.IsTrue(IsElementPresent(By.CssSelector("label > span.ng-scope")));
            driver.FindElement(By.XPath("(//input[@type='text'])[14]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[14]")).SendKeys("5142207157646588");
            Assert.AreEqual("3. Resumen de orden", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/h2/small")).Text);
            Assert.AreEqual("Producto", driver.FindElement(By.CssSelector("th.text-center.ng-scope")).Text);
            Assert.AreEqual("Cantidad", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/thead/tr/th[3]")).Text);
            Assert.AreEqual("Zapatos Casual para Hombre Bata", driver.FindElement(By.CssSelector("td.text-darkgray.ng-binding")).Text);
            Assert.AreEqual("Thaya 925 - Collar Sea Star", driver.FindElement(By.CssSelector("#item_218 > td.text-darkgray.ng-binding")).Text);
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("td.text-darkgray.text-center > span.ng-binding")).Text);
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("#item_218 > td.text-darkgray.text-center > span.ng-binding")).Text);
            Assert.AreEqual("S/. 159.90", driver.FindElement(By.XPath("//tr[@id='item_823']/td[3]")).Text);
            Assert.AreEqual("95.00", driver.FindElement(By.XPath("//tr[@id='item_218']/td[3]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.CssSelector("tfoot.chkout-table-footer > tr > td")).Text);
            Assert.AreEqual("(2 Productos)", driver.FindElement(By.CssSelector("tfoot.chkout-table-footer > tr > td.text-right.ng-binding")).Text);
            Assert.AreEqual("S/ 254.90", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr/td[3]")).Text);
            Assert.AreEqual("Envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[3]/td[2]")).Text);
            Assert.AreEqual("S/ 13.36", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[3]/td[3]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[4]/td[2]")).Text);
            Assert.AreEqual("S/ 268.26", driver.FindElement(By.CssSelector("td.text-right > b.ng-binding")).Text);
            Assert.AreEqual("Tiempo de envío", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[5]/td[2]")).Text);
            Assert.AreEqual("Entre 3 - 6 días utiles", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div/div/table/tfoot/tr[5]/td[4]")).Text);
            Assert.AreEqual("Código de cupón:", driver.FindElement(By.CssSelector("div.row.ng-scope > div.col-md-12 > label.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("name")));
            Assert.AreEqual("Comentarios:", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/form/div[3]/div/div[5]/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("comentarios")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[10]")));
            Assert.AreEqual("Finalizar compra", driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            StringAssert.Equals("Checkout \n Finalizar compra", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div")).Text);
            jse.ExecuteScript("scroll(0, 600)");
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[9]")));
            StringAssert.Equals("Finalizar compra", driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Text);
            driver.FindElement(By.XPath("(//button[@type='button'])[10]")).Click();
            Thread.Sleep(20000);
            Assert.AreEqual("Costos de envío: S/ 13.36", driver.FindElement(By.XPath("//div[3]/div/div/div[2]/h4")).Text);
            Assert.AreEqual("Total facturado: S/ 268.26", driver.FindElement(By.XPath("//div[2]/h3")).Text);
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
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Administrar direcciones")));
                Assert.AreEqual("Administrar direcciones", driver.FindElement(By.LinkText("Administrar direcciones")).Text);
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Mis órdenes")));
                Assert.AreEqual("Mis órdenes", driver.FindElement(By.LinkText("Mis órdenes")).Text);
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Cupón")));
                Assert.AreEqual("Cupón", driver.FindElement(By.LinkText("Cupón")).Text);
            }
            catch (AssertFailedException) { }
            Assert.AreEqual("Mis órdenes", driver.FindElement(By.CssSelector("h3.text-navy.text-bold")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[7]")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select")));
            StringAssert.Equals("Última semana Últimos 15 días Último mes", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select[2]")));
            StringAssert.Equals("Todas las Órdenes Órdenes completadasÓrdenes abiertasÓrdenes canceladas", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div[2]/div/select[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.bg-navy")));
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.bg-navy")).Text);
            Assert.AreEqual("Órdenes de juntoz", driver.FindElement(By.LinkText("Órdenes de juntoz")).Text);
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[7]")).SendKeys("161004210853");
            driver.FindElement(By.XPath("//div[2]/div/button")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("# de orden", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[2]")).Text);
            Assert.AreEqual("Fecha", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[3]")).Text);
            Assert.AreEqual("Sub total", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[4]")).Text);
            Assert.AreEqual("Costo de envío", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[5]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[6]")).Text);
            Assert.AreEqual("161004210853", driver.FindElement(By.CssSelector("td.text-center.ng-binding")).Text);
            Assert.AreEqual("S/ 254.90", driver.FindElement(By.CssSelector("td.text-right.ng-binding")).Text);
            Assert.AreEqual("S/ 13.36", driver.FindElement(By.XPath("//table[@id='accordion']/tbody[3]/tr/td[5]")).Text);
            Assert.AreEqual("S/ 268.26", driver.FindElement(By.XPath("//table[@id='accordion']/tbody[3]/tr/td[6]")).Text);
            driver.FindElement(By.Id("161004210853")).Click();
            Assert.AreEqual("Pedidos por Orden", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("# de orden", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/thead/tr/th")).Text);
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Status", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/thead/tr/th[3]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/thead/tr/th[4]")).Text);
            Assert.AreEqual("Opciones", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/thead/tr/th[5]")).Text);
            Assert.AreEqual("161004210853-001", driver.FindElement(By.CssSelector("tr.ng-scope > td.text-center.ng-binding")).Text);
            Assert.AreEqual("161004210853-002", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr[2]/td")).Text);
            Assert.AreEqual("Bata", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr/td[2]")).Text);
            Assert.AreEqual("Thaya 925", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr[2]/td[2]")).Text);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr/td[3]/span")).Text);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr[2]/td[3]/span")).Text);
            Assert.AreEqual("S/. 165.56", driver.FindElement(By.CssSelector("tr.ng-scope > td.text-right.ng-binding")).Text);
            Assert.AreEqual("S/. 102.70", driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr[2]/td[4]")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("i.fa.fa-eye")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-eye")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-times")));
            driver.FindElement(By.XPath("//tr[@id='c161004210853']/td/table/tbody/tr/td[5]/a")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Orden N°: 161004210853", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div/div/h3")).Text);
            Assert.AreEqual("Artículo 1", driver.FindElement(By.CssSelector("th > div.ng-binding")).Text);
            Assert.AreEqual("SKU", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Cantidad", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[3]")).Text);
            Assert.AreEqual("Precio unitario", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[4]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[5]")).Text);
            Assert.AreEqual("Estado", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/thead/tr/th[6]")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("853-7885-40", driver.FindElement(By.CssSelector("td.text-center.ng-binding")).Text);
            Assert.AreEqual("1", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[4]")).Text);
            Assert.AreEqual("S/. 159.90", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[5]")).Text);
            Assert.AreEqual("S/. 159.90", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[6]")).Text);
            Assert.AreEqual("Nuevo", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[7]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div/div/table/tbody/tr/td[8]/button")));
            Assert.AreEqual("Descuento: S/. 0.00", driver.FindElement(By.CssSelector("h5")).Text);
            Assert.AreEqual("Envío: S/. 5.66", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div[2]/div/h5[2]")).Text);
            Assert.AreEqual("Subtotal (1) artículos: S/. 165.56", driver.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/div/div/div[2]/div/div/div/div/div[3]/div/ul/li/div/div[2]/div/h4")).Text);
            StringAssert.Equals("Regresar a Mis Órdenes", driver.FindElement(By.XPath("//a[contains(text(),'Regresar a Mis Órdenes')]")).Text);
            driver.Close();
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
