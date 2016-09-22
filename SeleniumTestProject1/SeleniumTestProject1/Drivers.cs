using System;
using System.Threading;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text;

namespace SeleniumTestProject1
{
    [TestClass]
    public class Drivers
    {

        static IWebDriver driverFF;
        static IWebDriver driverGC;
        static StringBuilder verificationErrors;


        [AssemblyInitialize]
        public static void SetUp(TestContext context)
        {
            driverFF = new FirefoxDriver();
            driverGC = new ChromeDriver("C:/Users/Denisse/Documents/Selenium");
            verificationErrors = new StringBuilder();

        }


        [TestMethod]
        public void TestFirefox()
        {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(1000);
            driverFF.Close();
        }

        [TestMethod]
        public void TestChrome()
        {
            driverGC.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(1000);
            driverGC.Close();
        }

        //CABECERA
        [TestMethod]
        public void Head()
        {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(10000);
            Assert.IsTrue(IsElementPresent(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.pull-right.text-buy-by-category")));
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-stores']/a/span[2]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[2]")));
            Assert.AreEqual("Todas las tiendas", driverFF.FindElement(By.XPath("(//button[@type='button'])[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")));
            Assert.AreEqual("", driverFF.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span[2]/i")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span")));
            Assert.AreEqual("tu tienda", driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span[2]/span")).Text);
            Assert.IsTrue(IsElementPresent(By.Id("btncartitem")));
            StringAssert.Equals("Mi Carrito", driverFF.FindElement(By.Id("btncartitem")).Text);
            Assert.IsTrue(IsElementPresent(By.Id("btnaccount")));
            StringAssert.Equals("Mi Hola Cuenta", driverFF.FindElement(By.Id("btnaccount")).Text);
            driverFF.Close();
        }

        // Valida Option de Categoria
        [TestMethod]
        public void Categoria() {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(5000);
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-categories']/a/span[2]/span[2]")));

             for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//li[@id='dropdown-categories']/a/span[2]/span[2]"))) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(20000);
            }
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[2]/div[2]/div[2]/b")));
            Thread.Sleep(500);
            StringAssert.Contains("Celulares y Tablets", driverFF.FindElement(By.CssSelector("span.pull-left.ng-binding")).Text);
            StringAssert.Contains("Electrodomésticos", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[2]/div/a/span")).Text);
            StringAssert.Contains("Hogar, Jardín y Herramientas", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[3]/div/a/span")).Text);
            StringAssert.Contains("Moda", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[4]/div/a/span")).Text);
            StringAssert.Contains("Juguetes, Niños y Bebés", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[5]/div/a/span")).Text);
            driverFF.Close();
            
        }

        //Validacion POR Tiendas
        [TestMethod]
        public void PorTienda() {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(10000);
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[5]/div[2]/div[2]/b")));

            
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.XPath("//li[@id='dropdown-stores']/ul/li/div[3]/div"))) break;
                }
                catch (AssertFailedException)
                { }
                Thread.Sleep(30000);
            }
            Assert.AreEqual("Tienda", driverFF.FindElement(By.XPath("//li[@id='dropdown-stores']/a/span[2]/span[2]")).Text);
            Thread.Sleep(15000);
            Assert.IsTrue(IsElementPresent(By.Id("#")));
            StringAssert.Contains("#", driverFF.FindElement(By.Id("#")).Text); 
            Assert.IsTrue(IsElementPresent(By.Id("a")));
            StringAssert.Contains("a", driverFF.FindElement(By.Id("a")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("h2.title-general > b")));
            Assert.IsTrue(IsElementPresent(By.Id("b")));
            Assert.IsTrue(IsElementPresent(By.Id("c")));
            Assert.IsTrue(IsElementPresent(By.Id("d")));
            Assert.IsTrue(IsElementPresent(By.Id("e")));
            Assert.IsTrue(IsElementPresent(By.Id("f")));
            Assert.IsTrue(IsElementPresent(By.Id("g")));
            Assert.IsTrue(IsElementPresent(By.Id("h")));
            Assert.IsTrue(IsElementPresent(By.Id("i")));
            Assert.IsTrue(IsElementPresent(By.Id("j")));
            Assert.IsTrue(IsElementPresent(By.Id("k")));
            Assert.IsTrue(IsElementPresent(By.Id("l")));
            Assert.IsTrue(IsElementPresent(By.Id("m")));
            Assert.IsTrue(IsElementPresent(By.Id("n")));
            Assert.IsTrue(IsElementPresent(By.Id("o")));
            Assert.IsTrue(IsElementPresent(By.Id("p")));
            Assert.IsTrue(IsElementPresent(By.Id("q")));
            Assert.IsTrue(IsElementPresent(By.Id("r")));
            Assert.IsTrue(IsElementPresent(By.Id("s")));
            Assert.IsTrue(IsElementPresent(By.Id("t")));
            Assert.IsTrue(IsElementPresent(By.Id("u")));
            Assert.IsTrue(IsElementPresent(By.Id("v")));
            Assert.IsTrue(IsElementPresent(By.Id("w")));
            Assert.IsTrue(IsElementPresent(By.Id("x")));
            Assert.IsTrue(IsElementPresent(By.Id("y")));
            Assert.IsTrue(IsElementPresent(By.Id("z")));
            StringAssert.Contains("Tiendas destacadas", driverFF.FindElement(By.CssSelector("h2.title-general > b")).Text);
            driverFF.FindElement(By.PartialLinkText("tiendas")).Click();
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/tiendas");
            Assert.AreEqual("Búsqueda por tienda", driverFF.FindElement(By.CssSelector("h2.title-search-by-store")).Text);
            

            driverFF.Close();
        }
        //busqueda por TIENDA
        [TestMethod]
        public void BusquedaTienda()
        {
           
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(10000);
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.LinkText("Todas las tiendas"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
                driverFF.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();

                for (int secondS = 0; ; secondS++)
                {
                    if (secondS >= 60) Assert.Fail("timeout");
                    try
                    {
                        if (IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span/div/div/h5"))) break;
                    }
                    catch (Exception)
                    {
                    }
                    Thread.Sleep(1000);
                }
                Assert.AreEqual("Productos:", driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span/div/div/h5/span")).Text);
                Assert.AreEqual("Categorias:", driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span/div/div[2]/h5/span")).Text);
                Assert.AreEqual("Wawitas- Andador Musical- Abejita", driverFF.FindElement(By.LinkText("Wawitas- Andador Musical- Abejita")).Text);
                driverFF.FindElement(By.LinkText("Wawitas- Andador Musical- Abejita")).Click();
                driverFF.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).Clear();
                driverFF.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).SendKeys("");
                try
                {
                    Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
                }
                catch (AssertFailedException)
                { }
                driverFF.Close();
            }
        }
        // Abrir MI TIENDA
        [TestMethod]
        public void AbrirTienda() {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Thread.Sleep(5000);
            driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/i")).Click();
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if (IsElementPresent(By.CssSelector("img.img-responsive"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(10000);
            }
           
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
            Thread.Sleep(1000);
            Assert.IsTrue(IsElementPresent(By.CssSelector("h4.title-general >b")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/img"))); 
            Assert.IsTrue(IsElementPresent(By.CssSelector("p.ng-scope")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[2]/img"))); 
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[2]/p"))); 
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[3]/img"))); 
            Assert.AreEqual("de todos tus productos o marcas, logrando un incremento de tus ventas.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[3]/p")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[4]/img")));
            Assert.AreEqual("variados, permitiendo cumplir con todas las formas de pago con las que cuente el usuario.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[4]/p")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[5]/img")));
            Assert.AreEqual("para así ayudarte a contar con una buena estrategia de ventas y posicionamiento.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[5]/p")).Text);
            try { Assert.IsTrue(Regex.IsMatch(driverFF.FindElement(By.CssSelector("div.b2b-title > h2.title-general > b")).Text, "^exact:¿Quieres abrir tu tienda en Juntoz[\\s\\S]$")); }
            catch (AssertFailedException) { }
            Assert.AreEqual("Contáctate con nosotros y te ayudaremos a aumentar tus ventas al por mayor usando este nuevo canal online:", driverFF.FindElement(By.CssSelector("div.sell-section.form-b2b > h4.ng-scope")).Text);
            Assert.AreEqual("Datos de la empresa", driverFF.FindElement(By.CssSelector("h4.title-form-section.ng-scope")).Text);
            Assert.AreEqual("Número de RUC:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("RUC")));
            Assert.AreEqual("Nombre comercial:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[2]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("comercialname")));
            Assert.AreEqual("Categoría:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[3]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("categories")));
            Assert.AreEqual("Seleccione una categoría", driverFF.FindElement(By.CssSelector("option")).Text);
            StringAssert.Equals("Seleccione una categoríaSalud, Belleza y Cuidado PersonalTecnología y CómputoModaHogar, Jardín y HerramientasJuguetes, Niños y BebésMotoresDeportes y AventuraVinos, Licores y CervezasSupermercadoCelulares y TabletsLibrosMúsica, Películas y VideojuegosÚtiles de Oficina y EscolaresInstrumentos MusicalesElectrodomésticosMaletas y MochilasRelojesOcasiones Especiales", driverFF.FindElement(By.Name("categories")).Text);
            Assert.AreEqual("Representaciones", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[2]")).Text);
            Assert.AreEqual("Marcas que representa:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//input[@type='number']")));
            Assert.IsTrue(IsElementPresent(By.Name("brandsName")));
            Assert.AreEqual("Representante de la marca:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("representation")));
            Assert.AreEqual("Distribuidor autorizado:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[2]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-5 > div.radio > input[name=\"representation\"]")));
            Assert.AreEqual("Otros:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[3]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-4 > div.radio > input[name=\"representation\"]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[10]")));
            Assert.AreEqual("Datos del Contacto", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[3]")).Text);
            Assert.AreEqual("Nombre del Contacto:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("contactName")));
            Assert.AreEqual("Email:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[2]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("email")));
            Assert.AreEqual("Teléfono:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[3]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("telephone")));
            driverFF.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();
            driverFF.Close();

            }
        //Mi Carrito
        [TestMethod]
        public void MiCarrito()
        {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Assert.IsTrue(IsElementPresent(By.Id("btncartitem")));
            StringAssert.Equals("Mi Carrito", driverFF.FindElement(By.Id("btncartitem")).Text);
            driverFF.FindElement(By.Id("btncartitem")).Click();
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[2]/div/div[2]/div/div/div[2]")));
            Assert.AreEqual("Tu carrito de compras está vacío.", driverFF.FindElement(By.CssSelector("label.ng-scope")).Text);
            Assert.AreEqual("Empieza a usarlo, llénalo con tus marcas preferidas.", driverFF.FindElement(By.CssSelector("p.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Ver carrito")));
            Assert.AreEqual("Ver carrito", driverFF.FindElement(By.LinkText("Ver carrito")).Text);
            Assert.AreEqual("Si ya está registrado, ingresa aquí:", driverFF.FindElement(By.CssSelector("div.popover-cart-header__content.ng-scope > p > span.ng-scope")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("Mi cuenta")));
            Assert.AreEqual("Mi cuenta", driverFF.FindElement(By.LinkText("Mi cuenta")).Text);
            driverFF.Close();
        }
        //Mi Cuenta
        [TestMethod]
        public void MiCuenta()
        {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span[2]/span")).Click();
            driverFF.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();
            driverFF.FindElement(By.Id("btncartitem")).Click();
            Assert.IsTrue(IsElementPresent(By.Id("btnaccount")));
            StringAssert.Equals("Mi Hola Cuenta", driverFF.FindElement(By.Id("btnaccount")).Text);
            driverFF.FindElement(By.Id("btnaccount")).Click();
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")));
            Assert.AreEqual("Identificarse", driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li/div/div[2]/div/div/div/div/button")).Text);
            try { Assert.IsTrue(Regex.IsMatch(driverFF.FindElement(By.CssSelector("p.text-new-customer > span.ng-scope")).Text, "^exact:¿Eres cliente nuevo[\\s\\S]$")); } catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.text-new-customer.ng-scope")));
            Assert.AreEqual("Empieza aquí.", driverFF.FindElement(By.CssSelector("a.text-new-customer.ng-scope")).Text);
            driverFF.Close();

        }
        //Main Page
        [TestMethod]
        public void MainPage()
        {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
            Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive.img-100")));
            Assert.AreEqual("", driverFF.FindElement(By.XPath("//div[@id='brand-slide']/div/ul")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("i.fa.fa-facebook")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.owl-page.active > span")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.title-step-home")));
            Assert.AreEqual("Tiendas\noficiales", driverFF.FindElement(By.CssSelector("div.title-step-home")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[2]/div/div[2]")));
            Assert.AreEqual("Llegamos\na todo el país", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[2]/div/div[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[3]/div/div[2]")));
            Assert.AreEqual("Paga con cualquier\nforma de pago", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[3]/div/div[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[4]/div/div[2]")));
            Assert.AreEqual("Tiendas Destacadas", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div/h2/b")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.tab-text")));
            Assert.AreEqual("Todas las tiendas", driverFF.FindElement(By.CssSelector("span.tab-text")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("#cyber-tab > a > h3.no-margin > span.tab-text")));
            Assert.AreEqual(".Winter Sale", driverFF.FindElement(By.CssSelector("#cyber-tab > a > h3.no-margin > span.tab-text")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//ul[@id='tab-home']/li[3]/a/h3/span[2]")));
            Assert.AreEqual("Las más populares", driverFF.FindElement(By.XPath("//ul[@id='tab-home']/li[3]/a/h3/span[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//ul[@id='tab-home']/li[4]/a/h3/span[2]")));
            Assert.AreEqual("Tiendas multimarca", driverFF.FindElement(By.XPath("//ul[@id='tab-home']/li[4]/a/h3")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//ul[@id='tab-home']/li[5]/a/h3/span[2]")));
            Assert.AreEqual("Nuevas tiendas", driverFF.FindElement(By.XPath("//ul[@id='tab-home']/li[5]/a/h3/span[2]")).Text);
            Assert.IsTrue(IsElementPresent(By.LinkText("tienda.juntoz.com")));
            Assert.AreEqual("tienda.juntoz.com", driverFF.FindElement(By.LinkText("tienda.juntoz.com")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-12 > h2.title-general > b")));
            Assert.AreEqual("Productos recomendados para ti", driverFF.FindElement(By.CssSelector("div.col-md-12 > h2.title-general > b")).Text);
            Assert.AreEqual("Lo más buscado de nuestras tiendas", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div[5]/div/h2/b")).Text);
            Assert.AreEqual("Conoce más sobre Juntoz", driverFF.FindElement(By.CssSelector("div.col-md-12.text-home-juntoz > h2.title-general > b")).Text);
            Assert.IsTrue(Regex.IsMatch(driverFF.FindElement(By.CssSelector("div > p")).Text, "^exact:Juntoz es una nueva plataforma online enfocada en reunir marcas y tiendas, bajo el concepto de un Marketplace para todos\\. Agrupamos en un solo sitio a tus tiendas y marcas favoritas, cada una bajo el formato de Shop-in-Shop \\(tienda propia con su buscador propio\\) dentro de nuestra plataforma online\\. De este modo, acercamos las marcas más importantes a nuestros clientes en un canal complementario y adicional de ventas por internet\\. ¿Qué es Juntoz[\\s\\S] Es un mall o centro comercial, que abre tiendas de marcas, llevado al internet: Juntoz\\.com es un mall online o marketplace online\\.$"));
            Assert.AreEqual("En Juntoz, vive la nueva experiencia de realizar compras por internet en el Mall online de las mejores marcas y retailers. Aquí encontrarás tiendas con productos sobre audífonos, belleza, calzado, cámaras fotográficas, celulares, cervezas, colchones, computadoras, cuidado personal, deportes, electrodomésticos, hogar, instrumentos musicales, jardín, joyería, juguetes, lentes, libros, maletas y mochilas, moda, motores, productos para bebés, relojes, salud, supermercado, tablets, tecnología, TV, útiles escolares, videojuegos, vinos, vitaminas y suplementos, y mucho más.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div[6]/div/div[2]/div/p")).Text);
            Assert.AreEqual("Contamos con muchas marcas importantes dentro de Juntoz como: BabyPlaza, Calimod, DC Shoes, Delirium, Kawasaki, Quiksilver, Neff, Nutrishop, Roxy, Skullcandy, Spy, The Box, THM Store, Triathlon, Utilex, Vans, Victorinox, entre otros.", driverFF.FindElement(By.CssSelector("div.col-md-4 > p")).Text);
            Assert.AreEqual("juntos", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div[6]/div/div[3]/p[2]/strong[3]")).Text);
            Assert.AreEqual("Juntoz cuenta con métodos de pagos seguros y rápidos, entre ellos contamos con: Pago con tarjeta de crédito, pago con tarjeta de débito, Pago Efectivo, Safety Pay, pago contra entrega y store pickup (compra online y recoge en tienda). Visita nuestras redes sociales: Facebook, Twitter, Youtube y G+ y encuentra novedades, promociones, descuentos y mucho más.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[3]/div[6]/div/div[4]/p")).Text);
            Assert.AreEqual("Fonocompras\n(01) 640-9-640", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div[2]/div/div/div[4]/div/div[2]")).Text);
            driverFF.Close();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driverFF.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
       
             
        
    }
}
