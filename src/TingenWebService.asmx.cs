// The
// ████████╗██╗███╗   ██╗ ██████╗ ███████╗███╗   ██╗
// ╚══██╔══╝██║████╗  ██║██╔════╝ ██╔════╝████╗  ██║
//    ██║   ██║██╔██╗ ██║██║  ███╗█████╗  ██╔██╗ ██║
//    ██║   ██║██║╚██╗██║██║   ██║██╔══╝  ██║╚██╗██║
//    ██║   ██║██║ ╚████║╚██████╔╝███████╗██║ ╚████║
//    ╚═╝   ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝╚═╝  ╚═══╝
//                                       Web Service
//                        Development Release 25.4.0
//
// https://github.com/APrettyCoolProgram/Tingen-WebService
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.

// u250412_code
// u250412_documentation

using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Web.Services;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry point for the Tingen web service.</summary>
    /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/ClassDescription/*'/>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : WebService
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The Tingen current version number.</summary>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/TngnVersion/*'/>
        public static string TngnVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of Tingen.</summary>
        /// <remarks><b>This method is required by Avatar and should not be modified.</b></remarks>
        /// <returns>The current version number of Tingen.</returns>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnVersion}";

        /// <summary>Starts the Tingen web service.</summary>
        /// <param name="sentOptObj">The OptionObject that is sent from Avatar.</param>
        /// <param name="sentSlnkScriptParam">The Script Parameter that is sent from Avatar.</param>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/RunScript/*'/>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentSlnkScriptParam)
        {
            /* Trace Logs won't work here. */

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || sentOptObj == null)
            {
                /* #DEVNOTE#
                 * If we are missing the OptionObject or Script Parameter, write a Defcon1 file. Generally the fix for
                 * this issue is to re-import the Tingen Web Service WSDL.
                 */

                Defcon1();

                return sentOptObj.ToReturnOptionObject(0, "Missing OptionObject and/or Script Parameter");
            }

            if (sentSlnkScriptParam.ToLower().StartsWith("_p"))
            {
                return Outpost31.Module.Prototype.Run.Code(sentOptObj, sentSlnkScriptParam);
            }
            else
            {
                TngnWbsvSession tngnSession = TngnWbsvSession.New(sentOptObj, sentSlnkScriptParam, TngnVersion);

                Outpost31.Core.Service.Spin.Up(tngnSession);

                return sentOptObj; // should be "returnOptObj = Session.WorkOptObj", or something like that.
            }
        }

        /// <summary>Writes a Defcon1 file to the Tingen Web Service log directory.</summary>
        private void Defcon1()
        {
            const string message = "Missing OptionObject and/or Script Parameter";
            var dateTimeStamp    = DateTime.Now.ToString("yyyyMMdd-HHmmss");
            var fileName         = $@"C:\Tingen_Data\WebService\UAT\Defcon1.{dateTimeStamp}";

            File.WriteAllText(fileName, message);
        }
    }
}