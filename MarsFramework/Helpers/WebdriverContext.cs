using BoDi;
using Docker.DotNet.Models;
using MarsFramework.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Helpers
{
    public class WebdriverContext
    {


        public IWebDriver Driver { get; set; }



        private readonly IObjectContainer _objectContainer;

        public WebdriverContext(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

            Driver = new ChromeDriver();
            objectContainer.RegisterInstanceAs<IWebDriver>(Driver);

        }
     }
}
