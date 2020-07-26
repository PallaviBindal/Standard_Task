using BoDi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework.Helpers
{
    class FrameworkHook
    {
        public void initalSetUp(IObjectContainer objectContainer)
        {


            _ = new WebdriverContext(objectContainer);
            _ = new ExtentReportconfig();
           
        
        }
    }
}
