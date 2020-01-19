using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;


namespace TestowyProjekt.Exercises
{
    class Zadanie4
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driver.Navigate().GoToUrl("https://fakestore.testelka.pl/moje-konto/");
        }
        [Test]
        public void HeaderNavigateTest()
        {
            IWebElement tagName = driver.FindElement(By.TagName("article"));
            IWebElement headerName = tagName.FindElement(By.ClassName("entry-title"));
            string outerHtml = headerName.GetAttribute("outerHTML");
        }
        [Test]
        public void LoginNavigateTest()
        {
            IWebElement idElement = driver.FindElement(By.Id("username"));
            string outerHtml = idElement.GetAttribute("outerHTML");
        }
        [Test]
        public void PasswordNavigateTest()
        {
            IWebElement passwordElement = driver.FindElement(By.Id("password"));
            string outerHtml = passwordElement.GetAttribute("outerHTML");
        }
        [Test]
        public void CheckboxdNavigateTest()
        {
            IWebElement checkboxElement = driver.FindElement(By.Name("rememberme"));
            string outerHtml = checkboxElement.GetAttribute("outerHTML");

        }
        [Test]
        public void ButtonNavigateTest()
        {
            IWebElement buttonElement = driver.FindElement(By.Name("login"));
            string outerHtml = buttonElement.GetAttribute("outerHTML");
        }
        [Test]
        public void LinkNavigateTest()
        {
            IWebElement linkElement = driver.FindElement(By.LinkText("Nie pamiętasz hasła?"));
            string outerHtml = linkElement.GetAttribute("outerHTML");
        }
        [Test]
        public void CssSelectorNavigateTest()
        {
            driver.Navigate().GoToUrl("https://fakestore.testelka.pl/");
            driver.FindElement(By.LinkText("Zamknij")).Click();
            driver.FindElement(By.CssSelector("[data-product_id='393']")).Click();
        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
