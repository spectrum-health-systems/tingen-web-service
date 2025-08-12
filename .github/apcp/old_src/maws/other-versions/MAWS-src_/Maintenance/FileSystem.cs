// ============================================================================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// ============================================================================================

// MAWS.Maintenance.FileSystem.cs
// File system logic.
// b220621.131338
// https://github.com/https://github.com/spectrum-health-systems/MAWS/tree/main/Documentation/Sourcecode/MAWS.FileSystem.md

using System.IO;

namespace MAWS
{
    public class FileSystem
    {
        /// <summary></summary>
        public static void VerifyDirectoryExists(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}