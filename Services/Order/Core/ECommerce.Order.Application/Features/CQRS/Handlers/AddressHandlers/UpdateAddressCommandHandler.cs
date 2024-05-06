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
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAddressCommand command)
        {
            var valuse = await _repository.GetByIdAsync(command.AddressId);
           
            valuse.UserId = command.UserId;
            valuse.Disctrick = command.Disctrick;
            valuse.City = command.City;
            valuse.Detail = command.Detail;
            await _repository.UpdateAsync(valuse);
        }
    }
}
