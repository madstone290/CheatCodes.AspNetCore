using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Localization;
using System.Reflection;
using System.Text;

namespace CheatCodes.AspNetCore.ClientResources.Core
{
    /// <summary>
    /// 리소스 파일을 자바스크립트 객체로 변환하여 클라이언트에 전달
    /// </summary>
    [HtmlTargetElement("resources")]
    public class ResourcesTagHelper : TagHelper
    {
        private readonly IStringLocalizerFactory _stringLocalizerFactory;

        public ResourcesTagHelper(IStringLocalizerFactory stringLocalizerFactory)
        {
            _stringLocalizerFactory = stringLocalizerFactory;
        }

        /// <summary>
        /// 리소스 그룹 이름. 쉼표로 구분하여 여러개 지정 가능.
        /// </summary>
        [HtmlAttributeName("groups")]
        public string Groups { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var groupNames = Groups.Split(",").Select(x => x.Trim());

            IEnumerable<ResourceGroup> groupedResources = groupNames.Select(groupName =>
            {
                string resourceLocation = Assembly.GetEntryAssembly().FullName;
                IStringLocalizer localizer = _stringLocalizerFactory.Create(groupName, resourceLocation);
                var entries = localizer.GetAllStrings(true).ToList();
                return new ResourceGroup { Name = groupName, Entries = entries };
            });

            StringBuilder sb = new StringBuilder();
            sb.Append(groupedResources.ToJavascript());

            TagHelperContent content = await output.GetChildContentAsync();
            sb.Append(content.GetContent());

            // <script> 태그로 변환한다.
            output.TagName = "script";
            output.Content.AppendHtml(sb.ToString());
        }
    }
}
