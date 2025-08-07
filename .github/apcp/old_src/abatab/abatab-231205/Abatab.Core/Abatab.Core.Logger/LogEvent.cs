// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Abatab.Core.Logger
{
    /// <summary>Log and event.</summary>
    public static class LogEvent
    {
        /// <summary>Log an alert event.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName".)</param>
        /// <param name="callMember">The calling method (e.g., "MethodName").</param>

        public static void Alert(AbSession abSession,string assemblyName,[CallerFilePath] string callPath = "",[CallerMemberName] string callMember = "")
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            LogWriter.WriteAlert(abSession,assemblyName,callPath,callMember);
        }

        /// <summary>Log a trace event.</summary>
        /// <param name="logType"></param>
        /// <param name="abSession"></param>
        /// <param name="assemblyName"></param>
        /// <param name="logMsg"></param>
        /// <param name="callPath">The calling class (e.g., "ClassName".)</param>
        /// <param name="callMember">The calling method (e.g., "MethodName").</param>
        /// <param name="callLine">The calling line of the method (e.g., "100"</param>
        public static void Trace(string logType,AbSession abSession,string assemblyName,string logMsg = "",[CallerFilePath] string callPath = "",[CallerMemberName] string callMember = "",[CallerLineNumber] int callLine = 0)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            /* REVIEW
             * Is there a better way to do this, instead of checking if logging is enabled and then checking to see if the
             * types are correct?
             *
             * And potentially refactor &&/|| to and/or? Or at least clean this up so it's less confusing.
             */

            if (abSession.LoggerMode == "enabled" && (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains(logType)))
            {
                LogWriter.WriteTrace(abSession,assemblyName,logMsg,callPath,callMember,callLine);
            }
        }

        /// <summary>Log a session event.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void Session(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            LogWriter.WriteSession(abSession,Catalog.Output.Session.Complete(abSession));
        }

        /// <summary>Log the current settings.</summary>
        public static void CurrentSetting(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            LogWriter.WriteSetting(abSession,Catalog.Output.Setting.Current(abSession));
        }

        /// <summary>Log a warning event.</summary>
        public static void Warning(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name); // REVIEW Can a trace log go here, instead of a debuggler statement?

            /* DEVNOTE
             * We want to write this all the time, so the depreciated code below is probably not needed.
             */

            /* DEPRECIATED
            //if (abSession.LoggerMode == "enabled")
            //{
            //    if (abSession.LoggerTypes == "all" || abSession.LoggerTypes.Contains("warning"))
            //    {
            //        var logPath = LogPath.ForWarningLog(abSession);
            //        //var logMsg  = Catalog.Component.AlertLog.ModProgressNoteVerifyLocation(abSession);

            //        //LogWriter.LocalFile(logPath, logMsg, Convert.ToInt32(abSession.LoggerDelay));
            //    }
            //}
            */
        }
    }
}