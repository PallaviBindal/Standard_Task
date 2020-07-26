using MarsFramework.Helpers;
using MarsFramework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsFramework.StepDefinition.cs
{
    [Binding]
    public sealed class shareskillStepDefinition
    {

        ShareSkill shareskill;
        ManageListings manageListings;
        private IWebDriver driver;
        public shareskillStepDefinition(IWebDriver _driver)
        {
            driver = _driver;
        }
            [Given(@"Click on ShareSkill tab")]
        public void GivenClickOnShareSkillTab()
        {
           

            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//a[contains(.,'Share Skill')]")).Click();


        }

        [When(@"I provide all details of service and click on save button")]
        public void WhenIProvideAllDetailsOfServiceAndClickOnSaveButton()
        {
            shareskill = new ShareSkill(driver);
            shareskill.AdShareSkills();
           
        }

        [Then(@"Service list should be displayed on managelisting page")]
        public void ThenServiceListShouldBeDisplayedOnManagelistingPage()
        {
            manageListings = new ManageListings(driver);
            manageListings.ValidateManageListing();
        }


    }
}
