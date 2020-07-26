using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MarsFramework.Helpers
{

    public static class ConstantHelpers
    {
    
    
        //Base Url
        public static string Url = "http://localhost:5000";

        //ScreenshotPath
        public static string ScreenshotPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestReports\\Screenshots\\");


        //ExtentReportsPath
        public static string ReportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TestReports\\demo.html");


        //ReportXML Path
        public static string ReportXMLPath = "";

        //TestDataPath
        public static string TestDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Data\\Data.xlsx");


        //FilePath
        public static string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\TextFile\\Text.txt.txt");

        public static string IsLogin = "true";
    }

}