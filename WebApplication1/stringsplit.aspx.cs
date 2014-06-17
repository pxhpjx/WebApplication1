﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class stringsplit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string json = "{\"Data\":{\"PredInfo\":\"您的赎回款预计将于T+3日后到账\",\"ExceptConfirmTime\":\"2013-11-29\",\"FundName\":\"景顺长城内需增长贰\",\"ApplyAmount\":\"111.00\",\"ApplyUpperAmount\":\"壹佰壹拾壹份\",\"ApplyTime\":\"2013-11-27 15:00\",\"ApplyWorkDay\":\"2013-11-28\",\"RedeemForRecharge\":\"（确认后资金再充值活期宝）\",\"ApplyWorkDay2\":\"（您的申请时间与所属工作日不在同一天）\"},\"ErrorCode\":0,\"ErrorMessage\":[],\"FirstError\":null,\"DebugError\":null,\"Success\":true,\"HasWrongToken\":false}";
            string PredInfo = SplitJsonItem(json, "predinfo");
            string ExceptConfirmTime = SplitJsonItem(json, "ExceptConfirmTime");
            string ApplyWorkDay2 = SplitJsonItem(json, "ApplyWorkDay2");
            string www = SplitJsonItem(json, "ww");
            string nnn = SplitJsonItem(json, null);
        }

        public static string SplitJsonItem(string json, string itemName)
        {
            if (string.IsNullOrWhiteSpace(json) || string.IsNullOrWhiteSpace(itemName))
                return null;
            string result = null;
            int index = json.ToLower().IndexOf(itemName.ToLower());
            if (index > 0)
            {
                json = json.Substring(index + itemName.Length + 3);
                result = json.Substring(0, json.IndexOf("\""));
            }
            return result;
        }
    }
}