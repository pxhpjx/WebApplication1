using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace WebApplication1
{
    public partial class log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Thread th = new Thread(() =>
                {
                    while (true)
                    {
                        LogRecord.WriteLogExt("zzz", (new Random()).Next(3).ToString());
                        Thread.Sleep(300);
                    }
                });
            th.Start();
        }
    }
}