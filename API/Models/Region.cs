using System;
namespace API.Models {
    public static class Region {
        public static Apache.Geode.Client.IRegion<string, string> Initalize(string name, Apache.Geode.Client.Cache cache) {
            if (string.IsNullOrEmpty(name) || cache == null) {
                throw new ArgumentNullException();
            }

            Apache.Geode.Client.RegionFactory regionFactory = cache.CreateRegionFactory(Apache.Geode.Client.RegionShortcut.PROXY);
            Apache.Geode.Client.IRegion<string, string> region = regionFactory.Create<string, string>(name);

            return region;
        }
    }
}
