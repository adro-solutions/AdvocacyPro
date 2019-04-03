using AdvocacyPro.Data;
using AdvocacyPro.Services.Logging;
using Microsoft.Extensions.Logging;
using System;

namespace AdvocacyPro.Services.Extensions
{
    public static class LoggerFactoryExtensions
    {
        public static ILoggingBuilder AddDBLogger(this ILoggingBuilder builder, string connectionString)
        {
            DBLoggerProvider logProvider = new DBLoggerProvider(connectionString);
            builder.AddProvider(logProvider);
            return builder;
        }
    }
}
