using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace Howest.Functions;

public class CalculatorTrigger
{
    private readonly ILogger<CalculatorTrigger> _logger;

    public CalculatorTrigger(ILogger<CalculatorTrigger> logger)
    {
        _logger = logger;
    }

    [Function("CalculatorTrigger")]
    public IActionResult Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req,
        int a,
        int b)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        int result = a + b;
        return new OkObjectResult($"The sum of {a} and {b} is {result}");
    }
}