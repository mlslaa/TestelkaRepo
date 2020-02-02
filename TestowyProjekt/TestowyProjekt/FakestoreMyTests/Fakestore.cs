using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Data;
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
            driver.Navigate().Refresh();

            IWebElement orderby = driver.FindElement(By.XPath("//div[@class='col-full']//div[1]//form[1]//select[1]"));
            string orderbyHtml = orderby.GetAttribute("outerHTML");
            orderby.Click();
            IWebElement sortByNew = driver.FindElement(By.XPath("//div[@class='col-full']//div[1]//form[1]//select[1]//option[4]"));
            sortByNew.Click();
            Assert.AreEqual("https://fakestore.testelka.pl/product-category/wspinaczka/?orderby=date", driver.Url, "Sort by date url is not correct");
        }
        [Test]
        public void UdemyExercisesNavigationTest()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/filling-out-forms/");
            var contactNameField = driver.FindElements(By.Id("et_pb_contact_name_1"));

            contactNameField[0].SendKeys("x");
            var messageField = driver.FindElements(By.Id("et_pb_contact_message_1"));

            messageField[0].SendKeys("y");
            var contactQuestion = driver.FindElement(By.ClassName("et_pb_contact_captcha_question"));
            var table = new DataTable();
            var answerContactQuestion = (int)table.Compute(contactQuestion.Text, "");
            var questionCheckBox = driver.FindElement(By.XPath("//input[@name='et_pb_contact_captcha_1']"));
            questionCheckBox.SendKeys(answerContactQuestion.ToString());
            var submitBtn = driver.FindElements(By.XPath("//div[@id='et_pb_contact_form_1']//button[@name='et_builder_submit_button'][contains(text(),'Submit')]"))[0];
            submitBtn.Submit();
            var successMsg = driver.FindElement(By.XPath("//p[contains(text(),'Success')]"));
            Assert.IsTrue(successMsg.Text.Equals("Success"));
        }
        [Test]
        public void UdemyInterrogationElementsTest()
        {
            driver.Navigate().GoToUrl("https://ultimateqa.com/simple-html-elements-for-automation/");
            driver.Manage().Window.Maximize();
            var buttonCLickMe = driver.FindElement(By.Id("button1"));
            string buttonClickMeType = buttonCLickMe.GetAttribute("type");
            Assert.AreEqual("submit", buttonClickMeType, "Button type is not correct");
            var buttonCssValue = buttonCLickMe.GetCssValue("vertical-align");
            Assert.AreEqual("baseline", buttonCssValue, "Css value is not correct");
            var buttonLetterSpacing = buttonCLickMe.GetCssValue("letter-spacing");
            Assert.AreEqual("normal", buttonLetterSpacing, "Button Letter spacing is not correct");
            var buttonDisplayed = buttonCLickMe.Displayed;
            Assert.AreEqual(true, buttonDisplayed, "Button dysplaye status is not correct");
            Assert.AreEqual(true, buttonCLickMe.Enabled, "Button enable status is not correct");
            Assert.AreEqual(false, buttonCLickMe.Selected, "Button select status is not correct");
            Assert.AreEqual("Click Me!", buttonCLickMe.Text, "Button text is not correct");
            Assert.AreEqual("button", buttonCLickMe.TagName, "Button tag name is not correct");
            Assert.AreEqual(22, buttonCLickMe.Size.Height, "Button height is not correct");
            Assert.AreEqual(190, buttonCLickMe.Location.X, "Buttonlocation x is not correct");
            Assert.AreEqual(330, buttonCLickMe.Location.Y, "Buttonlocation y is not correct");


        }


        [TearDown]
        public void QuitDriver()
        {
            driver.Quit();
        }
    }
}
