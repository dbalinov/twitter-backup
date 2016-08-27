using System;
using System.Web;
using System.Web.Caching;

namespace TwitterBackup.Infrastructure.Cacheing
{
    internal class WebCacheProvider : ICacheProvider
    {
        public T Get<T>(string key)
            where T : class
        {
            var cache = HttpContext.Current.Cache;
            return cache.Get(key) as T;
        }

        public void Set<T>(string key, T value)
        {
            var cache = HttpContext.Current.Cache;
            cache.Insert(key, value);
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            var cache = HttpContext.Current.Cache;
            cache.Insert(key, value, null, DateTime.Now.Add(expiration), Cache.NoSlidingExpiration);
        }
    }
}
