using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class threadpool : System.Web.UI.Page
    {
        int i;

        protected void Page_Load(object sender, EventArgs e)
        {
            System.Threading.Thread th = new Thread(() => { });



            int[] ar = { 1, 2 };
            ThreadPool.QueueUserWorkItem(new WaitCallback(calc), ar);

            int[,] ia = new int[122, 998];
            Array arr = new int[10000, 7];
            ArrayList al = new ArrayList(11);
            //al[3] = "ww";
            al.Add(1);
            al.Add(null);
            arr.SetValue("", 66, 77);
        }


        void calc(object ob)
        {
        }
    }
}