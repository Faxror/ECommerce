using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    internal class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingRequest>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingRequest request, CancellationToken cancellationToken)
        {

            var valuse = await _repository.GetByIdAsync(request.OrderingId);

            valuse.UserId = request.UserId;
            valuse.OrderDate = request. OrderDate;
            valuse.TotalPrice = request.TotalPrice;
            await _repository.UpdateAsync(valuse);
        }
    }
}
