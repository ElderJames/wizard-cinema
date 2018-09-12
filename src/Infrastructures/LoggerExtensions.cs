using System;
using Microsoft.Extensions.Logging;

namespace Infrastructures
{
    public static class LoggerExtensions
    {
        public static void LogError(this ILogger logger, string message, Exception exception)
        {
            logger.LogError(exception, message);
        }

        public static void Debug(this ILogger logger, string message, Exception exception)
        {
            logger.LogDebug(exception, message);
        }

        public static void Information(this ILogger logger, string message, Exception exception)
        {
            logger.LogInformation(exception, message);
        }

        public static void Warning(this ILogger logger, string message, Exception exception)
        {
            logger.LogWarning(exception, message);
        }

        public static void Critical(this ILogger logger, string message, Exception exception)
        {
            logger.LogCritical(exception, message);
        }

        public static void Trace(this ILogger logger, string message, Exception exception)
        {
            logger.LogTrace(exception, message);
        }
    }
}
