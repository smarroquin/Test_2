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
            Assert.IsTrue(IsElementPresent(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("span.pull-right.text-buy-by-category")));
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='dropdown-stores']/a/span[2]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//button[@type='button'])[2]")));
            try
            {
                Assert.AreEqual("Todas las tiendas", driverFF.FindElement(By.XPath("(//button[@type='button'])[2]")).Text);
            }
            catch (AssertFailedException) { }

            Assert.IsTrue(IsElementPresent(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")));
            try
            {
                Assert.AreEqual("", driverFF.FindElement(By.CssSelector("div.content-input-search-header > span.twitter-typeahead > #typeahead")).Text);
            }
            catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/form/div/div[2]/span[2]/i")));
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span")));
            try
            {
                Assert.AreEqual("tu tienda", driverFF.FindElement(By.XPath("//div[@id='header-juntoz']/nav/div/div[2]/div/div/div/div/ul/li[3]/span/a/span/span[2]/span")).Text);
            }
            catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.Id("btncartitem")));
            try
            {
                Assert.AreEqual("Mi Carrito", driverFF.FindElement(By.Id("btncartitem")).Text);
            }
            catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.Id("btnaccount")));
            try
            {
                Assert.AreEqual("Mi Hola Cuenta", driverFF.FindElement(By.Id("btnaccount")).Text);
            }
            catch (AssertFailedException) { }
            driverFF.Close();
        }

        // Valida Option de Categoria
        [TestMethod]
        public void Categoria() {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
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
                Thread.Sleep(30000);
            }
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[2]/div[2]/div[2]/b")));
            try {
                Assert.AreEqual("Celulares y Tablets", driverFF.FindElement(By.CssSelector("span.pull-left.ng-binding")).Text);
            }
            catch (AssertFailedException) { }

            try
            {
                Assert.AreEqual("Electrodomésticos", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[2]/div/a/span")).Text);
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.AreEqual("Hogar, Jardín y Herramientas", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[3]/div/a/span")).Text);
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.AreEqual("Moda", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[4]/div/a/span")).Text);
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.AreEqual("Juguetes, Niños y Bebés", driverFF.FindElement(By.XPath("//li[@id='container-categories']/div/ul/li[5]/div/a/span")).Text);
            }
            catch (AssertFailedException) { }

            // VALIDA LAS OPCIONES DENTRO DE LA CATEGORIA "Celulares y Tablets"
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Celulares y Smartphones")));
            }
            catch (AssertFailedException)
            { }

            Assert.IsTrue(IsElementPresent(By.CssSelector("b.menu-big-title-orange.text-center")));

            // VALIDA LAS OPCIONES DENTRO DE LA CATEGORIA "Electrodomésticos"
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Pequeños Electrodomésticos")));
            }
            catch (AssertFailedException)
            { }
            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[2]/div[2]/div[2]/b")));

            // VALIDA LAS OPCIONES DENTRO DE LA CATEGORIA "Hogar, Jardín y Herramientas"

            try
            {
                Assert.AreEqual("Exteriores", driverFF.FindElement(By.LinkText("Exteriores")).Text);
            }
            catch (AssertFailedException) { }

            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[3]/div[2]/div[2]/b")));

            // VALIDA LAS OPCIONES DENTRO DE LA CATEGORIA "Moda"
            try
            {
                Assert.AreEqual("Moda Mujer", driverFF.FindElement(By.LinkText("Moda Mujer")).Text);
            }
            catch (AssertFailedException)
            {
            }

            Assert.IsTrue(IsElementPresent(By.XPath("//li[@id='container-categories']/div/ul/li[4]/div[2]/div[2]/b")));
            // VALIDA LAS OPCIONES DENTRO DE LA CATEGORIA "Juguetes, Niños y Bebés"
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Bebés")));
            }
            catch (AssertFailedException)
            {

            }
            try
            {
                Assert.AreEqual("Juguetes", driverFF.FindElement(By.LinkText("Juguetes")).Text);
            }
            catch (AssertFailedException)
            { }

            driverFF.Close();
        }

        //Validacion POR Tiendas
        [TestMethod]
        public void PorTienda() {
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
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
            try
            {
                Assert.AreEqual("Tienda", driverFF.FindElement(By.XPath("//li[@id='dropdown-stores']/a/span[2]/span[2]")).Text);
            }
            catch (AssertFailedException)
            { }

            Assert.IsTrue(IsElementPresent(By.Id("#")));

            try {
                Assert.AreEqual("#", driverFF.FindElement(By.Id("#")).Text); }
            catch (AssertFailedException) { }

            Assert.IsTrue(IsElementPresent(By.Id("a")));
            try {
                Assert.AreEqual("a", driverFF.FindElement(By.Id("a")).Text);
            }
            catch (AssertFailedException) { }
            Assert.IsTrue(IsElementPresent(By.CssSelector("h2.title-general > b")));
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("b")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("c")));
            }
            catch (AssertFailedException) { }
                        try
            {
                Assert.IsTrue(IsElementPresent(By.Id("d")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("e")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("f")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("g")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("h")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("i")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("j")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("k")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("l")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("m")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("n")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("o")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("p")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("q")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("r")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("s")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("t")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("u")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("v")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("w")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("x")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("y")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("z")));
            }
            catch (AssertFailedException) { }
            try
            {
                Assert.AreEqual("Tiendas destacadas", driverFF.FindElement(By.CssSelector("h2.title-general > b")).Text);
            }
            catch (AssertFailedException)
            { }
            try {
                Assert.IsTrue(IsElementPresent(By.LinkText("Ver todas las tiendas")));
            } catch (AssertFailedException) { }

            driverFF.Close();
        }
        //busqueda por TIENDA
        [TestMethod]
        public void BusquedaTienda()
        {
           
            driverFF.Navigate().GoToUrl("http://juntoz-qa.com/");
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
            try {
                Assert.IsTrue(IsElementPresent(By.CssSelector("img.img-responsive")));
            }
            catch (AssertFailedException) { }
            try {
                Assert.IsTrue(IsElementPresent(By.CssSelector("h4.title-general >b")));
            }
            catch (AssertFailedException) { }
            try {
                Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div/img")));
            }
            catch (AssertFailedException) { }
            try {
                Assert.IsTrue(IsElementPresent(By.CssSelector("p.ng-scope")));
            }
            catch (AssertFailedException) { }
            try { Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[2]/img"))); }
            catch (AssertFailedException) { }
            try { Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[2]/p"))); }
            catch (AssertFailedException) { }
            try { Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[3]/img"))); }
            catch (AssertFailedException) { }
            Assert.AreEqual("de todos tus productos o marcas, logrando un incremento de tus ventas.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[3]/p")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[4]/img")));
            Assert.AreEqual("variados, permitiendo cumplir con todas las formas de pago con las que cuente el usuario.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[4]/p")).Text);
            Assert.IsTrue(IsElementPresent(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[5]/img")));
            Assert.AreEqual("para así ayudarte a contar con una buena estrategia de ventas y posicionamiento.", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div/div/div[5]/p")).Text);
            try {
                Assert.IsTrue(Regex.IsMatch(driverFF.FindElement(By.CssSelector("div.b2b-title > h2.title-general > b")).Text, "^exact:¿Quieres abrir tu tienda en Juntoz[\\s\\S]$"));
            }
            catch (AssertFailedException) { }
                Assert.AreEqual("Contáctate con nosotros y te ayudaremos a aumentar tus ventas al por mayor usando este nuevo canal online:", driverFF.FindElement(By.CssSelector("div.sell-section.form-b2b > h4.ng-scope")).Text);
            Assert.AreEqual("Datos de la empresa", driverFF.FindElement(By.CssSelector("h4.title-form-section.ng-scope")).Text);
            Assert.AreEqual("Número de RUC:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("RUC")));
            }
            catch (AssertFailedException)
            { }
            try
            {
                Assert.AreEqual("Nombre comercial:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[2]/label")).Text);
            }
            catch (AssertFailedException)
            { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("comercialname")));
            }
            catch (AssertFailedException)
            { }
            try
            {
                Assert.AreEqual("Categoría:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div/div[3]/label")).Text);
            }
            catch (AssertFailedException)
            { }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("categories")));
            }
            catch (AssertFailedException)
            { }
            Assert.AreEqual("Seleccione una categoría", driverFF.FindElement(By.CssSelector("option")).Text);
            
            try
            {
                Assert.AreEqual("Representaciones", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[2]")).Text);
            }
            catch (AssertFailedException)
            { }
            Assert.AreEqual("Marcas que representa:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//input[@type='number']")));
            }
            catch (AssertFailedException)
            { }
            Assert.IsTrue(IsElementPresent(By.Name("brandsName")));
            Assert.AreEqual("Representante de la marca:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("representation")));
            }
            catch (AssertFailedException)
            { }
            Assert.AreEqual("Distribuidor autorizado:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[2]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-5 > div.radio > input[name=\"representation\"]")));
            Assert.AreEqual("Otros:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[2]/div[2]/div[3]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.CssSelector("div.col-md-4 > div.radio > input[name=\"representation\"]")));
            Assert.IsTrue(IsElementPresent(By.XPath("(//input[@type='text'])[10]")));
            Assert.AreEqual("Datos del Contacto", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/h4[3]")).Text);
            Assert.AreEqual("Nombre del Contacto:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("contactName")));
            }
            catch (AssertFailedException)
            { }
            Assert.AreEqual("Email:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Name("email")));
            }
            catch (AssertFailedException)
            { }
            Assert.AreEqual("Teléfono:", driverFF.FindElement(By.XPath("//div[@id='body-juntoz']/div[2]/div/div/div[2]/form/div[3]/div[3]/label")).Text);
            Assert.IsTrue(IsElementPresent(By.Name("telephone")));
            driverFF.FindElement(By.CssSelector("li > h1.h1-logo.ng-scope > a.logo")).Click();

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
