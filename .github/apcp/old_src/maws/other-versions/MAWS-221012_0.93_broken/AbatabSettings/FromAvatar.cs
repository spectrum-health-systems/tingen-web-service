// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;

namespace AbatabSettings
{
    /// <summary></summary>
    public class FromAvatar
    {
        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetSettings(OptionObject2015 sentOptObj, string scriptParameter)
        {
            List<Dictionary<string, string>> fromAvatarSettings = new List<Dictionary<string, string>>
            {
                GetScriptParameterComponents(scriptParameter),
                GetSentOptObjComponents(sentOptObj)
            };

            return Du.WithDictionary.JoinListOf(fromAvatarSettings);
        }

        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetScriptParameterComponents(string scriptParameter)
        {
            return AbatabParser.ScriptParameter.Parse(scriptParameter);
        }

        /// <summary></summary>
        /// <param name="scriptParameter"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetSentOptObjComponents(OptionObject2015 sentOptObj)
        {
            return new Dictionary<string, string>
            {
                { "AvatarUserName",   sentOptObj.OptionUserId },
                { "AvatarSystemCode", sentOptObj.OptionUserId },
            };
        }
    }
}
