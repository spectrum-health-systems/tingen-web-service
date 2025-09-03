// =============================================================================
// TingenWebService.Configuration.RuntimeConfiguration.cs
// https://github.com/spectrum-health-systems/outpost31
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250903_code
// u250903_documentation
// =============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using TingenWebService.Properties;

namespace TingenWebService.Configuration
{
    public class RuntimeConfig
    {
        public string AvatarSystem { get; set; }
        public string WsvcMode { get; set; }
        public string TraceLimit { get; set; }

        /// <summary>A required log file component.</summary>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        internal static Dictionary<string, string> Load(Settings runtimeConfig)
        {
            // Should have log here.
            // Need to convert this, since it's used as an integer elsewhere.
            //int traceLimitAsInt = Convert.ToInt32(runtimeConfig.TraceLimit);
            //Outpost31.Core.Logger.LogAppEvent.Trace(2, traceLimitAsInt, runtimeConfig.AvatarSystem, ExeAsmName, 0);



            return new Dictionary<string, string>
            {
                { "AvatarSystem", runtimeConfig.AvatarSystem.ToLower() },
                { "WsvcMode",     runtimeConfig.WsvcMode.ToLower() },
                { "TraceLimit",   runtimeConfig.TraceLimit }
            };
        }
    }
}