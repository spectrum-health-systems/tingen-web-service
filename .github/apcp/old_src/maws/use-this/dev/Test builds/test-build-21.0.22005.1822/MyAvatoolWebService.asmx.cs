/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 11-8-2021-9:56 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2021 A Pretty Cool Program All rights reserved
 */

/* The entry point for MAWS. The goal with this class is to keep it simple, with only the "GetVersion()", "RunScript()",
 * and "ForceTest()" methods. All other logic will be in a class that corresponds to the MAWS Command (e.g., "InptAdmitDate").
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace MyAvatoolWebService
{
    /// <summary>Entry point for MAWS.</summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {
        // THESE LINES MAY NEED TO BE MODIFIED FOR YOUR ORGANIZATION.

        /* MAWS uses an external configuration file ("MAWS.conf"), and for the most part each MAWS component also has
         * it's own external configuration file (e.g, "Dose.conf"). All configuration  files are located in the same
         * location.
         */
        public string ConfigurationDirectory = $@"C:\MAWS\Configurations\";

        /* MAWS has extensive logging functionality, and all log files are stored in the same location.
        */
        public string LoggingDirectory = $@"C:\MAWS\Logs\";

        /// <summary>Returns the MAWS version.</summary>
        /// <returns>The MAWS version (e.g., "VERSION 1.0").</returns>
        [WebMethod]
        public string GetVersion()
        {
            /* This method is required by myAvatar, so don't remove it.
             *
             * The "VERSION" will always be the target version that is being developed. For example, "VERSION 1.0" during v1.0
             * development, "VERSION 1.1" during v1.1 development.
             *
             * Injecting code into GetVersion() is a Bad Idea, and if you don't comment-out the `ForceTest()` line, MAWS won't work.
             * However I want an easy way to test some functionality on my local machine without having to publish the web service.
             * This functionality will probably be depreciated further down development.
             *
             * Here is how you can test MAWS:
             *  1. Make sure you have the proper testing settings configured in maws.conf
             *  2. Run MAWS
             *  3. Click "GetVersion"
             *  4. Click the "Invoke" button
             */

            /* This line performs specific tests on a local machine. It's a (useful) hack, but needs to be disabled in the production
             * version of MAWS, otherwise the web service will not work correctly. This will probably be removed as testing
             * functionality is added to MAWS.
             */
            ForceTest();

            return "VERSION 1.0";
        }

        /// <summary>Performs an MAWS Request.</summary>
        /// <param name="sentOptionObject">The OptionObject2015 object sent from myAvatar.</param>
        /// <param name="mawsRequest">     The MAWS Request to perform (e.g., "InptAdmitDate-ComparePreAdmitToAdmit")</param>
        /// <returns>A completed OptionObject2015 that MAWS will return to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string mawsRequest)
        {
            /* This method is required by myAvatar, so don't remove it.
             *
             * RunScript() is called when you add a ScriptLink event to a form in myAvatar that makes a MAWS Request.
             *
             * In form designer, the following Scriptlink event:
             *
             *                  Available Scripts         Script Parameter
             *                  ------------------  ----------------------------
             *      Form Load     WebServiceName         WebServiceRequest
             *
             * translates to:
             *
             *      WebServiceName.asmx.cs.RunScript(WebServiceRequest)
             *
             * or, MAWS specific example:
             *
             *      MyAvatoolWebService.asmx.cs.RunScript(InptAdmitDate-ComparePreAdmitToAdmit)
             */

            /* Let's set some things before we process the MAWS Request:
             *
             *   MawsSetting: A dictionary that contains the MAWS configuration settings from MAWS.conf. For more information,
             *                please see the MAWS.conf file.
             *    logSetting: Indicates what type of logging will be used. For more information, please see the MAWS.conf file.
             *  assemblyName: The name of the MAWS assembly.
             *
             *  Once these are setup, log the initial MAWS Request for troubleshooting.
             */
            Dictionary<string, string> MawsSetting = ExternalConfiguration.FromKeyValuePairFile("MAWS.conf");
            var logSetting                         = MawsSetting["Logging"].ToLower();
            var assemblyName                       = Assembly.GetExecutingAssembly().GetName().Name;
            // [LOG]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Initial MAWS Request: {mawsRequest}");

            // TODO - Move this block of code to it's own method, or potentially the Logging logic?
            /* These are the original values of the OptionObject2015 that is sent from myAvatar. Currently this is used for logging
             * purposes, just to verify data from myAvatar is correct. Once we've set them all, we will log them for troubleshooting.
             */
            var sentOptionObjectInitialValues = $"Original sentOptionObject values:{Environment.NewLine}" +
                                                $"sentOptionObject.EntityID        = [{sentOptionObject.EntityID}]{Environment.NewLine}" +
                                                $"sentOptionObject.Facility        = [{sentOptionObject.Facility}]{Environment.NewLine}" +
                                                $"sentOptionObject.NamespaceName   = [{sentOptionObject.NamespaceName}]{Environment.NewLine}" +
                                                $"sentOptionObject.OptionId        = [{sentOptionObject.OptionId}{Environment.NewLine}" +
                                                $"sentOptionObject.ParentNamespace = [{sentOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                                $"sentOptionObject.ServerName      = [{sentOptionObject.ServerName}]{Environment.NewLine}" +
                                                $"sentOptionObject.SystemCode      = [{sentOptionObject.SystemCode}]{Environment.NewLine}" +
                                                $"sentOptionObject.EpisodeNumber   = [{sentOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                                $"sentOptionObject.OptionStaffId   = [{sentOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                                $"sentOptionObject.OptionUserId    = [{sentOptionObject.OptionUserId}]{Environment.NewLine}" +
                                                $"sentOptionObject.ErrorCode       = [{sentOptionObject.ErrorCode}]{Environment.NewLine}" +
                                                $"sentOptionObject.ErrorMesg       = [{sentOptionObject.ErrorMesg}]";
            // [LOG]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObjectInitialValues);

            /* Get the command component of the MAWS request (e.g., "InptAdmitDate"), then log it for troubleshooting purposes.
             */
            var mawsCommand = RequestSyntaxEngine.RequestComponent.GetCommand(mawsRequest);
            // [LOG]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"Initial MAWS Command: {mawsCommand}");

            /* Initialize a new OptionObject2015. This is the OptionObject2015 object that will be updates/modified by MAWS, then
             * eventually be returned to Avatar.
             */
            var completedOptionObject = new OptionObject2015();


            // TODO - Move this switch statement to it's own method?
            /* This switch statement calls different classes/methods, depending on the MAWS Request command component.
             */
            switch(mawsCommand)
            {
                case "inptadmitdate":
                    /* For MAWS v1.1
                     * This will need to be tested, and match the syntax of commands released with v1.0.
                     */
                    //LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"switch(mawsCommand) case: InptAdmitDate [{mawsCommand}]");
                    //completedOptionObject = sentOptionObject;
                    //completedOptionObject = InptAdmitDate.Execute.Action(sentOptionObject, mawsRequest);
                    break;

                case "dose":
                    /* 1. Log the mawsCommand ("dose") for troubleshooting.
                     * 2. Pass the original OptionObject2015 and entire mawsRequest to the Dose.cs class, and put the results into
                     *    a new OptionObject2015 object that only contains the updated/modified values.
                     * 3. Create a variable for the original OptionObject2015 values, and log for troubleshooting.
                     */
                    // [LOG]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"switch(mawsCommand) case: Dose [{mawsCommand}]");

                    completedOptionObject = Dose.Execute.Action(sentOptionObject, mawsRequest);

                    // TODO - Is this needed? Seems to be redundant with the logging at the beginning of this method. At a minimum,
                    //        need to rename variable to be more descriptive.
                    var values = $"Original sentOptionObject values:{Environment.NewLine}" +
                                 $"sentOptionObject.EntityID        = [{completedOptionObject.EntityID}]{Environment.NewLine}" +
                                 $"sentOptionObject.Facility        = [{completedOptionObject.Facility}]{Environment.NewLine}" +
                                 $"sentOptionObject.NamespaceName   = [{completedOptionObject.NamespaceName}]{Environment.NewLine}" +
                                 $"sentOptionObject.OptionId        = [{completedOptionObject.OptionId}{Environment.NewLine}" +
                                 $"sentOptionObject.ParentNamespace = [{completedOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                 $"sentOptionObject.ServerName      = [{completedOptionObject.ServerName}]{Environment.NewLine}" +
                                 $"sentOptionObject.SystemCode      = [{completedOptionObject.SystemCode}]{Environment.NewLine}" +
                                 $"sentOptionObject.EpisodeNumber   = [{completedOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                 $"sentOptionObject.OptionStaffId   = [{completedOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                 $"sentOptionObject.OptionUserId    = [{completedOptionObject.OptionUserId}]{Environment.NewLine}" +
                                 $"sentOptionObject.ErrorCode       = [{completedOptionObject.ErrorCode}]{Environment.NewLine}" +
                                 $"sentOptionObject.ErrorMesg       = [{completedOptionObject.ErrorMesg}]";
                    // [LOG]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, values);
                    break;

                case "newdevelopment":
                    /* For MAWS v1.1
                     * This will need to be tested, and match the syntax of commands released with v1.0.
                     */
                    //LogEvent.Timestamped(logSetting, "TRACE", assemblyName, $"switch(mawsCommand) case: NewDevelopment [{mawsCommand}]");
                    //completedOptionObject = sentOptionObject;
                    //completedOptionObject = NewDevelopment.Execute.Action(sentOptionObject, mawsRequest);
                    break;

                default:
                    /* In the event that an invalid MAWS command is passed:
                     * 1. Log the error
                     * 2. Complete the completedOptionObject by copying the sent data over, so we are essentially returning the
                     * original information to myAvatar.
                     */
                    // TODO - Check the error type that is returned.
                    LogEvent.Timestamped(logSetting, "ERROR", assemblyName, $"Invalid MAWS Command: \"{mawsCommand}\".");
                    completedOptionObject = sentOptionObject;
                    break;
            }

            /* This line is used for local testing, and should be commented out in production. This can most likely be removed once
             * all MAWS Command cases have been completed.
             */
            //completedOptionObject = new OptionObject2015();

            // TODO - Should completing the OptionObject2015 be moved here, instead of outside classes?

            return completedOptionObject;
        }

        /// <summary>Force local functionality tests.</summary>
        private void ForceTest()
        {
            /* ForceTest() is here because otherwise it's a pain to get working, but eventually I would like to move it into its own
             * class, or probably remove it entirely and rely on logging functionality. This method isn't heavily commented, since it
             * is for testing purposes only.
             */
            Dictionary<string, string> MawsSetting = ExternalConfiguration.FromKeyValuePairFile("MAWS.conf");
            var logSetting                         = MawsSetting["Logging"].ToLower();
            var assemblyName                       = Assembly.GetExecutingAssembly().GetName().Name;
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Forcing MAWS functionality tests.");

            // Trace commands/actions/options.
            var emptyOptionObject = new OptionObject2015();
            _ = RunScript(emptyOptionObject, "InptAdmitDate-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RunScript() using MAWS Request \"InptAdmitDate-Action-Option\"");
            _ = RunScript(emptyOptionObject, "Dose-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RunScript() using MAWS Request \"Dose-Action-Option\"");
            _ = RunScript(emptyOptionObject, "NewDevelopment-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RunScript() using MAWS Request \"NewDevelopment-Action-Option\"");
            _ = RunScript(emptyOptionObject, "Fake-Action-Option");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RunScript() using MAWS Request \"Fake-Action-Option\"");

            // Test against an partially initialized OptionObject.
            var testInptAdmitDateOptionObject= new OptionObject2015
            {
                ErrorCode = 0,
                ErrorMesg = "",
            };
            _ = RunScript(testInptAdmitDateOptionObject, "InptAdmitDate-ComparePreAdmitToAdmit");
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RunScript() using MAWS Request \"InptAdmitDate-ComparePreAdmitToAdmit\"");

            // Test RequestSyntaxEngine functionality.
            RequestSyntaxEngine.TestFunctionality.Force();
            LogEvent.Timestamped(logSetting, "TEST", assemblyName, "Force test: RequestSyntaxEngine.");
        }
    }
}

/* TODO
 * Potentially have this be the only project that is built using the .NET Framework, with the other projects (e.g., "Dose") built in
 * .NET Core.
 */