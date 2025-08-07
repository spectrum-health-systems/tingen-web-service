/* PROJECT: MyAvatoolWebService (https://github.com/aprettycoolprogram/MyAvatoolWebService)
 *    FILE: MyAvatoolWebService.MyAvatoolWebService.asmx.cs
 * UPDATED: 1-15-2022-8:00 PM
 * LICENSE: Apache v2 (https://apache.org/licenses/LICENSE-2.0)
 *          Copyright 2022 A Pretty Cool Program All rights reserved
 */

using System;
using System.IO;
using System.Web.Services;
using NTST.ScriptLinkService.Objects;

namespace MyAvatoolWebService
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class MyAvatoolWebService : WebService
    {

        [WebMethod]
        public string GetVersion()
        {
            return "VERSION 1.0";
        }

        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string mawsRequest)
        {
/*             var dateStamp = DateTime.Now.ToString("yyMMdd");
            var timeStamp = DateTime.Now.ToString($"HHmmss.fffffff");
            var userName = sentOptionObject.OptionUserId;
            File.WriteAllText($@"C:\MAWS\temp_prod\{dateStamp}-{timeStamp}_p.{userName}", "temp_prod"); */

            var finalOptionObject = new OptionObject2015();

            OptionObject2015 errUpdate = new OptionObject2015
            {
                ErrorCode=0,
                ErrorMesg=""

            };

            finalOptionObject = TheOptionObject.Finalize.WhichComponents(sentOptionObject, errUpdate);


            return finalOptionObject;
        }
    }
}