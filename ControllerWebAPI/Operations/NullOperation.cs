using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;

namespace ControllerWebAPI.Operations
{
    public class NullOperation : IOperation
    {
        public async Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex)
        {
            return null;
        }
    }
}
