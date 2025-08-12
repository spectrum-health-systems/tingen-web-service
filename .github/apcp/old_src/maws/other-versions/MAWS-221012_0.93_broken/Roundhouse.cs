// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace Abatab
{
    /// <summary>
    /// Roundhouse functionality for Abatab.
    /// </summary>
    public static class Roundhouse
    {
        /// <summary>
        /// Determines where a script parameter request should go.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void ParseRequest(Session abatabSession)
        {
            Debuggler.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parse script parameter request.");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            switch (abatabSession.AbatabModule)
            {
                case "prototype":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    //ModPrototype.Roundhouse.ParseRequest(abatabSession);
                    break;

                case "quickmedorder":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ModQuickMedOrder.Roundhouse.ParseRequest(abatabSession);
                    break;

                case "testing":
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    ModTesting.Roundhouse.ParseRequest(abatabSession);
                    break;

                default:
                    LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
                    // Exit gracefully.
                    break;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}