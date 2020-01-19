using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestowyProjekt.FakestoreMyTests
{
    class Fakestore
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(7);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);
        }
        [Test]
        public void DropDownListTest()
        {
            driver.Navigate().GoToUrl("https://fakestore.testelka.pl/product-category/wspinaczka/");
            driver.FindElement(By.LinkText("Zamknij")).Click();

            IWebElement orderby = driver.FindElement(By.XPath("//div[@class='col-full']//div[1]//form[1]//select[1]"));
            string orderbyHtml = orderby.GetAttribute("outerHTML");
            orderby.Click();
            IWebElement sortByNew = driver.FindElement(By.XPath("//div[@class='col-full']//div[1]//form[1]//select[1]//option[4]"));
            sortByNew.Click();
            Assert.AreEqual("https://fakestore.testelka.pl/product-category/wspinaczka/?orderby=date", driver.Url, "Sort by date url is not correct");
        }
        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
