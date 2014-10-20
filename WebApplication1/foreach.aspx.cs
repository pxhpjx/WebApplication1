using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _foreach : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<tc> l = new List<tc>();
            l.Add(new tc());
            l.Add(new tc());
            l.Add(new tc());
            l.Add(new tc());
            l.Add(new tc());
            foreach (tc t in l)
            {
                t.i = 998;
            }
        }


        private class tc
        {
            public int i { get; set; }
            public string s { get; set; }
        }
    }
}