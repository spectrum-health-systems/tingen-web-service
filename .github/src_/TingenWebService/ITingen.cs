using RarelySimple.AvatarScriptLink.Objects;

using System.ServiceModel;


namespace TingenWebService
{
        [ServiceContract]
        public interface ITingen
        {
            [OperationContract]
            string GetVersion();

            [OperationContract]
            OptionObject2015 RunScript(OptionObject2015 optionObject, string parameter);
        }
}
