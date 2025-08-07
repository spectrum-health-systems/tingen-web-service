/* PROJECT: Dose (https://github.com/aprettycoolprogram/Dose)
 *    FILE: Dose.Compare.cs
 * UPDATED: 1-15-2022-6:29 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Logic for the Compare action of the Dose command.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace Dose
{
    internal class Compare
    {
        /// <summary>Compare the dose increase/decrease percentage.</summary>
        /// <param name="sentOptionObject"></param>
        /// <param name="doseSetting"></param>
        /// <returns>A completed OptionObject2015</returns>
        public static OptionObject2015 Percentage(OptionObject2015 sentOptionObject, Dictionary<string, string> doseSetting)
        {
            /* Get the information we need to create logfiles.
             */
            var logSetting   = doseSetting["LogSetting"].ToLower();
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId, "Location: Dose.Verify.Percentage()");
            // [TRACE]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

            /* Setup stuff
             */
            const string dosageOneFieldId          = "107";
            const string orderTypeFieldId          = "121";
            const string lastOrderScheduleFieldId  = "142";
            var currentDose                        = "0.0";
            var orderType                          = "0";
            var lastOrderScheduleText              = "";
            var foundDosageOneFieldId              = false;
            var foundOrderTypeFieldId              = false;
            var foundLastOrderScheduleFieldId      = false;
            var foundAllRequiredFieldIds           = false;
            // [DEBUG]
            var initializeDoseComparePercentageDebugMsg                      = $"These are the initial values for Dose.Compare.Percentage():{Environment.NewLine}{Environment.NewLine}" +
                                            $"dosageOneFieldId               = [{dosageOneFieldId}]{Environment.NewLine}" +
                                            $"orderTypeFieldId               = [{orderTypeFieldId}]{Environment.NewLine}" +
                                            $"lastOrderScheduleFieldId       = [{lastOrderScheduleFieldId}]{Environment.NewLine}" +
                                            $"currentDose                    = [{currentDose}{Environment.NewLine}" +
                                            $"orderType                      = [{orderType}]{Environment.NewLine}" +
                                            $"lastOrderScheduleText          = [{lastOrderScheduleText}]{Environment.NewLine}" +
                                            $"foundDosageOneFieldId          = [{foundDosageOneFieldId}]{Environment.NewLine}" +
                                            $"foundOrderTypeFieldId          = [{foundOrderTypeFieldId}]{Environment.NewLine}" +
                                            $"foundLastOrderScheduleFieldId  = [{foundLastOrderScheduleFieldId}]{Environment.NewLine}";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, initializeDoseComparePercentageDebugMsg);

            /* Initialize a blank doseOptionObject, where we will put everything.
             */
            var doseOptionObject = new OptionObject2015
            {
                ErrorCode = 0,
                ErrorMesg = ""
            };
            // [DEBUG]
            var sentAndDoseOptionObjectValuesDebugMsg      = $"These are the initial values from the sentOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{sentOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{sentOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{sentOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{sentOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{sentOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{sentOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{sentOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{sentOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{sentOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{sentOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{sentOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{sentOptionObject.ErrorMesg}]{Environment.NewLine}" +
                                            $"{ Environment.NewLine}" +
                                            $"These are the initial values from the workingOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{doseOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{doseOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{doseOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{doseOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{doseOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{doseOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{doseOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{doseOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{doseOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{doseOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{doseOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{doseOptionObject.ErrorMesg}]{Environment.NewLine}{ Environment.NewLine}";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, sentAndDoseOptionObjectValuesDebugMsg);

            /* We will loop through each field of every form in sentOptionObject2, and do something special if we land
             * on the "dosageOneFieldId" or "lastOrderScheduledFieldId".
             */
            // TODO - Should the foreach/switch blocks be moved to another method?
            foreach(FormObject form in sentOptionObject.Forms)
            {
                // [TRACE]
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                foreach(FieldObject field in form.CurrentRow.Fields)
                {
                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    /* Entering this loop doesn't trigger a logfile to be written, otherwise there would be tons of useless logs. Each of the important fields
                     * triggers a logfile, so if you don't see any of those, then you know something is wrong. Eventually we might want to trigger a logfile
                     * here, but only for the first time the loop is entered.
                     */
                    switch(field.FieldNumber)
                    {
                        case dosageOneFieldId:
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            /* The dose field is required, but since MAWS intercepts the form submission, we need to confirm that this field isn't empty,
                             * otherwise MAWS will throw an error.
                             */
                            if(field.FieldValue == "")
                            {
                                currentDose = "";
                                // [DEBUG]
                                var dosageOneIsBlankDebugMsg = $"dosageOneFieldId found, value is: {currentDose}.";
                                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, dosageOneIsBlankDebugMsg);
                            }
                            else
                            {
                                currentDose = field.FieldValue;
                                // [DEBUG]
                                var dosageOneHasValueDebugMsg = $"dosageOneFieldId found, value is: {currentDose}.";
                                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, dosageOneHasValueDebugMsg);
                            }

                            foundDosageOneFieldId = true;
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            break;

                        case orderTypeFieldId:
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            orderType = field.FieldValue;
                            // [DEBUG]
                            var orderTypeFieldDebugMsg = $"orderTypeFieldId found, value is: {orderType}.";

                            foundOrderTypeFieldId = true;
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            break;

                        case lastOrderScheduleFieldId:
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            lastOrderScheduleText = field.FieldValue;
                            // [DEBUG]
                            var lastOrderScheduleTextDebugMsg = $"orderTypeFieldId found, value is: {lastOrderScheduleText}.";
                            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, lastOrderScheduleTextDebugMsg);

                            foundLastOrderScheduleFieldId = true;
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            break;

                        default:
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            break;
                    }

                    /* If we found everything, stop
                    */
                    if(foundDosageOneFieldId && foundLastOrderScheduleFieldId && foundOrderTypeFieldId)
                    {
                        // [TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                        foundAllRequiredFieldIds = true;
                        //[DEBUG]
                        var foundAllFieldsDebugMsg = $"Found the following fields:{Environment.NewLine}{Environment.NewLine}" +
                                                          $"dosageOneFieldId found: {foundDosageOneFieldId}, value is: {currentDose}.]{Environment.NewLine}" +
                                                          $"orderTypeFieldId found: {foundOrderTypeFieldId}, value is: {orderType}.]{Environment.NewLine}" +
                                                          $"lastOrderScheduleFieldId found: {foundLastOrderScheduleFieldId}, value is: {lastOrderScheduleText}.]{Environment.NewLine}{Environment.NewLine}" +
                                                          $"Setting foundAllRequiredFields to {foundAllRequiredFieldIds}.{Environment.NewLine}{Environment.NewLine}" +
                                                          $"Exiting foreach...Field loop.";
                        LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, foundAllFieldsDebugMsg);

                        break;
                    }

                }

                /*
                 */
                if(foundAllRequiredFieldIds)
                {
                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    // [DEBUG]
                    var finishedSearchingFormsDebugMsg = $"All required fields foutd: {foundAllRequiredFieldIds}.{Environment.NewLine}{Environment.NewLine}" +
                                                         $"Exiting foreach...Form loop.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, finishedSearchingFormsDebugMsg);

                    break;
                }
            }

            /* Init the error message.
             */
            var errMsgBody = "";
            //[DEBUG]
            var initializeErrorMsgBodyDebugMsg = $"Initialized error message body to: {errMsgBody}.";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, initializeErrorMsgBodyDebugMsg);

            /* This whole, ugly block of code only executes if the orderType is "Recurring". Other orderTypes will be added in future versions.
             */
            if(orderType == "4")
            {
                // [TRACE]
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                // [DEBUG]
                var isValidOrderTypeTraceMsg = $"The orderType is valid ({orderType}).";
                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, isValidOrderTypeTraceMsg);

                /*1. Parse the lastOrderScheduledText and get the milligrams
                 * 2. Check what the percentage difference between the current does and the last dose
                 */
                var previousDosagePrefix = doseSetting["PreviousDosagePrefix"];
                var previousDosageSuffix = doseSetting["PreviousDosageSuffix"];
                // [DEBUG]
                var initializePreviousDoseInfoDebugMsg = $"Initialized previous dose prefix as: { previousDosagePrefix}.{Environment.NewLine}" +
                                                         $"Initialized previous dose suffix as: { previousDosageSuffix}.{Environment.NewLine}" +
                                                         $"orderType is: {orderType}.";
                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, initializePreviousDoseInfoDebugMsg);

                /* Before we continue, we need to:
                 *  1. Make sure there is a current dose (it's not blank)
                 *  2. Get the previous dose. if there is one
                 */
                if(currentDose == "")
                {
                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    doseOptionObject.ErrorCode = 1;
                    doseOptionObject.ErrorMesg = $"WARNING!\n\nDose missing!!\n\nFix it.";
                    // [DEBUG]
                    var currentDoseBlankDebugMsg = $"A current dose does not exist [currentDose = {currentDose}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, currentDoseBlankDebugMsg);
                }
                else if(lastOrderScheduleText == "")
                {
                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    /* If there isn't a previous dose, give the user the option to go back and fix that,
                     */
                    doseOptionObject.ErrorCode = 4;
                    doseOptionObject.ErrorMesg = $"WARNING!\n\nIt has been detected that there has not previously been an order in this episode.\n\nAre you sure you want to submit?";

                    // [DEBUG]
                    var previousDoseDoesntExistDebugMsg = $"A previous dose does not exist [lastOrderScheduleText = {lastOrderScheduleText}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, previousDoseDoesntExistDebugMsg);
                }
                else
                {
                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    /* Get the text in the last order box, and split it into seperate lines
                     */
                    var lastOrderedScheduledLines = lastOrderScheduleText.Split('\n');
                    var lastScheduledDosage     = "";
                    // [DEBUG]
                    var cleanPreviousOrderTextDebugMsg = $"The previous order text is: {lastOrderScheduleText}{Environment.NewLine}{Environment.NewLine}" +
                                                         $"Previous order text split into lines: {lastOrderedScheduledLines}{Environment.NewLine}{Environment.NewLine}" +
                                                         $"lastScheduledDosage set to: {lastScheduledDosage}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, cleanPreviousOrderTextDebugMsg);


                    /* Go throuh each line until we find one with both the prefix and suffix.
                    */
                    foreach(var line in lastOrderedScheduledLines)
                    {
                        // [TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                        if(line.Contains(previousDosagePrefix) && line.Contains(previousDosageSuffix))
                        {
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            lastScheduledDosage = line.Replace($"{previousDosagePrefix}", "");
                            // [DEBUG LOG]
                            var lastScheduledDosageWithoutPrefixDebugMsg = $"Previous dosage without prefix: {lastScheduledDosage}.";
                            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, lastScheduledDosageWithoutPrefixDebugMsg);

                            lastScheduledDosage = lastScheduledDosage.Replace(previousDosageSuffix, "");
                            //[DEBUG]
                            var lastScheduledDosageWithoutSuffixDebugMsg = $"Previous dosage without prefix/suffix: {lastScheduledDosage}.";
                            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, lastScheduledDosageWithoutSuffixDebugMsg);
                        }
                    }

                    // [TRACE]
                    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                    // [DEBUG]
                    var finalValuesDebugMsg = $"Current dosage: {currentDose}.{Environment.NewLine}" +
                                              $"Previous dosage: {lastScheduledDosage}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, finalValuesDebugMsg);

                    /* Convert previous dosage to a number
                     */
                    var previousDose = Convert.ToDouble(lastScheduledDosage);
                    // [DEBUG]
                    var previousDoseAsNumberDebugMsg = $"Previous dosage as number: {previousDose}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, previousDoseAsNumberDebugMsg);

                    /* Convert current dose to a number
                     */
                    var currDose = double.Parse(currentDose);
                    // [DEBUG]
                    var currentDoseAsNumberDebugMsg = $"Current dosage as number: {currDose}.";
                    LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, currentDoseAsNumberDebugMsg);

                    /* Check it.
                     */
                    if(currDose != previousDose)
                    {
                        // [TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                        /* Oh no! The current dose doesn't match the previous dose!
                         */

                        /* Get the difference
                         */
                        var milligramDifference = (previousDose - currDose);
                        var basePercentage = milligramDifference / previousDose;
                        var finalPercent = 100 - basePercentage;
                        // [DEBUG]
                        var dosagesDontMatchDebugMsg = $"Current dosage ({currDose}) doesn't match previous dose ({previousDose}).{Environment.NewLine}{Environment.NewLine}" +
                                                       $"There is a {finalPercent}% difference of {milligramDifference} mgs.";
                        LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, dosagesDontMatchDebugMsg);

                        /* Do somthing else.
                         */
                        var maxPercentIncrease = Convert.ToInt32(doseSetting["PercentageMax"]);
                        // [DEBUG]
                        var maxPercentIncreaseAsNumberDebugMsg = $"maxPercentIncrease as number: {maxPercentIncrease}.";
                        LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, maxPercentIncreaseAsNumberDebugMsg);

                        /* Math.
                         */
                        if(finalPercent >= maxPercentIncrease)
                        {
                            // [TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            /* Let the user fix it.
                             */
                            doseOptionObject.ErrorCode = 4;
                            doseOptionObject.ErrorMesg = $"WARNING: The percentage increase is too high!\n\nThe previous dose was: {previousDose}mg\nThe current dose is: {currentDose}mg\n\nThat's a difference of {finalPercent}%\n\nAre you sure you want to submit?";
                            //[ DEBUG]
                            var percentToHighDebugMsg = $"There is a {finalPercent}% difference between doses, which exceeds the maximum of {maxPercentIncrease}%.{Environment.NewLine}{Environment.NewLine}" +
                                                        $"Error code has been set to: {doseOptionObject.ErrorCode}.{Environment.NewLine}{Environment.NewLine}" +
                                                        $"Error message has been set to:{Environment.NewLine}{doseOptionObject.ErrorMesg}";
                            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, percentToHighDebugMsg);
                        }
                        else
                        {
                            //[TRACE]
                            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                            /* Everything is fine. No code here.
                             */
                            // [DEBUG]
                            var percentOkDebugMsg = $"There is a {finalPercent}% difference between doses, which is within the maximum of {maxPercentIncrease}%.";
                            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, percentOkDebugMsg);
                        }
                    }
                    else
                    {
                        //[TRACE]
                        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                        /* Everything is fine. No code here.
                         */
                        // [DEBUG]
                        var dosageSameDebugMsg = $"Current dosage ({currDose}) matches previous dose ({previousDose}).";
                        LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, dosageSameDebugMsg);
                    }
                }
            }
            else
            {
                //[TRACE]
                LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

                /* Not a valid orderType
                 */
                // [DEBUG]
                var notValidOrderTypeDebugMsg = $"orderType of {orderType} is not currently supported, so nothing will be done.";
                LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, notValidOrderTypeDebugMsg);
            }

            // [DEBUG]
            var UpdatedSentAndDoseOptionObjectValuesDebugMsg      = $"These are the initial values from the sentOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{sentOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{sentOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{sentOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{sentOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{sentOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{sentOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{sentOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{sentOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{sentOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{sentOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{sentOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{sentOptionObject.ErrorMesg}]{Environment.NewLine}" +
                                            $"{ Environment.NewLine}" +
                                            $"These are the initial values from the workingOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{doseOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{doseOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{doseOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{doseOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{doseOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{doseOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{doseOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{doseOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{doseOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{doseOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{doseOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{doseOptionObject.ErrorMesg}]{Environment.NewLine}{ Environment.NewLine}";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, UpdatedSentAndDoseOptionObjectValuesDebugMsg);

            //[TRACE]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

            /* Do it!
             */
            OptionObject2015 completedDoseOptionObject = TheOptionObject.Finalize.WhichComponents(sentOptionObject, doseOptionObject);
            // [DEBUG]
            var completedDoseOptionObjectValuesDebugMsg       = $"These are the updated values from the doseOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{completedDoseOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{completedDoseOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{completedDoseOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{completedDoseOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{completedDoseOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{completedDoseOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{completedDoseOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{completedDoseOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{completedDoseOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{completedDoseOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{completedDoseOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{completedDoseOptionObject.ErrorMesg}]";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, completedDoseOptionObjectValuesDebugMsg);


            // REMOVE
            /* When this block of code is uncommented, a pop-up with detailed information will be displayed when the
             * errMsgCode is "0", meaning no issues were found, and the form will being submitted normally.
             *
             * This is  useful when debugging, but normally it should be commented out.
             */
            //if (errMsgCode == 0)
            //{
            //    verifyAdmitDateOptionObject2.ErrorCode = 4;
            //    verifyAdmitDateOptionObject2.ErrorMesg = "[DEBUG]\nError Code: {errMsgCode}\nType of admission: {typeOfAdmission}\nPreAdmit Date: {preAdmitToAdmissionDate}\nSystem Date: {systemDate}";
            //}

            return completedDoseOptionObject;
        }
    }
}
