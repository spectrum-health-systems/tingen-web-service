// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.Configuration.MawsSession.cs
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
using NTST.ScriptLinkService.Objects;

namespace MAWS.Configuration
{
    public class Session
    {
        /// <summary>
        /// Get the MAWS session information
        /// </summary>
        /// <param name="sentOptObj"></param>
        /// <param name="sentMawsRequest"></param>
        /// <returns></returns>
        public static Dictionary<string, string> Build(OptionObject2015 sentOptObj, string sentMawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            MawsEvent.Trace(sentOptObj.OptionUserId, assemblyName);

            Dictionary<string, string> settingsFileContents = Configuration.SettingsFile.Build(sentOptObj.OptionUserId);
            Dictionary<string, string> mawsRequest = SyntaxEngine.MawsRequest.GetDic(sentOptObj.OptionUserId, sentMawsRequest);

            return new Dictionary<string, string>();
        }
    }
}