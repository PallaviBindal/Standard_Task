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
    public sealed class ManageListingDefinition
    {
        ShareSkill shareskill;
        ManageListings manageListings;
        private IWebDriver driver;
        public ManageListingDefinition(IWebDriver _driver)
        {

            driver = _driver;
        
        }
        [Given(@"I Click on Manage Listings tab on profile page")]
        public void GivenIClickOnManageListingsTabOnProfilePage()
        {
            
            manageListings = new ManageListings(driver);
            Thread.Sleep(2000);
            manageListings.clickonmanagelisting();
        }

        [When(@"I click on update icon and add new service")]
        public void WhenIClickOnUpdateIconAndAddNewService()
        {
            //click on update 
            Thread.Sleep(2000);
           driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i")).Click();
            shareskill = new ShareSkill(driver);
            
            Thread.Sleep(2000);
            shareskill.AdShareSkills();


        }

        [Then(@"I should be able to see updated service")]
        public void ThenIShouldBeAbleToSeeUpdatedService()
        {
            manageListings = new ManageListings(driver);
            manageListings.ValidateManageListing();
        }

        [When(@"I click on delete icon")]
        public void WhenIClickOnDeleteIcon()
        {
            ExtentionHelpers.TurnOnWait(driver);
            driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]/i")).Click();


        }

        [Then(@"I should be able to see confirmation message")]
        public void ThenIShouldBeAbleToSeeConfirmationMessage()
        {
            manageListings = new ManageListings(driver);
            manageListings.RemoveManageListing();

        }


    }
}
