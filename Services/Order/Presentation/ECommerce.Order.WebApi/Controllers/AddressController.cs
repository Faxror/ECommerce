using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using ECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly GetAddressQuaryHandler queryResult;
        private readonly GetAddressByIdQuaryHandler queryResultById;
        private readonly CreateAddressCommandHandler createAddressCommandHandler;
        private readonly RemoveAdressCommandHandler removeAdressCommandHandler;
        private readonly UpdateAddressCommandHandler updateAddressCommandHandler;

        public AddressController(GetAddressQuaryHandler queryResult, GetAddressByIdQuaryHandler queryResultById, UpdateAddressCommandHandler updateAddressCommandHandler = null, RemoveAdressCommandHandler removeAdressCommandHandler = null, CreateAddressCommandHandler createAddressCommandHandler = null)
        {
            this.queryResult = queryResult;
            this.queryResultById = queryResultById;
            this.updateAddressCommandHandler = updateAddressCommandHandler;
            this.removeAdressCommandHandler = removeAdressCommandHandler;
            this.createAddressCommandHandler = createAddressCommandHandler;
        }

        [HttpGet]
        public  async Task<IActionResult> AddressList()
        {
            var valuse = await queryResult.Handle();
            return Ok(valuse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressListById(int id)
        {
            var valuse = await queryResultById.Handle(new GetAddressByIdQuery(id));
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand create)
        {
           await createAddressCommandHandler.Handle(create);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await removeAdressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Başarılı şekilde silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
        {
            await updateAddressCommandHandler.Handle(updateAddressCommand);
            return Ok("Başarılı şekilde güncenllendi");
        }
    }
}
