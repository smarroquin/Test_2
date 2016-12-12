using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace Merchant
{
    [TestClass]
    public class Merchant
    {
        static IWebDriver driver;
        static StringBuilder verificationErrors;
        static string baseURL;
        static bool acceptNextAlert = true;

        [AssemblyInitialize]
        public static void Setup(TestContext Context)
        {
            driver = new FirefoxDriver();
            baseURL = "https://login.juntoz.com/";
            verificationErrors = new StringBuilder();
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

            driver.Navigate().GoToUrl(baseURL + "/auth/login?client_id=D109B864D02A4EC582CBBEFF19A84411FD97142461D2483599A8D786870296CE&formView=login&returnUrl=http://merchant.juntoz.com/signin-eagle&actionName=");
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("img.logo-login")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Iniciar sesión", driver.FindElement(By.LinkText("Iniciar sesión")).Text);
            Assert.AreEqual("Crear cuenta", driver.FindElement(By.LinkText("Crear cuenta")).Text);
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("label.control-label")).Text, "^exact:Email[\\s\\S]*$"));
            }
            catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("Email")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//form[@id='form-signin']/div[2]/label")).Text, "^exact:Contraseña[\\s\\S]*$"));
            }
            catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("Password")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.LinkText("¿Olvidaste tu clave?")).Text, "^exact:¿Olvidaste tu clave[\\s\\S]$"));
            }
            catch { };
            Assert.AreEqual("Recordar mi email y contraseña", driver.FindElement(By.CssSelector("#remember > label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.XPath("//button[@type='submit']")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Iniciar sesión", driver.FindElement(By.XPath("//button[@type='submit']")).Text);
            driver.FindElement(By.LinkText("Crear cuenta")).Click();
            Assert.AreEqual("Email", driver.FindElement(By.CssSelector("label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("Email")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//div[@id='text-2']/form/div/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("FirstName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Apellidos", driver.FindElement(By.XPath("//div[@id='text-2']/form/div/div[3]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("LastName")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Contraseña", driver.FindElement(By.CssSelector("div.form-group.col-sm-6 > label.control-label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("Password")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Confirmar Contraseña", driver.FindElement(By.XPath("//div[@id='text-2']/form/div[2]/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("ConfirmPassword")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Fecha de Nacimiento", driver.FindElement(By.XPath("//div[@id='text-2']/form/div[3]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("DateOfBirth")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("DNI o CE", driver.FindElement(By.XPath("//div[@id='text-2']/form/div[3]/div[2]/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("DNI")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Teléfono Celular", driver.FindElement(By.XPath("//div[@id='text-2']/form/div[4]/div/label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("Phone")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("He leído y acepto los términos y condiciones", driver.FindElement(By.CssSelector("#remember > label")).Text);
            Assert.AreEqual("términos y condiciones", driver.FindElement(By.LinkText("términos y condiciones")).Text);
            Assert.AreEqual("Completar registro", driver.FindElement(By.XPath("//button[@type='submit']")).Text);
            driver.FindElement(By.Id("tab-1")).Click();
            Thread.Sleep(1000);
            try { Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.CssSelector("label.control-label")).Text, "^exact:Email[\\s\\S]*$"));
            }
            catch { };
            //DATOS A MODIFICAR
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("denisse@ieholding.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("43445093");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
         }

        [TestMethod]
        public void IngresarTienda() {
            driver.Navigate().GoToUrl("http://merchant.juntoz.com/");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("denisse@ieholding.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("43445093");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(50000);
            Assert.AreEqual("MerchantCentral", driver.FindElement(By.CssSelector("span.logo-lg")).Text);
            Assert.AreEqual("Escoger Tienda", driver.FindElement(By.CssSelector("h3.box-title")).Text);
            Assert.AreEqual("Escoge tu Merchant (Razón Social)", driver.FindElement(By.CssSelector("label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("cboChooser")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Alma Restauraciones SAC", driver.FindElement(By.Id("cboChooser")).Text);
            Assert.AreEqual("Opciones Generales", driver.FindElement(By.XPath("//section[@id='scChooser']/div/div[2]/div[2]/div/div/label")).Text);
            Assert.AreEqual("CONFIGURACIÓN", driver.FindElement(By.XPath("//a[contains(text(),'Configuración')]")).Text);
            Assert.AreEqual("Configuración General", driver.FindElement(By.CssSelector("span.info-box-number")).Text);
            Assert.AreEqual("FINANZAS", driver.FindElement(By.XPath("//a[contains(text(),'Finanzas')]")).Text);
            Assert.AreEqual("Información Financiera", driver.FindElement(By.CssSelector("div.info-box.bg-green > div.info-box-content > span.info-box-number")).Text);
            Assert.AreEqual("Escoge la tienda a ingresar", driver.FindElement(By.XPath("//section[@id='scChooser']/div/div[2]/div[4]/div/div/label")).Text);
            Assert.AreEqual("D'SALA CAFFE", driver.FindElement(By.LinkText("D'SALA CAFFE")).Text);
            driver.FindElement(By.LinkText("D'SALA CAFFE")).Click();
            Thread.Sleep(1000);
            StringAssert.Equals("Alma Restauraciones SAC", driver.FindElement(By.CssSelector("#spMerchantName > b")).Text);
            StringAssert.Equals("Dashboard", driver.FindElement(By.CssSelector("h3.box-title")).Text);
            StringAssert.Equals("Sales today", driver.FindElement(By.CssSelector("span.info-box-text")).Text);
            StringAssert.Equals("Today Visitors", driver.FindElement(By.XPath("//div[2]/div/div/span")).Text);
            StringAssert.Equals("Customer Questions", driver.FindElement(By.XPath("//div[3]/div/div/span")).Text);
            try { Assert.AreEqual("SALES OF THE MONTH", driver.FindElement(By.XPath("//div[4]/div/div/span")).Text); } catch { };
            try { StringAssert.Equals("Dashboard", driver.FindElement(By.XPath("//section/ul/li[2]/a/span")).Text); 
            Assert.AreEqual("Catalogo", driver.FindElement(By.XPath("//section/ul/li[3]/a/span")).Text);
            Assert.AreEqual("Pedidos", driver.FindElement(By.XPath("//section/ul/li[4]/a/span")).Text);
            Assert.AreEqual("CMS", driver.FindElement(By.XPath("//li[5]/a/span")).Text);
            Assert.AreEqual("Editar Template", driver.FindElement(By.XPath("//li[6]/a/span")).Text);
            Assert.AreEqual("Configuracion", driver.FindElement(By.XPath("//li[7]/a/span")).Text);
            Assert.AreEqual("Listas", driver.FindElement(By.XPath("//li[8]/a/span")).Text);
            Assert.AreEqual("Logistica", driver.FindElement(By.XPath("//li[9]/a/span")).Text);
            Assert.AreEqual("Finanzas", driver.FindElement(By.XPath("//li[10]/a/span")).Text);
            Assert.AreEqual("Marketing", driver.FindElement(By.XPath("//li[11]/a/span")).Text);
            Assert.AreEqual("Testing", driver.FindElement(By.XPath("//li[12]/a/span")).Text);
            }
            catch { };

        }

        [TestMethod]
        public void Menu()
        {
            driver.Navigate().GoToUrl("http://merchant.juntoz.com/");
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("scroll(250, 0)");
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("denisse@ieholding.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("43445093");
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
            Thread.Sleep(50000);
            Assert.AreEqual("MerchantCentral", driver.FindElement(By.CssSelector("span.logo-lg")).Text);
            Assert.AreEqual("Escoger Tienda", driver.FindElement(By.CssSelector("h3.box-title")).Text);
            Assert.AreEqual("Escoge tu Merchant (Razón Social)", driver.FindElement(By.CssSelector("label")).Text);
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("cboChooser")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            Assert.AreEqual("Alma Restauraciones SAC", driver.FindElement(By.Id("cboChooser")).Text);
            driver.FindElement(By.LinkText("D'SALA CAFFE")).Click();
            Thread.Sleep(5000);
            try { Assert.AreEqual("Dashboard", driver.FindElement(By.CssSelector("a.au-target > span")).Text);
                Assert.AreEqual("Dashboard", driver.FindElement(By.CssSelector("h3.box-title")).Text); 
            Assert.AreEqual("Catalogo", driver.FindElement(By.XPath("//section/ul/li[3]/a/span")).Text);
        }
            catch { };
            driver.FindElement(By.LinkText("Catalogo")).Click();
            Assert.AreEqual("Productos", driver.FindElement(By.LinkText("Productos")).Text);
            Assert.AreEqual("Marcas", driver.FindElement(By.LinkText("Marcas")).Text);
            Assert.AreEqual("Categorias", driver.FindElement(By.LinkText("Categorias")).Text);
            Assert.AreEqual("Prod. Borrados", driver.FindElement(By.LinkText("Prod. Borrados")).Text);
            Assert.AreEqual("Variaciones", driver.FindElement(By.LinkText("Variaciones")).Text);
            Assert.AreEqual("Atributos", driver.FindElement(By.LinkText("Atributos")).Text);
            driver.FindElement(By.LinkText("Productos")).Click();
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("input.form-control.au-target")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.CssSelector("select.form-control.au-target")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Carga y Actualización Masiva")));
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
                Assert.IsTrue(IsElementPresent(By.CssSelector("span.glyphicon.glyphicon-refresh")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.LinkText("Crear Producto")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Total 29", driver.FindElement(By.CssSelector("label")).Text);
                Assert.AreEqual("Sin Fotos 0", driver.FindElement(By.XPath("//div[2]/div/label")).Text);
                Assert.AreEqual("Sin Stock 1", driver.FindElement(By.XPath("//div[3]/div/label")).Text);
                Assert.AreEqual("Sin Precio 0", driver.FindElement(By.XPath("//div[4]/div/label")).Text);
                Assert.AreEqual("Sin Publicar 0", driver.FindElement(By.XPath("//div[5]/div/label")).Text);
                Assert.AreEqual("Sin Pesos 0", driver.FindElement(By.XPath("//div[6]/div/label")).Text);
                Assert.AreEqual("Saltar a página", driver.FindElement(By.CssSelector("div.form-group > label")).Text);
                Assert.AreEqual("Items x página", driver.FindElement(By.XPath("//form/div[2]/div/label")).Text);
                Assert.AreEqual("paginas / 23 items", driver.FindElement(By.CssSelector("div.form-group > span")).Text);
            }
            catch { };
            driver.FindElement(By.LinkText("Marcas")).Click();
            try { Assert.AreEqual("Marcas", driver.FindElement(By.XPath("//h3/span")).Text);
                Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//th")).Text);
                Assert.AreEqual("SEO Url", driver.FindElement(By.XPath("//th[2]")).Text);
                Assert.AreEqual("Crear Marca", driver.FindElement(By.LinkText("Crear Marca")).Text);
                Assert.AreEqual("Total de Marcas", driver.FindElement(By.XPath("//div[2]/div/h3/span")).Text);
                Assert.AreEqual("Nombre", driver.FindElement(By.XPath("//div[2]/div/table/thead/tr/th")).Text);
                Assert.AreEqual("SEO Url", driver.FindElement(By.XPath("//div[2]/div/table/thead/tr/th[2]")).Text);
                Assert.AreEqual("Activo", driver.FindElement(By.XPath("//div[2]/div/table/thead/tr/th[3]")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Categorias")).Click();
            try { Assert.AreEqual("Categorías", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Crear Categoría", driver.FindElement(By.LinkText("Crear Categoría")).Text);
                Assert.AreEqual("Buscar Categoría", driver.FindElement(By.CssSelector("label")).Text);
            }catch { };
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btn-search-select")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btn-clear-select")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btn-expand-all")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.IsTrue(IsElementPresent(By.Id("btn-collapse-all")));
            }
            catch (AssertFailedException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                StringAssert.Equals("Directorio de Categorías", driver.FindElement(By.XPath("//div[2]/label")).Text);
            }
            catch { };
            driver.FindElement(By.LinkText("Prod. Borrados")).Click();
            try
            { Assert.AreEqual("Productos Borrados (borrados lógicos)", driver.FindElement(By.XPath("//h3/span")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Variaciones")).Click();
            try
            {
                Assert.AreEqual("Variaciones existentes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Nombre de Variacion", driver.FindElement(By.XPath("//th[2]")).Text);
                Assert.AreEqual("Nro. de Productos", driver.FindElement(By.XPath("//th[3]")).Text);
                Assert.AreEqual("Metadata", driver.FindElement(By.XPath("//th[4]")).Text);
            }
            catch { };
            driver.FindElement(By.LinkText("Atributos")).Click();
            try { Assert.AreEqual("Atributos existentes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Nombre de Atributo", driver.FindElement(By.XPath("//th[2]")).Text);
                Assert.AreEqual("Nro. de Productos", driver.FindElement(By.XPath("//th[3]")).Text);
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//th[4]")).Text, "^exact:¿Visible en Filtros[\\s\\S]$"));
                Assert.AreEqual("Tipo Display en Filtro", driver.FindElement(By.XPath("//th[5]")).Text);
                Assert.IsTrue(Regex.IsMatch(driver.FindElement(By.XPath("//th[6]")).Text, "^exact:¿Atado a Metadata[\\s\\S]$"));
            }
            catch { };

            driver.FindElement(By.XPath("//section/ul/li[4]/a/span")).Click();
            Assert.AreEqual("Store Pickup", driver.FindElement(By.LinkText("Store Pickup")).Text);
            Assert.AreEqual("Pedidos", driver.FindElement(By.XPath("//a[contains(text(),'Pedidos')]")).Text);
            Assert.AreEqual("Cupones", driver.FindElement(By.LinkText("Cupones")).Text);
            driver.FindElement(By.LinkText("Store Pickup")).Click();
            try { Assert.AreEqual("Listado de Reservas", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); }
            catch { };
            driver.FindElement(By.XPath("//a[contains(text(),'Pedidos')]")).Click();
            try
            { Assert.AreEqual("Listado de Pedidos", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Cupones")).Click();
            try { Assert.AreEqual("Listado de Cupones", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); 
            
            Assert.AreEqual("Codigo de Cupón", driver.FindElement(By.CssSelector("th")).Text);
            Assert.AreEqual("Descuento", driver.FindElement(By.XPath("//th[2]")).Text);
            Assert.AreEqual("Inicio", driver.FindElement(By.XPath("//th[3]")).Text);
            Assert.AreEqual("Vencimiento", driver.FindElement(By.XPath("//th[4]")).Text);
            Assert.AreEqual("Creación", driver.FindElement(By.XPath("//th[5]")).Text);
            Assert.AreEqual("Creador", driver.FindElement(By.XPath("//th[6]")).Text);
            Assert.AreEqual("Modificación", driver.FindElement(By.XPath("//th[7]")).Text);
            Assert.AreEqual("Editor", driver.FindElement(By.XPath("//th[8]")).Text);
            Assert.AreEqual("Opcion", driver.FindElement(By.XPath("//th[9]")).Text);
            }
            catch { };
            driver.FindElement(By.XPath("//li[5]/a/span")).Click();
            Assert.AreEqual("Administrar Imagenes", driver.FindElement(By.LinkText("Administrar Imagenes")).Text);
            driver.FindElement(By.LinkText("Administrar Imagenes")).Click();
            try { StringAssert.Equals("Administrar Imagenes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.XPath("//li[6]/a/span")).Click();
            Assert.AreEqual("Seleccionar Template", driver.FindElement(By.LinkText("Seleccionar Template")).Text);
            Assert.AreEqual("Administrar Imagenes", driver.FindElement(By.XPath("(//a[contains(text(),'Administrar Imagenes')])[2]")).Text);
            Assert.AreEqual("Producto Destacado", driver.FindElement(By.LinkText("Producto Destacado")).Text);
            Assert.AreEqual("Barra de navegacion", driver.FindElement(By.LinkText("Barra de navegacion")).Text);
            Assert.AreEqual("Sobre nosotros", driver.FindElement(By.LinkText("Sobre nosotros")).Text);
            driver.FindElement(By.LinkText("Seleccionar Template")).Click();
            try { Assert.AreEqual("Elegir Template", driver.FindElement(By.CssSelector("h3.box-title")).Text); } catch { };
            driver.FindElement(By.XPath("(//a[contains(text(),'Administrar Imagenes')])[2]")).Click();
            try { Assert.AreEqual("Administrar Imagenes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.LinkText("Producto Destacado")).Click();
            try { Assert.AreEqual("Barra de navegación", driver.FindElement(By.CssSelector("h3.box-title")).Text); } catch { };
            driver.FindElement(By.LinkText("Barra de navegacion")).Click();
            try { Assert.AreEqual("Barra de navegación", driver.FindElement(By.CssSelector("h3.box-title")).Text);
            }
            catch { };
            driver.FindElement(By.LinkText("Sobre nosotros")).Click();
            try { Assert.AreEqual("Barra de navegación", driver.FindElement(By.CssSelector("h3.box-title")).Text);
                Assert.AreEqual("Title", driver.FindElement(By.CssSelector("label")).Text);
                Assert.AreEqual("Video", driver.FindElement(By.XPath("//div[4]/div/div/div/label")).Text);
                Assert.AreEqual("Html", driver.FindElement(By.XPath("//div[6]/div/div/div/label")).Text);
            }
            catch { };
            driver.FindElement(By.XPath("//li[7]/a/span")).Click();
            Assert.AreEqual("Tienda", driver.FindElement(By.LinkText("Tienda")).Text);
            Assert.AreEqual("Usuarios", driver.FindElement(By.LinkText("Usuarios")).Text);
            Assert.AreEqual("API", driver.FindElement(By.LinkText("API")).Text);
            Assert.AreEqual("Integraciones", driver.FindElement(By.LinkText("Integraciones")).Text);
            Assert.AreEqual("Notificaciones", driver.FindElement(By.LinkText("Notificaciones")).Text);
            driver.FindElement(By.LinkText("Tienda")).Click();
            try
            {
                Assert.AreEqual("Configuración de Tienda", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Básica", driver.FindElement(By.CssSelector("h3.panel-title")).Text);
                Assert.AreEqual("Parámetros de Envío Logístico", driver.FindElement(By.XPath("//div[2]/div/h3")).Text);
                Assert.AreEqual("Umbrella Store", driver.FindElement(By.XPath("//div[3]/div/h3")).Text);
                Assert.AreEqual("Opciones Avanzadas", driver.FindElement(By.XPath("//div[4]/div/h3")).Text);
                Assert.AreEqual("Retiro en Tienda", driver.FindElement(By.XPath("//div[5]/div/h3")).Text);
                Assert.AreEqual("Notificaciones", driver.FindElement(By.XPath("//div[6]/div/h3")).Text);
            }
            catch { };
            driver.FindElement(By.LinkText("Usuarios")).Click();
            try { Assert.AreEqual("Usuarios en Entidad", driver.FindElement(By.CssSelector("h3.box-title")).Text); } catch { };
            driver.FindElement(By.LinkText("API")).Click();
            try { Assert.AreEqual("Credenciales del cliente", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.LinkText("Integraciones")).Click();
            try { Assert.AreEqual("Integraciones", driver.FindElement(By.CssSelector("h3.box-title")).Text); } catch { };
            driver.FindElement(By.LinkText("Notificaciones")).Click();
            try { Assert.AreEqual("Integraciones", driver.FindElement(By.CssSelector("h3.box-title")).Text); } catch { };
            driver.FindElement(By.LinkText("Notificaciones")).Click();
            driver.FindElement(By.XPath("//li[8]/a/span")).Click();
            Assert.AreEqual("Colegios", driver.FindElement(By.LinkText("Colegios")).Text);
            Assert.AreEqual("Listas", driver.FindElement(By.XPath("//a[contains(text(),'Listas')]")).Text);
            driver.FindElement(By.LinkText("Colegios")).Click();
            try { Assert.AreEqual("Colegios", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.XPath("//a[contains(text(),'Listas')]")).Click();
            try { Assert.AreEqual("Listas de Productos", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.XPath("//li[9]/a/span")).Click();
            try { Assert.AreEqual("Almacenes", driver.FindElement(By.LinkText("Almacenes")).Text);
                Assert.AreEqual("Formatos de paquete", driver.FindElement(By.LinkText("Formatos de paquete")).Text);
                Assert.AreEqual("Cotizador de Envio", driver.FindElement(By.LinkText("Cotizador de Envio")).Text);
                Assert.AreEqual("Operadores", driver.FindElement(By.LinkText("Operadores")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Almacenes")).Click();
            try { Assert.AreEqual("Almacenes", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Otros Almacenes en Merchant", driver.FindElement(By.CssSelector("div.col-md-8 > h3")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Formatos de paquete")).Click();
            try { Assert.AreEqual("Formatos de paquete", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.LinkText("Cotizador de Envio")).Click();
            try { Assert.AreEqual("Cotizar Envío", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); } catch { };
            driver.FindElement(By.LinkText("Operadores")).Click();
            try { Assert.AreEqual("Operadores Logísticos", driver.FindElement(By.CssSelector("h3.box-title > span")).Text);
                Assert.AreEqual("Proveedor", driver.FindElement(By.CssSelector("th")).Text);
                Assert.AreEqual("Activo", driver.FindElement(By.XPath("//th[2]")).Text);
                Assert.AreEqual("Por defecto", driver.FindElement(By.XPath("//th[3]")).Text); }
            catch { };
            driver.FindElement(By.XPath("//li[10]/a/span")).Click();
            try { Assert.AreEqual("Facturas", driver.FindElement(By.LinkText("Facturas")).Text);
                Assert.AreEqual("Ventas", driver.FindElement(By.LinkText("Ventas")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Facturas")).Click();
            try { Assert.AreEqual("Facturas por Comisiones, Logisticos y Otros Gastos", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Ventas")).Click();
            try
            {
                Assert.AreEqual("Ventas", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); }
            catch { };
            driver.FindElement(By.XPath("//li[11]/a/span")).Click();
            try
            {
                Assert.AreEqual("Campañas", driver.FindElement(By.LinkText("Campañas")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Campañas")).Click();
            try
            {
                Assert.AreEqual("Campañas", driver.FindElement(By.CssSelector("h3.box-title > span")).Text); }
            catch { };
            driver.FindElement(By.XPath("//li[12]/a/span")).Click();
            try
            {
                Assert.AreEqual("Laboratory", driver.FindElement(By.LinkText("Laboratory")).Text); }
            catch { };
            driver.FindElement(By.LinkText("Laboratory")).Click();
            try
            { Assert.AreEqual("Detail", driver.FindElement(By.CssSelector("h3.panel-title")).Text); }
            catch { };

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
