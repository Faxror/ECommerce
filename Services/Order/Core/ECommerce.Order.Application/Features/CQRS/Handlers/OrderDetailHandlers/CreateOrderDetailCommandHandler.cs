using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
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
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand createAddressCommand)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                ProductName = createAddressCommand.ProductName,
                ProductPrice = createAddressCommand.ProductPrice,
                ProductId = createAddressCommand.ProductId,
                ProductAmout = createAddressCommand.ProductAmout,
                ProductTotalPrice = createAddressCommand.ProductTotalPrice,
                OrderingId = createAddressCommand.OrderingId,
            });
        }
    }
}
