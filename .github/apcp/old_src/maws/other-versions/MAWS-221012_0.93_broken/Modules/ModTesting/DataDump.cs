// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModTesting
{
    public class DataDump
    {
        /// <summary>Do a data dump.</summary>
        /// <param name="abatabSession">Abatab session settings.</param>
        public static void SessionData(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
            LogEvent.Session(abatabSession, "Testing data dump functionality.");
        }
    }
}
