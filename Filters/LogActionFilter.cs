using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string controllerName = context.Controller.GetType().Name;
        string actionName = context.ActionDescriptor.DisplayName;
        string logMessage = $"Method: {controllerName}.{actionName}, Time: {DateTime.Now}";

        // Записати у файл
        string filePath = "Logs/ActionLog.txt";
        File.AppendAllText(filePath, logMessage + Environment.NewLine);
    }
}
