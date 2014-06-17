using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Fund.Web.Admin.Web.CommonLayer
{
    public static class Config
    {
        /// <summary>
        /// Oracle数据库连接字符串
        /// </summary>
        public static string OracleConnection = ConfigurationManager.AppSettings["OracleConnection"].ToString();

        /// <summary>
        /// 基金通行证连接字符串
        /// </summary>
        public static string EMBULLETIN = ConfigurationManager.ConnectionStrings["EMBULLETIN"].ConnectionString;
        //public static string EMBULLETIN = "Server=PANGJIAXI-PC\\SQLEXPRESSr2;Database=EMBULLETIN;User ID=sa;Password=sa";
    }
}
