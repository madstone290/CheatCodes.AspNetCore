using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Configuration.Json;
using System.Runtime.CompilerServices;

namespace CheatCodes.AspNetCore.Configuration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ILogger<ConfigController> _logger;
        private readonly IConfiguration _configuration;

        public ConfigController(ILogger<ConfigController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("CommandLine")]
        public IEnumerable<string> GetCommandLine()
        {
            return ((IConfigurationRoot)_configuration).GetConfigStrings(typeof(CommandLineConfigurationProvider));
        }

        [HttpGet]
        [Route("EnviornmentVariable")]
        public IEnumerable<string> GetEnviornmentVariable()
        {

            return ((IConfigurationRoot)_configuration).GetConfigStrings(typeof(EnvironmentVariablesConfigurationProvider));
        }

        [HttpGet]
        [Route("Json")]
        public IEnumerable<string> GetJson()
        {
            return ((IConfigurationRoot)_configuration).GetConfigStrings(typeof(JsonConfigurationProvider));
        }

    }
}