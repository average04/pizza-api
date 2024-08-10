using Pizza.Application;

var builder = WebApplication.CreateBuilder(args);

// Initialize environment variables
EnvironmentVariables.Initialize(builder.Configuration);

// Add more services here!
builder.Services
    .AddApiServices()
    .AddApplicationServices()
    .AddInfrastructureServices(EnvironmentVariables.ConnectionString);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiServices();

app.Run();
