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

namespace Abatab.Core.Catalog.Output
{
    /// <summary>Setting details.</summary>
    public static class Setting
    {
        /// <summary>Current setting details. </summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>Current setting details</returns>
        public static string Current(AbSession abSession) =>
            "# Current Abatab Settings" +
            Environment.NewLine +
            Body.Setting.Current(abSession);
    }
}