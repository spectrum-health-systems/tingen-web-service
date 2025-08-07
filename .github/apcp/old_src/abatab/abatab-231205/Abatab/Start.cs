// b231205.1400

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Framework;
using Abatab.Core.Session;
using Abatab.Core.Utility;
using Abatab.Properties;
using ScriptLinkStandard.Objects;
using System.Reflection;

namespace Abatab
{
    /// <summary>Starts a new Abatab session.</summary>
    public static class Start
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Initialize a new Abatab session.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="sentScriptParameter">The Script Parameter sent from myAvatar.</param>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        public static void NewSession(AbSession abSession,string sentScriptParameter,OptionObject2015 sentOptionObject)
        {
            Debuggler.DebugLog(Settings.Default.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            WebConfig.Load(abSession);

            Build.NewSession(sentOptionObject,sentScriptParameter,abSession);

            Validate.Status(abSession);
        }
    }
}