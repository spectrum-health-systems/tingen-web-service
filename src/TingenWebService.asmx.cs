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

/* Tingen documentation:
 * https://github.com/spectrum-health-systems/tingen-documentation
 */

/* u250616_code
 * u250616_documentation
 */

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Logger;
using Outpost31.Core.Session;
using Outpost31.Core.Blueprint;
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
    ///     <para>
    ///         While you're here, take a look at this stuff:
    ///         <list type="bullet">
    ///             <item>The <see href="https://github.com/spectrum-health-systems/Tingen-Documentation">Tingen Documentation</see></item>
    ///             <item>The <see href="https://spectrum-health-systems.github.io/tingen-documentation/api/shfb-tingen-web-service">Tingen Web Service API Documentation</see></item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <seealso href = "https://github.com/spectrum-health-systems/tingen-documentation">Tingen documentation</seealso>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        /// <remarks>The version number is pulled from <i>Properties/AssemblyInfo.cs</i></remarks>
        /// <value>YY.MM.Patch (e.g., <c>25.02.1</c>)</value>
        /// <seealso href="https://spectrum-health-systems.github.io/tingen-documentation/static/tingen-project-versioning"></seealso>
        public static string WbsrvcVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The Avatar environment that the Tingen Web Service will interface with.</summary>
        /// <remarks>This needs to be manually updated to "LIVE" when deploying to production.</remarks>
        /// <value><c>UAT</c> (testing) or <c>LIVE</c>(production)</value>
        public static string AvtrEnv { get; set; } = "UAT";

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <remarks>This method is required and <i>should not be modified</i>.</remarks>
        /// <returns>The current <see cref="WbsrvcVersion"/>.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {WbsrvcVersion}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     <note title="About this method">
        ///         <list type="bullet">
        ///             <item>
        ///                 This method is required and <i>should not be modified</i>.
        ///             </item>
        ///             <item>Trace Logs can't go here because the logging infrastructure<br/>
        ///                   hasn't been initialized yet.
        ///             </item>
        ///         </list>
        ///     </note>
        ///     <note type="security" title="Critical failure warning">
        ///         If Avatar doesn't pass an <paramref name="sentOptObj"/> or <paramref name="sentSlnkScriptParam"/>, the Tingen Web Service will fail.<br/>
        ///         <br/>
        ///         Since this can be difficult to troubleshoot, a<c> Critical Failure Log</c> will be created.<br/>
        ///         <br/>
        ///         Generally the fix for a missing OptionObject and/or Script Parameter is to<br/>
        ///         re-import the Tingen Web Service WSDL.
        ///     </note>
        /// </remarks>
        /// <param name="sentOptObj">The <see cref="OptionObject2015"/> sent from Avatar, which contains all of the content and metadata of an Avatar form.</param>
        /// <param name="sentSlnkScriptParam">The Script Parameter that is sent from Avatar, which contains the request the Tingen Web Service needs to do work.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentSlnkScriptParam) /* TODO - fix */
{
            /* We can write a Primeval log here to verify that the web service is starting up
             * correctly. This should be uncommented unless needed.
             */
            LogEvent.Primeval(AvtrEnv, "[TingenWebService.RunScript()]");

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || sentOptObj == null)
            {
                LogEvent.Critical(AvtrEnv, LogMessage.ServiceMissingArguments(sentOptObj, sentSlnkScriptParam));

                /* TODO - Since the OptionObject may not exist, we should figure out a way to exit the application without returning a null object. */
                return sentOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                var svcSession = TngnWbsvSession.New(sentOptObj, sentSlnkScriptParam, WbsrvcVersion, AvtrEnv);

                //LogEvent.Debuggler(AvtrEnv, "[SPIN UP]");

                //LogEvent.Debuggler(AvtrEnv, $"[PARSE REQUEST] '{svcSession.SentScriptParam}'");

                Outpost31.Core.Avatar.ScriptParameter.Request(svcSession);

                // LogEvent.Debuggler(AvtrEnv, "[COMPLETE]");

                return svcSession.ReturnOptObj;
            }
        }
    }
}