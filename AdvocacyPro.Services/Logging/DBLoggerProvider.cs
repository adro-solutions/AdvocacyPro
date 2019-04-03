using AdvocacyPro.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Services.Logging
{
    public class DBLoggerProvider : ILoggerProvider
    {
        private string ConnectionString;
        public DBLoggerProvider(string connectionString) { ConnectionString = connectionString;  }

        public ConcurrentDictionary<string, DBLogger> Loggers { get; set; } = new ConcurrentDictionary<string, DBLogger>();

        public ILogger CreateLogger(string categoryName)
        {
            DBLogger customLogger = Loggers.GetOrAdd(categoryName, new DBLogger(ConnectionString));
            return customLogger;
        }

        public void Dispose() { }
    }
}
