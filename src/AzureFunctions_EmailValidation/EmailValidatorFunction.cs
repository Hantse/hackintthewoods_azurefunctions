using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AzureFunctionsEmailValidation
{
    public static class EmailValidatorFunction
    {
        [FunctionName("EmailValidatorFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "validation/email")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger for validate email based on regex.");

            string email = req.Query["email"];

            if (!string.IsNullOrEmpty(email))
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);

                if (match.Success)
                    return new OkResult();
            }

            return new BadRequestResult();
        }
    }
}
