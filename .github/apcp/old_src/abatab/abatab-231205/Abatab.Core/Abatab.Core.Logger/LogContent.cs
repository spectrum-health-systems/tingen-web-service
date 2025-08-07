// b231205.1411

using Abatab.Core.Catalog.Definition;
using System.IO;

namespace Abatab.Core.Logger
{
    /// <summary>Creates log file content.</summary>
    public static class LogContent
    {
        /// <summary>Create alert log content</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="callPath">The calling class (e.g., "ClassName").</param>
        /// <returns>Content for an alert log.</returns>
        public static string Alert(AbSession abSession,string callPath)
        {
            switch (Path.GetFileName(callPath))
            {
                case "VerifyLocation.cs":
                    return Catalog.Component.ModProgressNote.VfyLocMessage(abSession,"Alert");

                default:
                    return "Invalid";
            }
        }
    }
}