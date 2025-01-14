using ControllerDomain.Entities;
using ControllerWebAPI.Db;
using ControllerWebAPI.Dto;
using ControllerWebAPI.Requests;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ControllerWebAPI.Operations
{
    public class Ping : IOperation
    {
        private readonly ControllerAppContext _dbContext;
        public Ping(ControllerAppContext dbContext) { _dbContext = dbContext; }
        public async Task<ServerMessage?> ProcessAndGetMessage(ControllerRequest request, int messageIndex)
        {
            var message = request.Messages[messageIndex];

            var controller = await _dbContext.Set<Controller>().FirstOrDefaultAsync(c => c.Sn == request.Sn.ToString());
            if (controller != null)
            {
                controller.LastPing = DateTime.UtcNow;
                _dbContext.Update(controller);
                await _dbContext.SaveChangesAsync();
            }
            if (request.Messages.FirstOrDefault(x => x.Operation != null && x.Operation.Equals("check_access")) != null)
            {
                return null;
            }
            var mes = await _dbContext.Set<Message>().Where(x => !x.IsComplited).Include(x => x.Operation).Include(x => x.Cards.Where(y => !y.IsLoaded).Take(1)).OrderBy(x => x.Create).FirstOrDefaultAsync();
            if (mes == null || mes.Operation == null)
            {
                return null;
            }
            var rand = new Random();
            var randomId = rand.Next(100000000, 999999999);
            var serverMessage = new ServerMessage()
            {
                Id = randomId
            };
            if (mes.Operation.OperationCode != "add_cards" && mes.Operation.OperationCode != "del_cards")
            {
                serverMessage.Operation = mes.Operation.OperationCode;
                return serverMessage;
            }

            //serverMessage.Cards(); 

            var cards = await _dbContext
                .Set<Message>()
                .Where(x => !x.IsComplited && x.Id == mes.Id)
                .Include(x => x.Cards)
                    .ThenInclude(x => x.Card)
                .SelectMany(x => x.Cards.Where(c => !c.IsLoaded))
                .Take(10)
                .ToListAsync() ;
            if (cards.Count == 0)
            {
                mes.IsComplited = true;
                _dbContext.Update(mes);
                await _dbContext.SaveChangesAsync();
                return null;
            }
            foreach (var card in cards)
            {
                serverMessage.Cards.Add(new Dto.Card
                {
                    Name = card.Card.CardNumb16,
                    Flags = 0,
                    Tz = 255
                });
                card.IsLoaded = true;
                _dbContext.Update(card);
            }
            serverMessage.Operation = mes.Operation.OperationCode;
            await _dbContext.SaveChangesAsync();
            return serverMessage;
        }
    }
}
