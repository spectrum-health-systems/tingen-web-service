// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.SyntaxEngine.MawsRequest.cs
// Logic for MAWS Requests.
// b220624.115605
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md


using MAWS.Logging;
using System.Collections.Generic;
using System.Reflection;

namespace MAWS.SyntaxEngine
{
    public class MawsRequest
    {
        /// <summary></summary>
        /// <param name="avatarUserName"></param>
        /// <param name="mawsRequest"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDic(string avatarUserName, string mawsRequest)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            LogEvent.Trace(avatarUserName, assemblyName);

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