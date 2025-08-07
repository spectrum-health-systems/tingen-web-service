// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabOptionObject
{
    /// <summary>
    /// Logic for working with the FinalOptObj.
    /// </summary>
    public class FinalObj
    {
        /// <summary>
        /// Finalizes an OptionObject.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void Finalize(Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Finalizing finalOptObj");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name, abatabSession.AbatabMode);

            switch (abatabSession.AbatabMode.ToLower())
            {
                case "passthrough":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ForPassthrough(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>
        /// Builds the FinalOptObj stuff when the Abatab mode is set to passthrough.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ForPassthrough(Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Finalizing finalOptObj for passthrough.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.FinalOptObj.ErrorCode = 0;
            abatabSession.FinalOptObj.ErrorMesg = "PASSTHROUGH";

            abatabSession.FinalOptObj.EntityID        = abatabSession.SentOptObj.EntityID;
            abatabSession.FinalOptObj.EpisodeNumber   = abatabSession.SentOptObj.EpisodeNumber;
            abatabSession.FinalOptObj.Facility        = abatabSession.SentOptObj.Facility;
            abatabSession.FinalOptObj.OptionId        = abatabSession.SentOptObj.OptionId;
            abatabSession.FinalOptObj.OptionStaffId   = abatabSession.SentOptObj.OptionStaffId;
            abatabSession.FinalOptObj.OptionUserId    = abatabSession.SentOptObj.OptionUserId;
            abatabSession.FinalOptObj.SystemCode      = abatabSession.SentOptObj.SystemCode;
            abatabSession.FinalOptObj.ServerName      = abatabSession.SentOptObj.ServerName;
            abatabSession.FinalOptObj.NamespaceName   = abatabSession.SentOptObj.NamespaceName;
            abatabSession.FinalOptObj.ParentNamespace = abatabSession.SentOptObj.ParentNamespace;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}