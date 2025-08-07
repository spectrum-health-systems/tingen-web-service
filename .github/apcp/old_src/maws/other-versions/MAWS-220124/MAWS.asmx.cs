// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Entry point for MAWS.
// b220124.124237

using System.Reflection;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace MAWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class MAWS : System.Web.Services.WebService
    {
        /// <summary>
        /// Returns the version of MAWS.
        /// </summary>
        /// <returns>The version of MAWS.</returns>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        /// <summary>
        /// Exectutes a MAWS Request.
        /// </summary>
        /// <param name="sentOptObj"> An OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>An OptionObject2015 with updated data.</returns>
        /// <remarks>This method is required by myAvatar.</remarks>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string mawsRequest)
        {
            LogEvent.Troubleshoot("maws-initialization");

            var assemblyName   = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            LogEvent.Trace(assemblyName, avatarUserName);

            var workOptObj = new OptionObject2015();
            LogEvent.OptObj(assemblyName, avatarUserName, workOptObj, "Initial workOptObj:");

            switch(Properties.Settings.Default.MawsMode.ToLower())
            {
                case "enabled":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Point to Roundhouse.cs

                    break;

                case "disabled":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Don't do anything, just return the data from sentOptObj.

                    break;

                case "passthrough":
                    LogEvent.Trace(assemblyName, avatarUserName);
                    // Just log things, don't make any changes to the data.

                    break;

                default:
                    break;
            }
            LogEvent.Trace(assemblyName, avatarUserName);

            var returnOptObj = OptObj.Finalize(sentOptObj, workOptObj);

            //return sentOptObj;
            return returnOptObj;
        }

        /// <summary>
        /// 
        /// </summary>
        ////private static void Troubleshooter(string logWhat)
        ////{
        ////    var logMessage = "";
        ////    logWhat = logWhat.ToLower();

        ////    if(logWhat == "initial-settings")
        ////    {
        ////        logMessage += $"Settings.settings values:{Environment.NewLine}" +
        ////                      $"    MAWS mode: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
        ////                      $"     Log mode: {Properties.Settings.Default.LogMode}{Environment.NewLine}" +
        ////                      $"    MAWS root: {Properties.Settings.Default.MawsRootDir}{Environment.NewLine}" +
        ////                      $"Fallback name: {Properties.Settings.Default.FallbackAvatarUserName}";
        ////    }

        ////    if(logWhat == "tbd")
        ////    {
        ////        logMessage += $"TBD values:{Environment.NewLine}" +
        ////                      $"   TBD1: {Properties.Settings.Default.MawsMode}{Environment.NewLine}" +
        ////                      $"   TBD2: {Properties.Settings.Default.LogMode}{Environment.NewLine}";
        ////    }

        ////    File.WriteAllText($@"C:\MAWS\Staging\Development\Devlogs\{logWhat}.log", logMessage);
        ////}
    }
}
