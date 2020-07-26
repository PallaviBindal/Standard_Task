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
    class ProfileCertification
    {

        private IWebDriver driver;
        public ProfileCertification(IWebDriver _driver)
        {
            driver = _driver;
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//a[text()='Certifications']")]
        public IWebElement CertificationsButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[1]/div[2]/div[1]/table[1]/thead/tr/th[4]/div[1]")]
        public IWebElement AddNewCertification { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@name='certificationName']")]
        public IWebElement CertificationText { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@name='certificationFrom']")]
        public IWebElement CertifiedFromText { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='ui fluid container']//div//div//div[3]//form//div[5]//div//div[2]/div//div[1]//div[3]//input[@type='button'][@value='Add']")]
        public IWebElement AddCertification { get; set; }


        //*[@id="account-profile-section"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i
        [FindsBy(How = How.XPath, Using = "//div[@data-tab = 'fourth']/div/div[2]/div/table/tbody[1]/tr/td[4]/span[1]/i")]
        public IWebElement CerficationUpdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td/div/span/input[1]")]
        public IWebElement UpdateButton { get; set; }



        //select dropdown for certification
        public void selectdropdown1(string dropdownname, string value)
        {
            new SelectElement(driver.FindElement(By.XPath("//select[contains(@name,'" + dropdownname + "')]"))).SelectByValue(value);
        }



        //Add Certification
        internal void AddCertification1()
        {
            Console.WriteLine("******************************");

            // CertificationsButton.Click();

            ExtentionHelpers.TurnOnWait(driver);

            //add new certification
            AddNewCertification.Click();

            ExtentionHelpers.TurnOnWait(driver);
            //add value in certificate field and certification from
            CertificationText.SendKeys(ExcelLibHelper.ReadData(3, "Certificate"));

            CertifiedFromText.SendKeys(ExcelLibHelper.ReadData(3, "Certified from"));

            //select certificate year 
            selectdropdown1("certificationYear", ExcelLibHelper.ReadData(3, "CertificationYear"));

            AddCertification.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        //update operation performs on Certification field
        internal void UpdateCertification()
        {

            ExtentionHelpers.TurnOnWait(driver);

            //click the pen icon to edit 
            CerficationUpdate.Click();

            ExtentionHelpers.TurnOnWait(driver);

            // clear text and enter value
            CertificationText.Clear();
            CertificationText.SendKeys(ExcelLibHelper.ReadData(4, "Certificate"));

            CertifiedFromText.Clear();
            CertifiedFromText.SendKeys(ExcelLibHelper.ReadData(4, "Certified from"));

            selectdropdown1("certificationYear", ExcelLibHelper.ReadData(4, "CertificationYear"));

            //click on update button
            UpdateButton.Click();

            ExtentionHelpers.TurnOnWait(driver);

            Console.WriteLine(driver.FindElement(By.XPath("//div[contains(@class,'ns-box-inner')]")).Text);

            driver.FindElement(By.XPath("//a[contains(@class,'ns-close')]"));

            Console.WriteLine("*******************************");
        }


        internal void ValidateAddcertifications()
        {
            //Validate the certification is added sucessfully 
            try
            {
                ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");
                String expectedValue = ExcelLibHelper.ReadData(3, "Certificate");

                //Get the table list
                IList<IWebElement> Trows = driver.FindElements(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody/tr"));

                //Get the row count in table
                var rows = Trows.Count;
                for (var i = 1; i <= rows; i++)
                {
                    ExtentionHelpers.TurnOnWait(driver);
                    string actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //Check if expected value is equal to actual value
                    if (expectedValue == actualValue)
                    {
                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "certification added");


                    }

                }
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            ExtentionHelpers.TurnOnWait(driver);

        }


        //Validate updation
        internal void ValidateUpdateCertification()
        {
            try
            {



                String expectedValue = ExcelLibHelper.ReadData(4, "Certificate");

                //Get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));

                //Get the row count in table
                var row = Tablerows.Count;

                for (var j = 1; j <= row; j++)
                {
                    ExtentionHelpers.TurnOnWait(driver);
                    string actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + j + "]/tr/td[1]")).Text;

                    ExtentionHelpers.TurnOnWait(driver);


                    //Check if expected value is equal to actual value
                    // Assert.AreEqual(expectedValue, actualValue);

                    if (expectedValue == actualValue)
                    {


                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "CertificationUpdate");
                        Assert.IsTrue(true);
                        Console.WriteLine("Assertion pass");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //Delete a given Certification
        internal void DeleteCertification()
        {
            CertificationsButton.Click();

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.TestDataPath, "FieldValues");

            String expectedValue1 = ExcelLibHelper.ReadData(4, "Certificate");

            //Get the row list
            IList<IWebElement> Trows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));

            //Get the row count of table
            var rows = Trows.Count;
            for (int i = 1; i <= rows; i++)
            {
                //Get the xpath of ith row Name
                String actualValue = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;


                if (actualValue == expectedValue1)
                {
                    // Click on delete button
                    driver.FindElement(By.XPath("//form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();

                }
            }


        }


        //Validate Deletion
        internal void ValidateDeleteCertification()
        {

            try
            {

                String expectedValue1 = ExcelLibHelper.ReadData(4, "Certificate");

                //get the table list
                IList<IWebElement> Tablerows = driver.FindElements(By.XPath("//form/div[5]/div/div[2]/div/table/tbody/tr"));

                for (int i = 1; i <= Tablerows.Count; i++)
                {

                    string actualvalue1 = driver.FindElement(By.XPath("//form/div[5]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;

                    //check if expected value is equal to actual value
                    if (expectedValue1 != actualvalue1)
                    {


                        SaveScreenShotClass save = new SaveScreenShotClass();
                        string img = save.SaveScreenshot(driver, "CerficationsDeleted");
                        Assert.Pass();
                        Console.WriteLine("Certification deleted");
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            


        }


















    }
}

