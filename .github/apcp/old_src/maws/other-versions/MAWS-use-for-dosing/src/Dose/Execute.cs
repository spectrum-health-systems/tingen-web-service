/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Execute.cs
 * UPDATED: 1-15-2022-2:50 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Each of the MAWS Request projects contains an "Execute" class, which is the entry point for that particular request,
 * determines what should be done with the MAWS Request (e.g., actions to perform, etc).
 *
 * This Execute class is for the Dose MAWS Request.
 */

using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace Dose
{
    public class Execute
    {
        public static Dictionary<string, string> DoseSetting;

        /// <summary>Executes a MAWS action for the Dose command.</summary>
        /// <param name="sentOptionObject">The original OptionObject2015 sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS Request string.</param>
        /// <returns>A completed OptionObject2015.</returns>
        public static OptionObject2015 Action(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            // TODO - Break this setup block into it's own method?
            /*
             */
            Dictionary<string, string>  doseSetting = ExternalConfiguration.FromKeyValuePairFile("Dose.conf");
            var logSetting                          = doseSetting["LogSetting"].ToLower();
            var assemblyName                        = Assembly.GetExecutingAssembly().GetName().Name;
            var mawsAction                          = RequestSyntaxEngine.RequestComponent.MawsAction(mawsRequest, sentOptionObject.OptionUserId);
            var mawsOption                          = RequestSyntaxEngine.RequestComponent.MawsOptions(mawsRequest, sentOptionObject.OptionUserId);

            //[TRACE LOG] Entering Execute.DoseSetting()
            var maintenanceConfirmDirectoryTraceMsg = $"Entering Execute.DoseSetting()";
            LogEvent.Timestamped("trace", "TRACE", assemblyName, sentOptionObject.OptionUserId, maintenanceConfirmDirectoryTraceMsg);

            //[DEBUG LOG] Dose Action[-Option]
            var doseActionOptionDebugMsg = $"Execute Dose Action: {mawsAction} Option: {mawsOption}]";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, doseActionOptionDebugMsg);

            var doseOptionObject = new OptionObject2015();

            // TODO - Break this switch statement into its own method?
            /*
             */
            switch(mawsAction)
            {
                case "verifypercentage":
                    /*
                     */
                    // [LOG]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId, $"Executing Dose Action: VerifyPercentage [{mawsAction}] [Option: {mawsOption}]");
                    doseOptionObject = Compare.Percentage(sentOptionObject, doseSetting);
                    break;

                default:
                    /* In the event that an invalid Dose command action is passed, log the error and exit gracefully.
                     */
                    // [LOG]
                    LogEvent.Timestamped(logSetting, "ERROR", assemblyName, sentOptionObject.OptionUserId, $"Invalid Dose Action: \"{mawsAction}\"");
                    break;
            }

            /*
             */
            return doseOptionObject;
        }
    }
}