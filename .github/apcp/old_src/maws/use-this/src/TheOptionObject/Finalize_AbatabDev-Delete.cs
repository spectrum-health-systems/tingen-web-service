/* PROJECT: TheOptionObject (https://github.com/aprettycoolprogram/TheOptionObject)
 *    FILE: TheOptionObject.Finalize.cs
 * UPDATED: 1-7-2022-10:13 AM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Finalizes an OptionObject.
 * 
 * This is a mess, and will be cleaned up for v1.1.
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using NTST.ScriptLinkService.Objects;
using Utility;

namespace TheOptionObject
{
    public class Finalize
    {

        public static OptionObject2015 WhichComponents(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, bool finalizeRecommended = true, bool finalizeNotRecommended = false)
        {
            /* myAvatar requires that a completed OptionObject2015 object be returned. This method will make sure that
             * all of the fields of an OptionObject2015 object that are not explicitly set are populated with the
             * original values in "sentOptionObject".
             */
            Dictionary<string, string> theOptionObjectSetting = ExternalConfiguration.FromKeyValuePairFile("TheOptionObject.conf");
            var logSetting                                    = theOptionObjectSetting["LogSetting"].ToLower();
            var assemblyName                                  = Assembly.GetExecutingAssembly().GetName().Name;
            //[TRACE]
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);

            // [DEBUG LOG] This is what the doseOptionObject looks like after all the work above has been completed.
            var sentAndWorkingOptionObjectValuesDebugMsg      = $"These are the initial values from the sentOptionObject:{Environment.NewLine}{Environment.NewLine}" +
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
                                            $"EntityID        = [{workingOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{workingOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{workingOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{workingOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{workingOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{workingOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{workingOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{workingOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{workingOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{workingOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{workingOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{workingOptionObject.ErrorMesg}]{Environment.NewLine}{ Environment.NewLine}";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, sentAndWorkingOptionObjectValuesDebugMsg);

            /* This method will make sure that all of the fields of an OptionObject2 object that are not explicitly set
             * are set to whatever the original values in "sentOptionObject" were. This ensures that the OptionObject2
             * that is returned to Avatar contains the required information. Currently this is done using brute force,
             * but eventually it will be accomplished with a loop.
             */
            var completedOptionObject = new OptionObject2015();

            // [DEBUG LOG] Initial values of the completedOptionObject2015, to make sure the initial values are correct.
            var initialCompletedOptionObjectValuesDebugMsg    = $"These are the initial values for the completedOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{completedOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{completedOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{completedOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{completedOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{completedOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{completedOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{completedOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{completedOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{completedOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{completedOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{completedOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{completedOptionObject.ErrorMesg}]";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, initialCompletedOptionObjectValuesDebugMsg);

            // Since these fields MUST be explicitly set prior to returning the OptionObject2, they are always set. If
            // these fields are null when returned to Avatar, the script will fail.


            /* These are from the working object
             */
            completedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
            completedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;

            /* These are from the sent object
             */
            completedOptionObject.EntityID = sentOptionObject.EntityID;
            completedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
            completedOptionObject.Facility = sentOptionObject.Facility;
            completedOptionObject.OptionId = sentOptionObject.OptionId;
            completedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
            completedOptionObject.OptionUserId = sentOptionObject.OptionUserId;
            completedOptionObject.SystemCode = sentOptionObject.SystemCode;
            completedOptionObject.ServerName = sentOptionObject.ServerName;
            completedOptionObject.NamespaceName = sentOptionObject.NamespaceName;
            completedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;

            // [DEBUG LOG] Updated values of the completedOptionObject2015, to make sure the initial values are correct.
            var updatedCompletedOptionObjectValuesDebugMsg    = $"These are the initial values for the completedOptionObject:{Environment.NewLine}{Environment.NewLine}" +
                                            $"EntityID        = [{completedOptionObject.EntityID}]{Environment.NewLine}" +
                                            $"Facility        = [{completedOptionObject.Facility}]{Environment.NewLine}" +
                                            $"NamespaceName   = [{completedOptionObject.NamespaceName}]{Environment.NewLine}" +
                                            $"OptionId        = [{completedOptionObject.OptionId}{Environment.NewLine}" +
                                            $"ParentNamespace = [{completedOptionObject.ParentNamespace}]{Environment.NewLine}" +
                                            $"ServerName      = [{completedOptionObject.ServerName}]{Environment.NewLine}" +
                                            $"SystemCode      = [{completedOptionObject.SystemCode}]{Environment.NewLine}" +
                                            $"EpisodeNumber   = [{completedOptionObject.EpisodeNumber}]{Environment.NewLine}" +
                                            $"OptionStaffId   = [{completedOptionObject.OptionStaffId}]{Environment.NewLine}" +
                                            $"OptionUserId    = [{completedOptionObject.OptionUserId}]{Environment.NewLine}" +
                                            $"ErrorCode       = [{completedOptionObject.ErrorCode}]{Environment.NewLine}" +
                                            $"ErrorMesg       = [{completedOptionObject.ErrorMesg}]";
            LogEvent.Timestamped(logSetting, "DEBUG", assemblyName, sentOptionObject.OptionUserId, updatedCompletedOptionObjectValuesDebugMsg);





            // ORIG
            //completedOptionObject.EntityID = sentOptionObject.EntityID;
            //completedOptionObject.Facility = sentOptionObject.Facility;
            //completedOptionObject.NamespaceName = sentOptionObject.NamespaceName;
            //completedOptionObject.OptionId = sentOptionObject.OptionId;
            //completedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
            //completedOptionObject.ServerName = sentOptionObject.ServerName;
            //completedOptionObject.SystemCode = sentOptionObject.SystemCode;
            //completedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
            //completedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
            //completedOptionObject.OptionUserId = sentOptionObject.OptionUserId;

            // Since it is recommended that these be explicitly set prior to returning the OptionObject2, they should
            // always be set by passing "true" as the value for the "recommended" argument. The if statement does its
            // best job to catch any invalid argument values.
            ////if(finalizeRecommended)
            ////{
            ///

            /// ORIG


            // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
            // the data that exists in the sentOptionObject.

            //ORIG
            ////if(workingOptionObject.ErrorCode >= 1)
            ////    {
            ////        completedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
            ////        completedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;
            ////    }
            ////    else
            ////    {
            ////        completedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
            ////        completedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
            ////    }
            ////}

            // Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
            // setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
            // contain data when returned to myAvatar, this script will fail. The if statement does its  best job to
            // catch any invalid argument values.
            ////if(finalizeNotRecommended)
            ////{
            ////    completedOptionObject.Forms = sentOptionObject.Forms;
            ////}



            //var finalizedOptionObject = new OptionObject2015();

            ////OptionObject2015 finalizedOptionObject = sentOptionObject;

            //finalizedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
            //finalizedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;

            //// Required
            //finalizedOptionObject.EntityID = sentOptionObject.EntityID;
            //finalizedOptionObject.Facility = sentOptionObject.Facility;
            //finalizedOptionObject.NamespaceName = sentOptionObject.NamespaceName;
            //finalizedOptionObject.OptionId = sentOptionObject.OptionId;
            //finalizedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
            //finalizedOptionObject.ServerName = sentOptionObject.ServerName;
            //finalizedOptionObject.SystemCode = sentOptionObject.SystemCode;

            //// Recommended

            //finalizedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
            //finalizedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
            //finalizedOptionObject.OptionUserId = sentOptionObject.OptionUserId;

            //    // If the returnOptionObject has data, use that to complete the completedOptionObject. Otherwise, use
            //    // the data that exists in the sentOptionObject.
            //    if(returnOptionObject.ErrorCode >= 1)
            //    {
            //        completedOptionObject.ErrorCode = returnOptionObject.ErrorCode;
            //        completedOptionObject.ErrorMesg = returnOptionObject.ErrorMesg;
            //    }
            //    else
            //    {
            //        completedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
            //        completedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
            //    }
            //}

            //// Since it is recommended that these NOT BE explicitly set prior to returning the OptionObject2, avoid
            //// setting them by passing "false" as the value for the "recommended" argument. Generally, if these fields
            //// contain data when returned to myAvatar, this script will fail. The if statement does its  best job to
            //// catch any invalid argument values.
            //if(notRecommended)
            //{
            //    completedOptionObject.Forms = sentOptionObject.Forms;
            //}

            //[TRACE] Meh.
            LogEvent.Timestamped(logSetting, "TRACE", assemblyName, sentOptionObject.OptionUserId);





            ////////var finalMessage = $"finalizedOptionObject values:{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.EntityID = {completedOptionObject.EntityID}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.Facility = {completedOptionObject.Facility}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.NamespaceName = {completedOptionObject.NamespaceName}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.OptionId = {completedOptionObject.OptionId}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.ParentNamespace = {completedOptionObject.ParentNamespace}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.ServerName = {completedOptionObject.ServerName}{Environment.NewLine}" +
            ////////                                    $"completedOptionObject.SystemCode = {completedOptionObject.SystemCode}";
            ////////LogEvent.Timestamped(logSetting, "TRACE", assemblyName, finalMessage);


            //OptionObject2015 finalizedOptionObject = new OptionObject2015();
            //LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Initialized finalizedOptionObject.");

            //FinalizeRequiredFields(sentOptionObject, finalizedOptionObject, logSetting, assemblyName);

            //if (finalizeRecommended)
            //{
            //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Request to finalize recommended fields.");
            //    finalizedOptionObject = FinalizeRecommendedFields(sentOptionObject, workingOptionObject, finalizedOptionObject, logSetting, assemblyName);
            //}

            //if (finalizeNotRecommended)
            //{
            //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Request to finalize not-recommended fields.");
            //    finalizedOptionObject = FinalizeNonRecommendedFields(sentOptionObject, finalizedOptionObject, logSetting, assemblyName);
            //}

            return completedOptionObject;
        }

        ///// <summary>
        ///// Confirms the required fields for a valid OptionObject2015 object are populated.
        ///// </summary>
        ///// <returns>An OptionObject2015 object with all required fields populated.</returns>
        //private static OptionObject2015 FinalizeRequiredFields(OptionObject2015 sentOptionObject, OptionObject2015 finalizedOptionObject, string logSetting, string assemblyName)
        //{
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finalizing required fields.");

        //    finalizedOptionObject.EntityID        = sentOptionObject.EntityID;
        //    finalizedOptionObject.Facility        = sentOptionObject.Facility;
        //    finalizedOptionObject.NamespaceName   = sentOptionObject.NamespaceName;
        //    finalizedOptionObject.OptionId        = sentOptionObject.OptionId;
        //    finalizedOptionObject.ParentNamespace = sentOptionObject.ParentNamespace;
        //    finalizedOptionObject.ServerName      = sentOptionObject.ServerName;
        //    finalizedOptionObject.SystemCode      = sentOptionObject.SystemCode;

        //    string finalizeRequiredFieldsMessage = $"FinalizeRequiredFields values:{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.EntityID = {finalizedOptionObject.EntityID}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.Facility = {finalizedOptionObject.Facility}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.NamespaceName = {finalizedOptionObject.NamespaceName}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.OptionId = {finalizedOptionObject.OptionId}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.ParentNamespace = {finalizedOptionObject.ParentNamespace}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.ServerName = {finalizedOptionObject.ServerName}{Environment.NewLine}" +
        //                                           $"finalizedOptionObject.SystemCode = {finalizedOptionObject.SystemCode}" +
        //                                           $"finalizedOptionObject.EpisodeNumber = {finalizedOptionObject.EpisodeNumber}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.OptionStaffId = {finalizedOptionObject.OptionStaffId}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.OptionUserId = {finalizedOptionObject.OptionUserId}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.ErrorCode = {finalizedOptionObject.ErrorCode}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.ErrorMesg = {finalizedOptionObject.ErrorMesg}";
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, finalizeRequiredFieldsMessage);

        //    return finalizedOptionObject;

        //}

        ///// <summary>
        ///// Confirms the recommended fields for a valid OptionObject2015 object are populated.
        ///// </summary>
        ///// <returns>An OptionObject2015 object with all recommended fields populated.</returns>
        //private static OptionObject2015 FinalizeRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 workingOptionObject, OptionObject2015 finalizedOptionObject, string logSetting, string assemblyName)
        //{
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finalizing recommended fields.");

        //    finalizedOptionObject.EpisodeNumber = sentOptionObject.EpisodeNumber;
        //    finalizedOptionObject.OptionStaffId = sentOptionObject.OptionStaffId;
        //    finalizedOptionObject.OptionUserId  = sentOptionObject.OptionUserId;

        //    // If the workingOptionObject has data, use that to complete the completedOptionObject. Otherwise, use the
        //    // data that exists in the sentOptionObject.
        //    if (workingOptionObject.ErrorCode >= 1)
        //    {
        //        finalizedOptionObject.ErrorCode = workingOptionObject.ErrorCode;
        //        finalizedOptionObject.ErrorMesg = workingOptionObject.ErrorMesg;
        //        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "ErrorCode >= 1");
        //    }
        //    else
        //    {
        //        finalizedOptionObject.ErrorCode = sentOptionObject.ErrorCode;
        //        finalizedOptionObject.ErrorMesg = sentOptionObject.ErrorMesg;
        //        LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "ErrorCode = 1");
        //    }

        //    string finalizeRecommendedFieldsMessage = $"FinalizeRequiredFields values:{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.EpisodeNumber = {finalizedOptionObject.EpisodeNumber}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.OptionStaffId = {finalizedOptionObject.OptionStaffId}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.OptionUserId = {finalizedOptionObject.OptionUserId}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.ErrorCode = {finalizedOptionObject.ErrorCode}{Environment.NewLine}" +
        //                                              $"finalizedOptionObject.ErrorMesg = {finalizedOptionObject.ErrorMesg}";
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, finalizeRecommendedFieldsMessage);

        //    return finalizedOptionObject;
        //}

        ///// Confirms the non-recommended fields for a valid OptionObject2015 object are populated.
        ///// </summary>
        ///// <returns>An OptionObject2015 object with all required fields populated.</returns>
        //private static OptionObject2015 FinalizeNonRecommendedFields(OptionObject2015 sentOptionObject, OptionObject2015 completedOptionObject2, string logSetting, string assemblyName)
        //{
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Finalizing not-recommended fields - WARNING: THIS SHOULD NOT HAPPEN.");

        //    completedOptionObject2.Forms = sentOptionObject.Forms;
        //    LogEvent.Timestamped(logSetting, "TRACE", assemblyName, "Uh oh! This shouldn't have happened!");

        //    return completedOptionObject2;
        //}
    }
}
