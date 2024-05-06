using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Cargo.BusinessLayer.Abstrack;
using ECommerce.Cargo.EntityLayer.Concrete;
using ECommerce.Cargo.DtoLayer.CargoCompanyDto;
using Microsoft.AspNetCore.Authorization;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCustomerService cargoCompanyService;

        public CargoCompanyController(ICargoCustomerService cargoCompanyService)
        {
            this.cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var valuse = cargoCompanyService.TgetAllList();
            return Ok(valuse);
        }


        [HttpGet("{ıd}")]
        public IActionResult CargoCompanyByIdList(int id)
        {
            var valuse = cargoCompanyService.TGetById(id);
            return Ok(valuse);
        }

        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto cargoCompany)
        {
            CargoCompany cargo = new CargoCompany() 
            { 
                CargoCompanyName = cargoCompany.CargoCompanyName
            };
            cargoCompanyService.TInsert(cargo);
            return Ok("Başarılı şekilde kargo şirketi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCompany(int id)
        {
           
            cargoCompanyService.TDelete(id);
            return Ok("Başarılı şekilde kargo şirketi silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto cargoCompany)
        {
            CargoCompany cargo = new CargoCompany()
            {
                CargoCompanyId = cargoCompany.CargoCompanyId,
                CargoCompanyName = cargoCompany.CargoCompanyName
            };
            cargoCompanyService.TInsert(cargo);
            return Ok("Başarılı şekilde kargo şirketi güncellendi");
        }


    }
}
