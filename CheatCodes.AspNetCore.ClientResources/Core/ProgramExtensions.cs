using System.Globalization;

namespace CheatCodes.AspNetCore.ClientResources.Core
{
    public static class ProgramExtensions
    {
        public static void AddCreateJSObjectInServer(this WebApplicationBuilder builder)
        {
            // 로컬라이제이션 서비스 추가
            builder.Services.AddLocalization(options =>
            {
                // 리소스 파일이 위치한 디렉토리를 지정
                options.ResourcesPath = "Resources";
            });
        }

        public static void UseCreateJSObjectInServer(this WebApplication app)
        {
            var supportedCultures = new[]
            {
                new CultureInfo("en-US"),
                new CultureInfo("ko-KR"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en-US"),
                // 숫자, 날짜 등의 포맷
                SupportedCultures = supportedCultures,
                // UI 문자열
                SupportedUICultures = supportedCultures
            });

        }
    }

}
