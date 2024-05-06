using ECommerce.Cargo.BusinessLayer.Abstrack;
using ECommerce.Cargo.DtoLayer.CargoDetailDto;
using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService cargoDetailService;

        public CargoDetailController(ICargoDetailService cargoDetailService)
        {
            this.cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList() 
        { 
           var valuse =  cargoDetailService.TgetAllList();
            return Ok(valuse);
        }

        [HttpGet("{ıd}")]
        public IActionResult CargoDetailByİdList(int id)
        {
            var valuse = cargoDetailService.TGetById(id);
            return Ok(valuse);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
             CargoDetail cargoDetail = new CargoDetail();
             cargoDetail.SenderCustomer = createCargoDetailDto.SenderCustomer;
             cargoDetail.ReceiverCustomer = createCargoDetailDto.ReceiverCustomer;
             cargoDetail.Barcode = createCargoDetailDto.Barcode;
             cargoDetail.CargoCompanyID = createCargoDetailDto.CargoCompanyID;
             cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayları başarılı şekilde eklendi");
        }


        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail();
            cargoDetail.SenderCustomer = updateCargoDetailDto.SenderCustomer;
            cargoDetail.ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer;
            cargoDetail.Barcode = updateCargoDetailDto.Barcode;
            cargoDetail.CargoCompanyID = updateCargoDetailDto.CargoCompanyID;
            cargoDetail.CargoDetailId = updateCargoDetailDto.CargoDetailId;
            cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayları başarılı şekilde güncellendi");
        }


        [HttpDelete]
        public IActionResult UpdateCargoDetail(int id)
        {

            cargoDetailService.TDelete(id);
            return Ok("Kargo detayları başarılı şekilde silindi");
        }

    }
}
