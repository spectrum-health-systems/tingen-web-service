// b231205.1411

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Logger;
using Abatab.Core.Utility;
using ScriptLinkStandard.Objects;
using System;
using System.Reflection;

namespace Abatab.Core.Session
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class Build
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
        public static void NewSession(OptionObject2015 sentOptionObject,string scriptParameter,AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            BuildSessionRuntimeDetail(abSession);
            BuildSessionOptionObjectDetail(abSession,sentOptionObject);
            BuildAbatabUserName(abSession);
            BuildSessionFrameworkDetail(abSession);
            BuildAbatabRequest(abSession,scriptParameter);
            //BuildModProgressNote(abSession);
            //BuildModPrototype(abSession);
            BuildModQuickMedicationOrder(abSession);
            //BuildModTesting(abSession);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void BuildSessionRuntimeDetail(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            abSession.Datestamp = $"{DateTime.Now:yyMMdd}";
            abSession.Timestamp = $"{DateTime.Now:HHmmss}";
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void BuildSessionFrameworkDetail(AbSession abSession)
        {
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            abSession.SessionDataRoot = $@"{abSession.AbatabDataRoot}\{abSession.AvatarEnvironment}\{abSession.Datestamp}";
            abSession.SessionDataDirectory = $@"{abSession.SessionDataRoot}\{abSession.AbatabUserName}\{abSession.Timestamp}";
            abSession.TraceLogDirectory = $@"{abSession.SessionDataDirectory}\trace";
            abSession.WarningLogDirectory = $@"{abSession.SessionDataDirectory}\warnings";
            abSession.PublicDataRoot = $@"{abSession.AbatabDataRoot}\public\";
            abSession.AlertLogDirectory = $@"{abSession.AbatabDataRoot}\public\alert";
            abSession.DebugglerLogDirectory = $@"{abSession.AbatabDataRoot}\debuggler";

            Utility.FileSys.VerifyDirectories(Catalog.Key.Directories.Session(abSession));
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void BuildAbatabUserName(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
             */
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            abSession.AbatabUserName = string.IsNullOrWhiteSpace(abSession.SentOptionObject.OptionUserId)
                ? abSession.AbatabFallbackUserName
                : abSession.SentOptionObject.OptionUserId;
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void BuildSessionOptionObjectDetail(AbSession abSession,OptionObject2015 sentOptionObject)
        {
            /* QUESTION Can a trace log go here?
             */
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            //LogEvent.Trace(abSession, "trace", AssemblyName);

            abSession.SentOptionObject = sentOptionObject;
            abSession.ReturnOptionObject = sentOptionObject.Clone();
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void BuildAbatabRequest(AbSession abSession,string scriptParameter)
        {
            LogEvent.Trace("trace",abSession,AssemblyName);

            string[] parameterComponent = scriptParameter.ToLower().Split('-');

            abSession.RequestModule = parameterComponent[0].Trim().ToLower();
            abSession.RequestCommand = parameterComponent[1].Trim().ToLower();
            abSession.RequestAction = parameterComponent[2].Trim().ToLower();

            if (parameterComponent.Length == 4)
            {
                LogEvent.Trace("traceinternal",abSession,AssemblyName);
                abSession.RequestOption = parameterComponent[3].ToLower();
            }
        }

        //private static void BuildModPrototype(AbSession abSession, Dictionary<string, string> webConfigContent)
        //{
        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);

        //    abSession.ModPrototype = new ModPrototype
        //    {
        //        Mode            = webConfigContent["ModProgressNoteMode"],
        //        AuthorizedUsers = webConfigContent["ModProgressNoteAuthorizedUsers"]
        //    };
        //}

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        private static void BuildModQuickMedicationOrder(AbSession abSession)
        {
            /* QUESTION Can a trace log go here?
 */
            Debuggler.DebugLog(abSession.DebugglerMode,Assembly.GetExecutingAssembly().GetName().Name);

            /* DEVELOPER_NOTE
             * These are the Quick Medication Order module settings that are created at runtime. There are also setting for the Progress Note module that are stored in
             * the local Web.config file that are loaded in Abatab.WebConfig.Load().
             */

            //abSession.ModQMedOrdr.

        }

        //private static void BuildModTesting(AbSession abSession, Dictionary<string)
        //{
        //    Debuggler.WriteLocal(Assembly.GetExecutingAssembly().GetName().Name);
        //}
    }
}