using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using ECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQuaryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQuaryHandler(IRepository<Address> repository)
        {
            this._repository = repository;
        }
        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery quary)
        {
            var valuse = await _repository.GetByIdAsync(quary.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = valuse.AddressId,
                City = valuse.City,
                Disctrick = valuse.Disctrick,
                Detail = valuse.Detail,
                UserId = valuse.UserId,
            };
        }
    }
}
