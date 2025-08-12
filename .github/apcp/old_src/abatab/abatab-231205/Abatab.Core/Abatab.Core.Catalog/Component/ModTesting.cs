// b231205.1411

/* Development note
 * ================
 * The strings that these methods return use Markdown syntax, which creates a
 * carriage return when a line ends with two blank characters:
 *
 *      $"**Mode:** {abSession.ModProgressNote.Mode}  {Environment.NewLine}"
 *                                                  ^^
 *                                                  
 * Removing the blank characters will break the Markdown output.
 */

// REVIEW Should this be moved to Abatab.Module.QuickMedicationOrder

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Component strings for testing functionality.</summary>
    public static class ModTesting
    {
        /// <summary>Creates a detail body for testing functionality.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A detail body for testing functionality.</returns>
        public static string Detail(AbSession abSession) =>
            $"### Testing Module{Environment.NewLine}" +
            $"**Mode:** {abSession.ModTesting.Mode}  {Environment.NewLine}";
    }
}