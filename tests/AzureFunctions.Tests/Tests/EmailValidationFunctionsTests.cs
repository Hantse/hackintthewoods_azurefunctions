using AzureFunctions.Tests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Xunit;
using AzureFunctionsEmailValidation;

namespace AzureFunctions.Tests
{
    public class EmailValidationFunctionsTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Theory]
        [InlineData("test@test.com")]
        [InlineData("test-123@test.com")]
        [InlineData("test_123@test.com")]
        public async void Http_trigger_should_return_valid_email(string email)
        {
            var request = TestFactory.CreateHttpRequest("email", email);
            var response = (OkResult)await EmailValidatorFunction.Run(request, logger);
            Assert.Equal(200, response.StatusCode);
        }

        [Theory]
        [InlineData("test@testcom")]
        [InlineData("test-123test.com")]
        [InlineData("test_123@test")]
        [InlineData("")]
        [InlineData(null)]
        public async void Http_trigger_should_return_invalid_email(string email)
        {
            var request = TestFactory.CreateHttpRequest("email", email);
            var response = (BadRequestResult)await EmailValidatorFunction.Run(request, logger);
            Assert.Equal(400, response.StatusCode);
        }
    }
}
