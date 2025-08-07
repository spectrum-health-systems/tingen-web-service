// Copyright (c) A Pretty Cool Program
// See the LICENSE file for more information.
// b221012.150358

// Used?

using NTST.ScriptLinkService.Objects;

namespace AbatabOptionObject
{
    public static class Verify
    {
        /// <summary>Verify that the sentOptObj has not been modified.</summary>
        /// <param name="sentOptObj"></param>
        /// <param name="altOptObj"></param>
        public static bool NotModified(OptionObject2015 sentOptObj, OptionObject2015 altOptObj)
        {
            return altOptObj == sentOptObj;
        }
    }
}