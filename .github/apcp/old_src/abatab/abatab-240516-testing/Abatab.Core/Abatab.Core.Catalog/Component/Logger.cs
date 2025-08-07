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

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Component strings for logging stuff.</summary>
    public static class Logger
    {
        // Nothing here yet!
    }
}