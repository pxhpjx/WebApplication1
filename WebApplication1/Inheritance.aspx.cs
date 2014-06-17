using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Inheritance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bc b = new c1();
            //r(ref b);
            rr(b);
            r(b);
            b.i = 1;
            c1 c = b as c1;
            c2 cc = b as c2;
            bool b1 = b is c1;
            bool b2 = b is c2;
        }

        void r(ref bc b)
        {
            b = new c2();

        }
        void r(bc b)
        {
            b = new c2();
        }

        void rr(bc b)
        {
            b.i = 4;
        }
    }



    public class bc
    {
        public int i;

        public virtual int ib()
        {
            return 0;
        }

        public string s0()
        {
            return null;
        }
    }

    public abstract class abc
    {
        int ai;

        public string sa()
        {
            return null;
        }

        abstract public string saa();


    }

    public interface I1
    {
        string s1();
    }

    public interface I2
    {
        string s2();
    }

    public interface I3 : I2
    {
        string s3();
    }

    public class c1 : bc, I1
    {
        public int i1;
        public string s1()
        {
            return i1.ToString();
        }
    }

    public class c2 : bc, I2
    {
        public int i2;

        public string s2()
        {
            return null;
        }

        public override int ib()
        {
            return 2;
        }

        new private int? s0()
        {
            return null;
        }
    }

    public class c3 : I1, I2
    {
        public string s1()
        {
            return "";
        }
        public string s2()
        {
            return "";
        }
    }
}