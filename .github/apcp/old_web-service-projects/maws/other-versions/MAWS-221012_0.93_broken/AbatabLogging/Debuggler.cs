// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

/* ========================================================================================================
 * PLEASE READ #1
 * --------------
 * Logging is done a little differently in AbatabLogging.csproj, since trying to create logs using the same
 * code that creates logs results in strange behavior.
 *
 * For the most part, LogEvent.Trace() is replaced with Debugger.BuildDebugLog(), although in some cases
 * log files aren't written at all. This makes it a little difficult to troubleshoot logging, which is why
 * it's a good idea to test the logging functionality extensively prior to deploying to production.
 ========================================================================================================*/

/* ========================================================================================================
 * PLEASE READ #2
 * --------------
 * Abatab debugging functionality should only be used for development/debugging. There is a hardcoded 100ms
 * delay when writing a debug log file, and there for should not be used production environments due to
 * the performance penalties it creates.
 *
 * The "DebugMode" setting in Web.config should be set to "off" unless you are debugging the Abatab source
 * code. Debug logs will only be written if DebugMode is set to "on".
 *
 * The advantage of debug logs is that you can create them at any time, even prior to the creation of a
 * SessionData object. All you need to do is add the following line anywhere in your code:
 *
 *      LogDebug.Debug()
 *
 * This will create a basic debug log file in the following hardcoded location:
 *
 *      C:\AvatoolWebService\Abatab_UAT\logs\debug\%yyMMdd%\%HHmmssfffffff%-%executingAssembly%-%callerPath%}-%callerMember%-%callerLine%.debug"
 *
 * You can also debug the debugger by setting "debugDebugger" to "true" in LogDebug.DebugContent(), which
 * will create additional debug files to aid in troubleshooting. These files have an additional hardcoded
 * 1000ms delay when they are written, and will cause significant performance issues when Abatab executes.
 ========================================================================================================*/

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace AbatabLogging
{
    /// <summary>
    /// Logic for debugging functionality.
    /// </summary>
    public class Debuggler
    {
        /// <summary>Builds a debug log file.</summary>
        /// <param name="debugMode">The Abatab debug mode.</param>
        /// <param name="debugMsg">The debug log message.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="exeAssembly">The name of executing assembly.</param>
        /// <param name="callPath">The filename of where the log is coming from.</param>
        /// <param name="callMember">The method name of where the log is coming from.</param>
        /// <param name="callLine">The file line of where the log is coming from.</param>
        public static void BuildDebugLog(string exeAssembly, string debugMode, string debugLogRoot = "", string debugMsg = "", [CallerFilePath] string callPath = "", [CallerMemberName] string callMember = "", [CallerLineNumber] int callLine = 0)
        {
            //if (debugMode == "on" || debugMode == "undefined") // TODO Remove.
            if (debugMode == "on")
            {
                const bool debugDebugger = false;

                DebugTheDebuggler(debugDebugger, debugLogRoot, "001");

                if (string.IsNullOrWhiteSpace(debugLogRoot))
                {
                    debugLogRoot = @"C:\AvatoolWebService\Abatab_UAT\logs\debug";
                }

                debugLogRoot = $@"{debugLogRoot}\{DateTime.Now:yyMMdd}"; // TODO Move this to where other dirs are created.
                _=Directory.CreateDirectory(debugLogRoot);

                DebugTheDebuggler(debugDebugger, debugLogRoot, "002");

                if (string.Equals(debugMode, "on", StringComparison.OrdinalIgnoreCase))
                {
                    DebugTheDebuggler(debugDebugger, debugLogRoot, "003");

                    /* Delay creating a debug log by 100ms, just to make sure we don't overwrite an
                     * existing log. This will have a negative affect on performance.
                     */
                    Thread.Sleep(100);

                    DebugTheDebuggler(debugDebugger, debugLogRoot, "004");

                    var debugContent = BuildContent.DebugComponents(exeAssembly, debugMode, debugMsg, callPath, callMember, callLine);

                    DebugTheDebuggler(debugDebugger, debugLogRoot, "005");

                    File.WriteAllText($@"{debugLogRoot}\{DateTime.Now:HHmmssfffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debug", debugContent);

                    DebugTheDebuggler(debugDebugger, debugLogRoot, "006");
                }

                DebugTheDebuggler(debugDebugger, debugLogRoot, "007");
            }
        }

        /// <summary>Debugs the debugger.</summary>
        /// <param name="debugDebugger">The flag that determines if the debugger should be debugged.</param>
        /// <param name="debugLogRoot">The debug log root directory.</param>
        /// <param name="debugMsg">The debugger log message.</param>
        private static void DebugTheDebuggler(bool debugDebugger, string debugLogRoot, string debugMsg)
        {
            if (debugDebugger)
            {
                /* Delay creating a debug log by 1000ms, just to make sure we don't overwrite an
                 * existing log. This will have a significant negative affect on performance.
                 */
                Thread.Sleep(1000);

                File.WriteAllText($@"{debugLogRoot}\{DateTime.Now:HHmmssfffffff}-Debugger[{debugMsg}].debug", debugMsg);
            }
        }
    }
}
