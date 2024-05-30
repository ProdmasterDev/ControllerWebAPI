using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;

namespace ControllerWebAPI.Operations
{
    public interface IOperation
    {
        Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex);
    }
}
