using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Caching;
using System.Threading;
using System.Web.Caching;

namespace WebApplication1
{
    public partial class memorycache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CacheItemPolicy p = new CacheItemPolicy();
            p.SlidingExpiration = new TimeSpan(0, 20, 0);
            CacheItem item = new CacheItem("default", "default.value");
            CacheDependency dep = new CacheDependency(null, new string[] { "default" });
            MemoryCache mc1 = new MemoryCache("mc1");
            mc1.Add(new CacheItem("mc1", "mc1.value"), new CacheItemPolicy());
            //Label1.Text = mc1.Name;
            MemoryCache.Default.Add(item, p);
            MemoryCache.Default.Add(new CacheItem("mc1", "mc1.value"), new CacheItemPolicy());

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MemoryCache.Default.Add(new CacheItem("mc1", "mc1.value2"), new CacheItemPolicy());

            string name = TextBox1.Text;
            //MemoryCache mc = new MemoryCache(name);
            object obj = MemoryCache.Default.Get(name);
            if (obj == null)
                Label1.Text = "Null!";
            else
                Label1.Text = obj.ToString();
        }

    }
}