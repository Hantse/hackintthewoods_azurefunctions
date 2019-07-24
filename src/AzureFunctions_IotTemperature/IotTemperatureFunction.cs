using Microsoft.Azure.EventHubs;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text;
using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;

namespace AzureFunctionsIotTemperature
{
    public static class IotTemperatureFunction
    {
        private static HttpClient client = new HttpClient();

        [FunctionName("IotTemperature")]
        public static void Run([IoTHubTrigger("messages/events", Connection = "IoTHubTriggerConnection")]EventData message, ILogger log)
        {
            log.LogInformation($"C# IoT Hub trigger function processed a message: {Encoding.UTF8.GetString(message.Body.Array)}");
        }
    }
}