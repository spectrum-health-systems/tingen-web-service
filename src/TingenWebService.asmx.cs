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
// u250404_code
// u250404_documentation

using System.Reflection;
using System.Web.Services;

using ScriptLinkStandard.Objects;
using Outpost31.Core.Session;
using Outpost31.Core.Runtime;
using System.IO;
using System.Data.SqlClient;

namespace TingenWebService
{
    /// <summary>The entry point for the Tingen web service.</summary>
    /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/TingenWebService/*'/>
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
        /// <param name="sentOptionObject">The SentOptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The SentScriptParameter sent from Avatar.</param>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        /// <include file='AppData/XmlDoc/TingenWebService.xml' path='TingenWebService/Class[@name="TingenWebService"]/RunScript/*'/>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace Logs won't work here. */

            Outpost31.Core.Logger.LogEvent.Primeval(@"C:\IT", ExeAsm, "Tingen primeval log");

            TngnSession tngnSession = new TngnSession(); // #DEVNOTE# Defined here so it can be used throughout app.

            Spin.Up(tngnSession, TngnVersion, sentOptionObject, sentScriptParameter);

            return sentOptionObject;
        }
    }
}