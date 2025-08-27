/* TingenWebService.TingenWebService.asmx.cs
 * u250827_code
 * u250827_documentation
 */

/*******************************************************************************
 * IMPORTANT!
 *
 * Before deploying the Tingen Web Service, please verify that avtrSys is set
 * correctly!
 * https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/setting-avtrsys.md
 ******************************************************************************/

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
    ///     <include file='AppData/XmlDoc/Asmx.xml' path='TngnWsvc/Class[@name="Asmx"]/ClassDescription/*'/>
    ///     <include file='AppData/XmlDoc/ProjectInfo.xml' path='TngnWsvc/Class[@name="ProjectInfo"]/Callback/*'/>
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
        /// <returns>The current <see cref="TngnWsvcVer"/> of the Tingen Web Service.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWsvcVer}";

        /// <summary>The entry point for the Tingen Web Service.</summary>
        /// <remarks>
        ///     <include file='AppData/XmlDoc/Asmx.xml' path='TngnWsvc/Class[@name="Asmx"]/RunScript/*'/>
        /// </remarks>
        /// <param name="origOptObj">The <see cref="OptionObject2015"/> sent from Avatar.</param>
        /// <param name="origScriptParam">The original Script Parameter that is sent from Avatar.</param>
        /// <returns>An <see cref="OptionObject2015"/> representing the result of the Script Parameter request.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 origOptObj, string origScriptParam)
        {
            /* For debugging only!
             */
            //WriteStartLog();

            /* Before deploying the Tingen Web Service, please verify that AvtrSys is set correctly!
             * https://github.com/spectrum-health-systems/tingen-documentation-project/blob/main/static/setting-avtrsys.md
             */
            string avtrSys = Settings.Default.AvtrSys;

            Outpost31.Core.Admin.AdminMode.Run(origOptObj, origScriptParam, TngnWsvcVer, avtrSys, Settings.Default.AdminMode);

            if (origOptObj == null || string.IsNullOrWhiteSpace(origScriptParam))
            {
                //-//LogEvent.Critical(avtrSys, ErrorContent.WsvcCriticalMissingArgs(origOptObj, origScriptParam), "Avatar data missing");

                /* DN01 */

                return origOptObj.ToReturnOptionObject(0, "");
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
    }
}

/* DN01
 * If the OptionObject wasn't sent from Avatar, it can't be "finalized" and returned. We need to figure out how to
 * handle this.
 */