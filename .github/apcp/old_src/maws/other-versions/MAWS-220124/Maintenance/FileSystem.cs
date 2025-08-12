// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// File system things.
// b220121.094731

using System.IO;

namespace MAWS
{
    public class FileSystem
    {
        /// <summary>
        /// 
        /// </summary>
        public static void VerifyDirectoryExists(string directoryPath)
        {
            if(!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}