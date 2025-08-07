// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.Configuration.SettingsFile.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v0.60.0.0-b220509.093205

/* =============================================================================
 * About this class
 * =============================================================================
 */

using System.Collections.Generic;
using System.Reflection;

namespace MAWS.Configuration
{
    public class SettingsFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="avatarUserName"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Build(string avatarUserName)
        {
            // These are in Settings.settings, but we need to confirm that making changes to the local config file
            // override these.
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            MawsEvent.Trace(avatarUserName, assemblyName);

            return new Dictionary<string, string>()
            {
                { "MawsMode", Properties.Settings.Default.MawsMode },
                { "LogMode",  Properties.Settings.Default.LogMode},
                { "MawsRootDir", Properties.Settings.Default.MawsRootDir },
                { "FallbackAvatarUserName", Properties.Settings.Default.FallbackAvatarUserName }
            };
        }
    }
}