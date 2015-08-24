using DevLayer.Dev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class xml : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> ls = new List<string>();
            ls.Add("1");
            ls.Add("11");
            ls.Add("111");


            //LogRecord.WriteSerXmlLog(ls);
            var r = LogRecord.ReadSerXmlLog<List<string>>(@"F:\Projects\WebApplication1\WebApplication1\log\20150205171413038.xml");
        }
    }
}