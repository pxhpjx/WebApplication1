using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class sessiontest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["qq"] == null)
                Session["qq"] = "wrew";
            Label1.Text = Session.SessionID;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpRuntime.Cache.Add(Session.SessionID, DateTime.Now.ToString(), null,System.Web.Caching.Cache.NoAbsoluteExpiration,new TimeSpan(0,0,20,0,0),System.Web.Caching.CacheItemPriority.Normal, null);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            object obj = HttpRuntime.Cache[TextBox1.Text];
            Label2.Text = obj.ToString();
        }
    }
}