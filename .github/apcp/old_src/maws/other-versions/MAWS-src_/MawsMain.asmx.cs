

using MAWS.Configuration;
using MAWS.Logging;
using NTST.ScriptLinkService.Objects;
using System.Collections.Generic;
using System.Web.Services;

namespace MAWS
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MawsMain : WebService
    {
        // /// <summary>Returns the version of MAWS.</summary>
        // /// <returns>MAWS version.</returns>
        // [WebMethod]
        // public string GetVersion()
        // {
        //     return "VERSION 2.0";
        // }

        /// <summary>Executes a MAWS Request.</summary>
        /// <param name="sentOptObj">The OptionObject2015 sent from myAvatar.</param
        /// <param name="mawsRequest">The MAWS request to be executed.</param>
        /// <returns>Updated OptionObject2015.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptObj, string sentMawsRequest)
        {


            //var assemblyName = Assembly.GetExecutingAssembly().GetName().Name.ToLower();
            //var avatarUserName = sentOptObj.OptionUserId;
            LogEvent.Trace(assemblyName, avatarUserName);

            var workOptObj = new OptionObject2015();
            LogEvent.OptObj(assemblyName, avatarUserName, workOptObj, "Initial workOptObj:");



            LogEvent.Trace(assemblyName, avatarUserName);

            OptionObject2015 returnOptObj = MAWS.OptionObject.Finalize.FinalizeIt(sentOptObj, workOptObj);

            return returnOptObj;
        }
    }
}