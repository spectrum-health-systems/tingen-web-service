// Du
// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

using System.IO;

namespace Du
{
    /// <summary></summary>
    public class WithDirectory
    {
        /// <summary>
        /// Verifies directory exists, and create if not.
        /// </summary>
        public static void VerifyDir(string dir)
        {
            _=Directory.CreateDirectory(dir);
        }
    }
}
