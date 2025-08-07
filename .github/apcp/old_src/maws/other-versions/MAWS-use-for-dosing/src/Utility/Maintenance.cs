/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.Maintenance.cs
 * UPDATED: 1-15-2022-6:01 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Performs various MAWS maintenance.
 *
 * Logging is done differently in this method, as everything is hard-coded.
 */

using System.IO;
using System.Reflection;

namespace Utility
{
    public class Maintenance
    {
        /// <summary>
        /// Confirm existence of and/or creates the log directory.
        /// </summary>
        public static void ConfirmDirectoryExists(string directoryPath)
        {
            /* We need the Assembly Name for log files.
             * TODO This stopped working, do we need it?
             */
            //var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            // TODO I think this creates an endless loop.
            ////[TRACE LOG] Entering Maintenance.ConfirmDirectoryExists()
            //var maintenanceConfirmDirectoryTraceMsg = $"Entering Maintenance.ConfirmDirectoryExists()";
            //LogEvent.Timestamped("trace", "TRACE", "MAINTENANCE", "_MAWS", maintenanceConfirmDirectoryTraceMsg);

            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);

                //[DEBUG LOG] Directory does not exist, so create it.
                var maintenanceDirectoryNonexistantDebugMsg = $"The {directoryPath} directory did not exist, and was created.";
                LogEvent.Timestamped("trace", "TRACE", "MAINTENANCE", "_MAWS", maintenanceDirectoryNonexistantDebugMsg);
            }
        }
    }
}