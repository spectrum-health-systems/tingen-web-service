// b231205.1411

/* DEVELOPER_NOTE
 * This class is under construction.
 */

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Net;
using System.Net.Mail;
using System.Reflection;

namespace Abatab.Core.Messaging
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public class EmailMsg
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
        public static void Send(AbSession abSession,string msgTo,string msgFrom,string acctPwd,string msgSubject,string msgBody)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            /* TODO
             * Most of this should be stored in external settings.
             */
            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                //UseDefaultCredentials = false,
                //Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
                //Credentials = new NetworkCredential("abatab@spectrumhealthsystems.org", "ChrisIsSmarterThanNetsmart123"),
                EnableSsl = true,
            };

            LogEvent.Trace("trace",abSession,AssemblyName);

            //smtpClient.UseDefaultCredentials = false;

            LogEvent.Trace("trace",abSession,AssemblyName);

            //Credentials = new NetworkCredential(abSession.AbatabEmailAddress, abSession.AbatabEmailPassword),
            smtpClient.Credentials = new NetworkCredential(msgTo,acctPwd);

            LogEvent.Trace("trace",abSession,AssemblyName);

            //var emailTo = "courtney.cross@spectrumhealthsystems.org";
            LogEvent.Trace("trace",abSession,AssemblyName);

            //smtpClient.Send("abatab@spectrumhealthsystems.org", "chris.banwarth@spectrumhealthsystems.org", "I AM AVATAR!", "Yay!");
            smtpClient.Send(msgTo,msgFrom,msgBody,msgSubject);
            LogEvent.Trace("trace",abSession,AssemblyName);
            abSession.ReturnOptionObject.ToReturnOptionObject();

            LogEvent.Trace("trace",abSession,AssemblyName);
        }
    }
}
