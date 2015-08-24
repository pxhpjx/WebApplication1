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
            //int q = dic["zzzzzzz"];
            dic["sss"] = 1;
            dic["ssds"] = 1;
            dic["sdss"] = 1;
            dic["ssdds"] = 1;
            dic["ssdds"] = 1;
            while (dic.Count > 0)
            {
                var k = dic.First();
                dic.Remove(k.Key);
            }
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            //dic.Add("sss", 1);
            List<int> list = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                dic.Add(i.ToString() + "Index", i);
                list.Add(i);
            }

            foreach (var o in dic)
            {
                if (dic.ToList().IndexOf(o) == 9)
                    break;
            }
        }
    }
}