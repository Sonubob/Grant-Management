using GrantManagement.LoggerModule;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagement.Middlewares
{
    public static class LoggingExtensions
    {
        public static ILoggerFactory GMFileLogger(this ILoggerFactory loggerFactory, Action<LogOptions> configure)
        {
            var config = new LogOptions();
            configure(config);
            return loggerFactory.GMFileLogger(configure);
        }
    }
}
