using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class classequal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            a c1 = new a();
            a c2 = new a();
            a c3 = new a();
            c1.s = "asfasfcasf";
            if (c2.Equals(c3))
            {
            }
            else
            {
            }
        }
    }

    class a
    {
        public string s;
    }
}