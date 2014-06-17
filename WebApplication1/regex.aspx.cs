using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class regex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string xml = @"<f><t>qwer</t><dd>1234</dd></f><f><t>asdf</t><dd>5678</dd><t>asdf</t><dd></dd></f>";
            FormatTools.SeekXmlNodeValue(xml, "dd", "\\d*");
            FormatTools.SeekXmlNodeValues(xml, "f");
        }

        public void t1()
        {
            Regex r = new Regex("5\\d\\d\\d");
            int matches = r.Matches("qqqqqq").Count;
            matches = r.Matches("1111").Count;
            matches = r.Matches("5111").Count;
            matches = r.Matches("6111").Count;
            matches = r.Matches("11136").Count;
            matches = r.Matches("11136").Count;
            string sss = " a b ".Trim();
        }

        public void t2()
        {
            Regex r = new Regex(@"<dd>\d*</dd>");
            string xml = @"<f><t>qwer</t><dd>1234</dd></f><f><t>asdf</t><dd>5678</dd></f>";
            Match m = r.Match(xml);
            //string mr = m.Result("");
            string v = m.Value;
        }
    }
}