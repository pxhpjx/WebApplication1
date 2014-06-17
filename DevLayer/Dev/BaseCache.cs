using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Fund.Web.Admin.Web.CommonLayer
{
    public static class BaseCache
    {
        public static void SetAbsolute(string key, object obj, double CacheSeconds, CacheItemPriority Level = CacheItemPriority.Normal)
        {
            HttpRuntime.Cache.Insert(key, obj, null, DateTime.UtcNow.AddSeconds(CacheSeconds), System.Web.Caching.Cache.NoSlidingExpiration, Level, null);
        }

        public static void SetSliding(string key, object obj, int CacheSeconds, CacheItemPriority Level = CacheItemPriority.Normal)
        {
            HttpRuntime.Cache.Insert(key, obj, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, CacheSeconds), Level, null);
        }

        public static void Remove(string key)
        {
            HttpRuntime.Cache.Remove(key);
        }

        public static object Get(string key)
        {
            return HttpRuntime.Cache.Get(key);
        }
    }
}
