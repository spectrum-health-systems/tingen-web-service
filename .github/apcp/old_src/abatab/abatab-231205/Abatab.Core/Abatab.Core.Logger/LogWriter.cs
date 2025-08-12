// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;

namespace Abatab.Core.Logger
{
    /// <summary>Writes a log to a file.</summary>
    public static class LogWriter
    {
        /// <summary>Write an alert log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName".)</param>
        /// <param name="callMember">The calling method (e.g., "MethodName").</param>

        public static void WriteAlert(AbSession abSession,string assemblyName,string callPath,string callMember)
        {
            string logPath = LogPath.Alert(abSession);
            string logMsg  = LogBuilder.BuildAlert(abSession, assemblyName, callPath, callMember);

            // DEVNOTE Probably don't need this next line.
            //int writeDelay = Convert.ToInt32(abSession.LoggerDelay);

            FileIO.WriteLocal(logPath,logMsg);
            // DEVNOTE Probably don't need this next line.
            //FileIO.WriteLocal(logPath, logMsg, writeDelay); // DEVNOTE: Prob don't need.
        }

        /// <summary>Write a session log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="logMsg">The log message.</param>
        public static void WriteSession(AbSession abSession,string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath,logMsg);
        }

        /// <summary>Write a settings log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="logMsg">The log message.</param>
        public static void WriteSetting(AbSession abSession,string logMsg)
        {
            string logPath = LogPath.Session(abSession);

            FileIO.WriteLocal(logPath,logMsg);
        }

        /// <summary>Write a trace log.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="assemblyName">The executing assembly name.</param>
        /// <param name="logMsg"></param>
        /// <param name="callPath">The calling class (e.g., "ClassName".)</param>
        /// <param name="callMember">The calling method (e.g., "MethodName").</param>
        /// <param name="callLine">The calling line of the method (e.g., "100"</param>

        public static void WriteTrace(AbSession abSession,string assemblyName,string logMsg,string callPath,string callMember,int callLine)
        {
            string logPath = LogPath.Trace(abSession, assemblyName, callPath, callMember, callLine);
            int writeDelay = Convert.ToInt32(abSession.LoggerDelay);

            FileIO.WriteLocal(logPath,logMsg,writeDelay);
        }
    }
}