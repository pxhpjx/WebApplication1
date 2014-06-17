using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class dele : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            asd dddddddddd = new asd();
            dddddddddd.aa = c;
            dddddddddd.aa += asd.b;
            dddddddddd.aa += dddddddddd.d;

            int i = dddddddddd.aa();
        }

        public static int c()
        {
            return 2;
        }
    }




    public class asd
    {
        public delegate int a();

        public a aa;

        public static int b()
        {
            return 1;
        }

        public int d()
        {
            return 3;
        }

    }
}