// =============================================================== 25.2.0 ======
// TingenWebService: The entry point for the Tingen web service.
// Repository: https://github.com/APrettyCoolProgram/Tingen-WebService
// Documentation: https://github.com/spectrum-health-systems/Tingen-Documentation
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// ================================================================ 250121 =====

// u250204_code
// u250204_documentation

using System.IO;
using System.Reflection;
using System.Web.Services;

using Outpost31.Core;
//using Outpost31.Core.Logger;
//using Outpost31.Core.Session;

using ScriptLinkStandard.Objects;

namespace TingenWebService
{
    /// <summary>The entry point for the Tingen web service.</summary>
    /// <include file='XmlDoc/TingenWebService_doc.xml' path='TingenWebService/Type[@name="Class"]/TingenWebService/*'/>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TingenWebService : System.Web.Services.WebService
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The Tingen current version number.</summary>
        /// <include file='XmlDoc/TingenWebService_doc.xml' path='TingenWebService/Type[@name="Property"]/TingenVersionNumber/*'/>
        public static string TngnVersionNumber { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>Get the current version of Tingen.</summary>
        /// <returns>The current version number of Tingen.</returns>
        /// <include file='XmlDoc/TingenWebService_doc.xml' path='TingenWebService/Type[@name="Method"]/GetVersion/*'/>
        [WebMethod]
        public string GetVersion() => $"VERSION {TngnVersionNumber}";

        /// <summary>Starts the Tingen web service.</summary>
        /// <param name="sentOptionObject">The SentOptionObject sent from Avatar.</param>
        /// <param name="sentScriptParameter">The SentScriptParameter sent from Avatar.</param>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        /// <include file='XmlDoc/TingenWebService_doc.xml' path='TingenWebService/Type[@name="Method"]/RunScript/*'/>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            /* Trace Logs can't go here because the logging infrastructure hasn't been initialized yet, so if you
               * need to create a log file here, use a Primeval Log.
               */

            string systemCode = Startup.GetSystemCode();




            // -- WAIT -- TingenSession tnSession = TingenSession.Build(sentOptionObject, sentScriptParameter, TingenVersionNumber);

            // -- WAIT -- tnSession.AvData.SystemCode = "UAT";

            // -- WAIT -- LogEvent.Trace(1, ExeAsm, tnSession.TraceInfo);

            // -- WAIT -- TingenApp.StartApp(tnSession);

            // -- WAIT -- TingenApp.StopApp(tnSession);

            // -- WAIT -- return tnSession.AvData.ReturnOptionObject;

            return sentOptionObject;
        }
    }
}
