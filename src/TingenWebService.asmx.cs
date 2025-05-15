// The
// ████████╗██╗███╗   ██╗ ██████╗ ███████╗███╗   ██╗
// ╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝████╗  ██║
//    ██║   ██║██╔██╗ ██║██║  ███╗█████╗  ██╔██╗ ██║
//    ██║   ██║██║╚██╗██║██║   ██║██╔══╝  ██║╚██╗██║
//    ██║   ██║██║ ╚████║╚██████╔╝███████╗██║ ╚████║
//    ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝
//                                       Web Service
//                        Development Release 25.5.0
//
// https://github.com/APrettyCoolProgram/Tingen-WebService
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
//
// Tingen Web Service documentation:
//  https://github.com/spectrum-health-systems/Tingen-Documentation

// u250515_code
// u250515_documentation

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Web.Services;
using System.Web.UI.WebControls.WebParts;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///     <note title="About this class">
    ///         This class doesn't do much actual work, and should remain fairly static.<br/>
    ///         <br/>
    ///         For the most part, it just hands information to<see href="https://github.com/spectrum-health-systems/Outpost31">Outpost31</see>, where the<br/>
    ///         heavy lifting is done.<br/>
    ///         <br/>
    ///         There are two methods in this class, both of which <i>are required</i><br/>
    ///         by Avatar:
    ///         <list type="bullet">
    ///             <item><see cref="GetVersion()"/></item>
    ///             <item><see cref="RunScript(OptionObject2015, string)"/></item>
    ///         </list>
    ///     </note>
    ///     <para>
    ///         While you're here, take a look at this stuff:
    ///         <list type="bullet">
    ///             <item>The <see href="https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen Documentation</see></item>
    ///             <item>The<see href = "https://github.com/spectrum-health-systems/Tingen-Documentation/tree/main/docs">Tingen Web Service API Documentation</see></item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso href = "https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen documentation</seealso>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The Tingen current version number.</summary>
        /// <remarks>The version number is pulled from <i>Properties/AssemblyInfo.cs</i></remarks>
        /// <value>YY.MM.Patch(e.g., <c>25.02.1</c>)</value>
        /// <seealso href="https://github.com/spectrum-health-systems/Tingen-Documentation/blob/main/Static/TngnWbsv-Versioning.md">More information about versions.</seealso>
        public static string TngnWbsvVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The environment that the Tingen Web Service will interface with.</summary>
        /// <remarks>This needs to be.</remarks>
        //public static string TngnWbsvEnvironment { get; set; } = "UAT";

        /// <summary>Get the current version of Tingen.</summary>
        /// <returns>The current version number of Tingen.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/GetVersion/*'/>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWbsvVersion}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     <note title="About this method">
        ///         <list type="bullet">
        ///             <item>This method is required by Avatar and <i>should not be modified</i>.</item>
        ///             <item>Trace Logs can't go here because the logging infrastructure<br/>
        ///                   hasn't been initialized yet.
        ///             </item>
        ///         </list>
        ///     </note>
        ///     <para>
        ///         For more information on the Tingen Web Service version<br/>
        ///         number, please see the<see cref="TngnWbsvVersion">TngnVersion</see> property.
        ///     </para>
        ///     This method logs critical events if the input parameters are invalid and debug-level
        ///     events during the script execution process. Ensure that both <paramref name="sentOptObj"/> and <paramref
        ///     name="sentSlnkScriptParam"/> are valid before calling this method.
        /// </remarks>
        /// <param name="sentOptObj">The <see cref="OptionObject2015"/> instance containing the data to be processed by the script.</param>
        /// <param name="sentSlnkScriptParam">A string representing the script parameter to be used during execution. Cannot be null, empty, or
        /// whitespace.</param>
        /// <returns>An <see cref="OptionObject2015"/> instance representing the result of the script execution.  If the input
        /// parameters are invalid, a default <see cref="OptionObject2015"/> with no changes is returned.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentSlnkScriptParam)
        {
            var tngnWbsvEnvironment = File.ReadAllText(@"..\AppData\Runtime\TngnWbsv.environment").Trim();

            /* Uncomment the following line to completely disable the Tingen Web Service.
             */
            //return sentOptObj.ToReturnOptionObject(0, "");

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || sentOptObj == null)
            {
                LogEvent.Critical(tngnWbsvEnvironment, Outpost31.Core.Template.Message.TngnWbsvCriticalMissingArguments(sentOptObj, sentSlnkScriptParam));

                /* This really should just be a stop - can't return something that doesn't exist.
                 */
                return sentOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                /* Depreciated [250515]
                 */
                //var tngnWbsvSession = new TngnWbsvSession();

                var tngnWbsvSession = TngnWbsvSession.New(sentOptObj, sentSlnkScriptParam, TngnWbsvVersion, tngnWbsvEnvironment);

                LogEvent.Debuggler(tngnWbsvEnvironment, "[SPIN UP]");

                /* Most likely not needed [250515]
                 */
                //Spin.Up(tngnWbsvSession, sentOptObj, sentSlnkScriptParam, TngnWbsvVersion, TngnWbsvEnvironment);

                LogEvent.Debuggler(tngnWbsvEnvironment, $"[PARSE REQUEST] '{tngnWbsvSession.SentScriptParam}'");

                Outpost31.Core.Avatar.ScriptParameter.Request(tngnWbsvSession);

                LogEvent.Debuggler(tngnWbsvEnvironment, "[COMPLETE]");

                return tngnWbsvSession.ReturnOptObj;
            }
        }
    }
}