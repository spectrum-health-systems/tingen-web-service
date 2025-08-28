// =============================================================================
// TingenWebService.asmx.cs
// The Tingen Web Service for Netsmart's Avatar EHR.
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250828_code
// u250828_documentation
// =============================================================================

// *****************************************************************************
// IMPORTANT!
//
// Before deploying the Tingen Web Service, please verify that avtrSys is set
// correctly! Please see the Manual for more information.
// *****************************************************************************

using System;
using System.IO;
using System.Reflection;
using System.Web.Services;
using ScriptLinkStandard.Objects;
using TingenWebService.Properties;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///   This class doesn't do much actual work, and should remain fairly static. For the most part, it just hands<br/>
    ///   information to <see cref="Outpost31.ProjectInfo"> Outpost31</see>, where the heavy lifting is done<br/>
    ///   <br/>
    ///   For more information about the Tingen Web Service, please see the <see cref="ProjectInfo"/> file.
    /// </remarks>
[WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing assembly name.</summary>
        /// <remarks>
        ///   This is a required component of most log files, and is defined at the start of each class, so it can be<br/>
        ///   used at any time that a log needs to be created.
        /// </remarks>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string TngnWsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <returns>The current <see cref="TngnWsvcVer"/> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>The entry method for the Tingen Web Service.</summary>
        /// <remarks>This method determines what the Tingen Web Service will do, if anything.</remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam)
        {
            /* For debugging only!
             */
            //WriteStartLog();

            /* Before deploying the Tingen Web Service, please verify that AvtrSys is set correctly! Please see the Manual
             * for more information.
             */
            string avtrSys = Settings.Default.AvtrSys;

            /* There are additional Administrative functions that can be performed by the Tingen Web Service. Please see
             * the Manual for more information.
             */
            Outpost31.Core.Admin.AdminMode.Run(origOptObj, origScriptParam, TngnWsvcVer, avtrSys, Settings.Default.AdminMode);

            if (origOptObj == null || string.IsNullOrWhiteSpace(origScriptParam))
            {
                Outpost31.Core.Logger.LogAppEvent.Critical(avtrSys, ExeAsmName, 0, "Missing arguments", LogMsg(origOptObj, origScriptParam));

                return origOptObj.ToReturnOptionObject(0, ""); // 
            }
            else if (Settings.Default.TngnWsvcMode == "enabled")
            {
                //-//var tngnWsvcSession = TngnWsvcSession.New(origOptObj, origScriptParam, TngnWsvcVer, avtrSys);

                //-//Outpost31.Core.Avatar.AvtrParameter.Request(tngnWsvcSession);

                //-//return tngnWsvcSession.OptObj.Finalized;

                return origOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                return origOptObj.ToReturnOptionObject(0, "");
            }
        }

        /// <summary>Writes a simple log file to indicate that the Tingen Web Service has started.</summary>
        internal static void WriteStartLog()
        {
            File.WriteAllText($@"C:\Tingen_Data\WebService\UAT\AppData\Log\Tingen Web Service.started", $"Tingen Web Service started: {DateTime.Now:MM/dd/yyyy-HH:mm:ss.fffffff}");
        }

        internal static string LogMsg(OptionObject2015 origOptObj, string origScriptParam)
        {
            return $"The OptionObject (\"{origOptObj}\") and/or Script Parameter (\"{origScriptParam}\") were not sent from Avatar.";
        }
    }
}

/* DN01
 * If the OptionObject wasn't sent from Avatar, it can't be "finalized" and returned. We need to figure out how to
 * handle this.
 */