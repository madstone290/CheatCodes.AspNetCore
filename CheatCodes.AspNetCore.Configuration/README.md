# Configuration in ASP.NET Core
하나 이상의 configuration provider를 사용하여 앱 설정을 등록할 수 있다. 
Configuration provider는 다양한 소스에서 key/value 쌍을 읽는다.

- `appsettings.json`과 같은 설정 파일
- 환경 변수
- 명령줄 인수
- Azure Key Vault
- Azure App Configuration
- 사용자 정의 제공자
- 파일
- 닷넷 객체

## Application and Host Configuration
ASP.NET Core 앱은 호스트를 구성하고 시작한다. 호스트는 앱의 시작 및 수명관리를 담당한다.
ASP.NET Core 템플릿은 호스트를 포함한 WebApplicationBuilder를 생성한다. 
일부 설정은 호스트와 애플리케이션 설정 제공자 둘다를 통해 수행할 수 있지만 일반적으로 호스트에 필요한 설정만 호스트 설정에서 수행해야 한다.
애플리케이션 설정이 호스트 설정보다 우선시 된다.
## 기본 애플리케이션 설정 소스
`WebApplication.CreateBuilder`는 미리 설정된 기본값을 이용해 `WebApplicationBuilder` 클래스를 초기화한다.
초기화 된 `WebApplicationBuilder`는 우선 순위가 높은 순서로 다음의 기본 설정을 제공한다.

1. 명령줄 인수. Command-line configuration provider 사용.
2. 접두사가 없는 환경 변수.  Non-prefixed environment variables configuration provider 사용.
3. 사용자 보안. `Development` 환경에서 실행하는 경우에만.
4. `appsettings.Production.json`과 같은 `appsettings.{Environment}.json` 형식의 파일. JSON configuration provider 사용.

## 기본 호스트 설정 소스
`WebApplicationBuilder` 설정. 우선순위가 높은 순서대로
1. 명령줄 인수
2. `DOTNET_` 접두사 환경변수
3. `ASPNETCORE_` 접두사 환경변수

`.NET Generic Host` 및 `Web Host` 설정. 우선순위가 높은 순서대로
1. `ASPNETCORE_` 접두사 환경변수
2. 명령줄 인수
3. `DOTNET_` 접두사 환경변수

## 호스트 변수
다음 변수들은 호스트 설정에만 영향을 받으며 애플리케이션 설정에 영향을 받지 않는다.

- Application name
- Environment name, for example Development, Production, and Staging
- Content root
- Web root
- Whether to scan for hosting startup assemblies and which assemblies to scan for.
- Variables read by app and library code from HostBuilderContext.Configuration in IHostBuilder.ConfigureAppConfiguration callbacks.

## 명령줄
기본 설정을 사용하는 경우 `CommandLineConfigurationProvider`는 key-value쌍 명령줄 인수를 불러온다.
명령줄 인수는 우선순위가 제일 높아 다른 설정을 덮어쓴다. 
`=`, `/`, `--`를 사용할 수 있다.
- value는 반드시 `=` 뒤에 와야한다. 만약 공백뒤에 value가 온다면 `--` 나 `/`를 사용해야 한다.
- `=`를 사용할 경우 값을 생략할 수 있다. `Key=`

`dotnet run {app} Key=Value Student:Name=John`

`dotnet run {app} /Key Value /Student:Name=John`

`dotnet run {app} --Key Value --Student:Name=John`

## 참조
* [MSDN](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0)
