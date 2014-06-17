using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DevLayer.Dev
{
    public static class XmlSplitter
    {
        public static void SplitByNode(string xml)
        {
            XmlDocument Doc = new XmlDocument();
            Doc.LoadXml("<?xml version=\"1.0\" encoding=\"UTF-8\"?><response><header><error><code>0</code></error><session_id>hp1h3otokgben8hr26ih6049o4</session_id><revision><card_rev>238</card_rev><boss_rev>239</boss_rev><item_rev>238</item_rev><card_category_rev>238</card_category_rev><gacha_rev>238</gacha_rev><privilege_rev>232</privilege_rev><combo_rev>238</combo_rev><eventbanner_rev>238</eventbanner_rev><resource_rev><revision>238</revision><filename>res</filename></resource_rev><resource_rev><revision>148</revision><filename>sound</filename></resource_rev><resource_rev><revision>232</revision><filename>advbg</filename></resource_rev><resource_rev><revision>221</revision><filename>cmpsheet</filename></resource_rev><resource_rev><revision>238</revision><filename>gacha</filename></resource_rev><resource_rev><revision>148</revision><filename>privilege</filename></resource_rev><resource_rev><revision>238</revision><filename>eventbanner</filename></resource_rev></revision><next_scene>6100</next_scene><lock_unlock><scenario_voice>1</scenario_voice></lock_unlock></header><body><exploration_area><area_info_list><area_info><id>95293</id><name>【活动】初到异界箱庭1</name><x>-98</x><y>-90</y><prog_area>4</prog_area><prog_item>0</prog_item><area_type>1</area_type><race_type>2</race_type></area_info><area_info><id>90500</id><name>【新手】初期探索升级</name><x>-115</x><y>-135</y><prog_area>66</prog_area><prog_item>0</prog_item><area_type>1</area_type><race_type>2</race_type></area_info><area_info><id>50004</id><name>拒绝万物的朽木之森</name><x>-29</x><y>-129</y><prog_area>0</prog_area><prog_item>0</prog_item><area_type>1</area_type><race_type>2</race_type></area_info><area_info><id>1</id><name>人鱼的断崖</name><x>-29</x><y>-129</y><prog_area>3</prog_area><prog_item>0</prog_item><area_type>0</area_type><race_type>2</race_type></area_info></area_info_list></exploration_area></body></response>");
            var responseNode = Doc.ChildNodes[1];
            IList<IDictionary<string, string>> ss = new List<IDictionary<string, string>>();
        }
    }
}
