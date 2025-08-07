// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using AbatabData;
using AbatabLogging;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Reflection;

namespace AbatabSession
{
    /// <summary>
    /// Logic for session instances.
    /// </summary>
    public class Create
    {
        /// <summary>
        /// Builds configuration settings for an Abatab session.
        /// </summary>
        /// <param name="sentOptObj">The original OptionObject sent from Avatar.</param>
        /// <param name="scriptParameter">The script parameter request from Avatar.</param>
        /// <returns>Session configuration settings.</returns>
        public static Session New(OptionObject2015 sentOptObj, string scriptParameter, Dictionary<string, string> abatabSettings)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSettings["DebugMode"], abatabSettings["DebugLogRoot"], "[DEBUG] Building session data.");
            // No LogEvent.Trace() here because we don't have the necessary information yet.

            var abatabSession = new Session
            {
                AbatabMode                        = abatabSettings["AbatabMode"],
                AbatabRoot                        = abatabSettings["AbatabRoot"],
                DebugMode                         = abatabSettings["DebugMode"],
                DebugLogRoot                      = abatabSettings["DebugLogRoot"],
                LoggingMode                       = abatabSettings["LoggingMode"],
                LoggingDetail                     = abatabSettings["LoggingDetail"],
                LoggingDelay                      = abatabSettings["LoggingDelay"],
                AvatarFallbackUserName            = abatabSettings["AvatarFallbackUserName"],
                ModQuickMedOrderMode              = abatabSettings["ModQuickMedOrderMode"],
                ModQuickMedOrderValidUsers        = abatabSettings["ModQuickMedOrderValidUsers"],
                ModQuickMedOrderDosePercentMaxInc = abatabSettings["ModQuickMedOrderDosePercentMaxInc"],
                ModPrototypeMode                  = abatabSettings["ModPrototypeMode"],
                ModTestingMode                    = abatabSettings["ModTestingMode"],
                AbatabVer                         = abatabSettings["AbatabVer"],
                SessionDate                       = abatabSettings["AbatabSessionDate"],
                ScriptParameter                   = scriptParameter.ToLower(),
                AbatabModule                      = abatabSettings["AbatabModule"],
                AbatabCommand                     = abatabSettings["AbatabCommand"],
                AbatabAction                      = abatabSettings["AbatabAction"],
                AbatabOption                      = abatabSettings["AbatabOption"],
                ModQuickMedOrderData              = new QuickMedOrder(),
                //SessionTime                       = $"{DateTime.Now:HHmmss}",                            // Probably don't need.
                //SessionLogRoot                    = ""                                                   // Set below
                AvatarUserName                    = abatabSettings["AvatarUserName"],
                AvatarSystemCode                  = abatabSettings["AvatarSystemCode"],
                SentOptObj                        = sentOptObj,
                WorkOptObj                        = AbatabOptionObject.WorkObj.Build(sentOptObj),
                FinalOptObj                       = new OptionObject2015()
            };

            abatabSession.SessionLogRoot = $@"{abatabSession.AbatabRoot}\logs\{abatabSession.SessionDate}\{abatabSession.AvatarUserName}";
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            Verify.SessionComponents(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            return abatabSession;
        }


    }
}