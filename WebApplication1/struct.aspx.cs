using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _struct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArrayList AL = null;
            aaa A = new aaa();
            aaa B = A;
            A.i = 3;
            sssssss(A);
        }

        void sssssss(aaa aa)
        {
            aa.i = 1;
        }

        struct aaa
        {
            public int i;
            public string s;
        }


    }


}