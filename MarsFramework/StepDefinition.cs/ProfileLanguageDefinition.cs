using MarsFramework.Helpers;
using MarsFramework.Pages;
using MarsFramework.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MarsFramework.StepDefinition.cs
{
    [Binding]
    public class ProfileLanguageDefinition 
    
    
    
    {


        ProfileLanguage profilelanguage;
        private IWebDriver driver;
        public ProfileLanguageDefinition(IWebDriver _driver)
        {
            driver = _driver;
        
        }


       

        [Given(@"I click on language button")]
        public void GivenIClickOnLanguageButton()
        {
            
            // Click on Language tab
            driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
        }



        [Then(@"I should able to validate new record Successfully")]
        public void ThenIShouldAbleToValidateNewRecordSuccessfully()
        {
         
            profilelanguage.ValidateAddLanguage();
        }

        [Then(@"I should be able to validate updated record successfully")]
        public void ThenIShouldBeAbleToValidateUpdatedRecordSuccessfully()
        {
            profilelanguage.ValidateUpdateLanguage(); 
        }

        [When(@"I add language")]
        public void WhenIAddLanguage()
        {
            profilelanguage = new ProfileLanguage(driver);
            profilelanguage.Addlanguage();
        }

        [When(@"I edit my language")]
        public void WhenIEditMyLanguage()
        {
            profilelanguage = new ProfileLanguage(driver);
            profilelanguage.UpdateLanguage();
        }

        [When(@"I delete language")]
        public void WhenIDeleteLanguage()
        {
            profilelanguage = new ProfileLanguage(driver);
            profilelanguage.DeleteLanguage();
        }

        [Then(@"I should not be able to able to see deleted language")]
        public void ThenIShouldNotBeAbleToAbleToSeeDeletedLanguage()
        {
            profilelanguage.ValidateDeleteLanguage();
        }

    }
}
