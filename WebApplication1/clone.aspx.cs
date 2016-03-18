using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class clone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            people p1, p2 = new people();
            p2.h = new hand();
            p2.h.i = 6;
            p2.i = 666;
            p1 = p2.C();

            p1 = p2.Clone() as people;
            p2.h.i = 888;
            string s1, s2;
            s1 = s2 = "55";
            s2 = "";


            ArrayList al = new ArrayList();
            List<hand> hl = new List<hand>();
            
        }
    }


    class hand : ICloneable
    {
        public int i;
        public object Clone()
        {
            hand h = new hand();
            h.i = i;
            return h;
        }
    }

    class people : ICloneable
    {
        public int i;

        public hand h;
        public object Clone()
        {
            people p = new people();
            p.h = h.Clone() as hand;
            return p;
        }


        public people C()
        {
            return (people)this.MemberwiseClone();
        }
    }
}