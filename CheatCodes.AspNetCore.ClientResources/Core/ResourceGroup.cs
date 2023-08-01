using Microsoft.Extensions.Localization;

namespace CheatCodes.AspNetCore.ClientResources.Core
{
    public class ResourceGroup
    {
        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Group entries
        /// </summary>
        public IEnumerable<LocalizedString> Entries { get; set; }
    }
}
