// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Logger
{
    /// <summary>Create the path for a log file.</summary>
    internal static class LogPath
    {
        /// <summary>Create a filepath for an alert log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>An alert log filepath.</returns>
        public static string Alert(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            var logPath = $@"{abSession.AlertLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}"; // REVIEW Oof, this is ugly.

            Utility.FileSys.VerifyDirectory(logPath); // REVIEW Do we need this?

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }

        /// <summary>Create a filepath for a trace log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName".)</param>
        /// <param name="callMember">The calling method (e.g., "MethodName").</param>
        /// <param name="callLine">The calling line of the method (e.g., "100"</param>
        /// <returns>A trace log filepath.</returns>
        public static string Trace(AbSession abSession,string assemblyName = "",string callPath = "",string callMember = "",int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            return $@"{abSession.TraceLogDirectory}\{DateTime.Now:HHmmss_fffffff}-{assemblyName}-{Path.GetFileName(callPath)}-{callMember}-{callLine}-[TRACE].md";
        }

        /// <summary>Create a filepath for a session log.</summary>
        /// <param name="abSession">The Abatab session object.</param> 
        public static string Session(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            return $@"{abSession.SessionDataDirectory}\{DateTime.Now:HHmmss.fffffff}-[SESSION].md";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string Setting(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            return $@"{abSession.AbatabDataRoot}\{abSession.AvatarEnvironment}\Abatab current settings.md";
        }

        /// <summary>Create a filepath for a warning log.</summary>
        /// <param name="abSession">The Abatab session object.</param> 
        public static string Warning(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            var logPath = $@"{abSession.WarningLogDirectory}\{abSession.SentOptionObject.OptionUserId}\{DateTime.Now:yyMMdd}\{abSession.RequestModule}\{abSession.RequestCommand}"; // REVIEW Oof, this is ugly.

            Utility.FileSys.VerifyDirectory(logPath); // REVIEW Do we need this?

            return $@"{logPath}\{DateTime.Now:HHmmss}-{abSession.RequestAction}.md";
        }
    }
}