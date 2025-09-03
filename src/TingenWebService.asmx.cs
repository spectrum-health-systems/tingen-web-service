// =============================================================================
// TingenWebService.asmx.cs
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250903_code
// u250903_documentation
// =============================================================================

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;
using TingenWebService.Configuration;
using Outpost31.Core.Request;
using TingenWebService.Properties;
using System.Collections.Generic;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>For more information about the Tingen Web Service, please see the <see cref="ProjectInfo"/> file.</remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>A required log file component.</summary>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string TngnWsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <returns>The current <see cref="TngnWsvcVer"/> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>Determines what the Tingen Web Service will do, if anything.</summary>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam) //TODO Rename to "Original"
        {
            /* Use this when you need to verify that the web service is actually starting.*/
            //File.WriteAllText($@"C:\Tingen_Data\WebService\Started", $"{DateTime.Now:MM/dd/yyyy-HH:mm:ss);

            Dictionary<string, string> runtimeConfig = RuntimeConfig.Load(Settings.Default);

            /* Use this to when you need to verify that the web service started, and actually did something.*/
            //Outpost31.Core.Logger.RootLog.StatusLog(runtimeConfig.AvatarSystem, "Started");

            if (origOptObj == null || string.IsNullOrWhiteSpace(origScriptParam))
            {
                Outpost31.Core.Logger.LogAppEvent.Critical(runtimeConfig["AvatarSystem"], ExeAsmName, 0, "Missing arguments", LogMsg(origOptObj, origScriptParam));

                return origOptObj.ToReturnOptionObject(0, $"Missing arguments! Please see log files for more information.");
            }
            else if (runtimeConfig["WsvcMode"] == "enabled") //TODO ...or passthrough?
            {
                /* Use this to verify the web service is enabled.*/
                //Outpost31.Core.Logger.LogAppEvent.Debuggler(runtimeConfig.AvatarSystem, ExeAsmName,0, "Web Service Enabled");

                TngnWsvcSession tngnWsvcSession = TngnWsvcSession.Start(origOptObj, origScriptParam, TngnWsvcVer, runtimeConfig);

                Parser.ParseRequest(tngnWsvcSession);

                return tngnWsvcSession.OptionObject.Completed;
            }
            else
            {
                /* Use this to verify the web service is disabled.*/
                //Outpost31.Core.Logger.LogAppEvent.Critical(runtimeConfig.AvatarSystem, ExeAsmName, 0, "Disabled.");

                return origOptObj.ToReturnOptionObject(3, $"The Tingen Web Service is disabled.");
            }
        }

        /// <summary>Build a message for the critical error.</summary>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>A message for the critical error log.</returns>
        internal static string LogMsg(OptionObject2015 origOptObj, string origScriptParam) =>
            $"The OptionObject (\"{origOptObj}\") and/or Script Parameter (\"{origScriptParam}\") were not sent from Avatar.";
    }
}