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
using System.Security.Cryptography;

namespace MarsFramework.Pages
{
    class ProfileEducation
    {



        private IWebDriver driver;
        public ProfileEducation(IWebDriver _driver)
        {
            driver = _driver;

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='Education']")]
        public IWebElement EducationButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[6]/div[1]")]
        public IWebElement AddNewEducation { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='degree']")]
        public IWebElement DegreeText { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='text'][@name='instituteName']")]
        public IWebElement InstituteText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[2]//div//div[3]//div//input[@type='button'][@value='Add']")]
        public IWebElement AddEducation { get; set; }
        //*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i";

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[6]/span[1]/i")]
        public IWebElement EducationUpdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td/div[3]/input[1]")]
        public IWebElement UpdateButton { get; set; }


        // select dropdown for education and certification
        public void selectdropdown1(string dropdownname, string value)
        {
            new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'" + dropdownname + "')]"))).SelectByValue(value);
        }



        //Add Education 
        internal void AddEducation1()
        {
            Console.WriteLine("****************************************************************************");
            ExtentionHelpers.TurnOnWait(driver);

            AddNewEducation.Click();

            //adding text in institute name
            InstituteText.SendKeys(ExcelLibHelper.ReadData(3, "University"));

            // select dropdown
            selectdropdown1("country", ExcelLibHelper.ReadData(2, "Country"));
            selectdropdown1("title", ExcelLibHelper.ReadData(2, "Title"));
            selectdropdown1("yearOfGraduation", ExcelLibHelper.ReadData(3, "Year"));

            //enter degree 
            DegreeText.SendKeys(ExcelLibHelper.ReadData(3, "Degree"));

            ExtentionHelpers.TurnOnWait(driver);

            // add education
            AddEducation.Click();

            ExtentionHelpers.TurnOnWait(driver);

        }

        //Validate add
        internal void ValidateAdd()
        {
            try
            {


                ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
                String ExpectedValue = ExcelLibHelper.ReadData(2, "Title");


                //Get the table list
                IList<IWebElement> Trows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));

                //Get the count number of rows
                var rows = Trows.Count;
                for (var i = 1; i <= rows; i++)
                {
                    ExtentionHelpers.TurnOnWait(driver);

                    string ActualValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;

                    //Check if expected value is equal to actual value
                    if (ExpectedValue == ActualValue)
                    {

                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "this");

                        Assert.IsTrue(true);
                        Console.WriteLine("Education added");


                    }

                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }

            Console.WriteLine("****************************************************************************");
        }

        //update education
        internal void UpdateEducation()
        {

            Console.WriteLine("****************************************************************************");
            ExtentionHelpers.TurnOnWait(driver);


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            String ExpectedValue = ExcelLibHelper.ReadData(2, "Country");

            //Get the table list
            IList<IWebElement> TRows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));


            //Get the row counts
            var rows = TRows.Count;
            for (int i = 1; i <= rows; i++)
            {
                ExtentionHelpers.TurnOnWait(driver);

                //get xpath
                String ActualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                //check value

                if (ActualValue.Equals(ExpectedValue))
                {
                    //CliCk on update pen icon
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]/i")).Click();

                    //update uni
                    IWebElement editRowValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));

                    editRowValue.Clear();
                    editRowValue.SendKeys(ExcelLibHelper.ReadData(2, "University"));

                    // update Country of College
                    new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[1]/div[2]/select"))).SelectByValue(ExcelLibHelper.ReadData(2, "Country"));


                    // update Title
                    new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[1]/select"))).SelectByValue(ExcelLibHelper.ReadData(2, "Title"));

                    //update the Degree
                    IWebElement EditDegree = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[2]/input"));

                    EditDegree.Clear();
                    EditDegree.SendKeys(ExcelLibHelper.ReadData(2, "Degree"));

                    //update the Year 
                    new SelectElement(driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[2]/div[3]/select"))).SelectByValue(ExcelLibHelper.ReadData(2, "Year"));

                    // Click on update button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div[3]/input[1]")).Click();


                    Console.WriteLine("updated");
                }
            }
        }


        //Validate Updation
        internal void Updatevalidate()
        {
            try
            {


                //title text 
                String expectedValue = ExcelLibHelper.ReadData(2, "Title");

                //Get the table list
                IList<IWebElement> TableRows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));

                //Get the row
                var Rows = TableRows.Count;

                //Iteration
                for (var j = 1; j <= Rows; j++)
                {
                    string actualValue = driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + j + "]/tr/td[3]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "this");


                        Console.WriteLine(" Education updated");
                    }

                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            ExtentionHelpers.TurnOnWait(driver);
        }


        //Delete Education
        internal void DeleteEduation()
        {


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            String expectedValue = ExcelLibHelper.ReadData(2, "Title");

            //Get the list
            IList<IWebElement> Trows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));

            //Get the row 
            var rows = Trows.Count;
            for (int i = 1; i <= rows; i++)
            {
                //Get the xpath of ith row
                String actualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;

                //validation if actual equal to expected
                if (actualValue == expectedValue)
                {
                    // Click on the  delete button
                    driver.FindElement(By.XPath("//form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();

                }
            }
            ExtentionHelpers.TurnOnWait(driver);
        }

        internal void DeleteValidation()
        {


            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");

            String expectedValue = ExcelLibHelper.ReadData(2, "Title");

            //Get the list
            IList<IWebElement> Trows = driver.FindElements(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody/tr"));

            //Get the row 
            var rows = Trows.Count;
            try
            {
                for (int i = 1; i <= rows; i++)
                {
                    //Get the xpath of ith row
                    String actualValue = driver.FindElement(By.XPath("//div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;

                    //validation
                    if (actualValue != expectedValue)
                    {
                        Console.WriteLine("pass");
                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "this");

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









































































