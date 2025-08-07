// b231205.1411

using System;
using System.Collections.Generic;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class ConvertCollection
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static List<string> ArrayToList(string[] arrayToConvert)
        {
            var list = new List<string>();

            foreach (var item in arrayToConvert)
            {
                list.Add(item);
            }

            return list;
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string ListToString(List<string> listToConvert)
        {
            /* QUESTION
             * Do we need this abstraction?
             */
            return string.Join(", ",listToConvert);
        }

        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static string ListToNewLineString(List<string> listToConvert)
        {
            var toReturn = "";

            foreach (var item in listToConvert)
            {
                toReturn += $"{item}{Environment.NewLine}";
            }

            return toReturn;
        }
    }
}