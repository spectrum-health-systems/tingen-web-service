// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

namespace ModCommon
{
    public class Verify
    {
        /// <summary></summary>
        /// <param name="userName"></param>
        /// <param name="validUsers"></param>
        /// <returns></returns>
        public static bool ValidUser(string userName, string validUsers)
        {
            return validUsers.Trim().ToLower() == "all" || validUsers.ToLower().Contains(userName.ToLower());
        }
    }
}
