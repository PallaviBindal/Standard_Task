using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Helpers
{
    public class ExtentReportconfig
    {


        public static AventStack.ExtentReports.ExtentReports ExtentReport { get; set; }
        static ExtentReportconfig()
        {
            ExtentReport = new AventStack.ExtentReports.ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(ConstantHelpers.ReportPath);
       
            ExtentReport.AddSystemInfo("HostName", "SkillSwap");
            ExtentReport.AddSystemInfo("Environment", "QC");
            ExtentReport.AddSystemInfo("Username", "Pallavi");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            ExtentReport.AttachReporter(htmlReporter);
        }
       
    }
}
