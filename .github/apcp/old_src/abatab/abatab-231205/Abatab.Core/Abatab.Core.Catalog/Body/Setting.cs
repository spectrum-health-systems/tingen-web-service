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

// REVIEW Better idea to use string interpolation here.

using Abatab.Core.Catalog.Definition;
using System;

namespace Abatab.Core.Catalog.Body
{
    /// <summary>Body strings for OptionObjects.</summary>
    public static class Setting
    {
        /// <summary>Creates a standard information body for settings.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A standard information body for settings.</returns>
        public static string Standard(AbSession abSession) =>
            "## Abatab settings" +
            Environment.NewLine +
            Component.Setting.Detail(abSession);

        /// <summary>Creates a standard information body for the current settings.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A standard information body for the current settings.</returns>
        public static string Current(AbSession abSession) =>
            "## Current Abatab settings" +
            Environment.NewLine +
            Component.Setting.Current(abSession);
    }
}