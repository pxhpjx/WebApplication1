using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class json : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var r = XMS.Core.Json.JsonSerializer.Deserialize<a>("qqqqqqqqqqqq");



            object d = JsonConvert.DeserializeObject("{\"Data\":{\"FixBagSharesGroupByFunds\":[{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"FundTypeName\":\"货币型\",\"MinSh\":0,\"MinHold\":1000,\"UnitAccrual\":1.6489,\"Navdate\":\"\\/Date(1389715200000)\\/\",\"Annual7D\":6.0520,\"TotalVol\":16267.89,\"TotalProfit\":0,\"Shares\":[{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":5061.02,\"TotalVol\":5061.03,\"ExpireField\":\"02-14 15:00~02-17 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392566400000)\\/\",\"DrawAccountDate\":\"\\/Date(1392652800000)\\/\"},{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":4059.51,\"TotalVol\":4059.51,\"ExpireField\":\"02-17 15:00~02-18 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392652800000)\\/\",\"DrawAccountDate\":\"\\/Date(1392739200000)\\/\"},{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":7147.35,\"TotalVol\":7147.35,\"ExpireField\":\"02-18 15:00~02-19 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392739200000)\\/\",\"DrawAccountDate\":\"\\/Date(1392825600000)\\/\"}]},{\"FundCode\":\"550012\",\"FundName\":\"信诚理财7日盈债券A\",\"FundTypeName\":\"货币型\",\"MinSh\":100,\"MinHold\":100,\"UnitAccrual\":1.5433,\"Navdate\":\"\\/Date(1389715200000)\\/\",\"Annual7D\":7.0580,\"TotalVol\":3605.61,\"TotalProfit\":0,\"Shares\":[{\"FundCode\":\"550012\",\"FundName\":\"信诚理财7日盈债券A\",\"AvailVol\":3605.61,\"TotalVol\":3605.61,\"ExpireField\":\"02-18 15:00~02-19 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392739200000)\\/\",\"DrawAccountDate\":\"\\/Date(1392825600000)\\/\"}]}]},\"ErrorCode\":0,\"ErrorMessage\":[],\"FirstError\":null,\"DebugError\":null,\"Success\":true,\"HasWrongToken\":false}");
            Response.Write(d.ToString());

            string s = "ssss";
            string s2 = JsonConvert.SerializeObject(s);
            s2 = JsonConvert.DeserializeObject(s) as string;
        }
    }
}