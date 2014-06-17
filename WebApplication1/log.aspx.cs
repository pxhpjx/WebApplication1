using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class log : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            a aa = null;
            string[] sa = null;
            try
            {
                int l = sa.Length;
                string s = aa.s;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                //LogRecord.WriteLog(ex.Message, "true", true);
                //LogRecord.WriteLog(s, "false");
                LogInfo info = new LogInfo();
                string ss = info.ToString();
                LogInfo lg = new LogInfo();
                lg.Message = s;
                LogRecord.WriteLog(lg);
            }
        }
    }
}