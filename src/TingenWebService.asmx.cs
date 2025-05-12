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

// u250501_code
// u250501_documentation

using System.Reflection;
using System.Web.Services;
using Outpost31.Core.Service;
using System.Web.UI;
using ScriptLinkStandard.Objects;
using Outpost31.Core.Session;
using Outpost31.Core.Logger;
using System.IO;
using System;

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
        /// <remarks>The version number is pulled from <i>Properties/AssemblyInfo.cs</i></remarks>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/TngnWbsvVersion/*'/>
        public static string TngnWbsvVersion { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>The environment that the Tingen Web Service will interface with.</summary>
        /// <remarks>This must be either LIVE or UAT.</remarks>
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
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentScriptParam)
        {
            if (string.IsNullOrWhiteSpace(sentScriptParam) || sentOptObj == null)
            {
                var optObjExists         = sentOptObj != null ? "true" : "false";
                var sentScriptParmExists = !string.IsNullOrWhiteSpace(sentScriptParam) ? "true" : "false";

                LogEvent.Critical(TngnWbsvEnvironment, Outpost31.Core.Template.Messages.TngnWbsvCriticalFailureDetail(optObjExists, sentScriptParmExists));

                // This really should just be a stop - can't return something that doesn't exist.

                return sentOptObj.ToReturnOptionObject(0, Outpost31.Core.Template.Messages.TngnWbsvCriticalFailureDetail(optObjExists, sentScriptParmExists));
            }
            else
            {
                File.WriteAllText("c:\\IT\\test.txt", "test");

                LogEvent.Debuggler(TngnWbsvEnvironment, "Test 1");

                TngnWbsvSession tngnWbsvSession = new TngnWbsvSession();

                Spin.Up(tngnWbsvSession, sentOptObj, sentScriptParam, TngnWbsvVersion, TngnWbsvEnvironment);

                Outpost31.Core.Avatar.ScriptParameter.Request(tngnWbsvSession);

                return tngnWbsvSession.ReturnOptObj;
            }
        }
    }
}