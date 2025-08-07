/* PROJECT: RequestSyntaxEngine (https://github.com/aprettycoolprogram/RequestSyntaxEngine)
 *    FILE: RequestSyntaxEngine.TestFunctionality.cs
 * UPDATED: 1-15-2022-6:10 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Tests RequestSyntaxEngine functionality.
 *
 * Logging is done differently in this method, as everything is hard-coded.
 *
 * This can be removed when MyAvatoolWebService.ForceTest() is depreciated.
 */

using System;
using System.Reflection;
using Utility;

namespace RequestSyntaxEngine
{
    public class TestFunctionality
    {
        /// <summary>
        /// Test RequestSyntaxEngine functionality.
        /// </summary>
        public static void Force()
        {
            /* We need the Assembly Name for log files.
             */
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

            //[TRACE LOG] Entering RequestSyntaxEngine.TestFunctionality()
            var requestSyntaxEngineTestingTraceMsg = $"Entering RequestSyntaxEngine.TestFunctionality()";
            LogEvent.Timestamped("trace", "TRACE", assemblyName, "_MAWS",requestSyntaxEngineTestingTraceMsg);

            /* This is a fake MAWS Request.
             */
            var mawsRequest = "ThisIsACommand-ThisIsAnAction-Testing-ShouldNotAppear";

            //[DEBUG LOG] Entering RequestSyntaxEngine.TestFunctionality()
            var requestSyntaxEngineTestingDebugMsg  = $"MAWS Request: {mawsRequest}{Environment.NewLine}" +
                                                      $"MAWS Command: {RequestComponent.MawsCommand(mawsRequest, "_MAWS")}{Environment.NewLine}" +
                                                      $" MAWS Action: {RequestComponent.MawsAction(mawsRequest, "_MAWS")}{Environment.NewLine}" +
                                                      $" MAWS Option: {RequestComponent.MawsOptions(mawsRequest, "_MAWS")}";
            LogEvent.Timestamped("debug", "DEBUG", Assembly.GetExecutingAssembly().GetName().Name, "_MAWS", requestSyntaxEngineTestingDebugMsg);
        }
    }
}