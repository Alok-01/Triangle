using Serilog;
using Serilog.Context;


namespace Triangle.Logging
{
    /// <summary>
    /// Log Sectury Class
    /// </summary>
    public static class LogSecurity
    {
        public static void Warning<T>(string messageTemplate, T propertyValue)
        {
            using (LogContext.PushProperty("Security", true))
            {
                Log.Warning(messageTemplate, propertyValue);
            }
        }

       
    }
}
