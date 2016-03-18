using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public partial class regex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = "zzz:667  192.168.1.1:667 :667 192.168.1.2:567";
            Regex reg = new Regex("192.168.1.1:(?<port>[\\d]+)");
            string m = reg.Replace(str, "eee");



            string sssp = "http://i1.s1.dpfile.com/2008-02-01/330397_b.jpg(139c100)/thumb.jpg";
            //string ssp = "[{\"TypeName\":\"ResName\",\"OldValue\":\"\",\"NewValue\":\"一线烫捞(金虹桥店)\"},{\"TypeName\":\"ShopName\",\"OldValue\":\"\",\"NewValue\":\"金虹桥店\"},{\"TypeName\":\"CuisineIds\",\"OldValue\":\"\",\"NewValue\":\"221\"},{\"TypeName\":\"RegionIds\",\"OldValue\":\"\",\"NewValue\":\"840\"},{\"TypeName\":\"BusinessStatus\",\"OldValue\":\"\",\"NewValue\":\"正常\"},{\"TypeName\":\"Address\",\"OldValue\":\"\",\"NewValue\":\"茅台路179号金虹桥国际中心商场\"},{\"TypeName\":\"TaskScore\",\"OldValue\":\"\",\"NewValue\":\"0\"},{\"TypeName\":\"EnvironmentScore\",\"OldValue\":\"\",\"NewValue\":\"0\"},{\"TypeName\":\"ServiceScore\",\"OldValue\":\"\",\"NewValue\":\"0\"},{\"TypeName\":\"Avrg\",\"OldValue\":\"\",\"NewValue\":\"0\"},{\"TypeName\":\"DianpingCityId\",\"OldValue\":\"\",\"NewValue\":\"1\"},{\"TypeName\":\"District\",\"OldValue\":\"\",\"NewValue\":\"840\"},{\"TypeName\":\"Maptype\",\"OldValue\":\"\",\"NewValue\":\"1\"},{\"TypeName\":\"CanSwingCard\",\"OldValue\":\"\",\"NewValue\":\"0\"}]";
            //Regex rrrrrrrrrrrrrrr = new Regex("(?<p1>[\\d-]+)/[\\d]+");
            //Match mmm = rrrrrrrrrrrrrrr.Match(sssp);
            //string sss = mmm.Groups["p1"].Value;
            //bool b = mmm.Success;

            ////rrrrrrrrrrrrrrr.Replace(ssp,)

            //sssp = sssp.Replace(sss, null);


            //return;




            //string h = GetFromFile<string>("D:\\DianPingMobileData\\city_1\\11548063\\main.html");

            //Regex rrrrr = new Regex("href=\"/shop/[\\d]+/product-[\\S]+?\"");

            //Match mmmm = rrrrr.Match(h.Replace("\n", ""));


            return;






            //string html = GetFromFile<string>("C:\\1.html");
            //Regex regbc = new Regex("<div class=\"breadcrumb\">[\\s\\S]+?</div>");
            //string bc = RegexMatchHelper.MatchValue(html, regbc, "0");
            //Regex r = new Regex("http://www.dianping.com/search/category/[\\0-9g]+r(?<r>[0-9]+)");
            //Regex c = new Regex("http://www.dianping.com/search/category/[\\0-9r]+g(?<c>[0-9]+)");
            //List<string> ls = new List<string>();
            //var m = r.Match(bc);
            //while (m.Success)
            //{
            //    ls.Add(m.Groups["r"].Value);
            //    m = m.NextMatch();
            //}
            //m = c.Match(bc);
            //while (m.Success)
            //{
            //    ls.Add(m.Groups["c"].Value);
            //    m = m.NextMatch();
            //}
            //string branh = RegexMatchHelper.MatchValue(html, new Regex("href=\"/addshop/[\\d]+_10/id=(?<no>[\\d]+)\""), "no");


            return;

            //string s = "AAA ddd sd+'g' 啊 饿哦";
            //Regex reg = new Regex("[^\u4e00-\u9fa5]+");
            ////Regex reg = new Regex("[^\u4e00-\u9fa5]+ [ ^\u4e00-\u9fa5]+");
            //Match m = reg.Match(s);
            //int i = m.Index;
            //i++;










            //return;



            //string xml = @"<f><t>qwer</t><dd>1234</dd></f><f><t>asdf</t><dd>5678</dd><t>asdf</t><dd></dd></f>";
            //FormatTools.SeekXmlNodeValue(xml, "dd", "\\d*");
            //FormatTools.SeekXmlNodeValues(xml, "f");
        }

        public void t1()
        {
            Regex r = new Regex("5\\d\\d\\d");
            int matches = r.Matches("qqqqqq").Count;
            matches = r.Matches("1111").Count;
            matches = r.Matches("5111").Count;
            matches = r.Matches("6111").Count;
            matches = r.Matches("11136").Count;
            matches = r.Matches("11136").Count;
            string sss = " a b ".Trim();
        }

        public void t2()
        {
            Regex r = new Regex(@"<dd>\d*</dd>");
            string xml = @"<f><t>qwer</t><dd>1234</dd></f><f><t>asdf</t><dd>5678</dd></f>";
            Match m = r.Match(xml);
            //string mr = m.Result("");
            string v = m.Value;
        }

        public static T GetFromFile<T>(string sFile)
        {
            if (!File.Exists(sFile))
            {
                return default(T);
            }
            try
            {
                return XMS.Core.Json.JsonSerializer.Deserialize<T>(File.ReadAllText(sFile, Encoding.UTF8));
            }
            catch (System.IO.IOException e)
            {
                XMS.Core.Container.LogService.Error(e.ToString());
                return GetFromFile<T>(sFile);
            }
            catch (Exception ex)
            {
                XMS.Core.Container.LogService.Error(ex.ToString());
                return default(T);
            }
        }

    }



    public class RegexMatchHelper
    {
        /// <summary>
        /// 匹配正则获取单个数据
        /// </summary>
        /// <param name="sSource"></param>
        /// <returns></returns>
        public static string MatchValue(string sSource, Regex reg, string sMatchName, Regex backUpReg = null)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (string.IsNullOrWhiteSpace(sSource) || reg == null || string.IsNullOrWhiteSpace(sMatchName))
            {
                return string.Empty;
            }
            Match match = reg.Match(sSource);
            dic = GetDicByMatch(match, reg, sMatchName);
            if (dic != null && dic.Count > 0 && dic.ContainsKey(sMatchName))
            {
                return dic[sMatchName];
            }
            if (backUpReg != null)
            {
                match = backUpReg.Match(sSource);
                dic = GetDicByMatch(match, backUpReg, sMatchName);
                if (dic != null && dic.Count > 0 && dic.ContainsKey(sMatchName))
                {
                    return dic[sMatchName];
                }
            }
            return string.Empty;
        }


        /// <summary>
        /// 匹配正则获取多个数据
        /// </summary>
        /// <param name="sSource"></param>
        /// <param name="reg"></param>
        /// <returns></returns>
        public static List<Dictionary<string, string>> MatchValues(string sSource, Regex reg, List<string> lstMatchName, Regex backUpReg = null)
        {
            List<Dictionary<string, string>> listDic = new List<Dictionary<string, string>>();
            if (string.IsNullOrWhiteSpace(sSource) || reg == null || lstMatchName == null || lstMatchName.Count <= 0)
            {
                return listDic;
            }
            MatchCollection matchCollection = reg.Matches(sSource);
            listDic = GetListDicByMatchCollection(matchCollection, reg, lstMatchName);
            if (listDic != null && listDic.Count > 0)
            {
                return listDic;
            }
            if (backUpReg != null)
            {
                matchCollection = backUpReg.Matches(sSource);
                listDic = GetListDicByMatchCollection(matchCollection, backUpReg, lstMatchName);
            }
            return listDic;
        }


        private static Dictionary<string, string> GetDicByMatch(Match match, Regex reg, string sMatchName)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (match != null && match.Groups.Count > 0 && reg != null && !string.IsNullOrWhiteSpace(sMatchName))
            {
                string[] sGroupNames = reg.GetGroupNames();
                if (sGroupNames != null && sGroupNames.Length > 0)
                {
                    foreach (string sName in sGroupNames)
                    {
                        if (sName == sMatchName && !string.IsNullOrWhiteSpace(match.Groups[sName].Value.Trim()))
                        {
                            dic[sName] = match.Groups[sName].Value.Trim();
                        }
                    }
                }
            }
            return dic;
        }

        private static List<Dictionary<string, string>> GetListDicByMatchCollection(MatchCollection matchCollection, Regex reg, List<string> listMatchName)
        {
            List<Dictionary<string, string>> listDic = new List<Dictionary<string, string>>();
            if (matchCollection != null && matchCollection.Count > 0)
            {
                string[] sGroupNames = reg.GetGroupNames();
                if (sGroupNames != null && sGroupNames.Length > 0 && listMatchName != null && listMatchName.Count > 0)
                {
                    for (int i = 0; i < matchCollection.Count; i++)
                    {
                        Dictionary<string, string> dic = new Dictionary<string, string>();
                        foreach (string sName in sGroupNames)
                        {
                            if (listMatchName.Contains(sName) && !string.IsNullOrWhiteSpace(matchCollection[i].Groups[sName].Value.Trim()))
                            {
                                dic[sName] = matchCollection[i].Groups[sName].Value.Trim();
                            }
                        }
                        if (dic.Count > 0)
                        {
                            listDic.Add(dic);
                        }
                    }
                }
            }
            return listDic;
        }
    }

}