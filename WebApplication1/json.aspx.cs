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
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            OrderDish rrr = new OrderDish();
            rrr.Dishs = new List<DishLite>();
            DishLite d = new DishLite();
            rrr.Dishs.Add(d);
            rrr.Dishs.Add(d);
            rrr.Dishs.Add(d);
            string ssssss = jss.Serialize(rrr);

            object dddd = JsonConvert.DeserializeObject("{\"Data\":{\"FixBagSharesGroupByFunds\":[{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"FundTypeName\":\"货币型\",\"MinSh\":0,\"MinHold\":1000,\"UnitAccrual\":1.6489,\"Navdate\":\"\\/Date(1389715200000)\\/\",\"Annual7D\":6.0520,\"TotalVol\":16267.89,\"TotalProfit\":0,\"Shares\":[{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":5061.02,\"TotalVol\":5061.03,\"ExpireField\":\"02-14 15:00~02-17 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392566400000)\\/\",\"DrawAccountDate\":\"\\/Date(1392652800000)\\/\"},{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":4059.51,\"TotalVol\":4059.51,\"ExpireField\":\"02-17 15:00~02-18 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392652800000)\\/\",\"DrawAccountDate\":\"\\/Date(1392739200000)\\/\"},{\"FundCode\":\"485118\",\"FundName\":\"工银7天理财债券A\",\"AvailVol\":7147.35,\"TotalVol\":7147.35,\"ExpireField\":\"02-18 15:00~02-19 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392739200000)\\/\",\"DrawAccountDate\":\"\\/Date(1392825600000)\\/\"}]},{\"FundCode\":\"550012\",\"FundName\":\"信诚理财7日盈债券A\",\"FundTypeName\":\"货币型\",\"MinSh\":100,\"MinHold\":100,\"UnitAccrual\":1.5433,\"Navdate\":\"\\/Date(1389715200000)\\/\",\"Annual7D\":7.0580,\"TotalVol\":3605.61,\"TotalProfit\":0,\"Shares\":[{\"FundCode\":\"550012\",\"FundName\":\"信诚理财7日盈债券A\",\"AvailVol\":3605.61,\"TotalVol\":3605.61,\"ExpireField\":\"02-18 15:00~02-19 15:00\",\"StateColor\":\"black\",\"NextExpiredDate\":\"\\/Date(1392739200000)\\/\",\"DrawAccountDate\":\"\\/Date(1392825600000)\\/\"}]}]},\"ErrorCode\":0,\"ErrorMessage\":[],\"FirstError\":null,\"DebugError\":null,\"Success\":true,\"HasWrongToken\":false}");
            Response.Write(dddd.ToString());

            string s = "ssss";
            string s2 = JsonConvert.SerializeObject(s);
            s2 = JsonConvert.DeserializeObject(s) as string;
        }


        [Serializable]
        public class OrderDish
        {
            private string ordertype;
            public string OrderType
            {
                get { return ordertype; }
                set { ordertype = value; }
            }

            private string padid;
            public string PadId
            {
                get { return padid; }
                set { padid = value; }
            }

            private string mac;
            public string MAC
            {
                get { return mac; }
                set { mac = value; }
            }

            private string waiterid;
            public string WaiterId
            {
                get { return waiterid; }
                set { waiterid = value; }
            }

            private string tableid;
            public string TableId
            {
                get { return tableid; }
                set { tableid = value; }
            }

            private int customerscount;
            public int CustomersCount
            {
                get { return customerscount; }
                set { customerscount = value; }
            }

            private string timestamp;
            public string TimeStamp
            {
                get { return timestamp; }
                set { timestamp = value; }
            }

            private string remarks;
            public string Remarks
            {
                get { return remarks; }
                set { remarks = value; }
            }

            private List<DishLite> dishs;
            public List<DishLite> Dishs
            {
                get { return dishs; }
                set { dishs = value; }
            }
        }

        [Serializable]
        public class DishLite
        {
            private string dishattr;
            public string DishAttr
            {
                get { return dishattr; }
                set { dishattr = value; }
            }

            private int dishid;
            public int DishId
            {
                get { return dishid; }
                set { dishid = value; }
            }

            private int amount;
            public int Amount
            {
                get { return amount; }
                set { amount = value; }
            }

            private string unittype;
            public string UnitType
            {
                get { return unittype; }
                set { unittype = value; }
            }

            private double unitprice;
            public double UnitPrice
            {
                get { return unitprice; }
                set { unitprice = value; }
            }

            private string cooktype;
            public string CookType
            {
                get { return cooktype; }
                set { cooktype = value; }
            }

            private string remarks;
            public string Remarks
            {
                get { return remarks; }
                set { remarks = value; }
            }







        }
    }
}