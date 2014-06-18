using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Diagnostics;

namespace WebApplication1
{
    public partial class threadsleepsuspend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool b;
            FormatTools.ExecFuncWithTimeOut<bool>(() => NC("dd"), 5000, out b);
            sw.Stop();
            string s = "";

            Thread th1 = new Thread((ThreadStart)(delegate
                {
                    while (true)
                    {
                        LogRecord.WriteLog("th1log");
                        Thread.Sleep(10000);
                    }
                }));
            th1.Start();
            int i = 0;
            Thread th2 = new Thread((ThreadStart)(delegate
                {
                    while (i < 3)
                    {
                        if (i == 1)
                        {
                            th1.Suspend();
                            LogRecord.WriteLog("th1sus");
                        }
                        if (i == 2)
                        {
                            th1.Resume();
                            LogRecord.WriteLog("th1res");
                        }
                        i++;
                        Thread.Sleep(8000);
                    }
                }));
            th2.Start();
        }

        private bool NC(string s)
        {
            while (true)
            { }
            return false;
        }
    }
}