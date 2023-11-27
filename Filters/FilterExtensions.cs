public static class FilterExtensions
{
    public static void AddFilters(this IServiceCollection services)
    {
        services.AddScoped<LogActionFilter>();
        services.AddScoped<UniqueUsersFilter>();
    }
}
