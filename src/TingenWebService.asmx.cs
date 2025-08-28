// =============================================================================
// TingenWebService.asmx.cs
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250828_code
// u250828_documentation
// =============================================================================

using System;
using System.IO;
using System.Reflection;
using System.Web.Services;
using ScriptLinkStandard.Objects;
using TingenWebService.Properties;
using Outpost31.Core.Admin;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///   The heavy lifting is done by <see cref="Outpost31.ProjectInfo"> Outpost31</see>.<br/>
    ///   <br/>
    ///   For more information about the Tingen Web Service, please see the <see cref="ProjectInfo"/> file.
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>A required log file component.</summary>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string WsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <returns>The current <see cref="WsvcVer"/> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {WsvcVer}";

        /// <summary>Determines what the Tingen Web Service will do, if anything.</summary>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam)
        {
            /* For debugging only!
             */
            WriteStartLog("Start");

            string avatarSystem = Settings.Default.AvatarSystem;

            /* There are additional Administrative functions that can be performed by the Tingen Web Service. Please see
             * the Manual for more information.
             */
            AdminMode.Parse(origOptObj, origScriptParam, WsvcVer, avatarSystem, Settings.Default.AdminMode);

            Outpost31.Core.Logger.LogAppEvent.Critical(avatarSystem, ExeAsmName, 0, "Missing arguments", LogMsg(origOptObj, origScriptParam));

            // TODO - Move this to a Parse() method?
            if (origOptObj == null || string.IsNullOrWhiteSpace(origScriptParam))
            {
                WriteStartLog("Start1");

                Outpost31.Core.Logger.LogAppEvent.Critical(avatarSystem, ExeAsmName, 0, "Missing arguments", LogMsg(origOptObj, origScriptParam));

                return origOptObj.ToReturnOptionObject(0, "");
            }
            else if (Settings.Default.WsvcMode == "enabled")
            {
                //-//var tngnWsvcSession = TngnWsvcSession.New(origOptObj, origScriptParam, TngnWsvcVer, avtrSys);

                //-//Outpost31.Core.Avatar.AvtrParameter.Request(tngnWsvcSession);

                //-//return tngnWsvcSession.OptObj.Finalized;
                WriteStartLog("Start2");
                return origOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                WriteStartLog("Start3");
                return origOptObj.ToReturnOptionObject(0, "");
            }
        }

        /// <summary>Writes a simple log file to indicate that the Tingen Web Service has started.</summary>
        internal static void WriteStartLog(string time)
        {
            File.WriteAllText($@"C:\Tingen_Data\WebService\UAT\Tingen Web Service.{time}", $"Tingen Web Service started: {DateTime.Now:MM/dd/yyyy-HH:mm:ss.fffffff}");
        }

        /// <summary>Build a message for the critical error.</summary>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>A message for the critical error log.</returns>
        internal static string LogMsg(OptionObject2015 origOptObj, string origScriptParam)
        {
            var t = $"The OptionObject (\"{origOptObj}\") and/or Script Parameter (\"{origScriptParam}\") were not sent from Avatar.";

            File.WriteAllText($@"C:\Tingen_Data\WebService\UAT\Tingen.tt", t);
        
        WriteStartLog("Start5");
            return $"The OptionObject (\"{origOptObj}\") and/or Script Parameter (\"{origScriptParam}\") were not sent from Avatar.";
        }
    }
}