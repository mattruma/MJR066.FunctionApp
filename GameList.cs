using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace FunctionApp
{
    public class GameList
    {
        private readonly CosmosClient _cosmosClient;

        public GameList(
            CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        [FunctionName(nameof(GameList))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation($"{nameof(GameList)} processed a request.");

            var cosmosContainer =
                _cosmosClient.GetContainer("games", "collections");

            var cosmosQuery =
                cosmosContainer.GetItemLinqQueryable<Game>();

            var cosmosFeedIterator = cosmosQuery
                .ToFeedIterator();

            var gameDataList =
                await cosmosFeedIterator.ReadNextAsync();

            return new OkObjectResult(gameDataList.ToList());
        }
    }
}