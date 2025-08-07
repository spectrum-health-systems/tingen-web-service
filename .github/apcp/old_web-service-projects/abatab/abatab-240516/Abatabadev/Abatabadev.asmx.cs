// ================================================================= v24.5 =====
// Abatabadev: The development version of Abatab.
// https://github.com/spectrum-health-systems/Abatabadev
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// ================================================================ 240430 =====

// 240517.1345

/* =========
 * HEADS UP!
 * =========
 *
 * This is a development version of Abatab, and is not intended for use in production environments!
 *
 * For production environments, please see the Abatab Community Release:
 *  https://github.com/spectrum-health-systems/Abatab-Community-Release
 *
 * For more information about Abatab, please visit the The Abatab Documenation Project:
 *  https://github.com/spectrum-health-systems/Abatab-Documentation-Project
 *
 * For more information about web services and Avatar, please visit myAvatar Developer Community:
 *  https://github.com/myAvatar-Development-Community
 */

using System.Reflection;
using System.Web.Services;

using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;

using System.Configuration;

using System.Reflection;
using System.Web.Services;
using Abatab.Core.Catalog.Definition;
using Abatab.Core.Utility;
using NuGet.Configuration;
using ScriptLinkStandard.Objects;

namespace Abatabadev
{
    /// <summary>The entry class for Abatab.</summary>
    /// <remarks>
    /// - This class is designed to be static, and should not be modified.
    /// </remarks>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Abatab : WebService
    {

        /// <summary>The starting method for Abatab.</summary>
        /// <param name="sentOptionObject">The OptionObject sent from myAvatar.</param>
        /// <param name="sentScriptParameter">The Script Parameter sent from myAvatar.</param>
        /// <remarks>
        ///     - This method is required by Avatar.
        /// </remarks>
        /// <returns>The finalized OptionObject to myAvatar.</returns>
        [WebMethod]
        public OptionObject2015 RunScript(OptionObject2015 sentOptionObject, string sentScriptParameter)
        {
            //Debuggler.DebugLog(Settings.Default.DebugglerMode, Assembly.GetExecutingAssembly().GetName().Name);

            AbSession abSession = new AbSession();

            if (Properties.Settings.Default.AbatabMode == "enabled")
            {
                Start.NewSession(abSession, sentScriptParameter, sentOptionObject);

                ParseModule.SendToModule(abSession);

                Stop.ExistingSession(abSession);
            }
            else
            {
                Debuggler.PrimevalLog("disabled");
            }

            return abSession.ReturnOptionObject;
        }
    }
}
