using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EastMoney.Utility.MongoDBHelper;
using System.Net;
using System.IO;
using System.Threading;
using MongoDB.Bson;

namespace WebApplication1
{
    public partial class erheawh : System.Web.UI.Page
    {
        static System.Timers.Timer t;

        protected void Page_Load(object sender, EventArgs e)
        {
            Run();
        }

        static string ConnectString = "Server=127.0.0.1";
        static string strDataBase = "test";
        static string strCollectionCurrencyFundCode = "qwe";
        static string strCollectionFundInfo = "asd";
        static string strCollectionWeek2Year = "qwe";

        public static void Run()
        {
            t = new System.Timers.Timer(3000);
            t.Elapsed += t_Elapsed;
            t.Enabled = true;
        }

        static void t_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            TimerDo();
        }

        static void TimerDo()
        {
            SyncCodes();
            SyncFund(CreateList(GetResponse()));
        }

        static bool SyncCodes()
        {
            try
            {
                MongoDBConfigure.SetConn(ConnectString);
                MongoDBProvider mongoDataBase = new MongoDBProvider(strDataBase, strCollectionCurrencyFundCode);

                FundWebService.FundWebServiceSoapClient fc = new FundWebService.FundWebServiceSoapClient();
                DataTable dt = fc.GetFirstTransMoney();
                foreach (DataRow dr in dt.Rows)
                {
                    Model.Codes c = new Model.Codes();
                    c.Id = int.Parse(dr["FundCode"].ToString());
                    c.MoneyCode = int.Parse(dr["MoneyCode"].ToString());
                    c.SyncTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    mongoDataBase.Collection.Save(c);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        static string GetResponse()
        {
            string url = "http://fund.eastmoney.com/Data/fundtradeindexinfo.aspx?dt=0&cp=&ft=&codes=&ib=1&sc=bzdm&st=desc&pn=1000&rnd=0.5244231091346592";
            string tmp = "";
            try
            {
                WebRequest myReq = WebRequest.Create(url);
                WebResponse myRes = myReq.GetResponse();
                Stream resStream = myRes.GetResponseStream();
                StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
                StringBuilder sb = new StringBuilder();
                while ((tmp = sr.ReadLine()) != null)
                {
                    sb.Append(tmp);
                }
                tmp = sb.ToString();
                myRes.Close();
            }
            catch { }
            return tmp;
        }

        static List<Model.SyncJJZB> CreateList(string s)
        {
            List<Model.SyncJJZB> JJ;
            try
            {
                string[] spliter = new string[2];
                spliter[0] = "\"values\":{\"";
                spliter[1] = "\"},\"codes\"";
                string tmp1 = s.Split(spliter, System.StringSplitOptions.RemoveEmptyEntries)[1];
                spliter[0] = "\",\"";
                spliter[1] = "\":\"";
                string[] tmp2 = tmp1.Split(spliter, System.StringSplitOptions.RemoveEmptyEntries);
                List<string[]> Result = new List<string[]>();
                spliter[0] = ",";
                for (int i = 1; i < tmp2.Length; i += 2)
                {
                    Result.Add(tmp2[i].Split(spliter, System.StringSplitOptions.None));
                }
                JJ = new List<Model.SyncJJZB>();
                foreach (string[] jjs in Result)
                {
                    Model.SyncJJZB J = new Model.SyncJJZB();
                    J.Id = jjs[0];
                    J.jjjc = jjs[1];
                    J.jjgs = jjs[2];
                    J.jjgsid = S2Intn(jjs[3]);
                    J.jjjl = jjs[4];
                    J.dwjz = S2Decn(jjs[5]);
                    J.ljjz = S2Decn(jjs[6]);
                    J.jzrq = jjs[7];
                    J.jjlx = S2Intn(jjs[8]);
                    J.jjlx1 = S2Intn(jjs[9]);
                    J.jjlx2 = S2Intn(jjs[10]);
                    J.jjlx3 = S2Intn(jjs[11]);
                    J.syl_r = S2Decn(jjs[12]);
                    J.syl_z = S2Decn(jjs[13]);
                    J.syl_y = S2Decn(jjs[14]);
                    J.syl_3y = S2Decn(jjs[15]);
                    J.syl_6y = S2Decn(jjs[16]);
                    J.syl_1n = S2Decn(jjs[17]);
                    J.syl_2n = S2Decn(jjs[18]);
                    J.syl_3n = S2Decn(jjs[19]);
                    J.syl_5n = S2Decn(jjs[20]);
                    J.syl_jn = S2Decn(jjs[21]);
                    J.syl_ln = S2Decn(jjs[22]);
                    J.wxpj = S2Intn(jjs[23]);
                    J.htpj = S2Intn(jjs[24]);
                    J.zspj = S2Intn(jjs[25]);
                    J.szpj = S2Intn(jjs[26]);
                    J.cxpj = S2Intn(jjs[27]);
                    J.japj = S2Intn(jjs[28]);
                    J.fxdj = S2Intn(jjs[29]);
                    J.zk = S2Decn(jjs[30]);
                    J.kfgm = S2Intn(jjs[31]);
                    J.SyncTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    JJ.Add(J);
                }
            }
            catch { return null; }
            return JJ;
        }

        static bool SyncFund(List<Model.SyncJJZB> JJ)
        {
            try
            {
                MongoDBConfigure.SetConn(ConnectString);
                MongoDBProvider mongoDataBase = new MongoDBProvider(strDataBase, strCollectionFundInfo);
                foreach (Model.SyncJJZB J in JJ)
                {
                    mongoDataBase.Collection.Save(J);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        static int? S2Intn(string s)
        {
            int i;
            if (int.TryParse(s, out i))
                return i;
            else
                return null;
        }

        static decimal? S2Decn(string s)
        {
            decimal d;
            if (decimal.TryParse(s, out d))
                return d;
            else
                return null;
        }

    }


    public static class Model
    {
        [Serializable]
        public class Codes
        {
            public int Id { get; set; }
            public int MoneyCode { get; set; }
            public string SyncTime { get; set; }//同步时间
        }

        [Serializable]
        public class SyncJJZB
        {
            public string Id { get; set; }//基金代码
            public string jjjc { get; set; }//基金简称
            public string jjgs { get; set; }//基金公司
            public int? jjgsid { get; set; }//公司id
            public string jjjl { get; set; }//基金经理
            public decimal? dwjz { get; set; }//单位净值          
            public decimal? ljjz { get; set; }//累积净值
            public string jzrq { get; set; }//净值日期
            public int? jjlx { get; set; }//基金类型
            public int? jjlx1 { get; set; }//基金类型1
            public int? jjlx2 { get; set; }//基金类型2
            public int? jjlx3 { get; set; }//基金类型3
            public decimal? syl_r { get; set; }//日收益
            public decimal? syl_z { get; set; }
            public decimal? syl_y { get; set; }
            public decimal? syl_3y { get; set; }
            public decimal? syl_6y { get; set; }
            public decimal? syl_1n { get; set; }
            public decimal? syl_2n { get; set; }
            public decimal? syl_3n { get; set; }
            public decimal? syl_5n { get; set; }
            public decimal? syl_jn { get; set; }
            public decimal? syl_ln { get; set; }
            public int? wxpj { get; set; }
            public int? htpj { get; set; }
            public int? zspj { get; set; }
            public int? szpj { get; set; }
            public int? cxpj { get; set; }
            public int? japj { get; set; }
            public int? fxdj { get; set; }//风险等级
            public decimal? zk { get; set; }//折扣
            public int? kfgm { get; set; }//可否购买
            public string SyncTime { get; set; }//同步时间
        }

    }
}