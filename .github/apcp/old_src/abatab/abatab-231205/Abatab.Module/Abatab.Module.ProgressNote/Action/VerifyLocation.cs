// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Abatab.Module.ProgressNote.Action
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class VerifyLocation
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            /* TODO: These values should be in the local settings file.*/
            var serviceChargeCodeValue = abSession.SentOptionObject.GetFieldValue("51001");
            var locationValue          = abSession.SentOptionObject.GetFieldValue("50004");

            switch (abSession.RequestAction)
            {
                case "telehlth90853":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    if (ValidGroupIndividualizedNote(abSession.ModProgNote.FlaggedServiceChargeCodeCodes,serviceChargeCodeValue,abSession.ModProgNote.ValidLocationCodes,locationValue,abSession)) // remove last parameter after testing
                    {
                        LogEvent.Trace("traceinternal",abSession,AssemblyName);

                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        LogEvent.Trace("traceinternal",abSession,AssemblyName);
                        LogEvent.Trace("traceinternal",abSession,AssemblyName,serviceChargeCodeValue); /* DEVELOPER_NOTE: For testing */

                        /* DEVNOTE: This is a quick fix.*/
                        if (serviceChargeCodeValue != "")
                        {
                            CreateWarning(abSession,serviceChargeCodeValue);
                        }
                        else
                        {
                            _ = abSession.ReturnOptionObject.ToReturnOptionObject();
                        }
                    }

                    break;

                case "telehlthwildcards":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    if (ValidIndividualCounselingNote(abSession.ModProgNote.FlaggedServiceChargeCodePrefixes,serviceChargeCodeValue,abSession.ModProgNote.ValidLocationCodes,locationValue,abSession))
                    {
                        LogEvent.Trace("traceinternal",abSession,AssemblyName);

                        abSession.ReturnOptionObject.ToReturnOptionObject();
                    }
                    else
                    {
                        LogEvent.Trace("traceinternal",abSession,AssemblyName);

                        /* DEVNOTE: This is a quick fix.*/
                        if (serviceChargeCodeValue != "")
                        {
                            CreateWarning(abSession,serviceChargeCodeValue);
                        }
                        else
                        {
                            _ = abSession.ReturnOptionObject.ToReturnOptionObject();
                        }
                    }

                    break;

                default:
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        private static bool ValidGroupIndividualizedNote(List<string> flaggedServiceChargeCodeCodes,string serviceChargeCodeValue,List<string> validLocations,string locationValue,AbSession abSession) // remove last argument after testing
        {
            /* DEVNOTE: We can't put a trace log here. */

            /* DEVNOTE
             * This is how this works:
             *
             *  IF the Service Charge Code on the form is in the list of service charge codes to check
             *      IF the location on the form is in the list of valid locations, return true
             *      IF the location on the form is not in the list of valid locations, return false
             *  IF the Service Charge Code on the form is not in the list of Service Charge Codes to check, return true.
             */

            /* TODO: Figure out a better way to do this. */
            if (flaggedServiceChargeCodeCodes.Contains(serviceChargeCodeValue))
            {
                LogEvent.Trace("traceinternal",abSession,AssemblyName,serviceChargeCodeValue);
                return validLocations.Contains(locationValue);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        private static bool ValidIndividualCounselingNote(List<string> flaggedServiceChargeCodePrefixes,string serviceChargeCodeValue,List<string> validLocations,string locationValue,AbSession abSession) // remove last argument after testing // Can't put a log event here.
        {
            /* DEVNOTE: We can't put a trace log here. */

            /* TODO: Figure out a better way to do this. */
            if (flaggedServiceChargeCodePrefixes.Any(codePrefix => serviceChargeCodeValue.StartsWith(codePrefix)))
            {
                LogEvent.Trace("traceinternal",abSession,AssemblyName,serviceChargeCodeValue);
                return validLocations.Contains(locationValue);
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        private static void CreateWarning(AbSession abSession,string serviceChargeCodeValue)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            /* DEVNOTE
             * The [TESTING] will let the user to be able to file the note after reviewing any warnings that pop up,
             * which will allow us to catch any edge-case issues. Once testing is complete, this block of code should
             * be removed.
             *
             * The [PRODUCTION] will not allow the user to file the note unless the information on the form is valid.
             * Once testing is complete, this block of code should be un-commented.
             */

            /* [TESTING] */
            var errorCode = 2;
            var errorMesg = $"WARNING!{Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"The current Service Charge Code ({serviceChargeCodeValue}) should probably match one of these locations:{Environment.NewLine}" +
                            $"{Environment.NewLine}" +
                            $"{ConvertCollection.ListToNewLineString(abSession.ModProgNote.ValidLocationNames)}" +
                            $"{Environment.NewLine}" +
                            $"Please click \"Cancel\" and verify you have the correct location, or \"OK\" if you are sure the location is correct.";

            /* [PRODUCTION] */
            //var errorCode = 1;
            //var errorMesg = $"WARNING!{Environment.NewLine}" +
            //                $"{Environment.NewLine}" +
            //                $"Service Charge Code {serviceChargeCodeValue} must match one of these locations:{Environment.NewLine}" +
            //                $"{Environment.NewLine}" +
            //                $"{Common.ListToNewLineString(abSession.ModProgressNote.ValidLocationNames)}" +
            //                $"{Environment.NewLine}" +
            //                $"Please verify you have the correct location.";

            /* REVIEW: Not sure what this is. */
            //var alertLogName = $"{DateTime.Now:yyMMdd}-{abSession.SentOptionObject.OptionId}-{abSession.RequestModule}-{abSession.RequestCommand}-{abSession.RequestAction}-{abSession.RequestOption}";

            _ = abSession.ReturnOptionObject.ToReturnOptionObject(errorCode,errorMesg);

            LogEvent.Warning(abSession);
            LogEvent.Alert(abSession,AssemblyName);
        }
    }
}