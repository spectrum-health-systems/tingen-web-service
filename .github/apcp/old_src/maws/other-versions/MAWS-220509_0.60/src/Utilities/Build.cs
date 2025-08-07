// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.Utilties.Build.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v0.60.0.0-b220509.093205

/* =============================================================================
 * About this class
 * =============================================================================
 */

using System;
using System.IO;
using System.Threading;
using NTST.ScriptLinkService.Objects;

namespace MAWS.Utilities
{
    public class Build
    {
        public static string LogfilePath(string logType, string assemblyName, string origAvatarUserName, string callerFilePath, int callerLine)
        {
            var mawsRootDir      = Properties.Settings.Default.MawsRootDir;
            var currentDate      = DateTime.Now.ToString("yyMMdd");
            var avatarUserName   = Validate.AvatarUserName(origAvatarUserName);
            var logfileDirectory = $@"{mawsRootDir}/{currentDate}/{avatarUserName}";

            FileSystem.VerifyDirectoryExists(logfileDirectory);

            var logfileName = Build.LogfileName(logType, assemblyName, avatarUserName, callerFilePath, callerLine);

            return $@"{logfileDirectory}/{logfileName}";
        }

        public static string LogfileName(string logType, string assemblyName, string avatarUserName, string callerFilePath, int callerLine)
        {
            var currentTime                    = DateTime.Now.ToString($"HHmmss.fffffff");
            var fileExtensionLocation          = callerFilePath.IndexOf('.');
            var callerfilePathWithoutExtension = callerFilePath.Remove(fileExtensionLocation);

            var logfileName = $"{currentTime}-{assemblyName}-{callerfilePathWithoutExtension}-{callerLine}.{logType}";

            if(File.Exists(logfileName))
            {
                Thread.Sleep(10);
                currentTime = DateTime.Now.ToString($"HHmmss.fffffff");
                logfileName = $"{currentTime}-{assemblyName}-{callerfilePathWithoutExtension}-{callerLine}.{logType}";
            }

            return $"{currentTime}-{assemblyName}-{callerfilePathWithoutExtension}-{callerLine}.{logType}";
        }






        /// <summary>
        /// Build the contents of a basic logfile.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="logMessage"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns></returns>
        public static string LogfileContent(string assemblyName, string logMessage, string callerFilePath, string callerMemberName, int callerLine)
        {
            /* Basic logfiles only have a header/footer, no body.
             */
            var logHeader = Build.LogHeader(logMessage);
            var logFooter = Build.LogFooter(assemblyName, callerFilePath, callerMemberName, callerLine);

            var logContents = $"{logHeader}"+
                              $"{logFooter}";

            return logContents;
        }

        /// <summary>
        /// Build the contents of a logfile with OptionObject2015 data.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="optObj"></param>
        /// <param name="callerfilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <param name="logMessage"></param>
        /// <returns></returns>
        public static string LogfileContents(string assemblyName, string logMessage, OptionObject2015 optObj, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logHeader = Build.LogHeader(logMessage);
            var logBody   = Build.LogBody(optObj);
            var logFooter = Build.LogFooter(assemblyName, callerFilePath, callerMemberName, callerLine);

            var logContents = $"{logHeader}"+
                              $"{logBody}" +
                              $"{logFooter}";

            return logContents;
        }

        /// <summary>
        /// Build the standard header for log content
        /// </summary>
        /// <returns>A standard log content header</returns>
        public static string LogHeader(string logMessage)
        {
            var logHeader = $"{logMessage}:{Environment.NewLine}" +
                            $"{Environment.NewLine}";

            return logHeader;
        }

        /// <summary>
        /// Build OptionObject2015 data for a logfile body.
        /// </summary>
        /// <param name="optObj"></param>
        /// <returns>OptionObject2015 data for a logfile.</returns>
        public static string LogBody(OptionObject2015 optObj)
        {
            var logBody = $"       EntityID: {optObj.EntityID}{Environment.NewLine}" +
                          $"       Facility: {optObj.Facility}{Environment.NewLine}" +
                          $"  NamespaceName: {optObj.NamespaceName}{Environment.NewLine}" +
                          $"       OptionId: {optObj.OptionId}{Environment.NewLine}" +
                          $"ParentNamespace: {optObj.ParentNamespace}{Environment.NewLine}" +
                          $"     ServerName: {optObj.ServerName}{Environment.NewLine}" +
                          $"     SystemCode: {optObj.SystemCode}{Environment.NewLine}" +
                          $"  EpisodeNumber: {optObj.EpisodeNumber}{Environment.NewLine}" +
                          $"  OptionStaffId: {optObj.OptionStaffId}{Environment.NewLine}" +
                          $"   OptionUserId: {optObj.OptionUserId}{Environment.NewLine}" +
                          $"      ErrorCode: {optObj.ErrorCode}{Environment.NewLine}" +
                          $"      ErrorMesg: {optObj.ErrorMesg}";

            return logBody;
        }

        /// <summary>
        /// Build the standard footer for log content.
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="callerFilePath"></param>
        /// <param name="callerMemberName"></param>
        /// <param name="callerLine"></param>
        /// <returns>A standard log content footer.</returns>
        public static string LogFooter(string assemblyName, string callerFilePath, string callerMemberName, int callerLine)
        {
            var logFooter = $"{Environment.NewLine}" +
                            $"Assembly: {assemblyName}{Environment.NewLine}" +
                            $"  Source: {Path.GetFileName(callerFilePath)}{Environment.NewLine}" +
                            $"  Member: {callerMemberName}{Environment.NewLine}" +
                            $"    Line: {callerLine}{Environment.NewLine}";

            return logFooter;
        }
    }
}