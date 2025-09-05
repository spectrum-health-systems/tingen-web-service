// =============================================================================
// TingenWebService.Configuration.RuntimeConfig.cs
// https://github.com/spectrum-health-systems/tingen-web-service
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// -----------------------------------------------------------------------------
// u250905_code
// u250905_documentation
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
        /// <remarks>Most settings are from the Web.config file.</remarks>
        /// <param name="webConfigSettings">The Settings.settings content</param>
        /// <returns>A dictionary with the runtime configuration.</returns>
        internal static Dictionary<string, string> Load(Settings webConfigSettings, string tngnWsvcVer) =>
            new Dictionary<string, string>
            {
                { "Version",        tngnWsvcVer },
                { "AvatarSystem",   webConfigSettings.AvatarSystem },
                { "Mode",           webConfigSettings.Mode.ToLower() },
                { "SystemWwwFolder",  $@"{webConfigSettings.WwwFolderBase}\{webConfigSettings.AvatarSystem}" },
                { "SystemDataFolder", $@"{webConfigSettings.DataFolderBase}\{webConfigSettings.AvatarSystem}" },
                { "TraceLogLimit",  webConfigSettings.TraceLogLimit}
            };
    }
}