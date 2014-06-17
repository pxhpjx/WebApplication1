using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;

namespace WebApplication1
{
    public partial class oracle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void Set()
        {
            OracleConnection oc = new OracleConnection("Data Source =(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.89.129)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = FDTEST)));User ID=funddev;Password=libaisi;");
            String sql = @"UPDATE fundadmin.FUND_SYPM SET SYL_Z = :SYL_Z WHERE EID = :EID";
            OracleCommand cmd = new OracleCommand(sql, oc);

            cmd.Parameters.Add(new OracleParameter(":SYL_Z", 1.2000));
            cmd.Parameters.Add(new OracleParameter(":EID", 176000000004131120));

            oc.Open();
            int updateRowCount = cmd.ExecuteNonQuery();
            oc.Close();

            Console.WriteLine("尝试更新数据， 结果造成了{0}条记录的更新。", updateRowCount);
        }



        void Get()
        {
            OracleConnection oc = new OracleConnection("Data Source =(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.16.89.129)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = FDTEST)));User ID=funddev;Password=libaisi;");
            string sql = "select * from fundadmin.FDBIO_b_TRADEDATE";
            OracleCommand ocmd = new OracleCommand(sql, oc);
            oc.Open();
            OracleDataReader odr = ocmd.ExecuteReader();
            while (odr.Read())
            {
                string[] entity = new string[odr.FieldCount];
                for (int i = 0; i < odr.FieldCount; i++)
                {
                    entity[i] = odr[i].ToString();
                }
                oc.Close();
            }
        }

    }
}