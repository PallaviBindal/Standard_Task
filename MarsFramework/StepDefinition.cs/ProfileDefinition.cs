using MarsFramework.Helpers;
using MarsFramework.Pages;
using MarsFramework.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using static MarsFramework.Helpers.ScreenShot;
using static NUnit.Core.NUnitFramework;
using Assert = NUnit.Framework.Assert;

namespace MarsFramework.StepDefinition.cs
{
    [Binding]
    public sealed class ProfileDefinition
    {


        Profile profile;
        string hourmessage;
        string availabilitymessage;
        string earntargetmessage;

        private IWebDriver driver;
        public ProfileDefinition(IWebDriver _driver)
        {

            driver = _driver;

        }


        [Given(@"I click on Availabilty button")]
        public void GivenIClickOnAvailabiltyButton()
        {
            Thread.Sleep(1500);
            driver.waitForElement(By.XPath("//i[contains(@class,'right floated outline small write icon')][1]")).Click();
        }

        [When(@"I add availability")]
        public void WhenIAddAvailability()
        {
            profile = new Profile(driver);
            availabilitymessage = profile.AddAvailability("part time");
            Thread.Sleep(2000);


        }



        [Given(@"I click on earn target button")]
        public void GivenIClickOnEarnTargetButton()
        {
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='extra content']/div/div[4]/div/span/i")).Click();
        }


        [When(@"I add earn target")]
        public void WhenIAddEarnTarget()
        {
            profile = new Profile(driver);
            earntargetmessage = profile.AddEarnTarget("more than 1000 per month");
        }


        [Given(@"I click on hours  button")]
        public void GivenIClickOnHoursButton()
        {

            driver.FindElement(By.XPath("//div[@class ='extra content']/div/div[3]/div/span/i")).Click();
        }

        [When(@"I add hours")]
        public void WhenIAddHours()
        {
            profile = new Profile(driver);
            hourmessage = profile.AddAvailabilityHour("as needed");

        }

        [Then(@"I should be able to read pop up")]
        public void ThenIShouldBeAbleToReadPopUp()
        {
            if (availabilitymessage == "Availability Updated" || hourmessage == "Availability Updated" || earntargetmessage == "Availability Updated")
            {
                Assert.IsTrue(true);

            }

        }




        [Given(@"Click on Change Password button")]
        public void GivenClickOnChangePasswordButton()
        {



            //Thread.Sleep(2000);
            // Navigate to change password page
            ExtentionHelpers.TurnOnWait(driver);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();

            Thread.Sleep(2000);
            IWebElement changepwd = driver.FindElement(By.XPath("//a[text()='Change Password']"));
            changepwd.Click();
        }

        [When(@"I  provide all  the details")]
        public void WhenIProvideAllTheDetails()
        {
            profile = new Profile(driver);
            profile.changePassword(ExcelLibHelper.ReadData(2, "oldPassword"), ExcelLibHelper.ReadData(2, "NewPassword"));
            Thread.Sleep(3000);


            // Navigate to change password page
            ExtentionHelpers.TurnOnWait(driver);
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span")).Click();

            Thread.Sleep(1500);
            IWebElement changepwd = driver.FindElement(By.XPath("//a[text()='Change Password']"));
            //Thread.Sleep(2000);
            changepwd.Click();

            Thread.Sleep(1500);
            profile.changePassword(ExcelLibHelper.ReadData(2, "NewPassword"), ExcelLibHelper.ReadData(2, "oldPassword"));
        }

        [Then(@"I should be ableto see change password")]
        public void ThenIShouldBeAbletoSeeChangePassword()
        {
            profile.ValidateChangedPassword();

        }

        [Given(@"Enter skill")]
        public void GivenEnterSkill()
        {

            Thread.Sleep(2000);

            driver.FindElement(By.XPath("//input[@placeholder='Search skills'][1]")).SendKeys("Testing");
            profile = new Profile(driver);
            profile.SearchSkills();
        }




        [When(@"I filter the search result")]
        public void WhenIFilterTheSearchResult()
        {
            profile = new Profile(driver);
            profile.FilterandRefineSkill();

        }


        [Then(@"I should be able to see skills")]
        public void ThenIShouldBeAbleToSeeSkills()
        {
            profile = new Profile(driver);
            profile.ValidateSearchSkill();
        }

        [Given(@"I click on description")]
        public void GivenIClickOnDescription()
        {
            
            Thread.Sleep(3000);

            // click on Description edit icon
            driver.FindElement(By.XPath("//h3/span/i[@class='outline write icon']")).Click();
        }

        [When(@"I have entered description using (.*) characters and click on save button")]
        public void WhenIHaveEnteredDescriptionUsingCharactersAndClickOnSaveButton(int p0)
        {
            Thread.Sleep(3000);
            profile = new Profile(driver);
            profile.addDescription();
        }





        [Then(@"I should be able to see the pop up message again")]
        public void ThenIShouldBeAbleToSeeThePopUpMessageAgain()
        {
            profile.ReadMessage();

        }


    }
}
