using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class dic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            List<int> list = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                dic.Add(i.ToString() + "Index", i);
                list.Add(i);
            }
            foreach (var o in dic.ToList())
            {
                if (dic.ToList().IndexOf(o) == 9)
                    break;
            }
        }
    }
}