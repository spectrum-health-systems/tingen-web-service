/* The
 * ████████╗██╗███╗   ██╗ ██████╗ ███████╗███╗   ██╗
 * ╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝████╗  ██║
 *    ██║   ██║██╔██╗ ██║██║  ███╗█████╗  ██╔██╗ ██║
 *    ██║   ██║██║╚██╗██║██║   ██║██╔══╝  ██║╚██╗██║
 *    ██║   ██║██║ ╚████║╚██████╔╝███████╗██║ ╚████║
 *    ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝
 *                                       Web Service
 *                                    Release 25.6.0
 *
 * https://github.com/spectrum-health-systems/tingen-web-service
 * Copyright (c) A Pretty Cool Program. All rights reserved.
 * Licensed under the Apache 2.0 license.
 */

/* Tingen Documentation Project:
 * https://github.com/spectrum-health-systems/tingen-documentation-project
 */

/* TingenWebService.TingenWebService.asmx.cs
 * u250618_code
 * u250618_documentation
 */

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Blueprint;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///     <para>
    ///         This class doesn't do much actual work, and should remain fairly static.<br/>
    ///         <br/>
    ///         For the most part, it just hands information to<see href="https://github.com/spectrum-health-systems/outpost31"> Outpost31</see>, where the<br/>
    ///         heavy lifting is done.<br/>
    ///         <br/>
    ///         There are two methods in this class, both of which <i>are required</i>:
    ///         <list type="bullet">
    ///             <item><see cref="GetVersion()"/></item>
    ///             <item><see cref="RunScript(OptionObject2015, string)"/></item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso href="https://spectrum-health-systems.github.io/tingen-documentation-project/api/shfb-tingen-web-service">Tingen Web Service API Documentation</see>
    /// <seealso href="https://github.com/spectrum-health-systems/tingen-documentation-project">Tingen Documentation Project</seealso>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The Executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        /// <remarks>The <see cref= "https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/project/versioning.md">version</see> is pulled from <i>Properties/AssemblyInfo.cs</i></remarks>
        /// <value>YY.MM.Patch (e.g., <c>25.02.1</c>)</value>
        public static string TngnWsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The Avatar System that the Tingen Web Service will interface with.</summary>
        /// <remarks>
        ///     The Avatar <see href="https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/avatar/environment.md#system"> <i>System</i></see>
        ///     is different than an Avatar <see href="https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/avatar/environment.md#system-code"> <i>System Code</i></see>.<br/>
        /// </remarks>
        /// <value><c>UAT</c> (testing) or <c>LIVE</c>(production)</value>
        public static string AvtrSys { get; set; } = "UAT";

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <remarks>This method is required and <i>should not be modified</i>.</remarks>
        /// <returns>The current <see cref="TngnWsvcVer"/>.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     About this method:
        ///     <list type="bullet">
        ///         <item>
        ///             This method is required and <i>should not be modified</i>.
        ///         </item>
        ///         <item><see cref= "LogEvent.Trace(int, string, string, string, string, int, string)">Trace Logs</see> can't go here because the logging infrastructure hasn't<br/>
        ///               been initialized yet.
        ///         </item>
        ///         <item>
        ///               If Avatar doesn't pass an <paramref name="OrigOptObj"/> or <paramref name="sentSlnkScriptParam"/>,<br/>
        ///               the Tingen Web Service will fail, and a <see cref= "Outpost31.Core.Logger.LogEvent.Critical(string, string)">Critical Failure Log</see> will be<br/>
        ///               created.
        ///               <br/>
        ///          </item>
        ///      </list>
        /// </remarks>
        /// <param name="OrigOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="sentSlnkScriptParam">The Script Parameter that is sent from Avatar, which contains the request the Tingen Web Service needs to do work.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 OrigOptObj, string sentSlnkScriptParam) /* TODO - fix */
{
            /* We can write a Primeval log here to verify that the web service is starting up
             * correctly. This should be uncommented unless needed.
             */
            LogEvent.Primeval(AvtrSys, "[TingenWebService.RunScript()]");

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || OrigOptObj == null)
            {
                LogEvent.Critical(AvtrSys, LogMsg.WsvcMissingArgs(OrigOptObj, sentSlnkScriptParam));

                /* TODO - Since the OptionObject may not exist, we should figure out a way to exit the application without returning a null object. */
                return OrigOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                var wsvcSession = WsvcSession.New(OrigOptObj, sentSlnkScriptParam, TngnWsvcVer, AvtrSys);

                Outpost31.Core.Avatar.ScriptParameter.Request(wsvcSession);

                return wsvcSession.OptObj.Finalized;
            }
        }
    }
}