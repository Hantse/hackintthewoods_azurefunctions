using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace AzureFunctionsFibonacci
{
    public static class FibonacciFunction
    {
        [FunctionName("Fibonacci")]
        public static void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            long fibonacciIndex = DateTime.Now.Hour + DateTime.Now.Minute;
            log.LogInformation($"C# Fibonacci Result: {Fibonacci(fibonacciIndex)} for {fibonacciIndex} (index)");
        }

        public static long Fibonacci(long n)
        {
            long a = 0;
            long b = 1;

            for (long i = 0; i < n; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
            }

            return a;
        }
    }
}
