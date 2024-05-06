using MediatR;
using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using System.Threading;
using System.Threading.Tasks;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
          var valuse = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = valuse.OrderDate,
                OrderingId = valuse.OrderingId,
                TotalPrice = valuse.TotalPrice,
                UserId = valuse.UserId  
            };
        }
    }
}
