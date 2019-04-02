using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvocacyPro.Models.Logging
{
    public class LogEntry
    {
        public long Id { get; set; }
        public DateTime EventDate { get; set; }
        public LogLevel LogLevel { get; set; }
        public int EventId { get; set; }
        public string Message { get; set; }
    }
}
