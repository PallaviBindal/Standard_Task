using SeleniumExtras.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using MarsFramework.Pages;
using MarsFramework.Helpers;
using static NUnit.Core.NUnitFramework;
using NUnit.Framework;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using static MarsFramework.Helpers.ScreenShot;
using AventStack.ExtentReports;
using static MarsFramework.Utils.Hook;
using AventStack.ExtentReports.Reporter;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;

namespace MarsFramework.Pages
{
    class ProfileLanguage
    {


        private IWebDriver driver;
        public ProfileLanguage(IWebDriver _driver)
        {
            driver = _driver;

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            PageFactory.InitElements(driver, this);
        }

        //Language button
        [FindsBy(How = How.XPath, Using = "//a[text()='Languages']")]
        public IWebElement LanguageButton { get; set; }

        //Add new Language
        [FindsBy(How = How.XPath, Using = "//div[@class='eight wide column']/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/thead/tr/th[3]/div[1]")]
        public IWebElement AddNewLanguage { get; set; }

        //Add Language Level
        [FindsBy(How = How.XPath, Using = "//select[@name ='level']")]
        public IWebElement LanguageLevel { get; set; }

        //LAnguage text
        [FindsBy(How = How.XPath, Using = "//input[@name ='name']")]
        public IWebElement LanguageText { get; set; }

        //Add LAnguage
        [FindsBy(How = How.XPath, Using = "//input[@value='Add']")]
        public IWebElement AddLanguage { get; set; }

        //Update Language
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
        public IWebElement UdpateLanguage { get; set; }

        //Update button
        [FindsBy(How = How.XPath, Using = "//input[contains(@type,'button')][1]")]
        public IWebElement UpdateButton { get; set; }

        //Pop up 
        [FindsBy(How = How.XPath, Using = "//div[contains(@class,'ns-box-inner')")]
        public IWebElement PopUp { get; set; }



        //Add new Lanuguage
        internal void Addlanguage()
        {
            Console.WriteLine("******************************");

            //implicit wait 
            ExtentionHelpers.TurnOnWait(driver);

            //click on add new button
            AddNewLanguage.Click();

            ExtentionHelpers.TurnOnWait(driver);
            //enter text in language field
            LanguageText.SendKeys(ExcelLibHelper.ReadData(3, "Language"));

            //select level from drop down

            new SelectElement(driver.FindElement(By.XPath("//select[@class='ui dropdown']"))).SelectByValue(ExcelLibHelper.ReadData(2, "LanguageLevel"));

            ExtentionHelpers.TurnOnWait(driver);

            //click on add button
            AddLanguage.Click();

            ExtentionHelpers.TurnOnWait(driver);

            Console.WriteLine("Language added");
            Console.WriteLine("******************************");

        }

        //Validate new Language
        internal void ValidateAddLanguage()
        {
            Console.WriteLine("******************************");
            try
            {
                //Start the Reports
                // test = extent.CreateTest("Add Language");
                // test.Log(Status.Info, "Add new language");

                //language test
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

                //click on language button
                // LanguageButton.Click();

                //text lang
                String Lang = driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[1])[1]")).Text;

                ExtentionHelpers.TurnOnWait(driver);

                //text level
                String level = driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")).Text;

                //Validation
                Assert.Multiple(() =>
                {
                    Assert.AreEqual(Lang, ExcelLibHelper.ReadData(3, "Language"));

                    Assert.AreEqual(level, ExcelLibHelper.ReadData(2, "LanguageLevel"));
                });


                SaveScreenShotClass save = new SaveScreenShotClass();
                string img = save.SaveScreenshot(driver, "AddLanguage");

                Console.WriteLine("Assertion Pass");
                Console.WriteLine("******************************");


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //update Language
        internal void UpdateLanguage()
        {
            {
                for (int j = 1; j <= 4; j++)
                {
                    ExtentionHelpers.TurnOnWait(driver);
                    //get the value of text language
                    var languagetext = driver.FindElement(By.XPath("//div/table/tbody[" + j + "]/tr/td[1]")).Text; ;


                    ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");

                    //Compare the text
                    if (languagetext == (ExcelLibHelper.ReadData(3, "Language")))
                    {

                        //Click on pen icon update
                        driver.FindElement(By.XPath("//div[@data-tab = 'first']/div/div[2]/div/table/tbody[" + j + "]/tr/td[3]/span[1]")).Click();

                        //update language 
                        IWebElement languageedit = driver.FindElement(By.XPath("//div[@data-tab = 'first']/div/div[2]/div/table/tbody[" + j + "]/tr/td/div/div/input[1]"));
                        languageedit.Clear();

                        languageedit.SendKeys(ExcelLibHelper.ReadData(4, "Language"));

                        //update language level
                        SelectElement s = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'first']/div/div[2]/div/table/tbody[" + j + "]/tr/td/div/div[2]/select")));
                        s.SelectByText("Basic");

                        //click on update
                        driver.FindElement(By.XPath("//div[@data-tab = 'first']/div/div[2]/div/table/tbody[" + j + "]/tr/td/div/span/input[1]")).Click();

                        Console.WriteLine("Language updated");


                    }
                    break;
                }

            }





        }


        //Validate update language 

        internal void ValidateUpdateLanguage()
        {
            try
            {

                //check language
                LanguageButton.Click();

                ExtentionHelpers.TurnOnWait(driver);

                //Lanuguage text
                //String Lang = Driver.driver.FindElement(By.XPath("//a[@class='item'][contains(.,'Languages')]")).Text;
                String Lang = driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[1])[1]")).Text;

                //Level Text
                String level = driver.FindElement(By.XPath("(//div[@data-tab='first']//table//tbody//tr[1]//td[2])[1]")).Text;

                //Assertions
                Assert.Multiple(() =>
                {
                    ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
                    Assert.AreEqual(Lang, ExcelLibHelper.ReadData(4, "Language"));
                    Assert.AreEqual(level, "Basic");
                });


                SaveScreenShotClass save = new SaveScreenShotClass();
                string img = save.SaveScreenshot(driver, "LanguageUpdate");

                Console.WriteLine("Assertion pass");

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }






        }














        //Delete a given language
        internal void DeleteLanguage()
        {
            ExtentionHelpers.TurnOnWait(driver);

            //populate from excel data
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");

            //expected value of language 
            String expectedValue1 = ExcelLibHelper.ReadData(4, "Language");

            //Get the table row list
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

            //Count how many rows 
            var rowCount = Tablerows.Count;
            for (int i = 1; i <= rowCount; i++)
            {
                ExtentionHelpers.TurnOnWait(driver);
                //xpath of ith languagename(row)
                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                if (expectedValue1 == actualValue)
                {


                    //click on delete icon
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();

                    Console.WriteLine("Language deleted");
                }
                break;
            }


        }


        //validate deletion
        internal void ValidateDeleteLanguage()
        {

            try
            {

                String expectedValue1 = ExcelLibHelper.ReadData(3, "Language");

                //get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[2]/div/div[2]/div/table/tbody/tr"));

                for (int i = 1; i <= Tablerows.Count; i++)
                {

                    string actualvalue1 = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //check if expected value is  not equal to actual value
                    if (expectedValue1 != actualvalue1)
                    {

                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "LanguageDeleted");

                        Console.WriteLine("deleted Successfully");

                    }

                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }

        }










    }














}


