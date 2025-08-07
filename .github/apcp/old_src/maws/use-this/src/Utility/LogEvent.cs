/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.LogEvent.cs
 * UPDATED: 1-15-2022-6:19 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Writes log files.
 *
 * This logic isn't logged, since it would create tons of data that probably wouldn't be very useful (you can probably
 * deduce what's wrong with logging by looking at whatever logs are - or are not - being written).
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Utility
{
    public class LogEvent
    {
        /// <summary>
        /// Determines if a log file should be written.
        /// </summary>
        /// <param name="logSetting">      The logging setting in the .settings file.</param>
        /// <param name="logType">         The type of log (e.g., "DEBUG", "ERROR"). This value will be enclosed in brackets, and pre-pended to the file name.</param>
        /// <param name="assemblyName">    The executing assembly name (e.g., "MyProgram"). This value will be included in the filename, as well as the log message.</param>
        /// <param name="logMessage">      The optional message that is written to the logfile ["No log message defined"]</param>
        /// <param name="callerfilePath">  The filename where the error occurred (e.g., "MyFile.cs").</param>
        /// <param name="callerMemberName">The method where the error occurred (e.g., "MyMethod()")</param>
        /// <param name="callerLineNumber">The line where the error occurred (e.g., "100")</param>
        public static void Timestamped(string logSetting, string logType, string assemblyName, string userName,
                                       string logMessage = "No log message defined.",
                                       [CallerFilePath] string callerfilePath = "",
                                       [CallerMemberName] string callerMemberName = "",
                                       [CallerLineNumber] int callerLineNumber = 0)
        {
            // REMOVE
            //var logEverything   = logSetting == "all";
            //var logSpecificType = logType.ToLower().Contains(logSetting);

            /* The logSetting can be set to "all", "none", a single specific log type, or multiple log types. If any of
             * these cases are met, we'll write a logfile.
             */
            if(logSetting == "all" || logType.ToLower().Contains(logSetting))
            {
                WriteTimestampedFile(logType, assemblyName, userName, logMessage, callerfilePath, callerMemberName, callerLineNumber);
            }
        }

        /// <summary>
        /// Writes a timestamped log file.
        /// </summary>
        /// <param name="logType">         The type of log (e.g., "DEBUG", "ERROR"). This value will be enclosed in brackets, and pre-pended to the file name.</param>
        /// <param name="assemblyName">    The executing assembly name (e.g., "MyProgram"). This value will be included in the filename, as well as the log message.</param>
        /// <param name="logMessage">      The optional message that is written to the logfile ["No log message defined"]</param>
        /// <param name="callerfilePath">  The filename where the error occurred (e.g., "MyFile.cs").</param>
        /// <param name="callerMemberName">The method where the error  occurred (e.g., "MyMethod()")</param>
        /// <param name="callerLineNumber">The line where the error  occurred (e.g., "100")</param>
        public static void WriteTimestampedFile(string logType, string assemblyName, string userName,
                                                string logMessage, string callerfilePath, string callerMemberName,
                                                int callerLineNumber)
        {
            // TODO Get this working
            /* Get the logging configuration settings.
             */
            //Dictionary<string, string> logSetting = ExternalConfiguration.FromKeyValuePairFile("Logging.conf");
            //var logDelay                          = Convert.ToInt32(logSetting["LogDelay"]);
            var logDelay = 10;

            if(userName == null)
            {
                userName = "_MAWS";
            }

            /* Normally logfiles have unique names, but in the event that the current logfile name is a duplicate, we'll
             * call that out in the logfile contents.
             */
            var fileNameIsDuplicate = false;

            // Get the DateTime, and verify that a folder with that name exists in Logs/
            var dateStamp        = DateTime.Now.ToString("yyMMdd");
            var logDirectoryPath = $"C:/MAWS/Logs/{dateStamp}/{userName}";
            Maintenance.ConfirmDirectoryExists(logDirectoryPath);

            /* Build the logfile name, which is pretty descriptive.
             */
            var logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerLineNumber);

            /* Get the logfile path.
             */
            var logFilePath = $"{logDirectoryPath}/{logFileName}";

            if(File.Exists(logFilePath))
            {
                /* If you are writing a lot of logfiles, there is the potential that duplicate names will occur. To
                 * Avoid this, a 100ms pause will take place before re-creating the filename and writing the file,
                 * ensuring that the name will be different.
                 */
                Thread.Sleep(10);
                logFileName = BuildLogFileName(logType, assemblyName, Path.GetFileName(callerfilePath), callerLineNumber);
                logFilePath = $"{logDirectoryPath}/{logFileName}";

                /* We will also call this out in the logfile contents.
                 */
                fileNameIsDuplicate = true;
            }

            // TODO This doesn't work, need to figure out how to get it working and then add "[{assemblyVersion}]" to
            //      the end of the log message.
            /* Get the Assembly Version, which we'll tack on to the end of the logfile for development/troubleshooting
             * purposes.
             */
            //var assemblyVersion = Assembly.GetEntryAssembly().GetName().Version.ToString();

            /* Create the content to be written to the logfile. The last line is development data that might be useful
             * in troubleshooting.
             */
            var logContents = $"======={Environment.NewLine}" +
                              $"MESSAGE{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"{logMessage}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"DETAILS{Environment.NewLine}" +
                              $"======={Environment.NewLine}" +
                              $"     Assembly name: {assemblyName}{Environment.NewLine}" +
                              $"  Source file path: {Path.GetFileName(callerfilePath)}{Environment.NewLine}" +
                              $"Source member name: {callerMemberName}{Environment.NewLine}" +
                              $"Source line number: {callerLineNumber}{Environment.NewLine}" +
                              $"{Environment.NewLine}" +
                              $"[MAWS LOG] [delay: {logDelay}ms] [duplicate: {fileNameIsDuplicate}]";

            /* By default the Logging.conf file should have a 0ms delay before writing logfiles, but when you are
             * writing many files, the chances are that the timestamp will be the same for multiple files, which can
             * make it difficult to determine in which order things happened. You can change the logDelay to be
             * something like 100ms, and that will ensure timestamps are different - at the expense of taking longer
             * to write files.
             *
             * Not working yet.
             */
            Thread.Sleep(logDelay);

            File.WriteAllText(logFilePath, logContents);
        }

        /// <summary>
        /// Build a logfile name.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="assemblyName"></param>
        /// <param name="callerfilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <returns>A logfile name string.</returns>
        private static string BuildLogFileName(string logType, string assemblyName, string callerfilePath,
                                               int callerLineNumber)
        {
            /* The first part of the logfile name is the time.
             */
            var timeStamp = DateTime.Now.ToString($"HHmmss.fffffff");

            /* The second part of the logfile name is the userName, which is passed to this method, so this comment is
             * here just for reference.
             */

            /* The third part of the logfile name is the logType, which is passed to this method, so this comment is
             * here just for reference.
             */

            /* The fourth part of the logfile name is the Assembly Name, which is passed to this method, so this
             * comment is here just for reference. The Assembly Name ends up being the MAWS Command - taken from the
             * project name - which is passed, so if you are logging something from the Dose Command, the Assembly Name
             * will be "Dose".
             */

            /* This pulls the filePath part of the name, which ends up being the MAWS Action - taken from a class
             * name - which is passed as a filename, and the extension is removed. So if you are logging something from
             * the "Compare" action of the "Dose" command, the callerFilePathWithoutExtension will be "Compare".
             */
            var fileExtensionLocation          = callerfilePath.IndexOf('.');
            var callerfilePathWithoutExtension = callerfilePath.Remove(fileExtensionLocation);

            /* The last part of the logfile name is the line number that is being logged, which is passed to this
             * method, so this comment is here just for reference. Originally the name also included the method name
             * (e.g., "Percentage" from "Dose-Compare"), but that ended up creating really long filenames, and just
             * having the line number is enough to figure out where to look.
             */

            /* Put it altogether.
             */
            var logFileName = $"{timeStamp}-{logType}-{assemblyName}-{callerfilePathWithoutExtension}-{callerLineNumber}.mawslog";

            return logFileName;
        }
    }
}

// REMOVE
/*

=================
DEVELOPMENT NOTES
=================

-------------
Timestamped()
-------------
When you call Utility.LogEvent.Timestamped(), you pass all the information that is need to write a logfile for a specific event,
which includes:
    - Whatever the current "Logging" setting is (e.g., "error"), which can vary depending on the .conf file being worked with
    - The type of logfile being passed (e.g., "ERROR")
    - All of the log information (messages, locations, et al.)

The first thing Timestamped() does is determine if a logfile should be written at all:

    -> If the "Logging" setting is "all", a logfile is written.
    -> If the "Logging" setting is another value:
       -> Determine what the passed logType is (e.g., "ERROR") AND if that logType is in the "Logging" setting.
          -> If the passed logType is found, write the logfile
          -> If the passed logType is not found, don't write the logfile.

The "Logging" setting can be a string of logTypes that are delimited by a "-". For example, "Logging=error-debug" would write all
logTypes of "ERROR" and "DEBUG", but no other logTypes. More information about how this work can be found in the .conf files.

The downside to this method is that every time LogEvent.Timestamped() is called, we do all of what is described above...and in
some cases it is determined that a logfile will not be created, which technically wastes time. The upside is that the type of logs
that can be written are completely agnostic: all you need to do is pass a particular logType, and make sure that logType is
defined in the "Logging" setting.


-------------
WriteTimestampedFile()
-------------
- The totally cool logic that determines the filepath/method/line number of the message that is being logged came
  from this article:
     https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/attributes/caller-information

- Code blocks:

    ```
    if(File.Exists(logFilePath))
    {
        > Since logfiles are written very quickly, it's possible that two logfiles will have the same name. The logic in this
        > block ensures filenames are unique by adding a few milliseconds to the timestamp when a duplicate filename is found.
    }
    ```

 */