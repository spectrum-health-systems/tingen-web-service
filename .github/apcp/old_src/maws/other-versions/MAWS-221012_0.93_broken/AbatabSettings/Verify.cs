using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabSettings
{
    /// <summary></summary>
    public static class Verify
    {
        /// <summary></summary>
        private static void AbatabDirectory(string dir)
        {

        }

        /// <summary>
        /// Verifies the session AvatarUserName is valid.
        /// </summary>
        /// <param name="abatabSession">Information/data for this session of Abatab.</param>
        public static void AvatarUserName(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            if (string.IsNullOrWhiteSpace(abatabSession.AvatarUserName))
            {
                abatabSession.AvatarUserName = abatabSession.AvatarFallbackUserName;
            }

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }
    }
}
