/* PROJECT: Utility (https://github.com/aprettycoolprogram/Utility)
 *    FILE: Utility.ExternalConfiguration.cs
 * UPDATED: 1-15-2022-5:52 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

/* Loads MAWS settings from an external file.
 */

using System.Collections.Generic;
using System.IO;

namespace Utility
{
    public class ExternalConfiguration
    {
        // =============================
        // MODIFIY FOR YOUR ORGANIZATION
        // =============================
        /* MAWS uses an external configuration file ("MAWS.conf"), and for the most part each MAWS component also has
         * it's own external configuration file (e.g, "Dose.conf"). All configuration  files are located in the same
         * location.
         */
        public static string ConfigurationDirectory = $@"C:\MAWS\Configurations\";

        /// <summary>Loads configuration values from a file with key/value pairs.</summary>
        /// <param name="fileName">Name of the configuration file.</param>
        /// <returns>A dictionary with the configuration values.</returns>
        public static Dictionary<string, string> FromKeyValuePairFile(string fileName)
        {

            var filePath = $"{ConfigurationDirectory}{fileName}";
            List<string> settingsAsList = SettingsAsList(filePath);

            return SettingsAsDictionary(settingsAsList);
        }

        /// <summary>
        /// Put valid setting lines from the a .settings file into a list.
        /// </summary>
        /// <param name="filePath">Path to the settings file.</param>
        /// <returns>A list with valid key/value pair setting lines.</returns>
        public static List<string> SettingsAsList(string filePath)
        {
            var fileAsList = new List<string>();

            var test = File.Exists(filePath);

            if(File.Exists(filePath))
            {
                var fileStream = new StreamReader(filePath);
                var fileLine   = "";

                using(fileStream)
                {
                    while((fileLine = fileStream.ReadLine()) != null)
                    {
                        fileLine = fileLine.Trim();

                        var lineContainsData   = !string.IsNullOrWhiteSpace(fileLine);
                        var lineIsNotComment   = !fileLine.StartsWith("#");
                        var lineIsKeyValuePair = fileLine.Contains("=");

                        if(lineContainsData && lineIsNotComment && lineIsKeyValuePair)
                        {
                            fileAsList.Add(fileLine);
                        }
                    }
                }
            }

            return fileAsList;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="fileAsList"></param>
        /// <returns></returns>
        public static Dictionary<string, string> SettingsAsDictionary(List<string> fileAsList)
        {
            string[] keyValuePair;
            var settingPairs = new Dictionary<string, string>();

            foreach(var item in fileAsList)
            {
                keyValuePair = item.Split('=');
                settingPairs.Add(keyValuePair[0], keyValuePair[1]);
            }

            return settingPairs;
        }
    }
}

/* =================
 * DEVELOPMENT NOTES
 * =================
 */