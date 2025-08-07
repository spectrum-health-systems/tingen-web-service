// 240516.1114

using System.Reflection;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;

namespace Abatab.Module.ProgressNote
{
    /// <summary>Parses the command component of the Script Parameter.</summary>
    /// <remarks>
    ///     - This class should not be modified unless a new command is added to the ProgressNote Module.<br></br>
    ///     - When a new command is added to the ProgressNote Module, you will need to add a new case to the <b>SendToCommand()</b> method.
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

        /// <summary>Sends the OptionObject to a specific ProgressNote Command.</summary>
        /// <param name="abSession">The Abatab session object.</param>
        /// <remarks>
        ///     - The <b>Command</b> component of the Script Parameter determines what ProgressNote Command class the OptionObject will be sent to.<br></br>
        ///     - This method ignores all other Script Parameter components, since they will be handled by the specifed Command ParseAction class.
        /// </remarks>
        public static void SendToCommand(AbSession abSession)
        {
            LogEvent.Trace("trace", abSession, AssemblyName);

            switch (abSession.RequestCommand)
            {
                case "vfyloc":
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    Action.VfyLoc.ParseAction(abSession);

                    break;

                default:
                    LogEvent.Trace("traceinternal", abSession, AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}