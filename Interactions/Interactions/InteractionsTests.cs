using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace Interactions
{
    public class InteractionsTests
    {
        IWebDriver _driver;
        private Actions _actions;
        private WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _actions = new Actions(_driver);
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
        }

        [Test]
        public void DragAndDropTest1()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));


            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));
            var x = _actions.DragAndDrop(sourceElement, targetElement).Build();
            x.Perform();
            Assert.AreEqual("Dropped!", targetElement.Text, "Drag and drop operation was failed");

        }

        [Test]
        public void DragAndDropTest2()
        {

            _driver.Navigate().GoToUrl("https://jqueryui.com/droppable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));

            IWebElement sourceElement = _driver.FindElement(By.Id("draggable"));
            IWebElement targetElement = _driver.FindElement(By.Id("droppable"));

            var drag = _actions
                 .ClickAndHold(sourceElement)
                 .MoveToElement(targetElement)
                 .Release(sourceElement)
                 .Build();

            drag.Perform();

            Assert.AreEqual("Dropped!", targetElement.Text, "Drag and drop operation was failed");
        }
        [Test]
        public void DragDropExercise()
        {
            _driver.Navigate().GoToUrl("http://www.pureexample.com/jquery-ui/basic-droppable.html");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("ExampleFrame-94")));

            IWebElement sourceElement = _driver.FindElement(By.XPath("//div[@class='square ui-draggable']"));
            IWebElement targetElement = _driver.FindElement(By.XPath("//div[@class='squaredotted ui-droppable']")); ;
            _actions.DragAndDrop(sourceElement, targetElement).Perform();

            var successInfo=_driver.FindElement(By.XPath("//div[@id='info']"));
            Assert.AreEqual("dropped!", successInfo.Text, "Drag and drop operation is not success");
        }
        [Test]
        public void ResizeTest()
        {
            _driver.Navigate().GoToUrl("https://jqueryui.com/resizable/");
            _wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.ClassName("demo-frame")));
            var resizableHandle = _driver.FindElement(By.XPath("//*[@class='ui-resizable-handle ui-resizable-se ui-icon ui-icon-gripsmall-diagonal-se']"));
            _actions.ClickAndHold(resizableHandle).MoveByOffset(200, 100).Perform();

            Assert.IsTrue(_driver.FindElement(By.XPath("//*[@id='resizable'and @style]")).Displayed);
   
        }


        [TearDown]
        public void QuitDriver()
        {
            _driver.Quit();
        }
    }
}