using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace WebApplication1
{
    public partial class Upload : System.Web.UI.Page
    {
        string SavePath = "E:\\Upload\\";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (!fuFile.HasFile)
            {
                lblTip.Text = "未选定文件";
                return;
            }
            if (!Directory.Exists(SavePath))
                Directory.CreateDirectory(SavePath);
            string file = SavePath + fuFile.FileName;
            if (File.Exists(file))
                lblTip.Text = string.Format("文件：{0}已存在", file);
            else
            {
                fuFile.SaveAs(file);
                lblTip.Text = "文件保存至：" + file;
            }
        }
    }
}