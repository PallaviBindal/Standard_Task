using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Docker.DotNet.Models;
using MarsFramework.Helpers;
using MarsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsFramework.Utils
{
    [Binding]
    public class Hook
    {
        // Define global variables for extent report
        private static ExtentTest featureName;
        private static ExtentTest scenario;

        private IWebDriver Driver;

        [BeforeTestRun]
        public static void Initialize(IObjectContainer objectContainer)
        {

            FrameworkHook frameworkHook = new FrameworkHook();
            frameworkHook.initalSetUp(objectContainer);
        }

        [AfterTestRun]
        public static void EndReport(IWebDriver driver)
        {

            // Close the driver   
            //driver.Close();

            ExtentReportconfig.ExtentReport.Flush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            //Create dynamic feature name
            featureName = ExtentReportconfig.ExtentReport.CreateTest<AventStack.ExtentReports.Gherkin.Model.Feature>(featureContext.FeatureInfo.Title);

        }

        [AfterStep]
        [Obsolete]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            switch (stepType)
            {

                case "Given":


                    if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text)
                            .Fail(ScenarioContext.Current.TestError.Message)
                            .Log(Status.Error, ScenarioContext.Current.TestError.Message);


                    }
                    else
                    {

                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                    }

                    break;

                case "When":


                    if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text)
                            .Fail(ScenarioContext.Current.TestError.Message)
                            .Log(Status.Error, ScenarioContext.Current.TestError.Message);


                    }
                    else
                    {

                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                    }

                    break;
                case "And":


                    if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                            .Fail(ScenarioContext.Current.TestError.Message)
                            .Log(Status.Error, ScenarioContext.Current.TestError.Message);


                    }
                    else
                    {

                        scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    break;
                case "Then":


                    if (ScenarioContext.Current.TestError != null)
                    {
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text)
                            .Fail(ScenarioContext.Current.TestError.Message)
                            .Log(Status.Error, ScenarioContext.Current.TestError.Message);

                    }
                    else
                    {

                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                    }
                    break;
                default:
                    break;
            }


        }

        [BeforeScenario]
        public void InititalizeTest(ScenarioContext scenarioContext, IWebDriver Driver)
        {

            //Create dynamic scenario name
            scenario = featureName.CreateNode<AventStack.ExtentReports.Gherkin.Model.Scenario>(scenarioContext.ScenarioInfo.Title);

            //navigate to URL
            Driver.Navigate().GoToUrl(ConstantHelpers.Url);

            //calling login method
            if (ConstantHelpers.IsLogin == "true")
            {
                SignIn loginobj = new SignIn(Driver);
                loginobj.LoginSteps();
            }
            else
            {
                Signup signUp = new Signup(Driver);
                signUp.register();
            }
        }

        [AfterScenario]
        public void TearDown(IWebDriver driver)
        {

            // Close the driver   
            driver.Close();
        }

    }




}