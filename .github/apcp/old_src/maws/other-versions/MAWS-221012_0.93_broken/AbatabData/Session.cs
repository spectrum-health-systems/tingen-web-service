// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using NTST.ScriptLinkService.Objects;

namespace AbatabData
{
    /// <summary>
    /// Defines the properties for the AbatabData.Session object, containing the information/data that Abatab needs to do its job.
    /// </summary>
    public class Session
    {
        // Web.config: General
        public string AbatabVer { get; set; }
        public string AbatabMode { get; set; }
        public string AbatabRoot { get; set; }
        public string DebugMode { get; set; }
        public string DebugLogRoot { get; set; }
        public string LoggingMode { get; set; }
        public string LoggingDetail { get; set; }
        public string LoggingDelay { get; set; }
        public string AvatarFallbackUserName { get; set; }

        // Web.config: ModQuickMedOrder
        public string ModQuickMedOrderMode { get; set; }
        public string ModQuickMedOrderValidUsers { get; set; }
        public string ModQuickMedOrderDosePercentMaxInc { get; set; }

        // Set at runtime: ModQuickMedOrder
        public QuickMedOrder ModQuickMedOrderData { get; set; }

        // Web.config: ModPrototype
        public string ModPrototypeMode { get; set; }

        // Web.config: ModTesting
        public string ModTestingMode { get; set; }

        // Set at runtime: General
        public string SessionDate { get; set; }
        //public string SessionTime { get; set; }
        public string SessionLogRoot { get; set; }
        public string AvatarUserName { get; set; }
        public string AvatarSystemCode { get; set; }
        public string ScriptParameter { get; set; }
        public string AbatabModule { get; set; }
        public string AbatabCommand { get; set; }
        public string AbatabAction { get; set; }
        public string AbatabOption { get; set; }

        // Set at runtime: OptionObject details
        public OptionObject2015 SentOptObj { get; set; }
        public OptionObject2015 WorkOptObj { get; set; }
        public OptionObject2015 FinalOptObj { get; set; }
    }

    ///// <summary>
    ///// Defines the properties for the AbatabData.QuickMedOrderData object,
    ///// containing the information needed for ModQuickMedOrder functionality.
    ///// </summary>
    //public class QuickMedOrder
    //{
    //    public string PrevDosePrefix { get; set; }
    //    public string PrevDoseSuffix { get; set; }
    //    public string DosageOneFieldId { get; set; }
    //    public bool FoundDosageOneFieldId { get; set; }
    //    public string CurrentDose { get; set; }
    //    public string OrderTypeFieldId { get; set; }
    //    public bool FoundOrderTypeFieldId { get; set; }
    //    public string OrderType { get; set; }
    //    public string LastOrderScheduleFieldId { get; set; }
    //    public bool FoundLastOrderScheduleFieldId { get; set; }
    //    public string LastOrderScheduleText { get; set; }
    //    public bool FoundAllRequiredFieldIds { get; set; }
    //}
}