using Abstergo.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstergo.Core
{
    public static class SM
    {
        private readonly static string _currentCulture = CultureInfo.CurrentCulture.ToString();

        public static string GetString(string key)
            => _GetString(key, _currentCulture);
        public static string GetString(string key, string culture)
            => _GetString(key, culture);
        public static void AddString(string key, string value)
            => _Add(key, value, _currentCulture);
        public static void DeleteString(string key)
            => _Delete(key, _currentCulture);
        public static void UpdateString(string key, string value)
            => _Update(key, value, _currentCulture);

        private static void _Add(string key, string value, string _currentCulture)
        {
            throw new NotImplementedException();
        }

        private static void _Delete(string key, string _currentCulture)
        {
            throw new NotImplementedException();
        }

        private static void _Update(string key, string value, string _currentCulture)
        {
            throw new NotImplementedException();
        }

        private static string _GetString(string key, string culture)
        {
            var value = new List<MultiLangModel>();
            CacheMan.StringList.TryGetValue(key, out value);

            return value == null ? "" : value.Where(a => a.Culture == culture)
                 .Select(b => b.Value)
                 .FirstOrDefault();
        }

        private static void FillStringCache() {

        }
    }
}
