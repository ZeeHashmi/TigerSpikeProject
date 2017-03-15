using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;



namespace TigerSpike
{
    [TestClass]
    //[TestFixture(typeof(string))]
    public class TigerSpikeDemoTest : TestBase
    {
        public static string BaseUrl = "https://www.amazon.com.au";


        String username = "arzoohai@hotmail.com";
        
        [Test]
        public void Login()
        {

            ReadData();
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl(BaseUrl);
            driver.Manage().Window.Maximize();

            var signin = driver.FindElementById("nav-link-yourAccount");
            signin.Click();

            var Username = driver.FindElementById("ap_email");
            Username.SendKeys(username);

            var Password = driver.FindElementById("ap_password");
            Password.SendKeys("Passw0rd");
            //Sign in
            var Loginbutton = driver.FindElementById("signInSubmit");
            Loginbutton.Click();
            Thread.Sleep(500);

            //Serch bar
            var searchBox = driver.FindElement(By.Id("twotabsearchtextbox"));
            Actions action = new Actions(driver);
            action.ClickAndHold(searchBox);
            searchBox.SendKeys(BrandName());

            //Search button
            var searchIcon = driver.FindElement(By.ClassName("nav-input"));
            searchIcon.Click();

            //Select second product from the search list
            var selectProduct = driver.FindElementByXPath("//html/body//div/div/div/ul/li[@id][2]//a/h2");
            selectProduct.Click();

            //Assert text contain on the page
            string actualvalue = driver.FindElement(By.Id("buybox")).Text;
            NUnit.Framework.Assert.IsTrue(actualvalue.Contains("Kindle Price"));
            var buyitnow = driver.FindElementById("one-click-button");
            buyitnow.Click();

            //Payment Page
            var paymentpage = driver.FindElementById("set_payments_widget");
            NUnit.Framework.Assert.IsTrue(actualvalue.Contains("How would you like to pay?"));
            Thread.Sleep(4000);
            driver.Quit();

            Thread.Sleep(4000);
            driver.Quit();

        }
    }
}