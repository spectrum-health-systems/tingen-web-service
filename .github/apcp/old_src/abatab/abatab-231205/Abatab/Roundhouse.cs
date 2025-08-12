// b231106.1009

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using System.Reflection;

namespace Abatab
{
    /// <summary>Parses the module component of the Script Parameter.</summary>
    /// <remarks>
    ///     - This class will need to be modified when a new Abatab Module is added.
    /// </remarks>
    public static class Roundhouse
    {
        /// <summary>Executing assembly name for log files.</summary>
        /// <remarks>
        ///     - The execuring assembly is defined at the start of the class so it can be easily used throughout the
        ///       method when creating log files.
        /// </remarks>
        public static string AssemblyName { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>Parses the `module` component of the sent Script Parameter.
        /// </summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        ///     - Each module has a case statement that routes the `command-action[-option]`n component of the sent
        ///       Script Parameter to the Roundhouse.cs for that specific Module. Therefore, this method <i>will need
        ///       to be modified</i> when new Module functionality is added.
        ///     - This method <i>does not need to be modified</i> when new a new `command-action[-option]` for an
        ///       existing module is added, since that is handled by the Roundhouse.cs of the Module.
        /// </remarks>
        public static void ParseModule(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestModule)
            {
                case "testing":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.Testing.Roundhouse.ParseCommand(abSession);

                    break;

                case "prognote":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.ProgressNote.Roundhouse.ParseCommand(abSession);

                    break;

                case "qmedordr":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    Module.QuickMedicationOrder.Roundhouse.ParseCommand(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    // TODO Eventually this should exit gracefully

                    break;
            }
        }
    }
}