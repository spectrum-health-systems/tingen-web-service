// MAWS - The myAvatool Web Service
// https://github.com/aprettycoolprogram/MAWS
// Copyright (C) 2015-2022 A Pretty Cool Program
// Licensed under Apache v2 (https://apache.org/licenses/LICENSE-2.0)

// OptionObject2015 specific stuff.
// b220121.094743

using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace MAWS
{
    public class OptObj
    {
        public static OptionObject2015 Finalize(OptionObject2015 sentOptObj, OptionObject2015 workOptObj)
        {
            var assemblyName   = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
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