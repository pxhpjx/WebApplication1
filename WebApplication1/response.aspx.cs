using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string s = HttpContext.Current.Request.Url.Host;
            Response.Clear();
            //Response.ContentEncoding = Encoding.Unicode;
            Response.ContentEncoding = Encoding.GetEncoding("UTF-8");
            Response.Write("\u003chtml\u003e\r\n\u003cbody\u003e\r\n    \u003cform  accept-charset=\u0027gbk\u0027 id=\u0027form1\u0027 name=\u0027form1\u0027 action=\u0027https://shanghu.yeepay.com/merchant/fundServlet\u0027 method=\u0027post\u0027\u003e\r\n    \u003cinput type=\u0027hidden\u0027 name=\u0027data\u0027 id= \u0027dataid\u0027 value=\u0027PE1zZ1Rlcz48R3JwPjxHcnBIZWFkPjxWZXJzaW9uPjIuMS4wPC9WZXJzaW9uPjxCdXNDZD4xMDAxPC9CdXNDZD48TWN0Q2Q+MjAxMjA1MjUwMDE8L01jdENkPjxTZW5kRGF0ZT4yMDE0MDExNjwvU2VuZERhdGU+PFNlbmRUaW1lPjE0MDk1NjwvU2VuZFRpbWU+PFNlbmRTZXE+MjAxNDAxMTYxNDA5NTYyNjQyNjk8L1NlbmRTZXE+PC9HcnBIZWFkPjxHcnBCb2R5PjxTaWduVHlwZT4xPC9TaWduVHlwZT48Q3N0TmFtZT7lvqHlnYIxMDAzNDwvQ3N0TmFtZT48Q2VydFR5cGU+MDEwPC9DZXJ0VHlwZT48Q2VydENvZGU+MzcwNzI1MTk5MDEyMjYwMDIxPC9DZXJ0Q29kZT48QmFua05vPjMwMzwvQmFua05vPjxVbmlvbkJhbmtObz4zMDMxMDAwMDAwMTQ8L1VuaW9uQmFua05vPjxDc3RDYXJkPjYyMjY2NjA2MDY2ODQ2NzI8L0NzdENhcmQ+PEJha1VybD5odHRwOi8vMTcyLjE2LjczLjQwOjQ1Njc4L0JhbmtIYW5kbGUvUmVnQ2hlY2tDYXJkLmFzcHg/Y29udGV4dD1Ic3BBOGNYZW5CRmM8L0Jha1VybD48UmVtYXJrPjwvUmVtYXJrPjwvR3JwQm9keT48L0dycD48U2lnbj5GOEVWRFd5aE9FVVNoUUJMY0RSZ3M2WFZrdGFsMG02ZEtWY0NxTm9oZDduRVBuWnNuNDFrbWtOaWFTOHNFUDJGc0ovY1d3OGRwK1d3Qmc0R3ZtYldNWlMveURjQXQrMCsvT1hjK0g1RG05K2ZqTEdvSlBMKzBsclV3bTVpMnRBeTc3anAzcm1NQ1o0U0hHUFNQdTNsODFQTUI1UVV2dlpha2xFbW5vV3FOUU09PC9TaWduPjwvTXNnVGVzPg==\u0027/\u003e\r\n    \u003c/form\u003e\r\n\u003c/body\u003e\r\n\u003cscript\u003edocument.getElementById(\u0027form1\u0027).submit();\u003c/script\u003e\r\n\u003c/html\u003e");
        }
    }
}