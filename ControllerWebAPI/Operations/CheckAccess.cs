using ControllerDomain.Entities;
using ControllerWebAPI.Db;
using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ControllerWebAPI.Operations
{
    public class CheckAccess : IOperation
    {
        private readonly ControllerAppContext _dbContext;
        private readonly ILogger<CheckAccess> _logger;
        public CheckAccess(ControllerAppContext dbContext, ILogger<CheckAccess> logger)
        {
            _dbContext = dbContext; _logger = logger;
        }
        public async Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex)
        {
            var message = request.Messages[messageIndex];
            var serverMessage = new ServerMessage()
            {
                Id = message.Id,
                Operation = message.Operation,
                Granted = 0
            };

            if (message.Reader == null || message.Reader == 0)
                return serverMessage;

            var quickAccess = await _dbContext
                .Set<QuickAccess>()
                .AsNoTracking()
                .FirstOrDefaultAsync(qa =>
                    qa.Sn == request.Sn.ToString()
                    && qa.Reader == message.Reader
                    && qa.Card == message.Card);

            if (quickAccess is not null)
            {
                if (quickAccess.DateBlock == null || quickAccess.DateBlock.Value.ToLocalTime() < DateTime.Now)
                    serverMessage.Granted = quickAccess.Granted;
                return serverMessage;
            }
            
            return serverMessage;
        }
    }
}
