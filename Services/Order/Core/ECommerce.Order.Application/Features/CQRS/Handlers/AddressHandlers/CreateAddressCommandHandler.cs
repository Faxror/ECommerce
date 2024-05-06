using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                 City = createAddressCommand.City,
                 Detail = createAddressCommand.Detail,
                 Disctrick = createAddressCommand.Disctrick,
                 UserId = createAddressCommand.UserId,
            });
        } 
    }
}
