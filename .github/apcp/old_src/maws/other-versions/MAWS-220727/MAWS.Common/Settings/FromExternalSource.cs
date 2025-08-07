// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.Session.Settings.FromExternalSource.cs
// Logic for building MAWS session configuration setting components from external sources.
// b220726.112734
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// ---------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Collections.Specialized;

namespace MAWS.Common.Settings
{
    public class FromExternalSource
    {
        //// These settings are static in the local configuration file.
        //public string MawsMode { get; set; }
        //public string LoggingMode { get; set; }
        //public string MawsRootDir { get; set; }
        //public string FallbackAvatarUserName { get; set; }


        /// <summary>
        /// Load the configuration settings from the local Web.config file.
        /// </summary>
        /// <returns>A dictionary with the configuration values.</returns>
        public static Dictionary<string, string> WebConfigFile(NameValueCollection mawsExternalSettings)
        {
            var webConfigSettings = new Dictionary<string, string>();

            foreach (var key in mawsExternalSettings.AllKeys)
            {
                webConfigSettings.Add(key, mawsExternalSettings[key]);
            }

            return webConfigSettings;
        }
    }
}