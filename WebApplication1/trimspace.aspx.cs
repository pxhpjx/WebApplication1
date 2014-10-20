using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class trimspace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "原麦     山丘            （SOHO尚都店）        ";
            s = FormatTools.TrimSpaces(s);

            string ss = s.oooooooooo();
            string ssss = "               ";
            ssss.Trim();
        }



    }

    public static class ccc
    {
        public static string oooooooooo(this string value)
        {
            value = "123";
            return "";
        }
    }
}