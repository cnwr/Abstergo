using Abstergo.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Abstergo.Core
{
    public static class CacheMan
    {
        private static MemoryCache cokonat
             => MemoryCache.Default;

        public static List<MethodDefinition> TestMethods
             => cokonat["TestMethods"] as List<MethodDefinition>;

        public static Dictionary<string, List<MultiLangModel>> StringList
            => cokonat["StringList"] as Dictionary<string, List<MultiLangModel>>;

        private static CacheItemPolicy cip
            => new CacheItemPolicy
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddDays(1)),
                SlidingExpiration = new TimeSpan(0, 60, 0)
            };

        public static void SaveToCache(string key, object item, DateTime expireDate)
            => _SaveToCache(key, item, expireDate);
        public static void SaveToCache(string key, object item)
            => _SaveToCache(key, item, null);

        private static void _SaveToCache(string key, object item, DateTime? expireDate)
        {
            if (Contains(key))
            {
                RemoveFromCache(key);
            }

            var _expireDate = expireDate ?? DateTime.Now.AddYears(5);
            cokonat.Add(key, item, _expireDate);
        }

        public static void OneDayCache(string cacheKey, object item)
            => cokonat.Add(cacheKey, item, cip, null);

        public static T GetFromCache<T>(string key) where T : class
        {
            return cokonat[key] as T;
        }

        public static T GetFromCache<T>(string key, Func<T> notFound) where T : class
        {
            T obj = GetFromCache<T>(key);

            if (obj == default(T))
            {
                obj = notFound.Invoke();
            }

            return obj;
        }

        public static void RemoveFromCache(string key)
            => cokonat.Remove(key);

        public static bool Contains(string key)
        {
            return cokonat[key] != null;
        }
    }
}
