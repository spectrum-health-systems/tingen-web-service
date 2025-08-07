using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace AbatabSession
{
    public class Verify
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        public static void SessionComponents(Session abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            Du.WithDirectory.VerifyDir(abatabSession.SessionLogRoot);

            AbatabSettings.Verify.AvatarUserName(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

    }
}
