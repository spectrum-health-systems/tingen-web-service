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
    public static class OptionObject
    {
        /// <summary>Creates a standard OptionObject information body.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A standard OptionObject information body.</returns>
        public static string Standard(AbSession abSession) =>
            "## OptionObjects" +
            Environment.NewLine +
            Component.OptionObject.SentObject(abSession) +
            Environment.NewLine +
            Component.OptionObject.ReturnObject(abSession) +
            Environment.NewLine;
    }
}