namespace MAWS.Utilities
{
    public class AvatarUserName
    {
        /// <summary>Validate the Avatar username.</summary>
        /// <param name="avatarUserName">The value of sentOptObj.OptionUserId.</param>
        /// <returns>A valid username.</returns>
        public static string ValidateUserName(string avatarUserName)
        {
            return string.IsNullOrWhiteSpace(avatarUserName)
                ? Properties.Settings.Default.FallbackAvatarUserName
                : avatarUserName;
        }
    }
}