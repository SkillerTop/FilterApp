using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

public class UniqueUsersFilter : IActionFilter
{
    private readonly ILogger<UniqueUsersFilter> _logger;

    public UniqueUsersFilter(ILogger<UniqueUsersFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string ipAddress = context.HttpContext.Connection.RemoteIpAddress.ToString();
        string filePath = "Logs/UniqueUsers.txt";

        if (!File.Exists(filePath) || !File.ReadAllText(filePath).Contains(ipAddress))
        {
            File.AppendAllText(filePath, $"{ipAddress}{Environment.NewLine}");

            _logger.LogInformation($"User {ipAddress} added to UniqueUsers.txt");
        }
        else
        {
            _logger.LogInformation($"User {ipAddress} already exists in UniqueUsers.txt");
        }
    }
}
