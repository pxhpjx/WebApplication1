using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class htmldecode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string pd = Pad("1");
            string b64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(pd));
            string s = HttpUtility.UrlDecode("area_id=f%2bewmFS3T0D%2bFhDppgefzw%3d%3d%0A&auto_build=9HaqjywR1NaIeX1PjAImGA%3d%3d%0A&floor_id=9HaqjywR1NaIeX1PjAImGA%3d%3d%0A&K=a9JkRa5Dt%2bWoOoYom8v9Oy9PhjuvqPLF9Hw%2bKXfmmpQ%2fbYTu%2bOD%2bJQ%2fvvFOKuXSeWtcWRn7yvagd6RdBS6zr%2fQ%3d%3d%0A");
        }



        public string Pad(string input)
        {
            int l = input.Length % 16;
            while (input.Length % 16 != 0)
            {
                input += (char)(16 - l);
            }
            return input;
        }
    }
}