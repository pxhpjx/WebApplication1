using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _this : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cccc cc = new cccc();
            cccc c3 = cc.sv();
        }

        class cccc
        {
            public int i { get; set; }

            public cccc sv()
            {
                i = 123;
                return this;
            }
        }
    }
}