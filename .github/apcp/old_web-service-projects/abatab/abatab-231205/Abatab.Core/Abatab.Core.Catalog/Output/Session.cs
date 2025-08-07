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
    /// <summary>Session details.</summary>
    public static class Session
    {
        /// <summary>Complete session data.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>Complete session data.</returns>
        public static string Complete(AbSession abSession) =>
                "# Abatab session" +
                Environment.NewLine +
                Body.Setting.Standard(abSession) +
                Environment.NewLine +
                Body.Module.Standard(abSession) +
                Environment.NewLine +
                Body.OptionObject.Standard(abSession);
    }
}