/* TingenWebService.TingenWebService.asmx.cs
 * u250821_code
 * u250821_documentation
 */

/* ##############
 *   IMPORTANT!
 * ##############
 *
 * Before deploying the Tingen Web Service, please verify that AvtrSys is set correctly!
 * https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/setting-avtrsys.md
 */

using System.Reflection;
using System.Web;
using System.Web.Services;
using Outpost31.Core.Logger;
using Outpost31.Core.Runtime;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;
using TingenWebService.Properties;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
    /// <remarks>
    ///     <include file='AppData/XMLDoc/Asmx.xml' path='TngnWsvc/Class[@name="Asmx"]/ClassDescription/*'/>
    ///     <include file='AppData/XMLDoc/ProjectInfo.xml' path='TngnWsvc/Class[@name="ProjectInfo"]/Callback/*'/>
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing assembly name.</summary>
        /// <remarks>
        ///     <include file='../../outpost31/src/AppData/XmlDoc/Common.xml' path='TngnOpto/Class[@name="Common"]/ExeAsmName/*'/>
        /// </remarks>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The current version of the Tingen Web Service.</summary>
        public static string TngnWsvcVer { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of the Tingen Web Service.</summary>
        /// <remarks>This method is required and <i>should not be modified</i>.</remarks>
        /// <returns>The current <see cref="TngnWsvcVer">version</see> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks><include file='AppData/XmlDoc/Asmx.xml' path='TngnWsvc/Class[@name="Asmx"]/RunScript/*'/></remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original <see cref="Outpost31.Core.Avatar.AvtrParameter.Original">Script Parameter</see> that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam)
        {
            /* Before deploying the Tingen Web Service, please verify that AvtrSys is set correctly!
             * https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/setting-avtrsys.md
             */
            string avtrSys = Settings.Default.AvtrSys;

            /* Only for development!
             */
            DevelopmentOnly(TngnWsvcVer, avtrSys);

            if (string.IsNullOrWhiteSpace(origScriptParam) || origOptObj == null)
            {
                LogEvent.Critical(avtrSys, Outpost31.Core.Blueprint.ErrorContent.WsvcCriticalMissingArgs(origOptObj, origScriptParam), "Avatar data missing");

                /* TODO - Since the OptionObject may not exist, we should figure out a way to exit the application without returning a null object. */
                return origOptObj.ToReturnOptionObject(0, "");
            }
            else
            {
                var tngnWsvcSession = TngnWsvcSession.New(origOptObj, origScriptParam, TngnWsvcVer, avtrSys);

                Outpost31.Core.Avatar.AvtrParameter.Request(tngnWsvcSession);

                return tngnWsvcSession.OptObj.Finalized;
            }
        }

        /// <summary>
        /// Executes development-specific operations for verifying runtime configurations and logging events.
        /// </summary>
        /// <remarks>This method is intended for development purposes only and should not be included in
        /// production deployments. It performs logging and runtime configuration verification for the specified
        /// system.</remarks>
        /// <param name="tngnWsvcVer">The version of the Tingen Web Service being used.</param>
        /// <param name="avtrSys"><include file='../../outpost31/src/AppData/XmlDoc/Common.xml' path='TngnOpto/Class[@name="Common"]/AvtrSys/*'/></param>
        internal static void DevelopmentOnly(string tngnWsvcVer, string avtrSys)
        {
            LogEvent.Primeval(avtrSys, $"The TingenWebService has started");
            RuntimeConfiguration.VerifyExists(avtrSys);
        }
    }
}