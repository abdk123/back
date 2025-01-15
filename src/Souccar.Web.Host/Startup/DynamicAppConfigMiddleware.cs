using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace Souccar.Web.Host
{
    public static class DynamicAppConfigMiddlewareBuilder
    {
        public static IApplicationBuilder UseDynamicAppConfig(this IApplicationBuilder builder, IConfigurationRoot appConfiguration)
        {
            var serverRootAddress = appConfiguration["App:ServerRootAddress"];
            var clientRootAddress = appConfiguration["App:ClientRootAddress"];
            return builder.UseMiddleware<DynamicAppConfigMiddleware>(serverRootAddress, clientRootAddress);
        }
    }

    public class DynamicAppConfigMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _serverRootAddress;
        private readonly string _clientRootAddress;

        public DynamicAppConfigMiddleware(RequestDelegate next, string serverRootAddress, string clientRootAddress)
        {
            _next = next;
            _serverRootAddress = serverRootAddress;
            _clientRootAddress = clientRootAddress;
        }

        public async Task Invoke(HttpContext context)
        {
            const string appConfigPath = "/assets/appconfig.production.json";
            var isRequestingAppConfig = appConfigPath.Equals(context.Request.Path.Value, StringComparison.CurrentCultureIgnoreCase);
            if (isRequestingAppConfig)
            {
                string response = GenerateResponse();
                await context.Response.WriteAsync(response);
            }
            else
            {
                await _next.Invoke(context);
            }
        }

        private string GenerateResponse()
        {
            var cleanServerRootAddress = _serverRootAddress.TrimEnd('/');
            var cleanClientRootAddress = _clientRootAddress.TrimEnd('/');
            return $@"{{
                        ""remoteServiceBaseUrl"": ""{cleanServerRootAddress}"",
                        ""appBaseUrl"": ""{cleanClientRootAddress}""
                        }}";
        }
    }
}