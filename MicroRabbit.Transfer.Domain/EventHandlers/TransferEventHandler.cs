using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Domain.EventHandlers
{
    public class TransferEventHandler : IEventHandler<TransferCreatedEvent>
    {
        private readonly ITransferRepository _repo;

        public TransferEventHandler(ITransferRepository repo)
        {
            _repo = repo;
        }

        public Task Handle(TransferCreatedEvent @event)
        {
            _repo.Add(new TransferLog()
            {
                FromAccount = @event.From,
                ToAccount = @event.To,
                TransferAmount = @event.Amount,
                TransferTime = DateTime.Now
            });
            return Task.CompletedTask;
        }
    }
}
