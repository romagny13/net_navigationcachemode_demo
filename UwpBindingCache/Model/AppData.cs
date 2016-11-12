using Windows.Storage;

namespace UwpBindingCache.Model
{
    public class AppData
    {
        public static void SaveSetting(string key, object value)
        {
            var settings = ApplicationData.Current.LocalSettings;
            settings.Values[key] = value;
        }

        public static object GetSetting(string key)
        {
            var settings = ApplicationData.Current.LocalSettings;
            if (settings.Values.ContainsKey(key))
            {
                var value = settings.Values[key];
                return value;
            }
            return null;
        }

        public static void RemoveSetting(string key)
        {
            var settings = ApplicationData.Current.LocalSettings;
            if (settings.Values.ContainsKey(key))
            {
                settings.Values.Remove(key);
            }
        }
    }
}
