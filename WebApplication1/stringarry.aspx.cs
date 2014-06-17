using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class stringarry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int[,] arr = { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            int l = arr.GetLength(0);
            int w = arr.GetLength(1);
            TextBox t = new TextBox();
            t.Text = null;
            object o = "efewfewf";
            DateTime ddd = (DateTime)o;
        }
    }
}