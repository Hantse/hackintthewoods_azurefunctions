using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunctionsFibonacci
{
    public static class FibonacciFunction
    {
        [FunctionName("Fibonacci")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            int fibonacciIndex = DateTime.Now.Hour + DateTime.Now.Minute;
            log.LogInformation($"C# Fibonacci Result: {Fibonacci(fibonacciIndex)}");
        }

        public static int Fibonacci(int n)
        {
            int a = 0;
            int b = 1;

            for (int i = 0; i < n; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}
