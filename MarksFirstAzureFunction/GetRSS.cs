using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace MarksFirstAzureFunction
{
    public static class GetRSS
    {
        private static HttpClient _httpClient = new HttpClient();

        


        [FunctionName("GetRSS")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            // The EC weather XML url for North Battleford
            const string rssURI = "https://weather.gc.ca/rss/city/sk-34_e.xml";

            string rawXML = await _httpClient.GetStringAsync(rssURI);

            return new OkObjectResult(rawXML);            

        }

    }
}
