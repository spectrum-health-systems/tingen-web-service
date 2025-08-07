// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.IO;
using System.Reflection;

namespace Abatab.Core.Framework
{
    /// <summary>Validate Abatab framework components.</summary>
    public static class Validate
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Verify framework status.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        public static void Status(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            if (!Directory.Exists(abSession.SessionDataDirectory))
            {
                LogEvent.Trace("traceinternal",abSession,AssemblyName);

                Maintenance.Refresh(abSession);
            }
        }
    }
}