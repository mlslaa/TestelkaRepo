using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestowyProjekt.DriverMethods
{
    class Zadanie2
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
        [Test]
        public void RevievSpainTitleTest()
        {
            string titleText = "Wikipedia, la enciclopedia libre";
            driver.Navigate().GoToUrl("https://es.wikipedia.org/");
            Assert.AreEqual(titleText, driver.Title, "title is not correct");
        }
        [Test]
        public void RevievSpainSourceTest()
        {
            string langText = "lang=\"es\"";
            driver.Navigate().GoToUrl("https://es.wikipedia.org/");
            Assert.IsTrue(driver.PageSource.Contains(langText), "source is not correct");
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
