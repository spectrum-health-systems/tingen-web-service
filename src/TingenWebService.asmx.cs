// =============================================================================
// TingenWebService.asmx.cs
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250904_code
// u250904_documentation
// =============================================================================

using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Request;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;
using TingenWebService.Configuration;
using TingenWebService.Properties;

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
        public static string Version { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <returns>The current <see cref="Version"/> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {Version}";

        /// <summary>Determines what the Tingen Web Service will do, if anything.</summary>
        /// <remarks><include file='AppData/XmlDoc/Asmx.xml' path='TngnWsvc/Class[@name="asmx"]/RunScript/*'/></remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam) //TODO Rename to "Original"
        {
            Dictionary<string, string> runtimeConfig = RuntimeConfig.Load(Settings.Default, Version);

            if (origOptObj == null || string.IsNullOrWhiteSpace(origScriptParam))
            {
                //TODO Check this
                Outpost31.Core.Logger.LogEvent.Critical(runtimeConfig["DataFolder"], runtimeConfig["AvatarSystem"], ExeAsmName, 0, "Missing arguments", LogMsg(origOptObj, origScriptParam));

                return origOptObj.ToReturnOptionObject(0, $"Missing arguments! Please see log files for more information.");
            }
            else if (runtimeConfig["Mode"] == "enabled") //TODO ...or passthrough?
            {
                Instance session = Instance.Start(origOptObj, origScriptParam, runtimeConfig);

                Parser.ParseRequest(session);

                //return origOptObj.ToReturnOptionObject(0, "");
                return session.OptionObject.Completed;
            }
            else
            {
                //Outpost31.Core.Logger.LogEvent.Critical(runtimeConfig["DataFolder"], runtimeConfig["AvatarSystem"], ExeAsmName, 0, "Disabled.");

                return origOptObj.ToReturnOptionObject(0, "");
            }
        }

        /// <summary>Build a message for the critical error.</summary>
        /// <remarks>This is here so it won't clutter RunScript().</remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>A message for the critical error log.</returns>
        internal static string LogMsg(OptionObject2015 origOptObj, string origScriptParam) =>
            $"The OptionObject (\"{origOptObj}\") and/or Script Parameter (\"{origScriptParam}\") were not sent from Avatar.";
    }
}

/* Use this when debugging
 */
//File.WriteAllText($@"C:\Tingen_Data\WebService\Started", $"{DateTime.Now:MM/dd/yyyy-HH:mm:ss); /* DEBUG USE ONLY */