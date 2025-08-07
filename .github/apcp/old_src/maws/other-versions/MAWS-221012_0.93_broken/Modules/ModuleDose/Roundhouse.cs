/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * ModuleDose.csproj                                                                                v0.92.0
 * Roundhouse.cs                                                                             b221010.124123
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleDose
{
    public class Roundhouse
    {
        /// <summary>Parse the Abatab request command.</summary>
        /// <param name="abatabSession">Abatab session information.</param>
        public static void ParseRequest(SessionData abatabSession)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing QuickMedOrder Module command.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabCommand.ToLower())
            {
                case "percentage":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ParseCommandPercentage(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary>Do a data dump.</summary>
        /// <param name="abatabSession">Abatab session information.</param>
        private static void ParseCommandPercentage(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabAction.ToLower())
            {
                case "verifyundermaxinc":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    Percentage.VerifyUnderMaxInc(abatabSession);
                    AbatabOptionObject.FinalObj.Finalize(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // Gracefully exit.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
