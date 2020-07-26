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
    public sealed class ProfileSkillDefinition 
    {

        ProfileSkill profileskill;

       
        private IWebDriver driver;
        public ProfileSkillDefinition(IWebDriver _driver)
        {
            driver = _driver;
        }
            [Given(@"I click on skill button")]
        public void GivenIClickOnSkillButton()
        {
            
            //click on Skill
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[2]")).Click();
        }

        

        [When(@"I add skill")]
        public void WhenIAddSkill()
        {
            profileskill = new ProfileSkill(driver);
            profileskill.AddSkills1();
        }

        [Then(@"I should able to validate new  skill record Successfully")]
        public void ThenIShouldAbleToValidateNewSkillRecordSuccessfully()
        {
            profileskill.ValidateAddSkill();
        }

        [When(@"I edit my skill")]
        public void WhenIEditMySkill()
        {
            profileskill = new ProfileSkill(driver);
            profileskill.UpdateSkill();
        }

        [Then(@"I should be able to validate updated skill record successfully")]
        public void ThenIShouldBeAbleToValidateUpdatedSkillRecordSuccessfully()
        {
            profileskill.ValidateUpdateSkill();  
        }

        [When(@"I delete skill")]
        public void WhenIDeleteSkill()
        {
            profileskill = new ProfileSkill(driver);
            profileskill.DeleteSkill();
        }

        [Then(@"I should not be able to able to see deleted skill")]
        public void ThenIShouldNotBeAbleToAbleToSeeDeletedSkill()
        {
            profileskill.ValidateUpdateSkill();
        }

    }
}
