using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(FunctionApp.Startup))]
namespace FunctionApp
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(
            IFunctionsHostBuilder builder)
        {
            var services =
                builder.Services;

            var cosmosClient =
                new CosmosClientBuilder(
                        Environment.GetEnvironmentVariable("CosmosConnectionString"))
                    .WithConnectionModeDirect()
                    .Build();

            services.AddSingleton(cosmosClient);
        }
    }
}
