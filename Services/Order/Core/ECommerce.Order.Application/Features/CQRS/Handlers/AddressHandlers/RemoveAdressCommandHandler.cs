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
    public class RemoveAdressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public RemoveAdressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand removeAddressCommand)
        {
            var value = await _repository.GetByIdAsync(removeAddressCommand.Id);
            await _repository.DeleteAsync(value);
        }
    }
}
