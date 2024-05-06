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
    public class GetAddressQuaryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQuaryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var valuse = await _repository.GetAllAsync();
            return valuse.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                Disctrick = x.Disctrick,
                UserId = x.UserId
            }).ToList();
        }
    }
}
