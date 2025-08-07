// PROJECT: MAWS (https://github.com/spectrum-health-systems/MAWS)
//    FILE: MAWS.OptionObject.Finalize.cs
// UPDATED: 5-09-2022
// LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
//          Copyright 2021 A Pretty Cool Program

// v0.60.0.0-b220509.093205

/* =============================================================================
 * About this class
 * =============================================================================
 */

using System.Reflection;
using NTST.ScriptLinkService.Objects;

namespace MAWS
{
    public class Finalize
    {
        public static OptionObject2015 FinalizeIt(OptionObject2015 sentOptObj, OptionObject2015 workOptObj)
        {
            var assemblyName   = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            var avatarUserName = sentOptObj.OptionUserId;
            MawsEvent.Trace(assemblyName, avatarUserName);

            var sentOptObjLogMessage = "Final sentOptObj:";
            MawsEvent.OptObj(assemblyName, avatarUserName, sentOptObj, sentOptObjLogMessage);

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
            MawsEvent.OptObj(assemblyName, avatarUserName, returnOptObj, returnOptObjLogMessage);

            return returnOptObj;
        }
    }
}