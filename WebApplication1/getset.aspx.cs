using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class getset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string c = sssss;
            sssss = "dd";
        }


        public string sssss
        {
            get
            {
                return "www";

            }
            set
            { }
        }
    }
}