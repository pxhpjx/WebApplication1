using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class newclass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ss = Guid.NewGuid().ToString().Replace("-", "");

            //s<List<QQQ>> R = new s<List<QQQ>>();
            DateTime dt = new DateTime(2013, 01, 6);
            int i = (int)dt.DayOfWeek;
        }
    }


    class QQQ
    {
        public string qq { get; set; }
        public int qqqq { get; set; }
    }

    class s<T>
    {
        T t { get; set; }
        int i { get; set; }
    }
}