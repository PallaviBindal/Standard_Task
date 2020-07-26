using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using MarsFramework.Pages;
using MarsFramework.Helpers;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using NUnit.Framework;
using DocumentFormat.OpenXml.Bibliography;
using System.Linq.Expressions;
using static MarsFramework.Helpers.ScreenShot;

namespace MarsFramework
{
    public class Profile
    {


        private IWebDriver driver;
        public Profile(IWebDriver _driver)
        {
            driver = _driver;
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement Shareskillbutton { get; set; }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement manageListingsLink { get; set; }

        //Click on old password
        [FindsBy(How = How.XPath, Using = "//input[@name='oldPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement oldpassword { get; set; }

        //Click on new password
        [FindsBy(How = How.XPath, Using = "//input[@name='newPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement newpassword { get; set; }

        //Click on Confirm password
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        //*[@id="listing-management-section"]/section[1]/div/a[3]
        private IWebElement confirmpassword { get; set; }



        [FindsBy(How = How.XPath, Using = "//button[@type='button' and text()='Save']")]

        private IWebElement savebutton { get; set; }


        //Click on search skill
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Search skills'])[1]")]

        private IWebElement searchskill { get; set; }

        //Click on pop up 
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ns-box-inner')]")]

        private IWebElement popup { get; set; }

        //Click on button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]")]


        private IWebElement buttonforskill { get; set; }

        //Click on searchresult
        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Test')]")]

        private IWebElement searchResult { get; set; }


        //Add Availabliity 
        internal string AddAvailability(string availType)
        {
            ExtentionHelpers.TurnOnWait(driver);

            if (availType.ToLower() == "part time")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class='extra content']/div/div[2]/div/span/select"))).SelectByText("Part Time");

                Console.WriteLine("added");
            }
            else if (availType.ToLower() == "full time")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class='extra content']/div/div[2]/div/span/select"))).SelectByText("Full Time");
                Console.WriteLine("added");
            }


            return ReadMessage();

        }


        //Add hours
        internal string AddAvailabilityHour(string hours)
        {
            ExtentionHelpers.TurnOnWait(driver);

            if (hours.ToLower() == "less than 30hours a week")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class ='extra content']/div/div[3]/div/span/select"))).SelectByIndex(0);

                Console.WriteLine("hours added");
            }
            else if (hours.ToLower() == "more than 30hours a week")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class ='extra content']/div/div[3]/div/span/select"))).SelectByIndex(1);

            }
            else if (hours.ToLower() == "as needed")
            {

                new SelectElement(driver.FindElement(By.XPath("//div[@class ='extra content']/div/div[3]/div/span/select"))).SelectByIndex(3);

                Console.WriteLine("hour added");
            }


            return ReadMessage();

        }

        //add Earn Target
        internal string AddEarnTarget(string addEarnTarget)
        {
            ExtentionHelpers.TurnOnWait(driver);

            if (addEarnTarget.ToLower() == "Less than $500 per month")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class = 'extra content']/div/div[4]/div/span/select"))).SelectByIndex(0);

                Console.WriteLine("earn target added");
            }
            else if (addEarnTarget.ToLower() == "between $500 And $1000 per month")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class = 'extra content']/div/div[4]/div/span/select"))).SelectByIndex(1);
                Console.WriteLine("earn target added");
            }
            else if (addEarnTarget.ToLower() == "more than 1000 per month")
            {
                new SelectElement(driver.FindElement(By.XPath("//div[@class = 'extra content']/div/div[4]/div/span/select"))).SelectByIndex(2);
                Console.WriteLine("earn target added");
            }



            return ReadMessage();
        }




        //add description
        internal void addDescription()
        {


            // click on Description edit icon
            // driver.FindElement(By.XPath("//h3[contains(text(),'Description')]/span/i")).Click();

            System.Threading.Thread.Sleep(2000);

            //Clear the text area 
            driver.FindElement(By.XPath("//div[@class='field  ']/textarea")).Clear();

            Thread.Sleep(1500);

            //enter text 
            driver.FindElement(By.XPath("//div[@class='field  ']/textarea")).SendKeys("I am currently intern at MVP studio");

            //click on save button
            driver.FindElement(By.XPath("//button[@class='ui teal button'][@type='button']")).Click();
        }


        internal string ReadMessage()
        {

            Thread.Sleep(3000);

            //ExtentionHelpers.waitClickableElement("//div[contains(@class,'ns-box-inner')]");
            string message = driver.waitForElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;

            // ExtentionHelpers.waitClickableElement("//div[contains(@class,'ns-box-inner')]");
            Thread.Sleep(3000);

            //Assert.That(driver.PageSource.Contains("message"), Is.EqualTo(true), "Availability not updated");
            // Assert.That((String)message, Is.Not.Null, "element not found");
            SaveScreenShotClass save = new SaveScreenShotClass();
            string img = save.SaveScreenshot(driver, "validate pop up message");

            return message;
        }




        internal void changePassword(string Oldpassword, string Newpaasword)
        {
            ExtentionHelpers.TurnOnWait(driver);

            oldpassword.SendKeys(Oldpassword);

            newpassword.SendKeys(Newpaasword);

            ExtentionHelpers.TurnOnWait(driver);

            confirmpassword.SendKeys(Newpaasword);

            // click on save button

            savebutton.Click();
            ExtentionHelpers.TurnOnWait(driver);


        }



        // Validate password changed successfully
        internal void ValidateChangedPassword()
        {

            Thread.Sleep(3000);
            string msg = driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text;

            Console.WriteLine(msg);

            Assert.AreEqual(msg, "Password Changed Successfully");
            SaveScreenShotClass save = new SaveScreenShotClass();
            string img = save.SaveScreenshot(driver, "Validate Password");


        }



        // Search Share Skills 
        public void SearchSkills()
        {




            //click on search button
            driver.FindElement(By.XPath("(//i[@class='search link icon'])[1]")).Click();

            ExtentionHelpers.TurnOnWait(driver);




        }

        internal void FilterandRefineSkill()
        {

            //Click on onsite filter 
            driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")).Click();

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//a[contains(text(),'Programming & Tech')]")).Click();

        }


        internal void ValidateSearchSkill()
        {



            ExtentionHelpers.TurnOnWait(driver);

            Assert.IsNotNull(searchResult);
            SaveScreenShotClass save = new SaveScreenShotClass();
            string img = save.SaveScreenshot(driver, "validate search skill");
        }
    }





























}



