/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.RequestComponent.cs
 * UPDATED: 1-11-2022-3:33 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Parses and returns various components of a MAWS Request.
 *
 * Logging is done differently in this method, as everything is hard-coded.
 */

using System.Reflection;
using Utility;

namespace RequestSyntaxEngine
{
    public class RequestComponent
    {
        /// <summary>
        /// Returns the MAWS Request command.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "InptAdmitDate").</returns>
        public static string MawsCommand(string mawsRequest, string userName)
        {
            /* We need the Assembly Name for log files.
             */
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            //[TRACE LOG] Entering RequestSyntaxEngine.RequestComponent.MawsCommand()
            var requestMawsCommandTraceMsg = $"Entering RequestSyntaxEngine.RequestComponent.MawsCommand()";
            LogEvent.Timestamped("trace", "TRACE", assemblyName, userName, requestMawsCommandTraceMsg);

            /* Parse the MAWS Command by splitting the MAWS Request at the "-", and taking the first element.
             */
            var mawsCommand = mawsRequest.Split('-')[0].ToLower();

            //[DEBUG LOG] The MAWS Command.
            var requestMawsCommandDebugMsg = $"MAWS Command: {mawsRequest}";
            LogEvent.Timestamped("debug", "DEBUG", assemblyName, userName, requestMawsCommandDebugMsg);

            return mawsCommand;
        }

        /// <summary>
        /// Returns the MAWS Request action.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "ComparePreAdmitToAdmit").</returns>
        public static string MawsAction(string mawsRequest, string userName)
        {
            /* We need the Assembly Name for log files.
             */
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            //[TRACE LOG] Entering RequestSyntaxEngine.RequestComponent.MawsAction()
            var requestMawsActionTraceMsg = $"Entering RequestSyntaxEngine.RequestComponent.MawsAction()";
            LogEvent.Timestamped("trace", "TRACE", assemblyName, userName, requestMawsActionTraceMsg);

            /* Parse the MAWS Command by splitting the MAWS Request at the "-", and taking the second element.
             */
            var mawsAction = mawsRequest.Split('-')[1].ToLower();

            //[DEBUG LOG] The MAWS Action.
            var requestMawsActionDebugMsg = $"MAWS Action: {mawsRequest}";
            LogEvent.Timestamped("debug", "DEBUG", assemblyName, userName, requestMawsActionDebugMsg);

            return mawsAction;
        }

        /// <summary>
        /// Returns the MAWS Request option.
        /// </summary>
        /// <param name="mawsRequest">The MAWS Request.</param>
        /// <returns>The command component of the MAWS Request (e.g., "Testing") ["none"].</returns>
        public static string MawsOptions(string mawsRequest, string userName)
        {
            /* We need the Assembly Name for log files.
             */
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            //[TRACE LOG] Entering RequestSyntaxEngine.RequestComponent.MawsOptions()
            var requestMawsOptionsTraceMsg = $"Entering RequestSyntaxEngine.RequestComponent.MawsOptions()";
            LogEvent.Timestamped("trace", "TRACE", assemblyName, userName, requestMawsOptionsTraceMsg);


            /* MAWS Options are after the Command and Action.
             *
             * < More info soon>
             */
            var mawsOptions = mawsRequest.Split('-').Length >= 3
                ? mawsRequest.Split('-')[2].ToLower()
                : "none";

            //[DEBUG LOG] The MAWS Options.
            var requestMawsOptionsDebugMsg = $"MAWS Options: {mawsOptions}";
            LogEvent.Timestamped("debug", "DEBUG", assemblyName, userName, requestMawsOptionsDebugMsg);

            return mawsOptions;
        }
    }
}