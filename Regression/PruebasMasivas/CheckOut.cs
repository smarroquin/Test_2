using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PruebasMasivas
{
    [TestClass]
    public class CheckOut
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
        public void CheckOut_PagoEntrega_B()
        {
            // Pago contra entrega con boleta
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            driver.FindElement(By.Id("btnaccount")).Click();
            driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            driver.FindElement(By.Id("btnaccount")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Name("userEmail")).Clear();
            driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
           // driver.FindElement(By.Id("btncartitem")).Click();
            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();
            
            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);
            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
            
            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[4]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("a > span")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Ver mis órdenes", driver.FindElement(By.CssSelector("a > span")).Text);
 
        }


        [TestMethod]
        public void CheckOut_PagoEntrega_F()
        {
            // Pago contra entrega con Factura
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.Id("btncartitem")).Click();
            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);
            new SelectElement(driver.FindElement(By.Id("order-document-type"))).SelectByText("Factura");
            driver.FindElement(By.XPath("//div[4]/div[2]/div/div/input")).Clear();
            driver.FindElement(By.XPath("//div[4]/div[2]/div/div/input")).SendKeys("25785242555");
            



            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
            
            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[4]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("a > span")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Ver mis órdenes", driver.FindElement(By.CssSelector("a > span")).Text);


        }


        [TestMethod]
        public void CheckOut_SafetyPay_F()
        {
            // Safety Pay con Factura
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
           // driver.FindElement(By.Id("btncartitem")).Click();
            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);
            
            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
           
            new SelectElement(driver.FindElement(By.Id("order-document-type"))).SelectByText("Factura");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys("02145852152");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys(Keys.Enter);


            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[3]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);

            Thread.Sleep(50000);

        }

        [TestMethod]
        public void CheckOut_SafetyPay_B()
        {
            // Safety Pay con Boleta
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.Id("btncartitem")).Click();
//            driver.FindElement(By.Id("btncartitem")).Click();

            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);

            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(1000);
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
            
            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[3]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);
            Thread.Sleep(50000);


        }

        [TestMethod]
        public void CheckOut_PagoEfectivo_B()
        {
            // PagoEfectivo con Boleta
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.Id("btncartitem")).Click();
//            driver.FindElement(By.Id("btncartitem")).Click();

            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);

            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(1000);
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
           
            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);
            Thread.Sleep(50000);


        }

        [TestMethod]
        public void CheckOut_PagoEfectivo_F()
        {
            // PagoEfectivo con Factura
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
            // driver.FindElement(By.Id("btncartitem")).Click();
//            driver.FindElement(By.Id("btncartitem")).Click();

            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);

            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(1000);
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
            

            new SelectElement(driver.FindElement(By.Id("order-document-type"))).SelectByText("Factura");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys("02145852152");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])[2]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);
            Thread.Sleep(50000);



        }

        [TestMethod]
        public void CheckOut_Visa_Rechazada()
        {
            // Tarjeta Visa Rechazada
            driver.Navigate().GoToUrl("http://juntoz-qa.com");
            //driver.FindElement(By.Id("btnaccount")).Click();
            //driver.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Click();
            //driver.FindElement(By.Id("btnaccount")).Click();
            //Thread.Sleep(1000);
            //driver.FindElement(By.Name("userEmail")).Clear();
            //driver.FindElement(By.Name("userEmail")).SendKeys("pruebas.juntoz@gmail.com");
            //driver.FindElement(By.Name("password")).Clear();
            //driver.FindElement(By.Name("password")).SendKeys("juntoz123");
            //driver.FindElement(By.Id("btnLogin")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys("d'sala");
            driver.FindElement(By.XPath("(//input[@id='typeahead'])[2]")).SendKeys(Keys.Enter);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//img[@alt='Hario Dripper V60']")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[2]/div/div/div/button")).Click();
            Thread.Sleep(5000);
            //driver.FindElement(By.Id("btncartitem")).Click();
//            driver.FindElement(By.Id("btncartitem")).Click();

            driver.FindElement(By.XPath("//input[@value='Comprar todo']")).Click();

            Assert.AreEqual("1", driver.FindElement(By.CssSelector("h3 > strong")).Text);
            Assert.AreEqual("Información de Envío", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Dirección de Envío", driver.FindElement(By.CssSelector("h3.no-border")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-home")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-plus")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Comprobante de pago", driver.FindElement(By.XPath("//div[@id='shipping-info']/h3[2]")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("order-document-type")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            StringAssert.Equals("Boleta Factura", driver.FindElement(By.Id("order-document-type")).Text);

            Assert.AreEqual("2", driver.FindElement(By.CssSelector("#payment-info > h3 > strong")).Text);
            Assert.AreEqual("Información de Pago", driver.FindElement(By.XPath("//div[@id='payment-info']/h3/strong[2]")).Text);
            Assert.AreEqual("Tarjeta credito", driver.FindElement(By.CssSelector("span.payment-method-description")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.pagoefectivo")).Text);
            Assert.AreEqual("", driver.FindElement(By.CssSelector("span.checkout-icons.bank-payment")).Text);
            Assert.AreEqual("Pago contra entrega", driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span[2]/span[2]")).Text);
            Assert.AreEqual("Promoción", driver.FindElement(By.XPath("//div[@id='payment-info']/h3[2]")).Text);
            Assert.AreEqual("Cupón de descuento", driver.FindElement(By.CssSelector("#payment-info > div.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.text-uppercase")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Aplicar", driver.FindElement(By.CssSelector("span.input-group-btn > button.btn.btn-orange")).Text);
            Assert.AreEqual("3", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong")).Text);
            Assert.AreEqual("Resumen de la Orden", driver.FindElement(By.XPath("//form[@id='checkout']/div[4]/h3/strong[2]")).Text);
            Assert.AreEqual("Sub total:", driver.FindElement(By.CssSelector("p.text-right")).Text);
            Assert.AreEqual("Costo de envío:", driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[2]/div/p")).Text);
            Assert.AreEqual("Total:", driver.FindElement(By.CssSelector("h4.text-right.no-margin-top")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[5]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Thread.Sleep(1000);
            Assert.AreEqual("Comprar ahora", driver.FindElement(By.XPath("(//button[@type='button'])[5]")).Text);
            Assert.AreEqual("Al finalizar la compra, acepto los términos & condiciones y privacidad de Juntoz", driver.FindElement(By.CssSelector("p.text-center > small")).Text);
            Assert.AreEqual("Fechas de entrega", driver.FindElement(By.CssSelector("div.delivery-date > h3")).Text);
           
            new SelectElement(driver.FindElement(By.Id("order-document-type"))).SelectByText("Factura");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).Clear();
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys("02145852152");
            driver.FindElement(By.XPath("(//input[@value=''])[7]")).SendKeys(Keys.Enter);

            driver.FindElement(By.XPath("//div[@id='pm-4']/h4/label/span")).Click();
            driver.FindElement(By.XPath("(//input[@name='paymentMethod'])")).Click();
            Assert.AreEqual("Nombre del titular:", driver.FindElement(By.CssSelector("div.panel-body.form > div.row > div.col-md-12 > div.form-group > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.panel-body.form > div.row > div.col-md-12 > div.form-group > input.form-control")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Número de tarjeta:", driver.FindElement(By.CssSelector("div.form-group.credit-card-input > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("credit-card-number-1")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Fecha de vencimiento:", driver.FindElement(By.XPath("//div[@id='pm-body-1']/div/div[3]/div/div/label")).Text);
            Assert.AreEqual("Mes:", driver.FindElement(By.CssSelector("div.col-md-4 > div.form-group > label.control-label")).Text);
            Assert.AreEqual("Año:", driver.FindElement(By.CssSelector("div.col-md-4.no-padding > div.form-group > label.control-label")).Text);
            Assert.AreEqual("CVV:", driver.FindElement(By.XPath("//div[@id='pm-body-1']/div/div[4]/div[3]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-4 > div.form-group > select.form-control")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-4.no-padding > div.form-group > select.form-control")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-4 > div.form-group > input.form-control")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Elija una fecha de vencimiento mayor a la actual.", driver.FindElement(By.CssSelector("p.error > small")).Text);
            driver.FindElement(By.Id("credit-card-number-1")).Clear();
            driver.FindElement(By.Id("credit-card-number-1")).SendKeys("407221");
            driver.FindElement(By.Id("credit-card-number-1")).Clear();
            driver.FindElement(By.Id("credit-card-number-1")).SendKeys("4072210290536663");
            new SelectElement(driver.FindElement(By.CssSelector("div.col-md-4 > div.form-group > select.form-control"))).SelectByText("3");
            new SelectElement(driver.FindElement(By.CssSelector("div.col-md-4.no-padding > div.form-group > select.form-control"))).SelectByText("2018");
            driver.FindElement(By.CssSelector("div.col-md-4 > div.form-group > input.form-control")).Clear();
            driver.FindElement(By.CssSelector("div.col-md-4 > div.form-group > input.form-control")).SendKeys("377");
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("i.credit-card-icon.new-visa")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }

            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//div[@id='order-summary']/div[2]/div[4]/div/button")).Click();
            Thread.Sleep(10000);
            StringAssert.Equals("¡Gracias por su compra!", driver.FindElement(By.CssSelector("b")).Text);

            StringAssert.Equals("Lo sentimos, tu pago no fue aprobado", driver.FindElement(By.CssSelector("b")).Text);
            Assert.AreEqual("Te recomendamos intentar con otra tarjeta u otro medio de pago.", driver.FindElement(By.CssSelector("p > b")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("div.modal-body")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Operación Denegada. Número de pedido del comercio duplicado. Favor no atender.", driver.FindElement(By.CssSelector("div.modal-body > p")).Text);
            Assert.AreEqual("Operación Denegada. Número de pedido del comercio duplicado. Favor no atender.", driver.FindElement(By.CssSelector("div.modal-body > p")).Text);
            Assert.AreEqual("Datos de la transacción", driver.FindElement(By.XPath("//div[@id='modal-card-error']/div/div/div[2]/p[2]/strong")).Text);
            Assert.AreEqual("Número de pedido:", driver.FindElement(By.CssSelector("b.col-md-6")).Text);
            Assert.AreEqual("Número de tarjeta:", driver.FindElement(By.XPath("//div[@id='modal-card-error']/div/div/div[2]/p[4]/b")).Text);
            Assert.AreEqual("Nombre del tarjetahabiente:", driver.FindElement(By.XPath("//div[@id='modal-card-error']/div/div/div[2]/p[5]/b")).Text);
            Assert.AreEqual("Fecha de transacción:", driver.FindElement(By.XPath("//div[@id='modal-card-error']/div/div/div[2]/p[6]/b")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.btn-danger")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.CssSelector("button.btn.btn-danger")).Click();
           





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
