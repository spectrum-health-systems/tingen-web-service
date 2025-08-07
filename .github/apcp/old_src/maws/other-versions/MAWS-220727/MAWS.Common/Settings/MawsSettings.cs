using NTST.ScriptLinkService.Objects;
using System;
using System.Collections.Generic;

namespace MAWS.Common.Settings
{
    public class MawsSettings
    {
        // External configuration settings from Web.config
        public string MawsMode { get; set; }
        public string LoggingMode { get; set; }
        public string MawsRootDir { get; set; }
        public string FallbackAvatarUserName { get; set; }

        // These settings are set at runtime.
        public string SessionStamp { get; set; }
        public string AvatarUserName { get; set; }
        public string MawsRequest { get; set; }
        public OptionObject2015 SentOptionObject { get; set; }
        public OptionObject2015 WorkOptionObject { get; set; }
        public OptionObject2015 FinalOptionObject { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="mawsExternalSettings"></param>
        /// <returns></returns>
        public static MawsSettings Initialize(OptionObject2015 sentOptionObject, string mawsRequest, Dictionary<string, string> applicationSettings)
        {
            //x Dictionary<string, string> mawsWebConfigSettings = Settings.FromExternalSource.WebConfigFile(webConfigSettings);

            var mawsSettings = new MawsSettings()
            {
                MawsMode               = applicationSettings["MawsMode"].ToLower(),
                MawsRootDir            = applicationSettings["MawsRootDirectory"].ToLower(),
                LoggingMode            = applicationSettings["LoggingMode"].ToLower(),
                FallbackAvatarUserName = applicationSettings["FallbackAvatarUserName"].ToLower(),
                SessionStamp           = DateTime.Now.ToString("yyMMdd-HHmmss.fffffff"),
                AvatarUserName         = "",
                MawsRequest            = mawsRequest,
                SentOptionObject       = sentOptionObject,
                WorkOptionObject       = sentOptionObject,
                FinalOptionObject      = sentOptionObject
            };

            mawsSettings.AvatarUserName = string.IsNullOrWhiteSpace(sentOptionObject.OptionUserId)
                ? mawsSettings.FallbackAvatarUserName
                : sentOptionObject.OptionUserId;

            return mawsSettings;
        }
    }
}
