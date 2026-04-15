using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeLogger
    {
        public static Logger logger { get; private set; }
        public static bool Initialized { get; private set; } = false;
        public static void init(string logfilename)
        {
            logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(logfilename, rollingInterval: RollingInterval.Day, retainedFileCountLimit: 3)
                .CreateLogger();

            Initialized = true;
            logger.Debug("Logger initialized.");
        }
    }
}
