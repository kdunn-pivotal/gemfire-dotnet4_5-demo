using System;
using System.IO;

namespace API.Models {
    public static class Cache {
        private const string baseDir = @"C:\inetpub\wwwroot";

        public static Apache.Geode.Client.Cache Initalize() {
            if (!File.Exists(baseDir + @"\cache.xml")) {
                throw new FileNotFoundException();
            }

            Apache.Geode.Client.Properties<string, string> cacheProps = new Apache.Geode.Client.Properties<string, string>();
            cacheProps.Insert("cache-xml-file", baseDir + @"\cache.xml");
            cacheProps.Insert("log-level", "fine");
            cacheProps.Insert("log-file", @"c:\Logs\client.log");
            cacheProps.Insert("ssl-enabled", "true");
            cacheProps.Insert("ssl-truststore", baseDir + @"\certificatetruststore");

            Apache.Geode.Client.CacheFactory cacheFactory = Apache.Geode.Client.CacheFactory.CreateCacheFactory(cacheProps);

            Apache.Geode.Client.Cache cache = cacheFactory.Create();

            return cache;
        }
    }
}
