﻿
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Docker.DotNet.Models;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Helpers
{
    public class ScreenShot
    {
        //Screenshots
        private static IWebDriver driver { get; set; }

        public MediaEntityModelProvider CaptureScreenshot(IWebDriver driver, String name)
        {

            var screenshot= ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
                return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot,name).Build();

        }

        //Screenshot1
        public class SaveScreenShotClass
        {
            

            public string SaveScreenshot(IWebDriver driver, string ScreenShotFileName) 
            {
                var folderLocation = (ConstantHelpers.ScreenshotPath);

                if (!System.IO.Directory.Exists(folderLocation))
                {
                    System.IO.Directory.CreateDirectory(folderLocation);
                }

                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                var fileName = new StringBuilder(folderLocation);

                fileName.Append(ScreenShotFileName);
                fileName.Append(DateTime.Now.ToString("_dd-mm-yyyy_mss"));
             
                fileName.Append(".jpeg");
                screenShot.SaveAsFile(fileName.ToString(), ScreenshotImageFormat.Jpeg);
                return fileName.ToString();
            }
        }

       

    }
}



