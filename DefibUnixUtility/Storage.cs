using System;
using System.Linq;
using System.IO;

namespace DefibWindowsUtility
{
    static class Storage
    {
        static string BasePath;

        public static bool RequiresPreparation()
        {
#if LINUX
            BasePath = "/etc/defib"
#endif
#if OSX
            BasePath = "/etc/defib"
#endif

            if (!Directory.Exists(BasePath))
            {
                Directory.CreateDirectory(BasePath);
            }

            return false;
        }

        public static void PrepareRegistry()
        {
            return;
        }

        public static bool ExistsAlias(string alias)
        {
            if (!File.Exists(string.Format("{0}/{1}.dfk", BasePath, alias)))
            {
                return false;
            }

            return true;
        }

        public static void CreateAlias(string alias, string key)
        {
            FileStream stream = File.Create(string.Format("{0}/{1}.dfk", BasePath, alias));
            stream.Dispose();

            File.WriteAllText(string.Format("{0}/{1}.dfk", BasePath, alias), key);
        }

        public static void UpdateAlias(string alias, string key)
        {
            File.WriteAllText(string.Format("{0}/{1}.dfk", BasePath, alias), key);
        }

        public static string FetchAlias(string alias)
        {
            return File.ReadAllText(string.Format("{0}/{1}.dfk", BasePath, alias));
        }

        public static void DeleteAlias(string alias)
        {
            File.Delete(string.Format("{0}/{1}.dfk", BasePath, alias));
        }
    }
}
