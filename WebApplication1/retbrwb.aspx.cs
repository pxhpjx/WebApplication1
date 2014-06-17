//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using MongoDB.Bson;
//using System.Data;
//using System.Net;
//using System.IO;
//using System.Text;

//namespace WebApplication1
//{
//    public partial class retbrwb : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            string url = "http://fund.eastmoney.com/Data/fundtradeindexinfo.aspx?dt=0&cp=&ft=&codes=&ib=1&sc=bzdm&st=desc&pn=1000&rnd=0.5244231091346592";
//            List<string[]> Result;
//            try
//            {
//                string tmp;
//                WebRequest myReq = WebRequest.Create(url);
//                WebResponse myRes = myReq.GetResponse();
//                Stream resStream = myRes.GetResponseStream();
//                StreamReader sr = new StreamReader(resStream, Encoding.UTF8);
//                StringBuilder sb = new StringBuilder();
//                while ((tmp = sr.ReadLine()) != null)
//                {
//                    sb.Append(tmp);
//                }
//                tmp = sb.ToString();
//                myRes.Close();
//                string[] spliter = new string[2];
//                spliter[0] = "\"values\":{\"";
//                spliter[1] = "\"},\"codes\"";
//                string tmp1 = tmp.Split(spliter, System.StringSplitOptions.RemoveEmptyEntries)[1];
//                spliter[0] = "\",\"";
//                spliter[1] = "\":\"";
//                string[] tmp2 = tmp1.Split(spliter, System.StringSplitOptions.RemoveEmptyEntries);
//                Result = new List<string[]>();
//                spliter[0] = ",";
//                for (int i = 1; i < tmp2.Length; i += 2)
//                {
//                    Result.Add(tmp2[i].Split(spliter, System.StringSplitOptions.None));
//                }
//                List<Fund.Entity.Class_SyncJJZB> JJ = new List<Fund.Entity.Class_SyncJJZB>();
//                foreach (string[] jjs in Result)
//                {
//                    Fund.Entity.Class_SyncJJZB j = new Fund.Entity.Class_SyncJJZB();
//                    j.bzdm = jjs[0];
//                    j.jjjc = jjs[1];
//                    j.jjgs = jjs[2];
//                    j.jjgsid = S2Intn(jjs[3]);
//                    j.jjjl = jjs[4];
//                    j.dwjz = S2Decn(jjs[5]);
//                    j.ljjz = S2Decn(jjs[6]);
//                    j.jzrq = S2Daten(jjs[7]);
//                    j.jjlx = S2Intn(jjs[8]);
//                    j.jjlx1 = S2Intn(jjs[9]);
//                    j.jjlx2 = S2Intn(jjs[10]);
//                    j.jjlx3 = S2Intn(jjs[11]);
//                    j.syl_r = S2Decn(jjs[12]);
//                    j.syl_z = S2Decn(jjs[13]);
//                    j.syl_y = S2Decn(jjs[14]);
//                    j.syl_3y = S2Decn(jjs[15]);
//                    j.syl_6y = S2Decn(jjs[16]);
//                    j.syl_1n = S2Decn(jjs[17]);
//                    j.syl_2n = S2Decn(jjs[18]);
//                    j.syl_3n = S2Decn(jjs[19]);
//                    j.syl_5n = S2Decn(jjs[20]);
//                    j.syl_jn = S2Decn(jjs[21]);
//                    j.syl_ln = S2Decn(jjs[22]);
//                    j.wxpj = S2Intn(jjs[23]);
//                    j.htpj = S2Intn(jjs[24]);
//                    j.zspj = S2Intn(jjs[25]);
//                    j.szpj = S2Intn(jjs[26]);
//                    j.cxpj = S2Intn(jjs[27]);
//                    j.japj = S2Intn(jjs[28]);
//                    j.fxdj = S2Intn(jjs[29]);
//                    j.zk = S2Decn(jjs[30]);
//                    j.kfgm = S2Intn(jjs[31]);
//                    JJ.Add(j);
//                }
                //MongoServer mongodb = MongoServer.Create("Server=127.0.0.1");
                //MongoDatabase mongoDataBase = mongodb.GetDatabase("test");
                //MongoCollection mongoCollection = mongoDataBase.GetCollection("PXHPJX");
                //mongodb.Connect();
                //mongoCollection.InsertBatch(JJ);
//            }
//            catch { }

//        }

//        public static int? S2Intn(string s)
//        {
//            int i;
//            if (int.TryParse(s, out i))
//                return i;
//            else
//                return null;
//        }

//        public static decimal? S2Decn(string s)
//        {
//            decimal d;
//            if (decimal.TryParse(s, out d))
//                return d;
//            else
//                return null;
//        }

//        public static DateTime? S2Daten(string s)
//        {
//            DateTime d;
//            if (DateTime.TryParse(s, out d))
//                return d;
//            else
//                return null;
//        }











































//        class o
//        {
//            public int i = 12;
//            public string s = "eee";
//        }


//        class Codes
//        {
//            public int FundCode { get; set; }
//            public int MoneyCode { get; set; }
//            public string Date { get; set; }
//        }


//        void wwww()
//        {
//            MongoServer mongodb = MongoServer.Create("Server=127.0.0.1");
//            MongoDatabase mongoDataBase = mongodb.GetDatabase("test");
//            MongoCollection mongoCollection = mongoDataBase.GetCollection("PXHPJX");
//            mongodb.Connect();

//            FundWebService.FundWebServiceSoapClient fc = new FundWebService.FundWebServiceSoapClient();
//            DataTable dt = fc.GetFirstTransMoney();
//            List<Codes> List = new List<Codes>();
//            foreach (DataRow dr in dt.Rows)
//            {
//                Codes c = new Codes();
//                c.FundCode = int.Parse(dr["FundCode"].ToString());
//                c.MoneyCode = int.Parse(dr["MoneyCode"].ToString());
//                c.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
//                List.Add(c);
//            }
//            mongoCollection.InsertBatch(List);
//        }














//        private string ZeroString(int l)
//        {
//            string s = "";
//            while (l > 0)
//            {
//                s += "0";
//                l--;
//            }
//            return s;
//        }

//        List<int> PowerString2Int(string s)
//        {
//            List<int> l;
//            if (s.Length % 4 == 0)
//            {
//                l = new List<int>();
//                try
//                {
//                    for (int i = s.Length / 4; i > 0; i--)
//                    {
//                        l.Add(int.Parse(s.Substring((i - 1) * 4, 4)));
//                    }
//                }
//                catch
//                {
//                    l = null;
//                }
//            }
//            else
//                return null;
//            return l;
//        }
//    }
//}