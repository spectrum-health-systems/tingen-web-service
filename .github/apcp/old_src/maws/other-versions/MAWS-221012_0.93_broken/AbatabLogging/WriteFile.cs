// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

/* ========================================================================================================
 * PLEASE READ
 * -----------
 * Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

using System.IO;
using System.Threading;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for writing log files.
    /// </summary>
    public class WriteFile
    {
        /// <summary>Writes a log file.</summary>
        /// <param name="logPath">The log file path.</param>
        /// <param name="logContent">The log file content.</param>
        /// <param name="loggingDelay">The delay between writing log files.</param>
        public static void LocalFile(string logPath, string logContent, int loggingDelay)
        {
            Thread.Sleep(loggingDelay);

            File.WriteAllText(logPath, logContent);
        }
    }
}