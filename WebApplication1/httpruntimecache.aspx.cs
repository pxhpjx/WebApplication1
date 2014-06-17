using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class httpruntimecache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpRuntime.Cache.Add("key2", "value1", new System.Web.Caching.CacheDependency(null, new string[] { "key1" }), System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), System.Web.Caching.CacheItemPriority.Normal, null);
            object obj1 = HttpRuntime.Cache.Get("key2");

            HttpRuntime.Cache.Add("key1", "value1", null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), System.Web.Caching.CacheItemPriority.Normal, null);
            object obj2 = HttpRuntime.Cache.Get("key1");

            HttpRuntime.Cache.Add("key2", "value2", new System.Web.Caching.CacheDependency(null, new string[] { "key1" }), System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 20, 0), System.Web.Caching.CacheItemPriority.Normal, null);
            obj2 = HttpRuntime.Cache.Get("key2");

            HttpRuntime.Cache.Insert("key1", "value1new");
            obj1 = HttpRuntime.Cache.Get("key1");
            obj2 = HttpRuntime.Cache.Get("key2");
        }
    }
}