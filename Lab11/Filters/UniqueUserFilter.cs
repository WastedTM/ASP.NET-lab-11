using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lab11.Filters;

public class UniqueUserFilter : IActionFilter
{
    private readonly HashSet<string> uniqueIPs = new HashSet<string>();
    private readonly string logFilePath = @"./TxtFiles/NewFile1.txt";

    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string ipAddress = filterContext.HttpContext.Connection.RemoteIpAddress!.ToString();
        
        if (IPAddress.IsLoopback(filterContext.HttpContext.Connection.RemoteIpAddress))
        {
            ipAddress = filterContext.HttpContext.Request.Host.Host;
        }
        
        if (uniqueIPs.Add(ipAddress))
        {
            LogToFile($"Unique user accessed with IP: {ipAddress}");
        }
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
        
    }

    private void LogToFile(string logMessage)
    {
        if (!File.Exists(logFilePath))
        {
            File.Create(logFilePath).Close();
        }

        using (StreamWriter streamWriter = new StreamWriter(logFilePath, true))
        {
            streamWriter.WriteLine($"{DateTime.Now} - {logMessage}");
        }
    }
}