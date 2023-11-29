using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        string actionName = context.ActionDescriptor.RouteValues["action"]!;
        string controllerName = context.ActionDescriptor.RouteValues["controller"]!;
        string logMessage = $"{DateTime.Now} - Action '{actionName}' in controller '{controllerName}' started.";

        LogToFile(logMessage);
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        
    }

    private void LogToFile(string logMessage)
    {
        string logFilePath = @"D:\all .net project\Lab11\Lab11\TxtFiles\Task.txt";

        using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
        {
            streamWriter.WriteLine(logMessage);
        }
    }
}