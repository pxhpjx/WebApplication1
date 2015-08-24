using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication1
{
    public partial class unicode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            char c = '\u62b1';
            string us = "\u4e0a\u6d77\u5c0f\u5357\u56fd\uff08\u5858\u6865\u5e97";
            System.Char.TryParse(us, out c);
            string s = ReadUnicode(us);
        }


        public string ReadUnicode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return null;

            byte[] cnCharByte = Encoding.UTF8.GetBytes(input);
            return Encoding.GetEncoding("UTF-8").GetString(cnCharByte);
        }
    }
}