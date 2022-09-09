using Microsoft.Extensions.Logging;

namespace BlazorWA.Logging
{
    public class DbLoggerConfiguration
    {
        public int EventId { get; set; }
        public List<LogLevel> LogLevel { get; set; }
        public string ConnectionString { get; set; }
    }
}