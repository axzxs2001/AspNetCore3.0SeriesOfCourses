using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Log009.LogTest
{
    public interface ILogTestService
    {
        void Log();
    }
    public class LogTestService : ILogTestService
    {
        private readonly ILogger<LogTestService> _logger;

        public LogTestService(ILogger<LogTestService> logger)
        {
            _logger = logger;
        }
        public void Log()
        {
            _logger.LogTrace("-----LogTestService   Trace");
            _logger.LogCritical("-----LogTestService    Critical");
            _logger.LogDebug("-----LogTestService    Debug");
            _logger.LogWarning("-----LogTestService    Warning");
            _logger.LogInformation("-----LogTestService    Information");
            _logger.LogError("-----LogTestService    Error");
        }
    }
}
