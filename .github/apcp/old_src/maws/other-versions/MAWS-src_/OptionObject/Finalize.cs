// =========================================[ PROJECT ]=========================================
// MAWS: MyAvatar Web Service
// A custom web service for Netsmart's myAvatar™ EHR.
// https://github.com/spectrum-health-systems/MAWSC)
// Apache v2 (https://apache.org/licenses/LICENSE-2.0)
// Copyright 2021-2022 A Pretty Cool Program
// =============================================================================================

// -----------------------------------------[ CLASS ]-------------------------------------------
// MAWS.OptionObject.Finalize.cs
// Logic for finalizing OptionObject2015 objects.
// bb220714.075906
// https://github.com/spectrum-health-systems/MAWS/blob/main/Documentation/Sourcecode/MAWS-Sourcecode.md
// ---------------------------------------------------------------------------------------------

using MAWS.Logging;
using NTST.ScriptLinkService.Objects;
using System.Reflection;

namespace MAWS.OptionObject
{
    public class Finalize
    {
        public static OptionObject2015 FinalizeIt(OptionObject2015 sentOptObj, OptionObject2015 workOptObj)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            LogEvent.Trace(assemblyName, avatarUserName);

            var sentOptObjLogMessage = "Final sentOptObj:";
            LogEvent.OptObj(assemblyName, avatarUserName, sentOptObj, sentOptObjLogMessage);

            /* Minimum things that need to be set. Notice that ErrorCode and ErrorMesg come from workOptObj, and the
             * rest come from sentOptObj.
             */
            var returnOptObj = new OptionObject2015
            {
                EntityID        = sentOptObj.EntityID,
                EpisodeNumber   = sentOptObj.EpisodeNumber,
                ErrorCode       = workOptObj.ErrorCode,
                ErrorMesg       = workOptObj.ErrorMesg,
                Facility        = sentOptObj.Facility,
                NamespaceName   = sentOptObj.NamespaceName,
                OptionId        = sentOptObj.OptionId,
                OptionStaffId   = sentOptObj.OptionStaffId,
                OptionUserId    = sentOptObj.OptionUserId,
                ParentNamespace = sentOptObj.ParentNamespace,
                ServerName      = sentOptObj.ServerName,
                SystemCode      = sentOptObj.SystemCode,
            };

            var returnOptObjLogMessage = "Final returnOptObj:";
            LogEvent.OptObj(assemblyName, avatarUserName, returnOptObj, returnOptObjLogMessage);

            return returnOptObj;
        }
    }
}