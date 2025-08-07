/* ========================== https://github.com/spectrum-health-systems/Abatab ===========================
 * Abatab                                                                                           v0.92.0
 * ModuleDose.csproj                                                                                v0.92.0
 * DosePercent.cs                                                                            b221010.124123
 * --------------------------------------------------------------------------------------------------------
 *
 * ================================= (c)2016-2022 A Pretty Cool Program ================================ */

using AbatabData;
using AbatabLogging;
using System.Reflection;

namespace ModuleDose
{
    public class Percentage
    {
        /// <summary></summary>
        /// <param name="abatabSession"></param>
        public static void VerifyUnderMaxInc(SessionData abatabSession)
        {
            Debugger.BuildDebugLog(Assembly.GetExecutingAssembly().GetName().Name, abatabSession.DebugMode, abatabSession.DebugLogRoot, "[DEBUG] Parsing Abatab request..");
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            InitializeData(abatabSession);

            AbatabOptionObject.WorkObj.ClearErrorData(abatabSession);

            LogEvent.ModQuickMedOrder(abatabSession);

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        /// <summary></summary>
        /// <returns></returns>
        private static void InitializeData(SessionData abatabSession)
        {
            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);

            abatabSession.ModQuickMedOrderData.DosageOneFieldId              = "107";
            abatabSession.ModQuickMedOrderData.FoundDosageOneFieldId         = false;
            abatabSession.ModQuickMedOrderData.CurrentDose                   = "0.0";
            abatabSession.ModQuickMedOrderData.OrderTypeFieldId              = "121";
            abatabSession.ModQuickMedOrderData.FoundOrderTypeFieldId         = false;
            abatabSession.ModQuickMedOrderData.OrderType                     = "0";
            abatabSession.ModQuickMedOrderData.LastOrderScheduleFieldId      = "142";
            abatabSession.ModQuickMedOrderData.FoundLastOrderScheduleFieldId = false;
            abatabSession.ModQuickMedOrderData.LastOrderScheduleText         = "";
            abatabSession.ModQuickMedOrderData.FoundAllRequiredFieldIds      = false;

            LogEvent.Trace(abatabSession, Assembly.GetExecutingAssembly().GetName().Name);
        }

        private static void UpdateWorkOptObj()
        {

        }
    }
}
