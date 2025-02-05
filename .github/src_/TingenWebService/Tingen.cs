using System.Reflection;

using RarelySimple.AvatarScriptLink.Objects;

namespace TingenWebService
{
    public class Tingen : ITingen
    {
        /// <summary>The executing Assembly name.</summary>
        /// <remarks>A required component for writing log files, defined here so it can be used throughout the class.</remarks>
        public static string ExeAsm { get; set; } = Assembly.GetExecutingAssembly().GetName().Name;

        /// <summary>The Tingen current version number.</summary>
        /// <include file='XmlDoc/TingenWebService.Tingen_doc.xml' path='TingenWebService.Tingen/Type[@name="Property"]/TingenVersionNumber/*'/>
        public static string TingenVersionNumber { get; set; } = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public string GetVersion() => $"VERSION {TingenVersionNumber}";

        public OptionObject2015 RunScript(OptionObject2015 optionObject, string parameter)
        {
            return optionObject.ToReturnOptionObject(ErrorCode.Alert, "Hello World!");
        }
    }
}
