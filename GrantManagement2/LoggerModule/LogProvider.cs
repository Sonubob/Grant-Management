using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GrantManagement.LoggerModule
{
    [ProviderAlias("LogFile")]
    public class LogProvider: ILoggerProvider
    {
        public readonly LogOptions _logOptions;

        public LogProvider(LogOptions logOptions)
        {
            _logOptions = logOptions;

            if (!Directory.Exists(_logOptions.FolderPath))
            {
                Directory.CreateDirectory(_logOptions.FolderPath);
            }
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new GMLogger(this);
        }
        public void Dispose()
        {
        }
    }
}
