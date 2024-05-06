using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using ECommerce.Order.Application.Features.CQRS.Queries.OrderQueries;
using ECommerce.Order.Application.Features.CQRS.Results.OrderDetailResult;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQuaryHandler getOrderDetailQuaryHandler;
        private readonly GetOrderDetailByIdQuaryHandler getOrderDetailByIdQuaryHandler;
        private readonly CreateOrderDetailCommandHandler createOrderDetailCommand;
        private readonly RemoveOrderDetailCommandHandler removeOrderDetailCommand;
        private readonly UpdateOrderDetailCommandHandler updateOrderDetailCommand;

        public OrderDetailController(GetOrderDetailQuaryHandler getOrderDetailQuaryHandler, GetOrderDetailByIdQuaryHandler getOrderDetailByIdQuaryHandler, CreateOrderDetailCommandHandler createOrderDetailCommand, RemoveOrderDetailCommandHandler removeOrderDetailCommand, UpdateOrderDetailCommandHandler updateOrderDetailCommand)
        {
            this.getOrderDetailQuaryHandler = getOrderDetailQuaryHandler;
            this.getOrderDetailByIdQuaryHandler = getOrderDetailByIdQuaryHandler;
            this.createOrderDetailCommand = createOrderDetailCommand;
            this.removeOrderDetailCommand = removeOrderDetailCommand;
            this.updateOrderDetailCommand = updateOrderDetailCommand;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailLst()
        {
            var valuse = await getOrderDetailQuaryHandler.Handle();
            return Ok(valuse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetailListById(int id)
        {
            var valuse = await getOrderDetailByIdQuaryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand create)
        {
            await createOrderDetailCommand.Handle(create);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await removeOrderDetailCommand.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Başarılı şekilde silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommands)
        {
            await updateOrderDetailCommand.Handle(updateOrderDetailCommands);
            return Ok("Başarılı şekilde güncenllendi");
        }
    }
}
