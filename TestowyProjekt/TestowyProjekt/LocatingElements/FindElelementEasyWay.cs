using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestowyProjekt.LocatingElements
{
    class FindElelementEasyWay
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
        }
        [Test]
        public void LocatingElementTest()
        {
            driver.Navigate().GoToUrl("https://fakestore.testelka.pl/");
            IWebElement header = driver.FindElement(By.TagName("header"));
            IWebElement search = header.FindElement(By.Name("s"));
            search.SendKeys("el gouna");
            search.Submit();
            Assert.AreEqual("Egipt – El Gouna – FakeStore", driver.Title, "Page title is not correct");
        }

        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }

    }
}
