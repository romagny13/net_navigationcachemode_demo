using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UwpBindingCache.Model
{
    public class AppCache
    {
        private Dictionary<string, object> cache = new Dictionary<string, object>();

        // Singleton
        public static AppCache Default
        {
            get { return Singleton<AppCache>.Instance; }
        }

        public void Add<T>(string key, T item) where T : new()
        {
            if (cache.ContainsKey(key))
            {
                cache[key] = item;
            }
            else
            {
                cache.Add(key, item);
            }
        }

        public T Get<T>(string key) where T : new()
        {
            if (cache.ContainsKey(key))
            {
                var item = cache[key];
                return (T)item;
            }
            return default(T);
        }

        public bool Has(string key)
        {
            if (cache.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        public bool Remove(string key)
        {
            if (cache.ContainsKey(key))
            {
                cache.Remove(key);
                return true;
            }
            return false;
        }

        public async Task SaveAsync(List<Type> knownTypes)
        {
            //
        }

        public async Task RestoreAsync(List<Type> knownTypes)
        {
            //
        }
    }
}
