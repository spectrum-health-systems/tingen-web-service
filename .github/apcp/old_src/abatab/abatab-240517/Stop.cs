
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatabadev
{
    public class Stop
    {
        /// <summary>Stops the current Abatab session.</summary>
        public class Stop
        {
            /// <summary>Executing assembly name for log files.</summary>
            /// <remarks>
            ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
            ///       method when creating log files.
            /// </remarks>
            public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

            /// <summary>Finalizes an Abatab session.</summary>
            /// <param name="abSession">The Abatab session object.</param>
            public static void ExistingSession(AbSession abSession)
            {
                LogEvent.Trace("trace", abSession, AssemblyName);

                LogEvent.Session(abSession);
            }
        }
    }
}