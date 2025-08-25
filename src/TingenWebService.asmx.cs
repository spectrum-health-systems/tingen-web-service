/* TingenWebService.TingenWebService.asmx.cs
 * u250821_code
 * u250821_documentation
 */

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Logger;
using Outpost31.Core.Runtime;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///     <para>
    ///       This class doesn't do much actual work, and should remain fairly static. For the most part, it just hands information to
    ///       <see href="https://github.com/spectrum-health-systems/outpost31"> Outpost31</see>, where the heavy lifting is done.
    ///       <br/>
    ///       There are two methods in this class, both of which <i>are required</i> and <i>should not be modified</i>:
    ///       <list type="bullet">
    ///          <item><see cref="GetVersion()"/></item>
    ///          <item><see cref="RunScript(OptionObject2015, string)"/></item>
    ///       </list>
    ///     </para>
    ///     <include file='AppData/XMLDoc/TngnWsvc.xml' path='TingenWebService/Class[@name="ProjectInfo"]/Callback/*'/>
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing assembly name.</summary>
        /// <include file='AppData/XMLDoc/TngnWsvc.xml' path='TingenWebService/Class[@name="Common"]/ExeAsmName/*'/>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string TngnWsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The Avatar System that the Tingen Web Service will interface with.</summary>
        /// <remarks>
        ///     The Avatar <see cref="Outpost31.Core.Avatar.AvtrSystem.AvtrSys"><i>System</i></see> is different than an
        ///     Avatar <see cref="Outpost31.Core.Avatar.AvtrSystem.AvtrSysCode"><i>System Code</i></see>.
        ///     <br/>
        ///     This is the only thing that is hard-coded in the Tingen Web Service, and needs to be set to the Avatar
        ///     System that this specific instance of the Tingen Web Service will interface with.
        /// </remarks>
        /// <value><c>UAT</c> (testing) or <c>LIVE</c>(production)</value>
        public static string AvtrSys { get; set; } = "UAT";

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <remarks>This method is required and <i>should not be modified</i>.</remarks>
        /// <returns>The current <see cref="TngnWsvcVer">version</see> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>
        ///             This method is required and <i>should not be modified</i>.
        ///         </item>
        ///         <item>
        ///             <see cref="LogEvent.Trace(int, string, string, string, string, int, string)">Trace Logs</see>
        ///             can't go here because the logging infrastructure hasn't been initialized yet.
        ///         </item>
        ///         <item>
        ///             If Avatar doesn't pass an <paramref name="origOptObj"/> or <paramref name="origScriptParam"/>, the Tingen Web
        ///             Service will fail, and a <see cref= "LogEvent.Critical(string, string)">Critical Failure Log</see> will be created.
        ///         </item>
        ///      </list>
        /// </remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The <see cref="Outpost31.Core.Avatar.AvtrParameter.Original">original Script Parameter</see> that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam)
        {
            /* Only for development! */
            DevelopmentOnly(TngnWsvcVer, AvtrSys);

            if (string.IsNullOrWhiteSpace(origScriptParam) || origOptObj == null)
            {
                LogEvent.Critical(AvtrSys, Outpost31.Core.Blueprint.ErrorContent.WsvcCriticalMissingArgs(origOptObj, origScriptParam), "Avatar data missing");

                /* TODO - Since the OptionObject may not exist, we should figure out a way to exit the application without returning a null object. */
                return origOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                var tngnWsvcSession = TngnWsvcSession.New(origOptObj, origScriptParam, TngnWsvcVer, AvtrSys);

                Outpost31.Core.Avatar.AvtrParameter.Request(tngnWsvcSession);

                return tngnWsvcSession.OptObj.Finalized;
            }
        }

        internal static void DevelopmentOnly(string tngnWsvcVer, string avtrSys)
        {
            // This method is only for development, and should be removed before deploying to production.
            LogEvent.Primeval(AvtrSys, $"The TingenWebService has started");
            RuntimeConfiguration.VerifyExists(avtrSys);
        }
    }
}