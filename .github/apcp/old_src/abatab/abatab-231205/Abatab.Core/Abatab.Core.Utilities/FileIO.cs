// b231205.1411

using System.IO;
using System.Threading;

namespace Abatab.Core.Utility
{
    /// <summary>
    /// Class summary goes here.
    /// </summary>
    public static class FileIO
    {
        /// <summary>
        /// Method summary goes here.
        /// </summary>
        public static void WriteLocal(string filePath,string fileContent,int writeDelay = 0)
        {
            Thread.Sleep(writeDelay);
            File.WriteAllText(filePath,fileContent);
        }
    }
}
