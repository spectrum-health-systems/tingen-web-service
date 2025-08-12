/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 1-15-2022-7:00 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* The entry point for MAWS.
 * 
 * The goal with this class is to keep it simple, with only the "GetVersion()", "RunScript()" methods. All other logic
 * will be in a class that corresponds to the MAWS Command (e.g., "Dose", "InptAdmitDate").
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace MyAvatoolWebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {
        /* Initialize MAWS configuration and log files locations. You may need to modify these for your organization.
         */
        public string ConfigurationDirectory = $@"C:\MAWS\Configurations\";
        public string LoggingDirectory       = $@"C:\MAWS\Logs\";

        /// <summary>
        /// Returns the MAWS version.
        /// </summary>
        /// <returns>The MAWS version (e.g., "VERSION 1.0").</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* The "VERSION" will always be the target version that is being developed.
             *
             * Injecting code into GetVersion() is a Bad Idea, and if you don't comment-out the `ForceTest()` line, MAWS won't work. However I want an easy way
             * to test some functionality on my local machine without having to publish the web service. This functionality will probably be depreciated further
             * down development.
             *
             * Here is how you can test MAWS:
             *  1. Make sure you have the proper testing settings configured in maws.conf
             *  2. Run MAWS
             *  3. Click "GetVersion"
             *  4. Click the "Invoke" button
             */
            //ForceTest();

            return "VERSION 1.0";
        }

        /// <summary>
        /// Executes a MAWS Request.
        /// </summary>
        /// <param name="originalOptionObject">The original data sent from myAvatar.</param>
        /// <param name="mawsRequest">         The MAWS Request to perform (e.g., "InptAdmitDate-ComparePreAdmitToAdmit")</param>
        /// <returns>A completed OptionObject2015 that MAWS will return to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 originalOptionObject, string mawsRequest)
        {
            /* Called from Avatar via a ScriptLink event
             */

            /* Get the MAWS configuration settings, and setup logging functionality.
             */
            Dictionary<string, string> MawsSetting = ExternalConfiguration.FromKeyValuePairFile("MAWS.conf");
            var logSetting                         = MawsSetting["LogSetting"].ToLower();
            var mawsStatus                         = MawsSetting["MawsStatus"].ToLower();
            var assemblyName                       = Assembly.GetExecutingAssembly().GetName().Name;
            var debugMessage                       = "";
            var errorMessage                       = "";
            // [TRACE]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, originalOptionObject.OptionUserId);

            // Keep just in case.

            /* Initialize a new OptionObject2015, which will be modified by MAWS and eventually returned to Avatar. We
             * do this here in the event that MAWS is disabled, so the original OptionObject data can be returned.
             */
            var finalOptionObject = new OptionObject2015();
            // [DEBUG]
            debugMessage = $"Initial values for the \"finalOptionObject\":{Environment.NewLine}" +
                           $"{Environment.NewLine}" +
                           $"           EntityID: {finalOptionObject.EntityID}{Environment.NewLine}" +
                           $"           Facility: {finalOptionObject.Facility}{Environment.NewLine}" +
                           $"      NamespaceName: {finalOptionObject.NamespaceName}{Environment.NewLine}" +
                           $"           OptionId: {finalOptionObject.OptionId}{Environment.NewLine}" +
                           $"    ParentNamespace: {finalOptionObject.ParentNamespace}{Environment.NewLine}" +
                           $"         ServerName: {finalOptionObject.ServerName}{Environment.NewLine}" +
                           $"         SystemCode: {finalOptionObject.SystemCode}{Environment.NewLine}" +
                           $"      EpisodeNumber: {finalOptionObject.EpisodeNumber}{Environment.NewLine}" +
                           $"      OptionStaffId: {finalOptionObject.OptionStaffId}{Environment.NewLine}" +
                           $"       OptionUserId: {finalOptionObject.OptionUserId}{Environment.NewLine}" +
                           $"          ErrorCode: {finalOptionObject.ErrorCode}{Environment.NewLine}" +
                           $"          ErrorMesg: {finalOptionObject.ErrorMesg}";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, originalOptionObject.OptionUserId, debugMessage);

            if(mawsStatus == "enabled")
            {
                /* Initialize a new OptionObject2015, which will be modified by MAWS and eventually returned to Avatar.
                 */
                //var finalOptionObject = new OptionObject2015();
                // [DEBUG]
                debugMessage = $"MAWS is: {mawsStatus}{Environment.NewLine}" +
                               $"{Environment.NewLine}" +
                               $"The initial MAWS Request is: {mawsRequest}{Environment.NewLine}" +
                               $"{Environment.NewLine}" +
                               $"myAvatar data sent via the \"originalOptionObject\"{Environment.NewLine}" +
                               $"{Environment.NewLine}" +
                               $"       EntityID: {originalOptionObject.EntityID}{Environment.NewLine}" +
                               $"       Facility: {originalOptionObject.Facility}{Environment.NewLine}" +
                               $"  NamespaceName: {originalOptionObject.NamespaceName}{Environment.NewLine}" +
                               $"       OptionId: {originalOptionObject.OptionId}{Environment.NewLine}" +
                               $"ParentNamespace: {originalOptionObject.ParentNamespace}{Environment.NewLine}" +
                               $"     ServerName: {originalOptionObject.ServerName}{Environment.NewLine}" +
                               $"     SystemCode: {originalOptionObject.SystemCode}{Environment.NewLine}" +
                               $"  EpisodeNumber: {originalOptionObject.EpisodeNumber}{Environment.NewLine}" +
                               $"  OptionStaffId: {originalOptionObject.OptionStaffId}{Environment.NewLine}" +
                               $"   OptionUserId: {originalOptionObject.OptionUserId}{Environment.NewLine}" +
                               $"      ErrorCode: {originalOptionObject.ErrorCode}{Environment.NewLine}" +
                               $"      ErrorMesg: {originalOptionObject.ErrorMesg}" +
                               $"{Environment.NewLine}" +
                               $"Initial values for the \"finalOptionObject\":{Environment.NewLine}" +
                               $"       EntityID: {finalOptionObject.EntityID}{Environment.NewLine}" +
                               $"       Facility: {finalOptionObject.Facility}{Environment.NewLine}" +
                               $"  NamespaceName: {finalOptionObject.NamespaceName}{Environment.NewLine}" +
                               $"       OptionId: {finalOptionObject.OptionId}{Environment.NewLine}" +
                               $"ParentNamespace: {finalOptionObject.ParentNamespace}{Environment.NewLine}" +
                               $"     ServerName: {finalOptionObject.ServerName}{Environment.NewLine}" +
                               $"     SystemCode: {finalOptionObject.SystemCode}{Environment.NewLine}" +
                               $"  EpisodeNumber: {finalOptionObject.EpisodeNumber}{Environment.NewLine}" +
                               $"  OptionStaffId: {finalOptionObject.OptionStaffId}{Environment.NewLine}" +
                               $"   OptionUserId: {finalOptionObject.OptionUserId}{Environment.NewLine}" +
                               $"      ErrorCode: {finalOptionObject.ErrorCode}{Environment.NewLine}" +
                               $"      ErrorMesg: {finalOptionObject.ErrorMesg}";
                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, originalOptionObject.OptionUserId, debugMessage);

                /* Get the MAWS command.
                 */
                var mawsCommand = RequestSyntaxEngine.RequestComponent.MawsCommand(mawsRequest, originalOptionObject.OptionUserId);
                // [DEBUG]
                debugMessage = $"MAWS Command: {mawsCommand}";
                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, originalOptionObject.OptionUserId, debugMessage);

                /* Main switch statement that is the brains of the operation.
                 */
                switch(mawsCommand)
                {
                    case "dose":
                        // [TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, originalOptionObject.OptionUserId);

                        /* Pass the sentOptionObject and the MAWS Request to the Dose.Execute method, which will determine
                         * what needs to be done to the completedOptionObject.
                         */
                        finalOptionObject = Dose.Execute.Action(originalOptionObject, mawsRequest);
                        // [DEBUG]
                        debugMessage = $"Values returned from the \"Dose\" command:{Environment.NewLine}" +
                                       $"       EntityID: {finalOptionObject.EntityID}{Environment.NewLine}" +
                                       $"       Facility: {finalOptionObject.Facility}{Environment.NewLine}" +
                                       $"  NamespaceName: {finalOptionObject.NamespaceName}{Environment.NewLine}" +
                                       $"       OptionId: {finalOptionObject.OptionId}{Environment.NewLine}" +
                                       $"ParentNamespace: {finalOptionObject.ParentNamespace}{Environment.NewLine}" +
                                       $"     ServerName: {finalOptionObject.ServerName}{Environment.NewLine}" +
                                       $"     SystemCode: {finalOptionObject.SystemCode}{Environment.NewLine}" +
                                       $"  EpisodeNumber: {finalOptionObject.EpisodeNumber}{Environment.NewLine}" +
                                       $"  OptionStaffId: {finalOptionObject.OptionStaffId}{Environment.NewLine}" +
                                       $"   OptionUserId: {finalOptionObject.OptionUserId}{Environment.NewLine}" +
                                       $"      ErrorCode: {finalOptionObject.ErrorCode}{Environment.NewLine}" +
                                       $"      ErrorMesg: {finalOptionObject.ErrorMesg}";
                        LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, originalOptionObject.OptionUserId, debugMessage);

                        break;

                    default:
                        // [TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, originalOptionObject.OptionUserId);

                        /* If an invalid MAWS Command is passed, return the original data to Avatar.
                         */
                        finalOptionObject = originalOptionObject;
                        // [ERROR]
                        errorMessage = $"Invalid MAWS Command: {mawsCommand}";
                        LogEvent.Timestamped(logSetting, "ERROR", assemblyName, originalOptionObject.OptionUserId, errorMessage);

                        break;
                }

                //return finalOptionObject;
            }
            else
            {
                finalOptionObject = originalOptionObject;
                //return originalOptionObject;
            }

            // Keep in case the above doesn't work.

            // [DEBUG LOG] Final values of the returned OptionObject2015, to make sure the values are correct.
            var finalValuesDebugMsg = $"These are the final values for the completedOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                          $"EntityID        = [{finalOptionObject.EntityID}]{Environment.NewLine}" +
                                          $"Facility        = [{finalOptionObject.Facility}]{Environment.NewLine}" +
                                          $"NamespaceName   = [{finalOptionObject.NamespaceName}]{Environment.NewLine}" +
                                          $"OptionId        = [{finalOptionObject.OptionId}{Environment.NewLine}" +
                                          $"ParentNamespace = [{finalOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                          $"ServerName      = [{finalOptionObject.ServerName}]{Environment.NewLine}" +
                                          $"SystemCode      = [{finalOptionObject.SystemCode}]{Environment.NewLine}" +
                                          $"EpisodeNumber   = [{finalOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                          $"OptionStaffId   = [{finalOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                          $"OptionUserId    = [{finalOptionObject.OptionUserId}]{Environment.NewLine}" +
                                          $"ErrorCode       = [{finalOptionObject.ErrorCode}]{Environment.NewLine}" +
                                          $"ErrorMesg       = [{finalOptionObject.ErrorMesg}]";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, originalOptionObject.OptionUserId, finalValuesDebugMsg);

            /* That's all, folks!
             */
            return finalOptionObject;
        }

        /// <summary>Force local functionality tests.</summary>
        private void ForceTest()
        {
            /* ForceTest() is here because otherwise it's a pain to get working, but eventually I would like to move it into its own
             * class, or probably remove it entirely and rely on logging functionality. This method isn't heavily commented, since it
             * is for testing purposes only.
             */
            Dictionary<string, string> MawsSetting = ExternalConfiguration.FromKeyValuePairFile("MAWS.conf");
            var logSetting                         = MawsSetting["LogSetting"].ToLower();
            var assemblyName                       = Assembly.GetExecutingAssembly().GetName().Name;
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force testing.");

            // Trace commands/actions/options.
            var emptyOptionObject = new OptionObject2015();
            _ = RunScript(emptyOptionObject, "InptAdmitDate-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RunScript() using MAWS Request \"InptAdmitDate-Action-Option\"");
            _ = RunScript(emptyOptionObject, "Dose-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RunScript() using MAWS Request \"Dose-Action-Option\"");
            _ = RunScript(emptyOptionObject, "NewDevelopment-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RunScript() using MAWS Request \"NewDevelopment-Action-Option\"");
            _ = RunScript(emptyOptionObject, "Fake-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RunScript() using MAWS Request \"Fake-Action-Option\"");

            // Test against an partially initialized OptionObject.
            var testInptAdmitDateOptionObject= new OptionObject2015
            {
                ErrorCode = 0,
                ErrorMesg = "",
            };
            _ = RunScript(testInptAdmitDateOptionObject, "InptAdmitDate-ComparePreAdmitToAdmit");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RunScript() using MAWS Request \"InptAdmitDate-ComparePreAdmitToAdmit\"");

            // Test RequestSyntaxEngine functionality.
            RequestSyntaxEngine.TestFunctionality.Force();
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "_MAWS", "Force test: RequestSyntaxEngine.");
        }
    }
}

/* TODO
 * Potentially have this be the only project that is built using the .NET Framework, with the other projects (e.g., "Dose") built in
 * .NET Core.
 */