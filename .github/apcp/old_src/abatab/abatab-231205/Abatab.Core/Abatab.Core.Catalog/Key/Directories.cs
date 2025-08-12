// b231205.1411

using Abatab.Core.Catalog.Definition;
using System.Collections.Generic;

namespace Abatab.Core.Catalog.Key
{
    /// <summary>Pre-defined lists of directories.</summary>
    public static class Directories
    {
        /// <summary>Framework directories.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A list of framework directories.</returns>
        public static List<string> Framework(AbSession abSession) => new List<string>()
        {
            abSession.AbatabDataRoot,
            abSession.SessionDataDirectory,
            abSession.PublicDataRoot,
            abSession.AlertLogDirectory,
            abSession.DebugglerLogDirectory
        };

        /// <summary>Session directories.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A list of Abatab session directories.</returns>
        public static List<string> Session(AbSession abSession) => new List<string>()
        {
            abSession.SessionDataDirectory,
            abSession.TraceLogDirectory,
            abSession.WarningLogDirectory
        };
    }
}