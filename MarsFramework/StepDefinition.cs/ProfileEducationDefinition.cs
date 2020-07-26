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
    public sealed class ProfileEducationDefinition
    {

        ProfileEducation profileeducation;
        private IWebDriver driver;
        public ProfileEducationDefinition(IWebDriver _driver)
        {
            driver = _driver;
        
        }



        [Given(@"I click on education button")]
        public void GivenIClickOnEducationButton()
        {
           

            // Click on Education tab
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[3]")).Click();

           }

            [When(@"I add education")]
        public void WhenIAddEducation()
        {
            profileeducation = new ProfileEducation(driver);
            profileeducation.AddEducation1();
        }

        [Then(@"I should able to validate new education record Successfully")]
        public void ThenIShouldAbleToValidateNewEducationRecordSuccessfully()
        {
            profileeducation.ValidateAdd();
        }

        [When(@"I edit my education")]
        public void WhenIEditMyEducation()
        {
            profileeducation = new ProfileEducation(driver);
            profileeducation.UpdateEducation();
        }

        [Then(@"I should be able to validate updated education record successfully")]
        public void ThenIShouldBeAbleToValidateUpdatedEducationRecordSuccessfully()
        {
            profileeducation.Updatevalidate();
        }

        [When(@"I delete education")]
        public void WhenIDeleteEducation()
        {
            profileeducation = new ProfileEducation(driver);
            profileeducation.DeleteEduation();
        }

        [Then(@"I should not be able to able to see deleted education")]
        public void ThenIShouldNotBeAbleToAbleToSeeDeletedEducation()
        {
            profileeducation.DeleteValidation();

        }

    }
}
