var builder = WebApplication.CreateBuilder(args);

// Initialize environment variables
EnvironmentVariables.Initialize(builder.Configuration);

// Add more services here!
builder.Services
    .AddApiServices()
    .AddInfrastructureServices(EnvironmentVariables.ConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiServices();

app.Run();
