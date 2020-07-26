
using DocumentFormat.OpenXml.Wordprocessing;
using MarsFramework.Helpers;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using SeleniumExtras.PageObjects;

namespace MarsFramework.Pages
{
    class SignIn
    {
        private readonly IWebDriver Driver;
        public SignIn(IWebDriver _driver)
        {
            Driver = _driver;


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "Credentials");
            PageFactory.InitElements(Driver, this);
        }

        #region  Initialize Web Elements 
        //Finding the Sign Link
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Sign In')]")]
        public IWebElement SignIntab { get; set; }

        // Finding the Email Field
        [FindsBy(How = How.Name, Using = "email")]
        public IWebElement Email { get; set; }

        //Finding the Password Field
        [FindsBy(How = How.Name, Using = "password")]
        public IWebElement Password { get; set; }

        //Finding the Login Button
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Login')]")]
        public IWebElement LoginBtn { get; set; }

        #endregion


        public void LoginSteps()
        {
           
            //Click on Join button
            SignIntab.Click();

            //Enter First Name
            Email.SendKeys(ExcelLibHelper.ReadData(2, "username"));

            //Enter LastName
            Password.SendKeys(ExcelLibHelper.ReadData(2, "password"));

            //Enter click button
            LoginBtn.Click();




        }


    }
}