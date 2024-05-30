using ControllerDomain.Entities;
using ControllerWebAPI.Db;
using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ControllerWebAPI.Operations
{
    public class PowerOn : IOperation
    {
        private readonly ControllerAppContext _dbContext;
        public PowerOn(ControllerAppContext dbContext) { _dbContext = dbContext; }
        public async Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex)
        {
            var message = request.Messages[messageIndex];

            var serverMessage = new ServerMessage()
            {
                Id = message.Id,
                Operation = "set_active",
                Active = 1,
                Online = 1
            };

            var controller = await _dbContext.Set<Controller>().FirstOrDefaultAsync(c => c.Sn == request.Sn.ToString());
            if (controller == null)
            {
                controller = new Controller()
                {
                    Sn = request.Sn.ToString(),
                    Type = request.Type,
                    FwVer = message.Fw ?? "",
                    ComFwVer = message.Conn_fw ?? "",
                    IpAddress = message.Controller_ip ?? "",
                    LastPowerOn = DateTime.Now.ToUniversalTime()
            };
                _dbContext.Add(controller);
            }
            else
            {
                controller.Type = request.Type;
                controller.FwVer = message.Fw ?? "";
                controller.ComFwVer = message.Conn_fw ?? "";
                controller.IpAddress = message.Controller_ip ?? "";
                controller.LastPowerOn = DateTime.Now.ToUniversalTime();
                _dbContext.Update(controller);
            }

            await _dbContext.SaveChangesAsync();

            return serverMessage;
        }
    }
}
