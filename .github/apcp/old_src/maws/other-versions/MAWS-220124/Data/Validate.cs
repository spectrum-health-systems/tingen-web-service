// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// Validate different data.
// b220121.094650

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