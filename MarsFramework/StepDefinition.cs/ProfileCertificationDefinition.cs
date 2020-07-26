using MarsFramework.Helpers;
using MarsFramework.Pages;
using MarsFramework.Utils;
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
    public sealed class ProfileCertificationDefinition 
    {
        ProfileCertification profilecertification;

        private IWebDriver driver;
        public ProfileCertificationDefinition(IWebDriver _driver)
        {
            driver = _driver;
        }
        [Given(@"I click on certification")]
        public void GivenIClickOnCertification()
        {
            Thread.Sleep(3000);
            //click on Certificate tab
            driver.FindElement(By.XPath("//div[@class='ui top attached tabular menu']/a[4]")).Click();
        }

        [When(@"I add certification")]
        public void WhenIAddCertification()
        {
            profilecertification = new ProfileCertification(driver);
            profilecertification.AddCertification1();
        }

        [Then(@"I should able to validate new certification record Successfully")]
        public void ThenIShouldAbleToValidateNewCertificationRecordSuccessfully()
        {
            profilecertification.ValidateAddcertifications();
        }

        [When(@"I edit my certification")]
        public void WhenIEditMyCertification()
        {
            profilecertification = new ProfileCertification(driver);
            profilecertification.UpdateCertification();
        }

        [Then(@"I should be able to validate updated  certification record successfully")]
        public void ThenIShouldBeAbleToValidateUpdatedCertificationRecordSuccessfully()
        {
            profilecertification.ValidateUpdateCertification();
        }

        [When(@"I delete certification")]
        public void WhenIDeleteCertification()
        {
            profilecertification = new ProfileCertification(driver);
            profilecertification.DeleteCertification();
        }

        [Then(@"I should not be able to able to see deleted certification")]
        public void ThenIShouldNotBeAbleToAbleToSeeDeletedCertification()
        {
            profilecertification.ValidateDeleteCertification();

        }

    }
}
