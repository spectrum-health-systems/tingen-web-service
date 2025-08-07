// b231205.1411

/* DEVNOTE
 * Write something about what this testing functionality is used for.
 */

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab.Module.Testing.Action
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Messaging
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestAction)
            {
                case "sendemail":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    SendEmail(abSession);

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
        private static void SendEmail(AbSession abSession)
        {
            //LogEvent.Trace("trace", abSession, AssemblyName);

            //var smtpClient = new SmtpClient("smtp.office365.com")
            //{
            //    Port = 587,
            //    //UseDefaultCredentials = false,
            //    //Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
            //    //Credentials = new NetworkCredential("abatab@spectrumhealthsystems.org", "ChrisIsSmarterThanNetsmart123"),
            //    EnableSsl = true,
            //};

            //LogEvent.Trace("trace", abSession, AssemblyName);

            ////smtpClient.UseDefaultCredentials = false;

            //LogEvent.Trace("trace", abSession, AssemblyName);

            ////Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
            //smtpClient.Credentials = new NetworkCredential("abatab@spectrumhealthsystems.org", "5cr33n5#07");

            //LogEvent.Trace("trace", abSession, AssemblyName);

            //var emailTo = "courtney.cross@spectrumhealthsystems.org";
            //LogEvent.Trace("trace", abSession, AssemblyName);

            //smtpClient.Send("abatab@spectrumhealthsystems.org", "chris.banwarth@spectrumhealthsystems.org", "I AM AVATAR!", "Yay!");
            ////smtpClient.Send(emailTo, abSession.AbatabEmailAddress, "test", "This is a test");
            //LogEvent.Trace("trace", abSession, AssemblyName);
            //abSession.ReturnOptionObject.ToReturnOptionObject();

            //LogEvent.Trace("trace", abSession, AssemblyName);
        }
    }
}