using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using ExcelDataReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Docker.DotNet.Models;
using MarsFramework.Pages;

namespace MarsFramework.Helpers
{
   

    public static class ExtentionHelpers
    {
        private  static IWebDriver Driver { get; set; }


       

        



        //explicit wait until element is clickable
        public static void waitClickableElement(this IWebDriver driver,string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitClickableElement", ex.Message);
            }

        }
            
        //explicit wait until element is visible
        public static  void waitElementIsVisible(this IWebDriver driver,string locatorValue)
        {
            try
            {
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 20));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath(locatorValue)));

            }
            catch (Exception ex)
            {
                Assert.Fail("Exception at waitElementIsVisible", ex.Message);
            }

        }
        public static IWebElement waitForElement(this IWebDriver driver, By ele, int timeOutinSeconds = 20)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
                return wait.Until(x => x.FindElement(ele));

            }
            catch (Exception)
            {
                throw;
            }

        }







        public static bool WaitforElementDisplayed(this IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return (wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by)).Displayed);
        }

        public static IWebElement WaitforElementClickable(this IWebElement element, IWebDriver driver, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(element));
        }
















        // generic method that allows driver to wait until element is clickable
        //public void waitClickableElement(IWebDriver driver, string locator, string locatorValue)
        //{
        //    try
        //    {
        //        if (locator == "Id")
        //        {
        //            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorValue)));
        //        }
        //        if (locator == "XPath")
        //        {
        //            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorValue)));
        //        }
        //        if (locator == "CSSSelector")
        //        {
        //            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
        //            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorValue)));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.Fail("Excetion at waitClickableElement", ex.Message);
        //    }

        //}


        //Implicit Wait
        public static void TurnOnWait(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        }

        //close the browser
        public static void close()
        {
          // ExtentionHelpers.Driver.();
       }


    }
}

