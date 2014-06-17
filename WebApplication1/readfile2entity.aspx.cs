using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using EastMoney.Fund.Service.CoreProcess.Model;
using EastMoney.Fund.Service.CoreProcess;

namespace WebApplication1
{
    public partial class readfile2entity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CPUInfo> c = ReadLog.ReadCPU(Server.MapPath("~") + "\\CPU.txt");
            List<MemoryInfo> m = ReadLog.ReadMemory(Server.MapPath("~") + "\\Memory.txt");
            List<NetInfo> n = ReadLog.ReadNet(Server.MapPath("~") + "\\Net.txt");
            test t = new test();
            change(t);
        }

        void change(test input)
        {
            input.i = 12345;
            input.s = "ccccc";
        }

    }


    public class test
    {
        public int i;
        public string s;
    }
}