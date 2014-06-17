using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication1
{
    public partial class thrtshstr : System.Web.UI.Page
    {
        static string sss = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Timer t1 = new System.Threading.Timer(tcb, (object)"1", 0, 200);
            System.Threading.Timer t2 = new System.Threading.Timer(tcb, (object)"2", 0, 200);
            Thread.Sleep(5000);
            t1.Dispose();
        }


        TimerCallback tcb = write;


        private static void write(object s)
        {
            sss += s.ToString();
            
        }
    }
}