using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MarsFramework.StepDefinition.cs
{
    [Binding]
    public sealed class LoginDefinition
    {
        private IWebDriver driver;
        public LoginDefinition(IWebDriver _driver)
        {
            driver = _driver;
        }
        [Given(@"I navigate to url")]
        public void GivenINavigateToUrl()
        {
            Console.WriteLine("I navigate to url");
        }
        [When(@"I enter username and password and click button")]
        public void WhenIEnterUsernameAndPasswordAndClickButton()
        {
            //SignIn.SigninStep();
            Console.WriteLine("I logged into the portal");

        }

        [Then(@"I should be able to see home page")]
        public void ThenIShouldBeAbleToSeeHomePage()
        {
            //assertion to check the title of the page 

           string s1 = driver.Title;
            Console.WriteLine(s1);

           Assert.That(s1, Is.EqualTo("Home"));
            Console.WriteLine("Assertion Pass");
            Console.WriteLine("home page opened successfully");
        }

    }
}
