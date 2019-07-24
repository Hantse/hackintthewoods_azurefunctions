using AzureFunctions.Tests.Infrastructure;
using Microsoft.Extensions.Logging;
using Xunit;
using AzureFunctionsFibonacci;
using Microsoft.Azure.WebJobs.Extensions.Timers;
using Microsoft.Azure.WebJobs;
using System;

namespace AzureFunctions.Tests
{
    public class FibonacciFunctionsTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Theory]
        [InlineData("test@test.com")]
        [InlineData("test-123@test.com")]
        [InlineData("test_123@test.com")]
        public void Http_trigger_should_return_valid_email(string email)
        {
            //var timer = new TimerInfo(new TimerSchedule().GetNextOccurrence(DateTime.Now), new ScheduleStatus());

            //FibonacciFunction.Run(timer, logger);
        }
    }
}
