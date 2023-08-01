using Newtonsoft.Json;
using ServiceStack.Text;
using System.Dynamic;
using System.Text;

namespace CheatCodes.AspNetCore.ClientResources.Core
{
    public static class ResourceGroupExtensions
    {
        /// <summary>
        /// Converts the source data to a Javascript variable
        /// </summary>
        /// <param name="resources">The record to convert</param>
        /// <returns>A valid Javascript object</returns>
        public static string ToJavascript(this IEnumerable<ResourceGroup> resources)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("let Resources = ");

            Dictionary<string, object> dict = new Dictionary<string, object>();

            foreach (ResourceGroup resourceGroup in resources)
            {
                string[] objectNames = resourceGroup.Name.Split(".");
                Dictionary<string, object> parent = dict;

                for (int i = 0; i < objectNames.Length; i++)
                {
                    string objName = objectNames[i];
                    if (i == objectNames.Length - 1)
                    {
                        parent[objName] = resourceGroup.Entries.ToDictionary(x => x.Name.ToString(), x => x.Value);
                    }
                    else
                    {
                        if (!parent.TryGetValue(objName, out object child))
                        {
                            parent[objName] = new Dictionary<string, object>();
                            child = parent[objName];
                        }
                        parent = child as Dictionary<string, object>;
                    }
                }
            }

            string serialized = JsonConvert.SerializeObject(dict);
            sb.Append(serialized);
            sb.Append(";");

            return sb.ToString();
        }
    }
}
