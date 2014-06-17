using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class theadtimeout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b;
            ulong i = 0;
            //bool eb = FormatTools.ExecFuncWithTimeOut<bool>(() => (wtf()), 3000, out b);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool ebb = FormatTools.ExecFuncWithTimeOut<bool>(() => (wtt(ref i)), 10, out b);
            sw.Stop();
        }


        static bool wtf()
        {
            while (true)
            {
            }
            return true;
        }

        static bool wtt(ref ulong i)
        {
            i = 0u;
            while (i < ulong.MaxValue)
            {
                i++;
            }
            return true;
        }
    }
}