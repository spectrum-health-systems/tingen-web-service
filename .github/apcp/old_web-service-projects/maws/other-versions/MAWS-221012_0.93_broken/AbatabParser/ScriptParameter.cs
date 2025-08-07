using System.Collections.Generic;

namespace AbatabParser
{
    /// <summary>
    /// 
    /// </summary>
    public class ScriptParameter
    {
        /// <summary>
        /// Parses the abatabRequest into separate components.
        /// </summary>

        public static Dictionary<string, string> Parse(string scriptParameter)
        {
            //TODO Debug statements

            string[] components = scriptParameter.Split('-');

            if (components.Length < 4)
            {
                components[3] = "undefined";
            }

            return new Dictionary<string, string>
            {
                { "AbatabModule",  components[0].Trim().ToLower()},
                { "AbatabCommand", components[1].Trim().ToLower() },
                { "AbatabAction",  components[2].Trim().ToLower() },
                { "AbatabOption",  components[3].Trim().ToLower() },
            };
        }
    }
}
