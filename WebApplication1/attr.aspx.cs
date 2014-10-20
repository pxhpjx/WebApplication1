using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class attr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            tc t = new tc();
        }
    }

    [Attr]
    public class tc
    {
    }



    public class Attr : Attribute
    {
        public string CCCC()
        {
            return "sss";
        }
    }
}