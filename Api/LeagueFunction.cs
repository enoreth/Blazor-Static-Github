using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BlazorApp.Shared;
using System.Collections.Generic;

namespace BlazorApp.Api
{
    public static class LeagueFunction
    {
        [FunctionName("League")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            /**string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";
            **/

            var table = GetTable();
            return new OkObjectResult(table);
        }

        private static IEnumerable<Team> GetTable()
        {
            return new List<Team>
            {
                new Team{Name = "Besiktas", Played = 16, Points = 34},
                new Team{Name = "Gaziantep FK", Played = 16, Points = 31},
                new Team{Name = "Alanyaspor", Played = 16, Points = 30},
                new Team{Name = "Galatasaray", Played = 16, Points = 29},
            };
        }
    }
}
