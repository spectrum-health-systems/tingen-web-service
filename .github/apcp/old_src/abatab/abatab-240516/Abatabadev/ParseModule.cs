
using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core;
using Abatab.Module.Testing;
using Abatab;
using Abatab.Core.Logger;


namespace Abatabadev
{

    /// <summary>Parses the module component of the Script Parameter.</summary>
    /// <remarks>
    ///     - This class should not be modified unless a new Abatab Module is added.<br></br>
    ///     - When a new Abatab Module is added, you will need to add a new case to the <b>SendToModule()</b> method
    ///       <see href="https://github.com/spectrum-health-systems/Abatab-Documentation-Project">(more information)</see>.
    /// </remarks>
    public static class ParseModule
    {
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Sends the OptionObject to a specific Abatab Module.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        ///     - The <b>module</b> component of the Script Parameter determines what Abatab Module the OptionObject will be sent to.<br></br>
        ///     - This method ignores all other Script Parameter components, since they will be handled by the recieving module's Roundhouse class.
        /// </remarks>
        public static void SendToModule(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    ParseCommand.SendToCommand(abSession);
                    //Abatab.Module.Testing.ParseCommand.SendToCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Abatab.Module.ProgressNote.ParseCommand.SendToCommand(abSession);

                    break;

                case "qmedordr":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Module.QuickMedicationOrder.Roundhouse.ParseCommand(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    // TODO Eventually this should exit gracefully

                    break;
            }
        }
    }

}