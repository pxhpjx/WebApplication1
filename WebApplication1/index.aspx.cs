using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class index : System.Web.UI.Page
    {
        string CurrentDir = System.Web.HttpContext.Current.Server.MapPath("~");

        protected void Page_Load(object sender, EventArgs e)
        {
            string[] files = Directory.GetFiles(CurrentDir, "*.aspx");
            string response = string.Empty;
            foreach (string file in files.ToList().OrderBy(item => item))
            {
                response += string.Format("<a href='{0}'>{0}</a><br/><br/>", file.Substring(file.LastIndexOf('\\') + 1));
            }
            Response.Clear();
            Response.Write(response);
        }
    }
}