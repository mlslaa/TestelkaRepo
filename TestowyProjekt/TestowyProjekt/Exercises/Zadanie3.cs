using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TestowyProjekt.Exercises
{
    class Zadanie3
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
        }
        [Test]
        public void SetWindowSizeTest()
        {
            Size windowSize = driver.Manage().Window.Size;
            windowSize = new System.Drawing.Size(854, 480);
            Assert.AreEqual(new Size(854,480),  windowSize, "size is not correct" );
        }
        [Test]
        public void SetWindowPositionTest()
        {
            Point windowPosition= driver.Manage().Window.Position;
            windowPosition = new System.Drawing.Point(445, 30);
            Assert.AreEqual(new Point(445, 30), windowPosition, "position is not correct");
        }
        [TearDown]
        public void QutDriver()
        {
            driver.Quit();
        }
    }
}
