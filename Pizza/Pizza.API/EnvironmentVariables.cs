namespace Pizza.API;

public static class EnvironmentVariables
{
    private static IConfiguration _configuration;

    public static void Initialize(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static string GetEnvironmentVariable(string key)
    {
        return _configuration[key];
    }

    public static string ConnectionString => _configuration["ConnectionStrings:DefaultConnection"] ?? throw new ApplicationException("Null connection string");
}
