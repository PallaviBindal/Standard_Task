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
using TechTalk.SpecFlow;

namespace MarsFramework.Pages
{
    class ProfileSkill
    {



        private IWebDriver driver;
        public ProfileSkill(IWebDriver _driver)
        {
            driver = _driver;


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[text()='Skills']")]
        public IWebElement SkillsButton { get; set; }



        [FindsBy(How = How.XPath, Using = "//div[@class='ui teal button']")]
        public IWebElement AddNewSkills { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[contains(@placeholder,'Add Skill')]")]
        public IWebElement SkillsText { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[3]/span[1]/i")]
        public IWebElement SkillsUpdate { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@class='buttons-wrapper']//input[@type='button'][@value='Add']")]
        public IWebElement AddSkill { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        public IWebElement UpdateButton { get; set; }


        //Add Skills
        internal void AddSkills1()
        {
            Console.WriteLine("*************************************************************");
            //click on skill
            // SkillsButton.Click();

            ExtentionHelpers.TurnOnWait(driver);


            //click on add new button
            AddNewSkills.Click();

            ExtentionHelpers.TurnOnWait(driver);

            //Driver.waitElementIsVisible("//input[contains(@placeholder,'Add Skill')]");
            //add value in skill text 
            SkillsText.SendKeys(ExcelLibHelper.ReadData(2, "Skills"));


            //Skill level
            new SelectElement(driver.FindElement(By.XPath("//select[@class='ui fluid dropdown']"))).SelectByText(ExcelLibHelper.ReadData(2, "SkillLevel")); ;

            //click on add button
            AddSkill.Click();

            ExtentionHelpers.TurnOnWait(driver);
            var actualskillMessage = driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]"));
            driver.FindElement(By.XPath("//a[contains(@class,'ns-close')]"));

            Console.WriteLine(actualskillMessage.Text);
            Console.WriteLine("skill added");
            Console.WriteLine("*******************************************");
        }


        internal void ValidateAddSkill()
        {
            //Validate the Skill is added sucessfully 
            try
            {

                //skills test
                SkillsButton.Click();
                String skill = driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]")).Text;
                Assert.AreEqual(skill, ExcelLibHelper.ReadData(2, "Skills"));

                //skill Level test
                String skilllevel = driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[2])[1]")).Text;
                Assert.AreEqual(skilllevel, ExcelLibHelper.ReadData(2, "SkillLevel"));


                SaveScreenShotClass save = new SaveScreenShotClass();
                string img = save.SaveScreenshot(driver, "SkillAdd");




            }
            catch (Exception)
            {
                Assert.Fail();
            }
            ExtentionHelpers.TurnOnWait(driver);

        }


        //Update skill
        internal void UpdateSkill()
        {

            //click on skill
            // SkillsButton.Click();

            for (int i = 1; i <= 5; i++)

            {
                ExtentionHelpers.TurnOnWait(driver);

                //get text of language 
                var skilltext = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                ExtentionHelpers.TurnOnWait(driver);

                ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");

                if (skilltext == ExcelLibHelper.ReadData(2, "Skills"))


                {
                    ExtentionHelpers.TurnOnWait(driver);

                    //click on pen icon update
                    driver.FindElement(By.XPath("//div[@data-tab='second']/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]")).Click();

                    //get language text box 
                    IWebElement skilledittext1 = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));

                    skilledittext1.Clear();

                    //enter language
                    skilledittext1.SendKeys(ExcelLibHelper.ReadData(3, "Skills"));

                    //Enter language level
                    SelectElement select = new SelectElement(driver.FindElement(By.XPath("//div[@data-tab = 'second']/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[2]/select")));
                    select.SelectByValue(ExcelLibHelper.ReadData(3, "SkillLevel"));

                    //click on update
                    driver.FindElement(By.XPath("//div[@data-tab = 'second']/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]")).Click();

                    Console.WriteLine("Skill updated");


                    break;
                }
            }


        }
        //Validate updation
        internal void ValidateUpdateSkill()
        {
            //click on skill
            SkillsButton.Click();
            try
            {
                ExtentionHelpers.TurnOnWait(driver);
                String skill = driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[1]/tr/td[1]")).Text;
                //String skill = Driver.driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[1])[1]")).Text;
                Assert.AreEqual(skill, "Performance");

                String skilllevel = driver.FindElement(By.XPath("(//div[@data-tab='second']//table//tbody//tr[1]//td[2])[1]")).Text;
                Assert.AreEqual(skilllevel, "Intermediate");
                ExtentionHelpers.TurnOnWait(driver);
                SaveScreenShotClass save = new SaveScreenShotClass();
                string img = save.SaveScreenshot(driver, "SkillUpdate");


            }
            catch (Exception)
            {
                Assert.Fail();

            }
            ExtentionHelpers.TurnOnWait(driver);
        }





        //Delete a given language
        internal void DeleteSkill()
        {

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            String expectedvalue = ExcelLibHelper.ReadData(3, "Skill");

            //table row
            IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));

            //Get the row count of table
            var rowCount = Tablerows.Count;

            for (int i = 1; i <= rowCount; i++)
            {

                String actualValue = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;
                // String actualValue = Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                //validate
                if (expectedvalue == actualValue)

                    //Click on delete button
                    driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));
                //Driver.driver.FindElement(By.XPath("//div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i")).Click();
                Console.WriteLine("Deleted");
                break;
            }
        }


        //Validate deletion
        internal void ValidateDeleteSkill()
        {

            try
            {

                ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
                String expectedValue1 = ExcelLibHelper.ReadData(4, "Skill");


                //get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[3]/div/div[2]/div/table/tbody/tr"));
                for (int i = 1; i <= Tablerows.Count; i++)
                {

                    string actualvalue1 = driver.FindElement(By.XPath("//div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //check if expected value is not  equal to actual value

                    if (expectedValue1 != actualvalue1)
                    {
                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "skillDeleted");
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






























