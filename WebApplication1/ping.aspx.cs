using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;

namespace WebApplication1
{
    public partial class ping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Ping p = new Ping();
            var pr = p.Send("www.baidu.com", 3000);
            p.Dispose();
            if (IPStatus.Success == pr.Status)
            {
            }
        }
    }
}