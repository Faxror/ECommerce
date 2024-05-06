using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderDetailCommand removeOrderDetailCommand)
        {
            var value = await _repository.GetByIdAsync(removeOrderDetailCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
