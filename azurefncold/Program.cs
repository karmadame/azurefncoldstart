using azurefncold.Infra;
using azurefncold.Logic;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = FunctionsApplication.CreateBuilder(args);

// builder.ConfigureFunctionsWebApplication();

builder.Services
    .AddApplicationInsightsTelemetryWorkerService()
    .ConfigureFunctionsApplicationInsights();

builder.Services.AddTransient<TodoRepo>();
builder.Services.AddTransient<TodoQuery>();
builder.Services.AddTransient<Lazy<TodoRepo>>(provider => new Lazy<TodoRepo>(provider.GetRequiredService<TodoRepo>));
builder.Services.AddTransient<Lazy<TodoQuery>>(provider => new Lazy<TodoQuery>(provider.GetRequiredService<TodoQuery>));

builder.Build().Run();
