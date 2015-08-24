using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class md55 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string r = DevLayer.Import.MD5.GetMd5String("rrrrr");
        }
    }
}