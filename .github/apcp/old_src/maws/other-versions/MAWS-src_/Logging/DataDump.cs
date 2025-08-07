// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Logging.DataDump.cs
// Logic for creating data dumps for troubleshooting.
// b220707.120000
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// -----------------------------------------[ CLASS ]-------------------------------------------

using System;
using System.IO;

namespace MAWS.Logging
{
    public class DataDump
    {
        public static void WriteDump()
        {
            // TODO Move the logMsg generation to a seperate class.
            var logMsg = $"Settings.settings values:{Environment.NewLine}" +
                         $"    MAWS mode: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
                         $"     Log mode: {Properties.Settings.Default.LoggingMode}{Environment.NewLine}" +
                         $"    MAWS root: {Properties.Settings.Default.MawsRootDir}{Environment.NewLine}" +
                         $"Fallback name: {Properties.Settings.Default.FallbackAvatarUserName}";

            var dataDumpDirectory = $@"C:/MAWS/Datadump";

            Directory.CreateDirectory(dataDumpDirectory);

            File.WriteAllText($@"{dataDumpDirectory}/{DateTime.Now:yyMMdd-HHmmss}.datadump", logMsg);

            //TODO Exit gracefully.
        }
    }
}