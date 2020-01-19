using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;



namespace TestowyProjekt.WaitExtensions
{
   public static class Wait
    {
        public static WebDriverWait Waiting(this IWebDriver driver)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        public static void WaitForClickable(this IWebDriver driver, By by)
        {
            Waiting(driver).Until(ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
