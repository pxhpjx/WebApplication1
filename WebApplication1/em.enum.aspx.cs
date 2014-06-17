using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Em.Entities;

namespace WebApplication1
{
    public partial class em__enum : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sss = EnumBusinType.RgCfm.Trim();
            sss = EnumBusinType.DqdesgCfm;
            sss = EnumBusinType.FedjCfm;
            sss = EnumBusinType.FejdCfm;
            sss = EnumBusinType.FejyCfm;
            sss = EnumBusinType.FezyCfm;
            sss = EnumBusinType.FjyghcCfm;
            sss = EnumBusinType.FjyghcCfm;
            sss = EnumBusinType.FjyghcFail;
            sss = EnumBusinType.FjyghCfm;
            sss = EnumBusinType.FjyghFail;
            sss = EnumBusinType.FjyghrCfm;
            sss = EnumBusinType.Jjqp;
            sss = EnumBusinType.JjzhcCfm;
            sss = EnumBusinType.JjzhcFail;
            sss = EnumBusinType.JjzhCfm;
            sss = EnumBusinType.JjzhFail;
            sss = EnumBusinType.JjzhrCfm;
            sss = EnumBusinType.Jjzz;
            sss = EnumBusinType.Qzsh;
            sss = EnumBusinType.Qztj;
            sss = EnumBusinType.RgclCfm;
            sss = EnumBusinType.SgCfm;
            sss = EnumBusinType.ShCfm;
            sss = EnumBusinType.ShFail;
            sss = EnumBusinType.ZtgcCfm;
            sss = EnumBusinType.ZtgcFail;
            sss = EnumBusinType.ZtgCfm;
            sss = EnumBusinType.ZtgFail;
            sss = EnumBusinType.ZtgrCfm;
            sss = EnumCashBagType.CashBagRecharge;
            sss = EnumCashBagType.CashBagWithDraw;
            sss = EnumCashBagState.FailCfmCashBag;
            sss = EnumCashBagState.HalfCfmCashBag;
            sss = EnumCashBagState.SuccessCfmCashBag;
        }
    }
}