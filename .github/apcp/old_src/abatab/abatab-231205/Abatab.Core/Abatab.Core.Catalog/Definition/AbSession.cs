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

using ScriptLinkStandard.Objects;
using System.Collections.Generic;

namespace Abatab.Core.Catalog.Definition
{
    /// <summary>Properties for the AbSession object.</summary>
    /// <remarks>
    ///     - The AbSession object contains all of the necessary information that Abatab needs to do what it does.
    /// </remarks>
    public class AbSession
    {
        /* DEVNOTE
         * The following settings are loaded from the local Web.config file.
         */

        /// <summary>The mode that Abatab will use when executed.</summary>
        /// <remarks>
        ///     <list type="table">
        ///         <listheader>
        ///             <term>Setting</term>
        ///             <description>Description</description>
        ///         </listheader>
        ///         <item>
        ///             <term><b><i>enabled</i></b></term>
        ///             <description>All Abatab functionality is (potentially) available.</description>
        ///         </item>
        ///         <item>
        ///             <term>disabled</term>
        ///             <description>Abatab functionality is not available.</description>
        ///         </item>
        ///         <item>
        ///             <term>passthrough</term>
        ///             <description>All functionality is available, but no changes are made to Avatar.</description>
        ///         </item>
        ///     </list>
        ///     <list type="bullet">
        ///         <item>If this is set to <c>AbatabMode=enabled</c>, you are still able to disable specific modules via their corresponding mode setting.</item>
        ///         <item>The <c>AbatabMode=passthrough</c> mode is intended for development, not production.</item>
        ///     </list>
        /// </remarks>
        /// <value>Default value is <c>enabled</c></value>
        public string AbatabMode { get; set; }

        /// <summary>The current Abatab version.</summary>
        public string AbatabVersion { get; set; }

        /// <summary>The current Abatab build.</summary>
        public string AbatabBuild { get; set; }

        // REVIEW Potentially change this from "C:\Abatab_LIVE" to "C:\Abatab\LIVE"

        /// <summary>The root directory where the Abatab web service has been deployed.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>At runtime the <c>AvatarEnvironment</c> value is added to the end of <c>AbatabRoot</c> to form the complete path.</item>
        ///         </list>
        /// </remarks>
        /// <example>
        ///     If <c>AbatabRoot=C:\Abatab_</c>, and <c>AvatarEnvironment=LIVE</c>, then <c>AbatabRoot</c> would be set to <c>C:\Abatab_LIVE</c> at runtime.
        /// </example>
        /// <value>Default value is <c>C:\Abatab_</c></value>
        public string AbatabServiceRoot { get; set; }

        /// <summary>The root directory where non-web service data code is located.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>At runtime the <c>AvatarEnvironment</c> value is created as a sub-directory of the <c>AbatabDataRoot</c>.</item>
        ///         <item>This is the directory where exported data/logs should be stored.</item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     If <c>AbatabDataRoot=C:\AbatabData</c>, and <c>AvatarEnvironment=LIVE</c>, then <c>AbatabDataRoot</c> would be set to <c>C:\AbatabData\LIVE</c> at runtime.
        /// </example>
        /// <value>Default value is <c>C:\AbatabData</c></value>
        public string AbatabDataRoot { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerMode { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerTypes { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string LoggerDelay { get; set; }

        /// <summary>The Avatar environment that Abatab will reference when executed.</summary>
        /// <remarks>
        ///     <list type="table">
        ///         <listheader>
        ///             <term>Environment name</term>
        ///             <description>Description</description>
        ///         </listheader>
        ///         <item>
        ///             <term><b><i>LIVE</i></b></term>
        ///             <description>The Avatar production environment.</description>
        ///         </item>
        ///         <item>
        ///             <term>UAT</term>
        ///             <description>The Avatar testing environment.</description>
        ///         </item>
        ///         <item>
        ///             <term>SBOX</term>
        ///             <description>The Avatar sandbox environment.</description>
        ///         </item>
        ///     </list>
        /// </remarks>
        /// <value>Default value is <c>LIVE</c></value>
        public string AvatarEnvironment { get; set; }

        /// <summary>The fallback username for Abatab.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>If <c>sentOptObj.OptionUserId</c> does not contain a valid username, <c>AbatabFallbackUserName</c> will be used.</item>
        ///     </list>
        /// </remarks>
        /// <value>Default value is <c>_Abatab</c></value>
        public string AbatabFallbackUserName { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabEmailAddress { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string AbatabEmailPassword { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DebugglerMode { get; set; }

        /* DEVNOTE
         * The following settings are created at runtime.
         */

        /// <summary>The session date.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>Uses the following syntax: <c>yyMMdd</c>.</item>
        ///     </list>
        /// </remarks>
        /// <value>Set at runtime.</value>
        public string Datestamp { get; set; }

        /// <summary>The session time.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>Uses the following syntax: <c>HHmmss</c>.</item>
        ///     </list>
        /// </remarks>
        /// <value>Set at runtime.</value>
        public string Timestamp { get; set; }

        /// <summary>The Module component of the Script Parameter.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This is the first component of the Script Parameter passed from Avatar.</item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     The Script Parameter <c>QMedOrdr-Dose-VfyAmount</c> uses the <c>QMedOrdr</c> module.
        /// </example>
        /// <value>Set at runtime.</value>
        public string RequestModule { get; set; }

        /// <summary>The Command component of the Script Parameter.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This is the second component of the Script Parameter passed from Avatar.</item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     The Script Parameter <c>QMedOrdr-Dose-VfyAmount</c> contains the <c>Dose</c> command.
        /// </example>
        /// <value>Set at runtime.</value>
        public string RequestCommand { get; set; }

        /// <summary>The Action component of the Script Parameter.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This is the third component of the Script Parameter passed from Avatar.</item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     The Script Parameter <c>QMedOrdr-Dose-VfyAmount</c> contains the <c>VfyAmount</c> action.
        /// </example>
        /// <value>Set at runtime.</value>
        public string RequestAction { get; set; }

        /// <summary>The Option component of the Script Parameter.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This is the (optional) fourth component of the Script Parameter passed from Avatar.</item>
        ///     </list>
        /// </remarks>
        /// <example>
        ///     The Script Parameter <c>QMedOrdr-Dose-VfyAmount-Clear</c> contains the <c>Clear</c> option.
        /// </example>
        /// <value>Set at runtime.</value>
        public string RequestOption { get; set; }

        /// <summary>The Abatab username.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This should be set to the value in <c>sentOptObj.OptionUserId</c>.</item>
        ///         <item>If the value in <c>sentOptObj.OptionUserId</c> is not valid, this will be set to <c>AbatabFallbackUserName</c>.</item>
        ///     </list>
        ///  </remarks>
        /// <value>Set at runtime.</value>
        public string AbatabUserName { get; set; }

        /// <summary>Property description goes here.</summary>
        public string SessionDataRoot { get; set; }

        /// <summary>Property description goes here.</summary>
        public string SessionDataDirectory { get; set; }

        /// <summary>Property description goes here.</summary>
        public string TraceLogDirectory { get; set; }

        /// <summary>Property description goes here.</summary>
        public string WarningLogDirectory { get; set; }

        /// <summary>Property description goes here.</summary>
        public string PublicDataRoot { get; set; }

        /// <summary>Property description goes here.</summary>
        public string AlertLogDirectory { get; set; }

        /// <summary>
        /// Property description goes here.
        /// </summary>
        public string DebugglerLogDirectory { get; set; }

        /* DEVNOTE
         * The following settings specific to OptionObjects.
         */

        /// <summary>The OptionObject that Avatar sends to Abatab.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This OptionObject is not modified by Abatab.</item>
        ///     </list>
        /// </remarks>
        /// <value>Set at runtime</value>
        public OptionObject2015 SentOptionObject { get; set; }

        /// <summary>The OptionObject that Abatab sends back to Avatar.</summary>
        /// <remarks>
        ///     <list type="bullet">
        ///         <item>This OptionObject is modified by Abatab.</item>
        ///     </list>
        /// </remarks>
        /// <value>Set at runtime</value>
        public OptionObject2015 ReturnOptionObject { get; set; }

        /* DEVNOTE
         * The following settings are module-specific.
         */

        /// <summary>Property description goes here.</summary>
        public ModProgNote ModProgNote { get; set; }

        /// <summary>Property description goes here.</summary>
        public ModProto ModProto { get; set; }

        /// <summary>Property description goes here.</summary>
        public ModQMedOrdr ModQMedOrdr { get; set; }

        /// <summary>Property description goes here.</summary>
        public ModTesting ModTesting { get; set; }
    }

    /* DEVNOTE
     * The following settings are module-specific.
     */

    /// <summary>Progress Note module</summary>
    public class ModProgNote
    {
        /// <summary>Property description goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Property description goes here.</summary>
        public string Users { get; set; }

        /// <summary>Property description goes here.</summary>
        public string ServiceChargeCodeFieldId { get; set; }

        /// <summary>Property description goes here.</summary>
        public List<string> FlaggedServiceChargeCodePrefixes { get; set; }

        /// <summary>Property description goes here.</summary>
        public List<string> FlaggedServiceChargeCodeCodes { get; set; }

        /// <summary>Property description goes here.</summary>
        public string LocationFieldId { get; set; }

        /// <summary>Property description goes here.</summary>
        public List<string> ValidLocationCodes { get; set; }

        /// <summary>Property description goes here.</summary>
        public List<string> ValidLocationNames { get; set; }
    }

    /// <summary>Prototype module</summary>
    public class ModProto
    {
        /// <summary>Property description goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Property description goes here.</summary>
        public string Users { get; set; }
    }


    //// <summary>Quick Medication Order module</summary>
    public class ModQMedOrdr
    {
        /// <summary>Property description goes here.</summary>
        public string Mode { get; set; }

        /// <summary>Property description goes here.</summary>
        public string Users { get; set; }

        /// <summary>Property description goes here.</summary>
        public string OrderTypeFieldId { get; set; }

        /// <summary>Property description goes here.</summary>
        public string ValidOrderTypes { get; set; }

        /// <summary>Property description goes here.</summary>
        public string LastOrderScheduleFieldId { get; set; }

        /// <summary>Property description goes here.</summary>
        public string LastOrderScheduleText { get; set; }

        /// <summary>Property description goes here.</summary>
        public string LastScheduledDosage { get; set; }

        /// <summary>Property description goes here.</summary>
        public string PreviousDosePrefix { get; set; }

        /// <summary>Property description goes here.</summary>
        public string PreviousDoseSuffix { get; set; }

        /// <summary>Property description goes here.</summary>
        public string DosageOneFieldId { get; set; }

        /// <summary>Property description goes here.</summary>
        public string CurrentDosage { get; set; }

        /// <summary>Property description goes here.</summary>
        public string DosePercentBoundary { get; set; }

        /// <summary>Property description goes here.</summary>
        public string DoseMilligramBoundary { get; set; }
    }

    /// <summary>Testing module</summary>
    public class ModTesting
    {
        /// <summary>Property description goes here.</summary>
        public string Mode { get; set; }
    }
}