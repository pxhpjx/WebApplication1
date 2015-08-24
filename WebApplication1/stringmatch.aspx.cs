using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevLayer.Dev;

namespace WebApplication1
{
    public partial class stringmatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var r = StringCompareTool.StringMatchWithStrictOrder("秦淮区中山东路18号国贸大厦6楼", "正洪街18号东宇大厦5楼", 3);
        }
    }
}