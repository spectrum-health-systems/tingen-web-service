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
    public class ErrorCode
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
        public static void ParseAction(AbSession abSession)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            switch (abSession.RequestAction)
            {
                case "errorcode1":
                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    abSession.ReturnOptionObject.SetFieldValue("50004","T102");
                    abSession.ReturnOptionObject.SetFieldValue("10750","TEST 230301.1147");
                    abSession.ReturnOptionObject.ToReturnOptionObject(4,"Testing Error Code 1");

                    //abSession.ReturnOptionObject.ErrorCode = 1;
                    //abSession.ReturnOptionObject.ErrorMesg = "Testing: Error Code 1";

                    break;

                default:

                    LogEvent.Trace("traceinternal",abSession,AssemblyName);

                    /* TODO: Make sure this exits gracefully. */
                    break;
            }
        }
    }
}