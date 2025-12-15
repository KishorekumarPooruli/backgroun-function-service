using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace background_function_service
{
    public static class Echo
    {
        [FunctionName("Echo")]
        public static async Task<IActionResult> RunAsync(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            ILogger logger)
        {
            logger.LogInformation("HTTP Trigger Executed Successfully");
            Stream body = req.Body;
            string requestBody = await new StreamReader(body).ReadToEndAsync();
            return new OkObjectResult($"This HTTP triggered function executed successfully. Content: {requestBody}");
        }
    }
}
