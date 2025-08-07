// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.SyntaxEngine.MawsRequest.cs
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

namespace MAWS.SyntaxEngine
{
    public class MawsRequest
    {
        public static Dictionary<string, string> GetDic(string avatarUserName, string mawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            MawsEvent.Trace(avatarUserName, assemblyName);

            var mawsRequestComponent = mawsRequest.Split('-');

            return new Dictionary<string, string>()
            {
                { "MawsCommand", mawsRequestComponent[0].ToLower() },
                { "MawsAction",  mawsRequestComponent[1].ToLower() },
                { "MawsOptions", mawsRequestComponent[2].ToLower() }
            };
        }
    }
}