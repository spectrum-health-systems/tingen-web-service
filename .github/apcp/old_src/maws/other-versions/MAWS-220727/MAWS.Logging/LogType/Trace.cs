// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Logging.LogType.Trace.cs
// Logic for MAWS trace logs.
// b220726.112734
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// ---------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.CompilerServices;


namespace MAWS.Logging.LogType
{
    public class Trace
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mawsSettings"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        public static void LogEvent(string sessionStamp, string avatarUserName, [CallerFilePath] string callerFilePath = "", [CallerMemberName] string callerMemberName = "", [CallerLineNumber] int callerLine = 0)
        {
            var logfileContent = CreateContent(sessionStamp, callerFilePath, callerMemberName, callerLine);
            var logfilePath    = MAWS.Logging.LogFile.Details.GetPath(avatarUserName, sessionStamp);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionStamp"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        public static string CreateContent(string sessionStamp, string callerFilePath, string callerMemberName, int callerLine)
        {
            return $"{LogHeader()}" +
                   $"{LogBody(sessionStamp)}" +
                   $"{LogFooter(callerFilePath, callerMemberName, callerLine)}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static string LogHeader()
        {
            return $"TRACE LOG{Environment.NewLine}" +
                   $"---------{Environment.NewLine}";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sessionStamp"></param>
        /// <returns></returns>
        private static string LogBody(string sessionStamp)
        {
            return $"Session: {sessionStamp}{Environment.NewLine}";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        private static string LogFooter(string callerFilePath, string callerMemberName, int callerLine)
        {
            return $"  Source: {Path.GetFileName(callerFilePath)}{Environment.NewLine}" +
                   $"  Member: {callerMemberName}{Environment.NewLine}" +
                   $"    Line: {callerLine}{Environment.NewLine}";
        }
    }
}