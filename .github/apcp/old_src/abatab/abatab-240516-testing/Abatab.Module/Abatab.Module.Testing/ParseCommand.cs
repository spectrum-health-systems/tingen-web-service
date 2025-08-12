// 240516.1143

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.Testing
{
    /// <summary>Parses the command component of the Script Parameter.</summary>
    /// <remarks>
    ///     - This class should not be modified unless a new command is added to the Testing Module.<br></br>
    ///     - When a new command is added to the Testing Module, you will need to add a new case to the <b>SendToCommand()</b> method.
    ///       <see href="https://github.com/spectrum-health-systems/Abatab-Documentation-Project">(more information)</see>.
    /// </remarks>
    public static class ParseCommand
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The executing assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Sends the OptionObject to a specific Testing Command.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        ///     - The <b>Command</b> component of the Script Parameter determines what Testing Command class the OptionObject will be sent to.<br></br>
        ///     - This method ignores all other Script Parameter components, since they will be handled by the specifed Command ParseAction class.
        /// </remarks>
        public static void SendToCommand(AbSession abSession)
        {
            /* DEVNOTE
             * Uncommenting the following line will write a Debuggler log file, which isuseful for development and
             * troubleshooting. It is not recommended to leave this line uncommented in production code.
             */
            //Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "admin":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    //Action.Admin.SendEmail(abSession);

                    break;

                case "datadump":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.DataDump.ParseAction(abSession);

                    break;

                case "errorcode":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.ErrorCode.ParseAction(abSession);

                    break;

                /* The "sendemail" will test the email functionality.
                 * 
                 * 
                 */
                case "sendemail":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Abatab.Core.Messaging.EmailMsg.Send(abSession, abSession.AbatabEmailTestAddress, abSession.AbatabEmailFromAddress, abSession.AbatabEmailFromPassword, abSession.AbatabEmailTestSubject, abSession.AbatabEmailTestBody);

                    //Action.Messaging.SendEmail(abSession);

                    //Action.Messaging.ParseAction(abSession);

                    break;


                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}