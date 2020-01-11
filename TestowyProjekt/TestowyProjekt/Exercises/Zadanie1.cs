using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestowyProjekt.DriverMethods
{
    class Zadanie1
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
        public void BackToWikipediaTest()
        {
            string searchWikipedia = "https://pl.wikipedia.org/wiki/Wikipedia:Strona_g%C5%82%C3%B3wna";
            driver.Navigate().GoToUrl(searchWikipedia);
            string searchNasa = "https://www.nasa.gov/";
            driver.Navigate().GoToUrl(searchNasa);
            driver.Navigate().Back();
            Assert.AreEqual(searchWikipedia, driver.Url, "Url is not correct");
        }
        [Test]
        public void ForwardToNasaTest()
        {
            string searchWikipedia = "https://pl.wikipedia.org/wiki/Wikipedia:Strona_g%C5%82%C3%B3wna";
            driver.Navigate().GoToUrl(searchWikipedia);
            string searchNasa = "https://www.nasa.gov/";
            driver.Navigate().GoToUrl(searchNasa);
            driver.Navigate().Back();
            driver.Navigate().Forward();
            Assert.AreEqual(searchNasa, driver.Url, "Url is not correct");
        }
        [TearDown]
        public void QutAndClose()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
