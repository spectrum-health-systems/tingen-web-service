// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
// Abatab v23.7.0.0
// A custom web service/framework for myAvatar.
// https://github.com/spectrum-health-systems/Abatab
// Copyright (c) A Pretty Cool Program. All rights reserved.
// Licensed under the Apache 2.0 license.
// =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=

using ScriptLinkStandard.Objects;

namespace ScriptLinkStandard.Interfaces
{
    public interface IScriptLink
    {
        OptionObject ProcessScript(IOptionObject optionObject, string parameter);
        OptionObject2 ProcessScript(IOptionObject2 optionObject, string parameter);
        OptionObject2015 ProcessScript(IOptionObject2015 optionObject, string parameter);
    }
}