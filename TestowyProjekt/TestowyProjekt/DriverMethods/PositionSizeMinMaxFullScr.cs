using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestowyProjekt.DriverMethods
{

    class PositionSizeMinMaxFullScr
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void PositionWindowTest()
        {
            Point posiitonWindow = driver.Manage().Window.Position;
            Assert.AreEqual(new Point(9, 9), posiitonWindow, "Position is not correct");
        }
        [Test]
        public void SizeWindowTest()
        {
            Size sizeWindow = driver.Manage().Window.Size;
            Assert.AreEqual(new Size(1051, 806), sizeWindow, "Size is not correct");
        }
        [Test]
        public void MinimalizeWindowTest()
        {
            driver.Navigate().GoToUrl("https://google.pl");
            driver.Manage().Window.Minimize();
        }
        [Test]
        public void MaximizeWindowTest()
        {
            driver.Navigate().GoToUrl("https://google.pl");
            driver.Manage().Window.Maximize();
        }
        [Test]
        public void FullScreenWindowTest()
        {
            driver.Navigate().GoToUrl("https://google.pl");
            driver.Manage().Window.FullScreen();
        }

        [TearDown]
          public void QuitDriver()
        {
            driver.Quit();
        }

    }

}
