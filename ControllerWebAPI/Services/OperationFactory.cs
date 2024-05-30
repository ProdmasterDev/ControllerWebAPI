using ControllerWebAPI.Operations;
using ControllerWebAPI.Requests;
using System.Net.NetworkInformation;
using Ping = ControllerWebAPI.Operations.Ping;

namespace ControllerWebAPI.Services
{
    public class OperationFactory
    {
        private readonly Dictionary<string, IOperation> _operations;
        private readonly NullOperation _nullOperation;
        public OperationFactory(PowerOn powerOn, Ping ping, CheckAccess checkAccess, Events events, NullOperation nullOperation) 
        {
            _nullOperation = nullOperation;
            _operations = new Dictionary<string, IOperation>()
            {
                {"power_on", powerOn },
                {"ping", ping },
                {"check_access", checkAccess },
                {"events", events }
            };
        }
        public IOperation GetOperationByControllerMessage(ControllerMessage controllerMessage)
        {
            if (controllerMessage.Operation == null) { return _nullOperation; }

            var keyValuePair = _operations.FirstOrDefault(o => o.Key.Equals(controllerMessage.Operation));
            if (keyValuePair.Key == null)
            {
                return _nullOperation;
            }

            return keyValuePair.Value;
        }
    }
}
