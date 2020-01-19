using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestowyProjekt.DriverMethods
{
    class TitleUrlAndSource
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);
            driver.Manage().Timeouts().PageLoad = System.TimeSpan.FromSeconds(5);
        }
        [Test]
        public void RevievTitleTest()
        {
            String titleText = "Wikipedia, wolna encyklopedia";
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.AreEqual(titleText, driver.Title, "title is not correct");
        }
        [Test]
        public void RevievUrlTest()
        {
            String urlText = "https://pl.wikipedia.org/wiki/Wikipedia:Strona_g%C5%82%C3%B3wna";
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.AreEqual(urlText, driver.Url, "url is not correct");
        }
        [Test]
        public void RevievSourceTest()
        {
            String imgText = "Johann Wilhelm Ritter.jpg";
            driver.Navigate().GoToUrl("https://pl.wikipedia.org/");
            Assert.False(driver.PageSource.Contains(imgText), "source is not correct");
        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
