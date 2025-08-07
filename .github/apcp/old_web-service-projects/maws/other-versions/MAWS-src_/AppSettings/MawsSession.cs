// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Configuration.MawsSession.cs
// Logic for current MAWS session variables.
// b220714.080729
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// ---------------------------------------------------------------------------------------------

using MAWS.Logging;
using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace MAWS.AppSettings
{
    public class MawsSession
    {
        // These settings are static in the local configuration file.
        public string MawsMode { get; set; }
        public string LoggingMode { get; set; }
        public string MawsRootDir { get; set; }
        public string FallbackAvatarUserName { get; set; }

        // These settings are set at runtime.
        public string DateStamp { get; set; }
        public string TimeStamp { get; set; }
        public string AvatarUserName { get; set; }
        public OptionObject2015 sentOptObj { get; set; }
        public OptionObject2015 finalOptObj { get; set; }

        /// <summary>Build the settings for this MAWS session.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param>
        /// <param name="sentMawsRequest">The MAWS request to be executed.</param>
        /// <returns>MAWS session configuration settings.</returns>
        public static Dictionary<string, string> BuildSessionSettings(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            Dictionary<string, string> mawsSession = LocalFile.LoadLocalSettings();

            mawsSession["DateStamp"] = DateTime.Now.ToString("yyMMdd");
            mawsSession["TimeStamp"] = DateTime.Now.ToString($"HHmmss.fffffff");

            mawsSession["AvatarUserName"] = "";



            var userName = sentOptObj.OptionUserId;
            File.WriteAllText($@"C:\MAWS\temp_prod\{dateStamp}-{timeStamp}_p.{userName}", "temp_prod");

            var avatarUserName = sentOptObj.OptionUserId;

            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);

            return new Dictionary<string, string>();
        }
    }
}