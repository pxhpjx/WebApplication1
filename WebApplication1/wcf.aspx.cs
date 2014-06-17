using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.VC;

namespace WebApplication1
{
    public partial class wcf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cookie = Request.Cookies["VerifyCode"].Value.ToString();
            TextBox2.Text = cookie.Substring(4, 32);
            TextBox3.Text = cookie.Substring(41, 12);
            TextBox4.Text = cookie.Substring(63, 16);
            Label1.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            VerifyCodeOperateClient cl = new VerifyCodeOperateClient();
            VC.CodeCheckResult Result = cl.CheckVerifyCode(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text);
            Label1.Text = Result.IsPass.ToString() + ":" + Result.Message;
            cl.Close();
        }
    }
}