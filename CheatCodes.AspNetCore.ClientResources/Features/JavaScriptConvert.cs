using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace CheatCodes.AspNetCore.ClientResources.Features
{
    public static class JavaScriptConvert
    {
        /// <summary>
        /// .Net 객체를 JavaScript 객체로 변환
        /// <example>
        /// <para />
        /// 다음 코드는 jsObj 객체를 생성한다.
        /// <code>
        /// const jsObj = @JavaScriptConvert.SerializeObject(new { Name = "John", Age = 30 });
        /// </code>
        /// </example>
        /// </summary>
        /// <param name="value"></param>

        /// <returns></returns>
        public static HtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer();

                // We don't want quotes around object names
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }
    }
}
