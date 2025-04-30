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
//
// Tingen Web Service documentation:
//  https://github.com/spectrum-health-systems/Tingen-Documentation

// u250430_code
// u250430_documentation

using System.IO;
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
        public static string TngnWbsvVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public static string TngnWbsvEnvironment { get; set; } = "UAT";

        /// <summary>Get the current version of Tingen.</summary>
        /// <returns>The current version number of Tingen.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/GetVersion/*'/>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnWbsvVersion}";

        /// <summary>The entry method for the Tingen Web Service that Avatar sends data to.</summary>
        /// <param name="sentOptObj">The OptionObject that is sent from Avatar.</param>
        /// <param name="sentSlnkScriptParam">The Script Parameter that is sent from Avatar.</param>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/RunScript/*'/>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentSlnkScriptParam)
        {
            /* Please see XML Documentation for important information about this method.
             */        

            if (string.IsNullOrWhiteSpace(sentSlnkScriptParam) || sentOptObj == null)
            {
                string TngnWbsvEnvironment = File.ReadAllText(@".\AppData\Runtime\TngnWbsv.Environment");

                Outpost31.Core.Logger.LogEvent.Critical(TngnWbsvEnvironment, "Missing OptionObject and/or Script Parameter");

                return sentOptObj.ToReturnOptionObject(0, MsgCriticalFailure());
            }

            if (sentSlnkScriptParam.ToLower().StartsWith("_p"))
            {
                return Outpost31.Module.Prototype.Run.Code(sentOptObj, sentSlnkScriptParam);
            }
            else
            {
                TngnWbsvSession tngnWbsvSession = TngnWbsvSession.New(sentOptObj, sentSlnkScriptParam, TngnWbsvVersion, TngnWbsvEnvironment);

                Outpost31.Core.Service.Spin.Up(tngnWbsvSession);

                return sentOptObj.ToReturnOptionObject(0, ""); // THIS IS A PLACEHOLDER.
            }
        }

        private static string MsgCriticalFailure()
        {
            return File.ReadAllText(@"C:\Tingen_Data\WebService\UAT\ErrorCodeMessages\TingenWebService.CriticalFailure");
        }
    }
}