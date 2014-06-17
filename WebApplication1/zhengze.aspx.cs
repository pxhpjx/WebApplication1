using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class zhengze : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ss = "ddd";
        char[] Spl = { ',' };
        string[] ssss = ss.Split(Spl);
            string s = "345万元以上，12万元以下";
            if (Regex.IsMatch(s, "\\d*万元以上，\\d*万元以下"))
            {
            }
            else
            {
            }
        }
    }
}