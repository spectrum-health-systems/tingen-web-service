// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.asmx.cs
// Entry point for MAWS.
// b220727.091950
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.asmx.cs.md
// ---------------------------------------------------------------------------------------------

// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-[ ABOUT MAWS ]-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
// https://github.com/spectrum-health-systems/MAWS
// Version 1.99.0.x
// Build: 220727.092002 [devbuild]
//
// The MyAvatool Web Service (MAWS) is a custom web service which includes various tools and
// utilities for myAvatar™ that aren't included in the official release, and provides a solid
// foundation for building additional functionality quickly and efficiently.
//
// DOCUMENTATION
// -------------
// Manual: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Manual/MAWS-manual.md
// Sourcecode: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Sourcecode/MAWS-sourcecode.md
// README: https://github.com/spectrum-health-systems/MAWS#readme
// Changelog: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Changelog.md
// Roadmap: https://github.com/spectrum-health-systems/MAWS/blob/main/Documents/Roadmap.md
// Known issues: https://github.com/spectrum-health-systems/MAWS/blob/Documents/Known%20issues.md
//
// For more myAvatar™ related development, please visit the myAvatar™ Development Community:
// https://github.com/myAvatar-Development-Community
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using MAWS.Common.Settings;
using MAWS.Logging.LogType;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Web.Services;

namespace MAWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MAWS : WebService
    {
        /// <summary>
        /// Returns the version of MAWS.
        /// </summary>
        /// <returns>MAWS version.</returns>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 2.0";
        }

        /// <summary>
        /// Execute a MAWS Request.
        /// </summary>
        /// <param name="sentOptionObject">The OptionObject2015 sent from myAvatar.</param
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>Updated OptionObject2015.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string sentMawsRequest)
        {
            Dictionary<string, string> applicationSettings = GetApplicationSettings();
            MawsSettings mawsSettings = MawsSettings.Initialize(sentOptionObject, sentMawsRequest, applicationSettings);
            Trace.LogEvent(mawsSettings.AvatarUserName, mawsSettings.SessionStamp);

            return new OptionObject2015(); //! Temporary
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, string> GetApplicationSettings()
        {
            return new Dictionary<string, string>()
            {
                { "MawsMode", Properties.Settings.Default.MawsMode },
                { "LogMode",  Properties.Settings.Default.LoggingMode},
                { "MawsRootDir", Properties.Settings.Default.MawsRootDirectory },
                { "FallbackAvatarUserName", Properties.Settings.Default.FallbackAvatarUserName }
            };
        }
    }
}