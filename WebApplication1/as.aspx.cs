using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _as : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            baseCl bc = new baseCl();
            bc.i = 123;
            Cl c = FormatTools.SampleCopy<baseCl, Cl>(bc);


            c.c = 'v';
            baseCl bc2 = c as baseCl;
        }
    }


    class baseCl
    {
        public int i { get; set; }

        public string s { get; set; }
    }

    class Cl : baseCl
    {
        public char c { get; set; }
    }
}