using ControllerDomain.Entities;
using ControllerWebAPI.Controllers;
using ControllerWebAPI.Db;
using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using DB = ControllerDomain.Entities;
using Location = ControllerDomain.Entities.ControllerLocation;
using CultInf = System.Globalization.CultureInfo;

namespace ControllerWebAPI.Operations
{
    public class Events : IOperation
    {
        private readonly ControllerAppContext _dbContext;
        private readonly ILogger<IOperation> _logger;
        public Events(ControllerAppContext dbContext, ILogger<Events> logger) { _dbContext = dbContext; _logger = logger; }
        public async Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex)
        {
            var message = request.Messages[messageIndex];
            var serverMessage = new ServerMessage()
            {
                Id = message.Id,
                Operation = message.Operation,
                EventsSuccess = message.Last_event!.Value
            };

            var controllerLocation = await _dbContext
                .Set<Location>()
                .Include(x => x.Controller)
                .FirstOrDefaultAsync(x => x.Controller != null && x.Controller.Sn.Equals(request.Sn.ToString()));

            if (controllerLocation == null)
                return serverMessage;

            var events = await _dbContext
                .Set<EventType>()
                .ToListAsync();

            foreach (var ev in message.Events)
            {
                var card = await _dbContext
                    .Set<DB.Card>()
                    .Include(x => x.Worker)
                    .FirstOrDefaultAsync(c => c.CardNumb16 == ev.Card);

                var worker = (card == null) ? null : card.Worker;

                var eventType = events.FirstOrDefault(e => e.Id == ev.Event);

                var entity = new DB.Event()
                {
                    ControllerLocation = controllerLocation,
                    EventType = eventType,
                    Worker = worker,
                    Card = ev.Card ?? string.Empty,
                    Create = DateTime.ParseExact(ev.Time ?? "2000-01-01 12:00:00",
                        "yyyy-MM-dd HH:mm:ss",
                        CultInf.InvariantCulture).ToUniversalTime(),
                    Flag = ev.Flag,
                };

                _dbContext.Add(entity);
            }

            await _dbContext.SaveChangesAsync();

            return serverMessage;
        }
    }
}
