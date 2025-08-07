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

// REVIEW Should this be moved to Abatab.Module.ProgressNote

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using System;

namespace Abatab.Core.Catalog.Component
{
    /// <summary>Component strings for progress notes.</summary>
    public static class ModProgressNote
    {
        /// <summary>Creates a detail body for progress notes.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <returns>A detail body for progress notes.</returns>
        public static string Detail(AbSession abSession) =>
            $"### Progress Note Module{Environment.NewLine}" +
            $"**Mode:** {abSession.ModProgNote.Mode}  {Environment.NewLine}" +
            $"**Authorized users:** {abSession.ModProgNote.Users}  {Environment.NewLine}" +
            $"**Service Charge Code FieldId:** {abSession.ModProgNote.ServiceChargeCodeFieldId}  {Environment.NewLine}" +
            $"**Service Charge Code prefixes:** {ConvertCollection.ListToString(abSession.ModProgNote.FlaggedServiceChargeCodePrefixes)}  {Environment.NewLine}" +
            $"**Service Charge Code codes:** {ConvertCollection.ListToString(abSession.ModProgNote.FlaggedServiceChargeCodeCodes)}  {Environment.NewLine}" +
            $"**Location FieldId:** {abSession.ModProgNote.LocationFieldId}  {Environment.NewLine}" +
            $"**Valid location codes:** {ConvertCollection.ListToString(abSession.ModProgNote.ValidLocationCodes)}  {Environment.NewLine}" +
            $"**Valid location names:** {ConvertCollection.ListToString(abSession.ModProgNote.ValidLocationNames)}  {Environment.NewLine}";

        /// <summary>Creates the verify location message for progress notes.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <param name="logType">The type of log.</param>
        /// <returns>The verify location message for progress notes.</returns>
        public static string VfyLocMessage(AbSession abSession,string logType) =>
            $"# [{logType}] Progress Note >+ Verify Location{Environment.NewLine}" +
            $"{Detail(abSession)}{Environment.NewLine}" +
            $"# {logType} information{Environment.NewLine}" +
            $"Error Code: `{abSession.ReturnOptionObject.ErrorCode}`<br>{Environment.NewLine}" +
            $"Error Message:  {Environment.NewLine}" +
            $"```{abSession.ReturnOptionObject.ErrorMesg}```";
    }
}