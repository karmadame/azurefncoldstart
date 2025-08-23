using System.Net;
using azurefncold.Logic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker.Http;

namespace azurefncold;

public class ExampleLightStart(ILogger<ExampleLightStart> logger, Lazy<TodoQuery> todoQuery)
{
    
    [Function("ExampleLightStart")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req,
        CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var response = req.CreateResponse(HttpStatusCode.OK);
        logger.LogInformation("C# HTTP trigger function processed a request.");
        var todos = await todoQuery.Value.GetTodos();
        await response.WriteAsJsonAsync(todos, cancellationToken: cancellationToken);
        return response;
    }
}
