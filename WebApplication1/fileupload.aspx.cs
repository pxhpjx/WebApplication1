using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class fileupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(FileUpload1.HasFile)
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~\\pic\\")+FileUpload1.FileName);
            System.IO.File.Copy("C:\\Users\\PangJiaxi\\Desktop\\今天你脑残了吗.txt", "pic\\aa");
        }
    }
}