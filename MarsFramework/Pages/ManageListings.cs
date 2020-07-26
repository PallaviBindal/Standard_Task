using MarsFramework.Helpers;
using OpenQA.Selenium;
using System;
using static NUnit.Core.NUnitFramework;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System.Xml.Serialization;
using FluentAssertions.AssertMultiple;
using Assert = NUnit.Framework.Assert;
using static MarsFramework.Helpers.ScreenShot;

namespace MarsFramework.Pages
{
    public class ManageListings
    {
        //Constructor

        private IWebDriver driver;
        public ManageListings(IWebDriver _driver)
        {
            driver = _driver;
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "ManageListing");
            PageFactory.InitElements(driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement Update { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }

        //Clcik on yes 
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement clickYes { get; set; }

        //Click on No
        [FindsBy(How = How.XPath, Using = "//button[@class='ui negative button']")]
        private IWebElement clickNo { get; set; }

        //Click on ManageLsiting Link
        public void clickonmanagelisting()
        {
            //Click on Manage listing skill
            manageListingsLink.Click();
        }

        //Delete Record
        public void RemoveManageListing()
        {

            ExtentionHelpers.TurnOnWait(driver);
            //Click on yes button
            clickYes.Click();



            // Driver.waitElement(@"//div[@class='ns-box-inner']");
            Thread.Sleep(3000);
            //Get the message of pop up 
            var message = driver.FindElement(By.XPath(@"//div[@class='ns-box-inner']")).Text;

            // Explicit Wait
            // ExtentionHelpers.WaitforElementDisplayed(@"//div[@class='ns-box-inner']");

            //print message on Console
            Console.WriteLine(message);

            //  Assert.That(driver.PageSource.Contains("Selenium has been deleted"),Is.EqualTo(true), "Selenium has not been deleted");

            //Validate if expected message is equal to actual
            Assert.That(message, Is.EqualTo("Selenium has been deleted"));

            SaveScreenShotClass save = new SaveScreenShotClass();
            string img = save.SaveScreenshot(driver, "ServiceDeleted");
        }




        //Validation 
        public void ValidateManageListing()
        {

            try
            {
                //iterate from start record to end record on first page 
                for (var i = 1; i <= 5; i++)
                {
                    //Text of Title
                    var title = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]")).Text;

                    ExtentionHelpers.TurnOnWait(driver);
                    //Text of Description
                    var testdescription = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[4]")).Text;

                    // Text of Category
                    var category = driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[2]")).Text;

                    //Check whether expected result is equal to actual result
                    Assert.Multiple(() =>
                    {
                        Assert.That(title, Is.EqualTo("Selenium"));
                        Assert.That(testdescription, Is.EqualTo("Provide Training on Selenium"));
                        Assert.That(category, Is.EqualTo("Programming & Tech"));
                    });

                    SaveScreenShotClass save = new SaveScreenShotClass();
                    string img = save.SaveScreenshot(driver, "validate service");

                    //Print message on Console
                    Console.WriteLine("Assertion Pass");

                    break;
                }


            }
            catch (Exception)
            {
                Console.WriteLine("Test Failed");

            }
        }








    }
}







































































