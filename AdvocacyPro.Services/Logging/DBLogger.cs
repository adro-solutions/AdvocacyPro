using AdvocacyPro.Data;
using AdvocacyPro.Models.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace AdvocacyPro.Services.Logging
{
    public class DBLogger : ILogger
    {
        private string ConnectionString;

        public DBLogger(string connectionString) { ConnectionString = connectionString; }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel != LogLevel.Debug;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string message = string.Empty;

            if (formatter != null)
            {
                message = formatter(state, exception);
            }
            else
            {
                message = state?.ToString() ?? exception?.Message;
            }

            LogToDB(new LogEntry
            {
                EventDate = DateTime.UtcNow,
                EventId = eventId.Id,
                LogLevel = logLevel,
                Message = message
            });
        }

        public void LogToDB(LogEntry entry)
        {
            if (!DataContext.Initialized)
                return;

            string commandStr = "INSERT INTO [dbo].[Log] ([EventId],[LogLevel],[Message],[EventDate]) " +
                "VALUES (@EventId, @LogLevel, @Message, @EventDate)";
            
            List<SqlParameter> paramList = new List<SqlParameter>();
            paramList.Add(new SqlParameter("EventId", entry.EventId));
            paramList.Add(new SqlParameter("LogLevel", entry.LogLevel));
            paramList.Add(new SqlParameter("Message", entry.Message));
            paramList.Add(new SqlParameter("EventDate", entry.EventDate));

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                if (conn.State != System.Data.ConnectionState.Open)
                    conn.Open();

                using (SqlCommand command = new SqlCommand(commandStr, conn))
                {
                    command.Parameters.AddRange(paramList.ToArray());
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
