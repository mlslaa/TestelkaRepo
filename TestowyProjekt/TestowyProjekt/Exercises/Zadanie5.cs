using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestowyProjekt.WaitExtensions;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Interactions;

namespace TestowyProjekt.Exercises
{
    internal class Zadanie5
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver(@"E:\Visual Studio\Testelka\TestowyProjekt\TestowyProjekt\Resources");
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://fakestore.testelka.pl/moje-konto/");


        }
        [Test]
        public void LocatingBUsernameTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement login = driver.FindElement(By.CssSelector("[id='username']"));
            var outerHtml = login.GetAttribute("outerHTML");
            const string name = "misia";
            login.SendKeys(name);
            // Assert.);

        }
        [Test]
        public void LocatingPasswordTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement password = driver.FindElement(By.CssSelector("[id='password']"));
            var outerHtml = password.GetAttribute("outerHTML");
            const string Text = "somePassword";
            password.SendKeys(Text);

        }
        [Test]
        public void LocatingCheckboxTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement rememberme = driver.FindElement(By.CssSelector("input#rememberme"));
            var outerHtml = rememberme.GetAttribute("outerHTML");
            rememberme.Click();
        }
        [Test]
        public void LocatingLinkTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement forgotPassword = driver.FindElement(By.CssSelector("[href='https://fakestore.testelka.pl/moje-konto/zapomniane-haslo/']"));
            var outerHtml = forgotPassword.GetAttribute("outerHTML");
            forgotPassword.Click();
            Assert.AreEqual("https://fakestore.testelka.pl/moje-konto/zapomniane-haslo/", driver.Url, "Url is not correct.");
        }
        [Test]
        public void LocatingByEmailTest()
        {

            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement email = driver.FindElement(By.CssSelector("#reg_email"));
            // var outerHtml = email.GetAttribute("outerHTML");
            const string name = "misia@misia";
            email.SendKeys(name);
            driver.WaitForClickable(By.CssSelector("[name='register']"));
            driver.FindElement(By.CssSelector("[name='register']")).Click();
            IWebElement errorMessage = driver.FindElement(By.TagName("strong"));
            var outerHtml = errorMessage.GetAttribute("outerHTML");
            Assert.DoesNotThrow(() => driver.FindElement(By.TagName("strong")), "Error message is not visible");
        }
        [Test]
        public void LocatingRegPasswordTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement regPassword = driver.FindElement(By.CssSelector("#reg_password"));
            //  var outerHtml = regPassword.GetAttribute("outerHTML");
            const string Text = "somePassword@opp";
            regPassword.SendKeys(Text);
            driver.FindElement(By.CssSelector("[name='register']")).Click();
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='woocommerce']//li[1]"));
            var errorMsgHtml = errorMessage.GetAttribute("outerHTML");
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@class='woocommerce']//li[1]")), "Error message is not visible");

        }
        [Test]
        public void LocatingRegisterButtonTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement regButton = driver.FindElement(By.XPath("//button[@name='register']"));
            var regButtonHtml = regButton.GetAttribute("outerHTML");
            regButton.Click();
            IWebElement errorMessage = driver.FindElement(By.XPath("//div[@class='woocommerce']//li[1]"));
            var errorMsgHtml = errorMessage.GetAttribute("outerHTML");
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//div[@class='woocommerce']//li[1]")), "Error message is not visible");
        }
        [Test]
        public void LocatingProductCategoriesTest()
        {
            driver.FindElement(By.LinkText("Zamknij")).Click();
            IWebElement productCategories = driver.FindElement(By.XPath("//span[contains(text(),'Kategorie produktów')]"));
            var productCategoriesHtml = productCategories.GetAttribute("outerHTML");
         
            Assert.DoesNotThrow(() => driver.FindElement(By.XPath("//span[contains(text(),'Kategorie produktów')]")), "Product Categories name is not visible");
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
