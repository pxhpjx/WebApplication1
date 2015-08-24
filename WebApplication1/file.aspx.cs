using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public partial class file : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = File.ReadAllText(@"C:\420.txt", Encoding.GetEncoding("GB2312"));

            File.Create("C:\\cf").Dispose();
        }
    }
}