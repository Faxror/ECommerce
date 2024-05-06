using ECommerce.Cargo.BusinessLayer.Abstrack;
using ECommerce.Cargo.DtoLayer.CargoDetailDto;
using ECommerce.Cargo.DtoLayer.CargoOperationDto;
using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService cargoOperationService;

        public CargoOperationController(ICargoOperationService cargoOperationService)
        {
            this.cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var valuse = cargoOperationService.TgetAllList();
            return Ok(valuse);
        }

        [HttpGet("{ıd}")]
        public IActionResult CargoOperationByİdList(int id)
        {
            var valuse = cargoOperationService.TGetById(id);
            return Ok(valuse);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperation)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation.Barcode = createCargoOperation.Barcode;
            cargoOperation.Description = createCargoOperation.Description;
            cargoOperation.OperationDate = createCargoOperation.OperationDate;
            cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo detayları başarılı şekilde eklendi");
        }


        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation();
            cargoOperation.Barcode = updateCargoOperationDto.Barcode;
            cargoOperation.Description = updateCargoOperationDto.Description;
            cargoOperation.CargoOperationId = updateCargoOperationDto.CargoOperationId;
            cargoOperation.OperationDate = updateCargoOperationDto.OperationDate;
            cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo detayları başarılı şekilde güncellendi");
        }


        [HttpDelete]
        public IActionResult UpdateCargoOperation(int id)
        {

            cargoOperationService.TDelete(id);
            return Ok("Kargo detayları başarılı şekilde silindi");
        }

    }
}
