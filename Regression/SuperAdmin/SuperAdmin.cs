using System;
using System.Text;

using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Interactions;
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
            Thread.Sleep(5000);
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
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(1000);
            StringAssert.Equals("Edición", driver.FindElement(By.CssSelector("small.ng-scope")).Text);
            Assert.AreEqual("Información Básica", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span.ng-scope")).Text);
            Assert.AreEqual("Información de contacto", driver.FindElement(By.XPath("//li[2]/a/uib-tab-heading/span")).Text);
            Assert.AreEqual("Politicas y Devoluciones", driver.FindElement(By.XPath("//li[3]/a/uib-tab-heading/span")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//button[@type='button']")).Text);
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Merchants", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            driver.FindElement(By.XPath("//li[3]/ul/li[2]/a/span")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Stores", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Merchants", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Merchants", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("txt-merchant")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[2]")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.CssSelector("div.sa-body > div.col-md-12.sa-bordered > h4")).Text);
         
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).Clear();
            driver.FindElement(By.XPath("(//input[@type='text'])[2]")).SendKeys("vans");
            driver.FindElement(By.CssSelector("button.btn.btn-success")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.CssSelector("div.sa-body > div.col-md-12.sa-bordered > h4")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.CssSelector("th.ng-scope")).Text);
            Assert.AreEqual("Merchant", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Publicado", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Acciones", driver.FindElement(By.XPath("//th[4]")).Text);
            Assert.AreEqual("Vans", driver.FindElement(By.CssSelector("td.ng-binding")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("span.glyphicon.glyphicon-pencil")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("a.btn.btn-danger")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("button.btn.btn-primary")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Crear store", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Información básica", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span.ng-scope")).Text);
            Assert.AreEqual("Merchant", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//div[2]/div/div/label")).Text);
            Assert.AreEqual("País", driver.FindElement(By.XPath("//div[3]/div/div/label")).Text);
            StringAssert.Equals("Descipción", driver.FindElement(By.XPath("//div[4]/div/div/label")).Text);
            Assert.AreEqual("Seo Url", driver.FindElement(By.XPath("//div[5]/div/div/label")).Text);
            Assert.AreEqual("Delivery Time", driver.FindElement(By.XPath("//div[6]/div/div/label")).Text);
            Assert.AreEqual("Logo", driver.FindElement(By.CssSelector("h3.panel-title.pull-left")).Text);
            Assert.AreEqual("Shop in Shop", driver.FindElement(By.XPath("//div[2]/div/div/div/label/span")).Text);
            Assert.AreEqual("White Label", driver.FindElement(By.XPath("//div[3]/div/div/div/label/span")).Text);
            Assert.AreEqual("Modulo Aplicación", driver.FindElement(By.XPath("//div[2]/div[4]/div/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//button[@type='button']")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//button[@type='button']")).Text);
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Assert.AreEqual("Stores", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);

            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//section/ul/li[4]/a/span")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.XPath("//section/ul/li[4]/a/span")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Ordenes", driver.FindElement(By.CssSelector("ul.treeview-menu.menu-open > li > a > span.ng-scope")).Text);
            driver.FindElement(By.CssSelector("ul.treeview-menu.menu-open > li > a > span.ng-scope")).Click();
            Thread.Sleep(5000);
            Assert.AreEqual("Ordenes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Ordenes", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Número Orden", driver.FindElement(By.XPath("//div[2]/label")).Text);
            Assert.AreEqual("Cupón", driver.FindElement(By.XPath("//div[3]/label")).Text);
            Assert.AreEqual("Cliente", driver.FindElement(By.XPath("//div[4]/label")).Text);
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//div[5]/label")).Text);
            Assert.AreEqual("Operador Logístico", driver.FindElement(By.XPath("//div[6]/label")).Text);
            Assert.AreEqual("Opción Fechas", driver.FindElement(By.XPath("//div[7]/label")).Text);
            Assert.AreEqual("Filtrar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            // StringAssert.Equals("Resultados de Búsqueda", driver.FindElement(By.XPath("//div[2]/div/h4")).Text);
            Assert.AreEqual("Otros", driver.FindElement(By.Id("myTabDrop1")).Text);
            Assert.AreEqual("Pendiente Confirmar", driver.FindElement(By.LinkText("Pendiente Confirmar")).Text);
            Assert.AreEqual("Pendiente Pago", driver.FindElement(By.LinkText("Pendiente Pago")).Text);
            Assert.AreEqual("Confirmado", driver.FindElement(By.LinkText("Confirmado")).Text);
            Assert.AreEqual("Listo para Enviar", driver.FindElement(By.LinkText("Listo para Enviar")).Text);
            Assert.AreEqual("En tránsito", driver.FindElement(By.LinkText("En tránsito")).Text);
            Assert.AreEqual("Nuevo", driver.FindElement(By.LinkText("Nuevo")).Text);
            Assert.AreEqual("Ordenes (Nuevo)", driver.FindElement(By.XPath("//li[4]/ul/li[2]/a/span")).Text);
            driver.FindElement(By.LinkText("Ordenes (Nuevo)")).Click();
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);

            Assert.AreEqual("Ordenes", driver.FindElement(By.XPath("//h3/span")).Text);
            //try
            //{
            //    StringAssert.Equals("Nro Orden", driver.FindElement(By.CssSelector("label")).Text);
            //}
            //catch (AssertFailedException e)
            //{
            //    verificationErrors.Append(e.Message);
            //}
            Assert.AreEqual("Estado", driver.FindElement(By.XPath("//div[2]/label")).Text);
            Assert.AreEqual("Cliente", driver.FindElement(By.XPath("//div[3]/label")).Text);
            Assert.AreEqual("SKU", driver.FindElement(By.XPath("//div[4]/label")).Text);
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//div[5]/label")).Text);
            Assert.AreEqual("Operador Logístico", driver.FindElement(By.XPath("//div[6]/label")).Text);
            Assert.AreEqual("Método de Pago", driver.FindElement(By.XPath("//div[7]/label")).Text);
            Assert.AreEqual("Cupón", driver.FindElement(By.XPath("//div[8]/label")).Text);
            Assert.AreEqual("Desde", driver.FindElement(By.XPath("//div[9]/label")).Text);
            Assert.AreEqual("Hasta", driver.FindElement(By.XPath("//div[10]/label")).Text);
            Assert.AreEqual("Buscar", driver.FindElement(By.Id("btnSearch")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.Id("btnClear")).Text);
            Assert.AreEqual("Export to Excel", driver.FindElement(By.LinkText("Export to Excel")).Text);
            Assert.AreEqual("Númer de Orden", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[2]")).Text);
            Assert.AreEqual("Estado", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[3]")).Text);
            
            Assert.AreEqual("Fecha de Entrega", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[4]")).Text);
            Assert.AreEqual("Sub Total", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[5]")).Text);
            Assert.AreEqual("Descuento", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[6]")).Text);
            Assert.AreEqual("Envío", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[7]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div/table/thead/tr/th[8]")).Text);
            Assert.AreEqual("Cupón", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div[2]/table/thead/tr/th[4]")).Text);
           
            
            Assert.AreEqual("Merchant", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div[2]/table/thead/tr/th[5]")).Text);
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div[2]/table/thead/tr/th[6]")).Text);
            Assert.AreEqual("Operador", driver.FindElement(By.XPath("//div[@id='orders']/div[2]/div[2]/table/thead/tr/th[7]")).Text);

            driver.FindElement(By.Id("btnSearch")).Click();
            Thread.Sleep(50000);
            driver.FindElement(By.XPath("//li[4]/ul/li[3]/a/span")).Click();
            Thread.Sleep(50000);
            Assert.AreEqual("Clientes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Nombre de Cliente:", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Apellidos", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("N° de Documento", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Email", driver.FindElement(By.XPath("//th[4]")).Text);
            Assert.AreEqual("Teléfono", driver.FindElement(By.XPath("//th[5]")).Text);
            StringAssert.Equals("Celular", driver.FindElement(By.XPath("//th[6]")).Text);
            Assert.AreEqual("Crear Cliente", driver.FindElement(By.XPath("//button")).Text);
         
            driver.FindElement(By.CssSelector("button.btn.btn-default")).Click();
            Thread.Sleep(50000);
            Assert.AreEqual("Clientes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Información básica", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span.ng-scope")).Text);
            Assert.AreEqual("Nombres", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Apellidos", driver.FindElement(By.XPath("//div[2]/div/div/label")).Text);
            Assert.AreEqual("Tipo de Documento", driver.FindElement(By.XPath("//div[3]/div/div/label")).Text);
            Assert.AreEqual("N° de Documento", driver.FindElement(By.XPath("//div[4]/div/div/label")).Text);
            Assert.AreEqual("Email", driver.FindElement(By.XPath("//div[5]/div/div/label")).Text);
            Assert.AreEqual("Teléfono", driver.FindElement(By.CssSelector("div.col-md-3 > div.form-group > label")).Text);
            Assert.AreEqual("Celular", driver.FindElement(By.XPath("//div[2]/div/label")).Text);
            Assert.AreEqual("Country", driver.FindElement(By.XPath("//div[7]/div/div/label")).Text);
            Assert.AreEqual("Guardar", driver.FindElement(By.XPath("//button[@type='submit']")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//button[@type='button']")).Text);
            Thread.Sleep(1000);
            //driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Thread.Sleep(50000);
            driver.FindElement(By.XPath("//li[4]/ul/li[4]/a/span")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Coupons", driver.FindElement(By.CssSelector("span.ng-binding")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Cupón", driver.FindElement(By.CssSelector("label.control-label")).Text);
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            StringAssert.Contains("Resultados de Búsqueda", driver.FindElement(By.XPath("//div[2]/div/h4")).Text);
            Assert.AreEqual("Codigo de Cupón", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Descuento", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Inicio", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Vencimiento", driver.FindElement(By.XPath("//th[4]")).Text);
            try
            {
                Assert.AreEqual("Creación", driver.FindElement(By.XPath("//th[5]")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Creador", driver.FindElement(By.XPath("//th[6]")).Text);
            Assert.AreEqual("Modificación", driver.FindElement(By.XPath("//th[7]")).Text);
            Assert.AreEqual("Editor", driver.FindElement(By.XPath("//th[8]")).Text);
            Assert.AreEqual("Opciones", driver.FindElement(By.XPath("//th[9]")).Text);
            Assert.AreEqual("Crear Cupón", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            StringAssert.Contains("Información básica", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span.ng-scope")).Text);
            Assert.AreEqual("Código de Cupón", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Tipo de Descuento", driver.FindElement(By.XPath("//div[2]/div/div/label")).Text);
            Assert.AreEqual("Descuento", driver.FindElement(By.XPath("//div[3]/div/div/label")).Text);
            Assert.AreEqual("Fecha de Inicio", driver.FindElement(By.XPath("//div[4]/div/div/label")).Text);
            Assert.AreEqual("Fecha de Expiración (Seleccionar un día despues)", driver.FindElement(By.XPath("//div[5]/div/div/label")).Text);
            Assert.AreEqual("Numero Máximo de Usos", driver.FindElement(By.XPath("//div[6]/div/div/label")).Text);
            Assert.AreEqual("Numero Máximo de Usos", driver.FindElement(By.XPath("//div[6]/div/div/label")).Text);
            Assert.AreEqual("Monto Mínimo de consumo", driver.FindElement(By.XPath("//div[7]/div/div/label")).Text);
            Assert.AreEqual("Monto Máximo de descuento", driver.FindElement(By.XPath("//div[8]/div/div/label")).Text);
            Assert.AreEqual("Usuario", driver.FindElement(By.XPath("//div[2]/div/div/div/label")).Text);
            Assert.AreEqual("Categoria", driver.FindElement(By.XPath("//div[2]/div[2]/div/div/label")).Text);
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//div[2]/div[3]/div/div/label")).Text);
            Assert.AreEqual("White Label", driver.FindElement(By.XPath("//div[2]/div[4]/div/div/label")).Text);
            Assert.AreEqual("Marca", driver.FindElement(By.XPath("//div[2]/div[5]/div/div/label")).Text);
            Assert.AreEqual("Método de Pago", driver.FindElement(By.XPath("//div[2]/div[6]/div/div/label")).Text);
            Assert.AreEqual("País", driver.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Guardar", driver.FindElement(By.XPath("//button[@type='submit']")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Text);
            driver.FindElement(By.XPath("(//button[@type='button'])[3]")).Click();
            driver.FindElement(By.XPath("//li[5]/a/span")).Click();
            StringAssert.Contains("Reembolsos", driver.FindElement(By.XPath("//li[5]/ul/li/a/span")).Text);
            driver.FindElement(By.XPath("//li[5]/ul/li/a/span")).Click();
            Thread.Sleep(1000);
            Assert.AreEqual("Reembolsos", driver.FindElement(By.XPath("//h3/span")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Número Orden", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Cupón", driver.FindElement(By.XPath("//div[2]/label")).Text);
            try
            {
                Assert.AreEqual("Cliente", driver.FindElement(By.XPath("//div[3]/label")).Text);
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Tienda", driver.FindElement(By.XPath("//div[4]/label")).Text);
            Assert.AreEqual("Estado Orden", driver.FindElement(By.XPath("//div[5]/label")).Text);
            Assert.AreEqual("Opción Fechas", driver.FindElement(By.XPath("//div[6]/label")).Text);
            Assert.AreEqual("Filtrar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.XPath("(//button[@type='submit'])[2]")).Text);
            StringAssert.Equals("Resultados de Búsqueda", driver.FindElement(By.XPath("//div[2]/div/h4")).Text);
            Assert.AreEqual("# de Orden", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[2]")).Text);
            Assert.AreEqual("Fecha", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[3]")).Text);
            Assert.AreEqual("Operador", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[4]")).Text);
            Assert.AreEqual("User", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[5]")).Text);
            Assert.AreEqual("Subtotal", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[6]")).Text);
            Assert.AreEqual("Descuento", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[7]")).Text);
            Assert.AreEqual("Costo de Envío", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[8]")).Text);
            Assert.AreEqual("Total", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[9]")).Text);
            Assert.AreEqual("Opciones", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[10]")).Text);
            driver.FindElement(By.XPath("//li[5]/ul/li[2]/a/span")).Click();
            Thread.Sleep(50000);
            Assert.AreEqual("Pagos", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Número de Factura", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Número de Operación", driver.FindElement(By.XPath("//div[2]/label")).Text);
            Assert.AreEqual("Número Orden", driver.FindElement(By.XPath("//div[3]/label")).Text);
            Assert.AreEqual("SKU", driver.FindElement(By.XPath("//div[4]/label")).Text);
            Assert.AreEqual("Filtrar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.XPath("//div[2]/div/h4")).Text);
            Assert.AreEqual("# de Factura", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("# de Operación", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[2]")).Text);
            Assert.AreEqual("# de Orden", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[3]")).Text);
            Assert.AreEqual("SKU", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[4]")).Text);
            Assert.AreEqual("Total Bruto", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[5]")).Text);
            Assert.AreEqual("Comisión", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[6]")).Text);
            Assert.AreEqual("Incidencias", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[7]")).Text);
            Assert.AreEqual("Total Neto", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[8]")).Text);
            Assert.AreEqual("Fecha de Pago", driver.FindElement(By.XPath("//table[@id='accordion']/thead/tr/th[9]")).Text);
            Assert.AreEqual("Cargar Pagos", driver.FindElement(By.LinkText("Cargar Pagos")).Text);

            Assert.AreEqual("Logistica", driver.FindElement(By.XPath("//li[6]/a/span")).Text);
            driver.FindElement(By.XPath("//li[6]/a/span")).Click();
            Assert.AreEqual("Operadores", driver.FindElement(By.XPath("//li[6]/ul/li/a/span")).Text);
            Assert.AreEqual("Zonas", driver.FindElement(By.LinkText("Zonas")).Text);
            driver.FindElement(By.XPath("//li[6]/ul/li/a/span")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Suppliers", driver.FindElement(By.XPath("//h3/span")).Text);
            Assert.AreEqual("Filtros de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//input[@value='']")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Buscar", driver.FindElement(By.CssSelector("button.btn.btn-success")).Text);
            Assert.AreEqual("Limpiar Filtros", driver.FindElement(By.CssSelector("button.btn.btn-default")).Text);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.XPath("//div[2]/div/h4")).Text);
            Assert.AreEqual("Supplier ID", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Name", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Tax Identifier", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Opciones", driver.FindElement(By.XPath("//th[4]")).Text);
            Assert.AreEqual("Crear Supplier", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Información básica", driver.FindElement(By.XPath("//uib-tab-heading/span")).Text);
            Assert.AreEqual("Name", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Ingrese nombre", driver.FindElement(By.XPath("//div/div/div/p")).Text);
            Assert.AreEqual("Tax Identifier", driver.FindElement(By.XPath("//div[2]/div/div/label")).Text);
            Assert.AreEqual("Ingrese TAX", driver.FindElement(By.XPath("//div[2]/div/div/p")).Text);
            Assert.AreEqual("Servicio Express", driver.FindElement(By.XPath("//div[3]/div/div/label")).Text);
            Assert.AreEqual("Country", driver.FindElement(By.XPath("//div[4]/div/div/label")).Text);
            Assert.AreEqual("Action", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            Assert.AreEqual("Guardar", driver.FindElement(By.XPath("//button[@type='submit']")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//button[@type='button']")).Text);
            driver.FindElement(By.XPath("//button[@type='button']")).Click();
            Thread.Sleep(10000);
            driver.FindElement(By.XPath("//li[6]/ul/li[2]/a/span")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Zonas", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
            Assert.AreEqual("Resultados de Búsqueda", driver.FindElement(By.CssSelector("h4")).Text);
            Assert.AreEqual("Nombre", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Ubigeos", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Opciones", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Crear Zona", driver.FindElement(By.CssSelector("button.btn.btn-primary")).Text);
            driver.FindElement(By.CssSelector("button.btn.btn-primary")).Click();
            Thread.Sleep(10000);
            Assert.AreEqual("Información Básica", driver.FindElement(By.CssSelector("uib-tab-heading.ng-scope > span")).Text);
            Assert.AreEqual("Nombre de Zona", driver.FindElement(By.CssSelector("label")).Text);
            Assert.AreEqual("Ubigeo", driver.FindElement(By.XPath("//div[2]/div/div/div/label")).Text);
            Assert.AreEqual("Lista de Ubigeos", driver.FindElement(By.CssSelector("h5 > b")).Text);
            Assert.AreEqual("Código de Ubigeo", driver.FindElement(By.CssSelector("td > b")).Text);
            Assert.AreEqual("Nombre de Ubigeo", driver.FindElement(By.XPath("//td[2]/b")).Text);
            Assert.AreEqual("Cancelar", driver.FindElement(By.XPath("//button[2]")).Text);
            driver.FindElement(By.XPath("//button[2]")).Click();
            Thread.Sleep(10000);




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
