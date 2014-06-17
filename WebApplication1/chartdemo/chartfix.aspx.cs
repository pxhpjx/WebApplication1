using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.chartdemo
{
    public partial class chartfix : System.Web.UI.Page
    {
        public string chartdata = "{cycle:'05-13',date:'05-13',total:'3.9962',link:''},{cycle:'03-26',date:'03-26',total:'3.2011',link:''},{cycle:'03-25',date:'03-25',total:'3.5201',link:''},{cycle:'03-22',date:'03-22',total:'3.3012',link:''},{cycle:'03-21',date:'03-21',total:'3',link:''},{cycle:'03-20',date:'03-20',total:'3.2401',link:''},{cycle:'03-19',date:'03-19',total:'3.1525',link:''},{cycle:'03-18',date:'03-18',total:'3.1110',link:''},{cycle:'03-15',date:'03-15',total:'2.9235',link:''},{cycle:'03-14',date:'03-14',total:'3.2022',link:''}";
        protected void Page_Load(object sender, EventArgs e)
        {
            double Max = 11.42;
            double Min = 8.35;
            int Height = (int)(130 - Min / Max * 80);
            if (Height < 40)
                Height = 40;
            hfBankRate.Value = "0.35";
            hfHeight.Value = Height.ToString();
        }
    }
}