// b231205.1411

/* DEVELOPER_NOTE
 * Write something about what the Debuggler is, and why it exists.
 */

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Primeval log logic.
    /// </summary>
    public static class Debuggler
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>

        public static void DebugLog(string debugglerMode,string exeAssembly,string logMsg = "",[CallerFilePath] string callPath = "",[CallerMemberName] string callMember = "",[CallerLineNumber] int callLine = 0)
        {
            if (debugglerMode == "enabled")
            {
                FileIO.WriteLocal($@"C:\AbatabData\Debuggler\{DateTime.Now:HHmmss_fffffff}-{exeAssembly}-{Path.GetFileName(callPath)}-{callMember}-{callLine}.debuggler",logMsg,100);
            }
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>

        public static void PrimevalLog(string fileExtension)
        {
            FileIO.WriteLocal($@"C:\AbatabData\Primeval\{DateTime.Now:yyMMddHHmmssfffffff}_Abatab.{fileExtension}","");
        }
    }
}