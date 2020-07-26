using System;

using DocumentFormat.OpenXml.Wordprocessing;
using MarsFramework.Helpers;
using OpenQA.Selenium;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class Signup
    {

        private IWebDriver driver;
        public Signup(IWebDriver _driver)
        {
            driver = _driver;


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "SignUp");
            PageFactory.InitElements(driver, this);
        }
        #region  Initialize Web Elements 
        //Finding the Join 
        [FindsBy(How = How.XPath, Using = "//*[@id='home']//button[text()='Join']")]
        private IWebElement Join { get; set; }

        //Identify FirstName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='firstName']")]
        private IWebElement FirstName { get; set; }

        //Identify LastName Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='lastName']")]
        private IWebElement LastName { get; set; }

        //Identify Email Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='email']")]
        private IWebElement Email { get; set; }

        //Identify Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='password']")]
        private IWebElement Password { get; set; }

        //Identify Confirm Password Textbox
        [FindsBy(How = How.XPath, Using = "//input[@name='confirmPassword']")]
        private IWebElement ConfirmPassword { get; set; }

        //Identify Term and Conditions Checkbox
        [FindsBy(How = How.XPath, Using = "//input[@name='terms']")]
        private IWebElement Checkbox { get; set; }

        //Identify join button
        [FindsBy(How = How.XPath, Using = "//*[@id='submit-btn']")]
        private IWebElement JoinBtn { get; set; }
        #endregion

        internal void register()
        {



            //Click on Join button
            Join.Click();
            Thread.Sleep(2000);

            //Enter FirstName
            FirstName.SendKeys(ExcelLibHelper.ReadData(2, "FirstName"));

            //Enter LastName
            LastName.SendKeys(ExcelLibHelper.ReadData(2, "LastName"));

            //Enter Email
            Email.SendKeys(ExcelLibHelper.ReadData(2, "Email"));

            //Enter Password
            Password.SendKeys(ExcelLibHelper.ReadData(2, "Password"));

            //Enter Password again to confirm
            ConfirmPassword.SendKeys(ExcelLibHelper.ReadData(2, "Confirm Password"));

            //Click on Checkbox
            Checkbox.Click();

            //Click on join button to Sign Up
            JoinBtn.Click();


        }





    }
}