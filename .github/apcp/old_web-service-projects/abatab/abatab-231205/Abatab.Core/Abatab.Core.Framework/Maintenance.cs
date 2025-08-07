// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Collections.Generic;
using System.Reflection;

namespace Abatab.Core.Framework
{
    /// <summary>Abatab framework maintenance.</summary>
    public static class Maintenance
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Refresh the Abatab framework.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void Refresh(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            VerifyDirectories(abSession);
            ExportCurrentSettings(abSession);
        }

        /// <summary>Verify Abatab framework directories.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        private static void VerifyDirectories(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            List <string> frameworkDirectories = Catalog.Key.Directories.Framework(abSession);
            Utility.FileSys.VerifyDirectories(frameworkDirectories);
        }

        /// <summary>Export current Abatab settings.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        private static void ExportCurrentSettings(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            LogEvent.CurrentSetting(abSession);
        }
    }
}