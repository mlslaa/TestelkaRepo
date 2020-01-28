using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace TestowyProjekt.UdemyTestAutomation
{
    class ExplicitWaitExercise
    {
        IWebDriver driver = new ChromeDriver();
        [SetUp]
        public void SetUp()
        {
        }
        [Test]
        public void SynchronizeTest()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/");
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='et_pb_module et_pb_image et_pb_image_0 et-animated et_had_animation']//img")));
            driver.FindElement(By.XPath("//ul[@id='top-menu']//a[contains(text(),'Automation Exercises')]")).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[contains(text(),'Big page with many elements')]")));
            driver.FindElement(By.XPath("//a[contains(text(),'Big page with many elements')]")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='tcb-button-text thrv-inline-text']")));
            Assert.IsTrue(wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@class='tcb-button-text thrv-inline-text']"))).Displayed);
        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
