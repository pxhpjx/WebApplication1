using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _try : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = "33333";
            try
            {
                throw new ArgumentException("?");
                char c = s[34];
            }
            catch (ArgumentNullException anex)
            {
            }
            //catch (ArgumentException aex)
            //{
            //}
            //catch
            //{ }
            //finally
            //{
            //}
        }
    }
}