// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.Data.Validate.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v0.60.0.0-b220509.093205

/* =============================================================================
 * About this class
 * =============================================================================
 */

namespace MAWS
{
    public class Validate
    {
        /// <summary>
        /// Validate the Avatar username.
        /// </summary>
        /// <param name="avatarUserName">The value of sentOptObj.OptionUserId.</param>
        /// <returns>A valid username.</returns>
        public static string AvatarUserName(string avatarUserName)
        {
            /* If the value in sentOptObj.OptionUserId isn't an actual username, make the username a catch-all.
             */
            return string.IsNullOrWhiteSpace(avatarUserName)
                ? Properties.Settings.Default.FallbackAvatarUserName
                : avatarUserName;
        }
    }
}