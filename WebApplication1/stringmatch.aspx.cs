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
            var r = StringCompareTool.StringMatchWithStrictOrder("小辉哥火锅(大宁国际商业广场店)", "小辉哥火锅 大宁国际店");
        }
    }
}