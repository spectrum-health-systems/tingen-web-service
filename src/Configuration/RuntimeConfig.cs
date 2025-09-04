// =============================================================================
// TingenWebService.Configuration.RuntimeConfig.cs
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250904_code
// u250904_documentation
// =============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using TingenWebService.Properties;

namespace TingenWebService.Configuration
{
    /// <summary>Runtime configuration logic.</summary>
    internal class RuntimeConfig
    {
        /// <summary>A required log file component.</summary>
        public static string ExeAsmName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;


        /// <summary>Loads the runtime configuration for the Tingen Web Service.</summary>
        /// <param name="runtimeConfig"></param>
        /// <returns>A dictionary with the runtime configuration.</returns>
        internal static Dictionary<string, string> Load(Settings runtimeConfig, string tngnWsvcVer) =>
            new Dictionary<string, string>
            {
                { "Version",        tngnWsvcVer },
                { "AvatarSystem",   runtimeConfig.AvatarSystem },
                { "Mode",           runtimeConfig.Mode.ToLower() },
                { "BaseWwwFolder",  $@"{runtimeConfig.WwwFolderBase}\{runtimeConfig.AvatarSystem}" },
                { "BaseDataFolder", $@"{runtimeConfig.DataFolderBase}\{runtimeConfig.AvatarSystem}" },
                { "TraceLogLimit",  runtimeConfig.TraceLogLimit}
            };
    }
}