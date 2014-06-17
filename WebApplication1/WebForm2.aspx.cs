using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Xml;
using System.IO;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnMakePic_Click(this, EventArgs.Empty);
        }

        private List<decimal> GetNumber()
        {
            List<decimal> FundList = new List<decimal>();
            decimal j;
            if (decimal.TryParse(txtCurrencyPer.Text, out j) && j != 0)
            {
                FundList.Add(j);
            }
            if (decimal.TryParse(txtStockPer.Text, out j) && j != 0)
            {
                FundList.Add(j);
            }
            if (decimal.TryParse(txtBondPer.Text, out j) && j != 0)
            {
                FundList.Add(j);
            }
            if (decimal.TryParse(txtSelf1Per.Text, out j) && j != 0)
            {
                FundList.Add(j);
            }
            if (decimal.TryParse(txtSelf2Per.Text, out j) && j != 0)
            {
                FundList.Add(j);
            }
            return FundList;
        }

        public void BuildPic(List<decimal> FundList)
        {
            List<decimal> Values = FundList;
            Color[] m_colors = new Color[] { Color.FromArgb(112, 181, 240), Color.FromArgb(247, 171, 51), Color.FromArgb(151, 201, 90), Color.FromArgb(240, 112, 145), Color.FromArgb(233, 240, 116) };

            Series series1 = ChartFundRate.Series["Default"];


            ChartFundRate.Series["Default"].ChartType = SeriesChartType.Pie;
            ChartFundRate.Series["Default"].Points.Clear();
            foreach (decimal d in Values)
            {
                DataPoint dp = new DataPoint();
                dp.SetValueY(d);
                ChartFundRate.Series["Default"].Points.Add(dp);
            }

            ChartFundRate.Palette = ChartColorPalette.None;
            ChartFundRate.PaletteCustomColors = m_colors;

            ChartFundRate.Series["Default"].Label = "#PERCENT{P1}";

            ChartFundRate.Series["Default"].ChartType = SeriesChartType.Pie;

            ChartFundRate.Series["Default"]["MinimumRelativePieSize"] = "50";
            ChartFundRate.Series["Default"]["3DLabelLineSize"] = "30";
            ChartFundRate.Series["Default"]["ArrowSize"] = "2.0";
            ChartFundRate.Series["Default"]["ArrowsType"] = "Triangle";


            ChartFundRate.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = false;
            ChartFundRate.Series[0]["PieDrawingStyle"] = "Default";

        }

        private XmlDocument XmlCreate()
        {
            txtOutputXml.Text = "";
            XmlDocument doc = new XmlDocument();
            decimal j;
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("FundInfo");
            doc.AppendChild(root);
            XmlElement element1 = doc.CreateElement("类型");
            element1.InnerText = ddlPersonalRiskType.SelectedValue;
            root.AppendChild(element1);
            XmlNode node1 = doc.CreateElement("风险等级");
            XmlElement element2 = doc.CreateElement("低风险");
            element2.InnerText = chkFundRisk1.Checked.ToString();
            node1.AppendChild(element2);
            XmlElement element3 = doc.CreateElement("较低风险");
            element3.InnerText = chkFundRisk2.Checked.ToString();
            node1.AppendChild(element3);
            XmlElement element4 = doc.CreateElement("中风险");
            element4.InnerText = chkFundRisk3.Checked.ToString();
            node1.AppendChild(element4);
            XmlElement element5 = doc.CreateElement("较高风险");
            element5.InnerText = chkFundRisk4.Checked.ToString();
            node1.AppendChild(element5);
            XmlElement element6 = doc.CreateElement("高风险");
            element6.InnerText = chkFundRisk5.Checked.ToString();
            node1.AppendChild(element6);
            root.AppendChild(node1);
            XmlElement element7 = doc.CreateElement("描述");
            element7.InnerText = txtDescription.Text;
            root.AppendChild(element7);
            XmlNode node2 = doc.CreateElement("配置");
            if (decimal.TryParse(txtCurrencyPer.Text, out j) && j != 0)
            {
                XmlElement element8 = doc.CreateElement("货币型");
                element8.InnerText = txtCurrencyPer.Text;
                node2.AppendChild(element8);
            }
            if (decimal.TryParse(txtStockPer.Text, out j) && j != 0)
            {
                XmlElement element9 = doc.CreateElement("股票型");
                element9.InnerText = txtStockPer.Text;
                node2.AppendChild(element9);
            }
            if (decimal.TryParse(txtBondPer.Text, out j) && j != 0)
            {
                XmlElement element10 = doc.CreateElement("债券型");
                element10.InnerText = txtBondPer.Text;
                node2.AppendChild(element10);
            }
            if (decimal.TryParse(txtSelf1Per.Text, out j) && j != 0)
            {
                XmlElement element11 = doc.CreateElement(txtSelf1.Text);
                element11.InnerText = txtSelf1Per.Text;
                node2.AppendChild(element11);
            }
            if (decimal.TryParse(txtSelf2Per.Text, out j) && j != 0)
            {
                XmlElement element12 = doc.CreateElement(txtSelf2.Text);
                element12.InnerText = txtSelf2Per.Text;
                node2.AppendChild(element12);
            }
            root.AppendChild(node2);

            txtOutputXml.Text = doc.OuterXml;
            return doc;
        }

        protected void btnMakePic_Click(object sender, EventArgs e)
        {
            List<decimal> FundList = GetNumber();
            BuildPic(FundList);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            List<decimal> FundList = GetNumber();
            BuildPic(FundList);
            XmlCreate();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string path = txtPath.Text;
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                XmlDocument doc = XmlCreate();
                Random r = new Random();
                string file = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "+" + r.Next(1000);
                doc.Save(path + "\\" + file + ".xml");
                ChartFundRate.SaveImage(path + "\\" + file + ".png");
                lblTip.Text = "保存成功";
                if(chkView.Checked)
                    System.Diagnostics.Process.Start("Explorer.exe", path);
            }
            catch
            {
                lblTip.Text = "保存失败！请检查权限和路径名！";
            }
        }
    }
}