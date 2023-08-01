namespace CheatCodes.AspNetCore.Configuration
{
    public static class ConfigurationExtenstions
    {

        /// <summary>
        /// 주어진 제공자에 포함된 설정을 가져온다.
        /// </summary>
        /// <param name="configurationRoot"></param>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetConfigStrings(this IConfigurationRoot configurationRoot, Type providerType)
        {
            var children = configurationRoot.GetChildren();
            List<string> output = new List<string>();
            AddStringToList(configurationRoot, children, providerType, output);
            return output;
        }

        private static void AddStringToList(IConfigurationRoot root, IEnumerable<IConfigurationSection> configurationSections, Type providerType, List<string> stringList)
        {
            foreach (var config in configurationSections)
            {
                var providers = GetProviders(root, config.Path);
                var provider = providers.FirstOrDefault(x => x.GetType() == providerType);
                if(provider != null)
                {
                    var configString = string.Format("Path: {0}, Key: {1}, Value: {2}, Provider: {3}", config.Path, config.Key, config.Value, provider?.GetType().Name);
                    stringList.Add(configString);
                }
                AddStringToList(root, config.GetChildren(), providerType, stringList);
            }
        }

        /// <summary>
        /// 모든 설정을 출력한다.
        /// </summary>
        /// <param name="root"></param>
        public static void PrintAll(this IConfigurationRoot root)
        {
            var providers = root.Providers;
            var children = root.GetChildren();

            foreach (var provider in providers)
            {
                Print(root, provider, children, 0);
            }
        }

        private static void Print(IConfigurationRoot root, IConfigurationProvider targetProvider, IEnumerable<IConfigurationSection> configurationSections, int level)
        {
            foreach (var config in configurationSections)
            {
                var padding = string.Empty.PadLeft(level * 4);
                var providers = GetProviders(root, config.Path);
                if(providers.Any(x=> x.GetType() == targetProvider.GetType()))
                {
                    Console.WriteLine(padding + "Provider: {3}, Path: {0}, Key: {1}, Value: {2}", config.Path, config.Key, config.Value, targetProvider.GetType().Name);
                }
                Print(root, targetProvider, config.GetChildren(), level + 1);
            }
        }

        private static IEnumerable<IConfigurationProvider> GetProviders(IConfigurationRoot root, string key)
        {
            return root.Providers.Where(x => x.TryGet(key, out string _));
        }

    }
}
