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
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var vales = await _repository.GetByIdAsync(command.OrrdeDetailId);
          
                vales.ProductName = command.ProductName;
                vales.ProductPrice = command.ProductPrice;
                vales.ProductTotalPrice = command.ProductTotalPrice;
                vales.ProductAmout =    command.ProductAmout;
                vales.ProductId = command.ProductId;
                vales.OrderingId = command.OrderingId;
               await _repository.UpdateAsync(vales); 

            
        }
    }
}
