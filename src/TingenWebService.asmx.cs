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

// u250421_code
// u250421_documentation

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Session;
using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry class for the Tingen Web Service.</summary>
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
        /// <returns>The current version number of Tingen.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/GetVersion/*'/>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnVersion}";

        /// <summary>The entry method for the Tingen Web Service that Avatar sends data to.</summary>
        /// <param name="sentOptObj">The OptionObject that is sent from Avatar.</param>
        /// <param name="sentSlnkScriptParam">The Script Parameter that is sent from Avatar.</param>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/RunScript/*'/>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentSlnkScriptParam)
        {
            /* Please see method documentation for important information about this method.
             */

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || sentOptObj == null)
            {
                Outpost31.Core.Logger.LogEvent.Defcon1(@"C:\\Tingen_Data\Defcon", "Missing OptionObject and/or Script Parameter");

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
    }
}