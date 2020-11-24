using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DummyBinding;

namespace funcapp
{
    public static class SampleBindingFunction
    {
        [FunctionName("SampleBindingFunction")]
        public static async Task<DummyMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [Dummy(ConStr = "MyConStrSetting")] DummyMessage inDummy,
            ILogger log)
        {
            // output binding
            DummyMessage outDummy = new DummyMessage
            {
                Id = "Sending out from",
                Name = inDummy.Name
            };

            // print the input binding to screen
            //return new OkObjectResult($"I got Id: {inDummy.Id} and Name: {inDummy.Name} from the binding");
            return outDummy;
        }
    }
}
