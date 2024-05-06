using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Features.CQRS.Queries.OrderQueries;
using ECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using ECommerce.Order.Application.Features.CQRS.Results.OrderDetailResult;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQuaryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQuaryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQuaryResult>> Handle()
        {
          var value =  await _repository.GetAllAsync();
            return value.Select(x => new GetOrderDetailQuaryResult
            {
                OrderingId = x.OrderingId,
                OrderDetailId = x.OrderDetailId,
                ProductAmout  = x.ProductAmout,
                ProductName = x.ProductName,
                ProductId = x.ProductId,
                ProductPrice = x.ProductPrice,
                ProductTotalPrice = x.ProductTotalPrice,
            }).ToList();
        }
    }
}
