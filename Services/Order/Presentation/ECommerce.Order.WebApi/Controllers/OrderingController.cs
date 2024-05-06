using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderingList()
        {
            var valuse = await _mediator.Send(new GetOrderingQuery());
            return Ok(valuse);
        }
        [HttpGet("{ıd}")]
        public async Task<IActionResult> GetByIdOrderingList(int id)
        {
            var valuse = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(valuse);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarılı şekilde eklendi");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingRequest(id));
            return Ok("Sipariş başarılı şekilde silindi");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingRequest command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarılı şekilde güncellendi");
        }
    }
}
