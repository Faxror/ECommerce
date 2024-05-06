using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
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
    public class GetOrderDetailByIdQuaryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQuaryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery quary)
        {
            var valuse = await _repository.GetByIdAsync(quary.Id);
            return new GetOrderDetailByIdQueryResult
            {
                ProductName = valuse.ProductName,
                ProductAmout = valuse.ProductAmout,
                ProductPrice = valuse.ProductPrice,
                ProductTotalPrice = valuse.ProductTotalPrice,
                OrderDetailId = valuse.OrderDetailId,
                ProductId = valuse.ProductId,
                OrderingId = valuse.OrderingId,
            };
        }
    }
}
