using ECommerce.Cargo.BusinessLayer.Abstrack;
using ECommerce.Cargo.DtoLayer.CargoCustomerDto;
using ECommerce.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;

namespace ECommerce.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCostumerController : ControllerBase
    {
        private readonly ICargoCostumerService _cargoCostumerService;

        public CargoCostumerController(ICargoCostumerService cargoCostumerService)
        {
            _cargoCostumerService = cargoCostumerService;
        }

        [HttpGet]
        public IActionResult GetCargoCustomerList()
        {
            var valuse = _cargoCostumerService.TgetAllList();
            return Ok(valuse);
        }

        [HttpGet("{ıd}")]
        public IActionResult GetCargoCustomerByIdList(int id)
        {
            var valuse = _cargoCostumerService.TGetById(id);
            return Ok(valuse);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCostumer cargoCostumer = new CargoCostumer();
            cargoCostumer.Address = createCargoCustomerDto.Address;
            cargoCostumer.Phone = createCargoCustomerDto.Phone;
            cargoCostumer.Disctrict = createCargoCustomerDto.Disctrict;
            cargoCostumer.Email = createCargoCustomerDto.Email;
            cargoCostumer.Name = createCargoCustomerDto.Name;
            cargoCostumer.Surname = createCargoCustomerDto.Surname;
            cargoCostumer.City = createCargoCustomerDto.City;

            _cargoCostumerService.TInsert(cargoCostumer);
            return Ok("Başarılı şekilde kargo müşterisi eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCostumer(int id)
        {
            _cargoCostumerService.TDelete(id);
            return Ok("Başarılı şekilde kargo muşterisi silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCostumer cargoCostumer = new CargoCostumer();
            cargoCostumer.CargoCustomerId = updateCargoCustomerDto.CargoCustomerId;
            cargoCostumer.Address = updateCargoCustomerDto.Address;
            cargoCostumer.Phone = updateCargoCustomerDto.Phone;
            cargoCostumer.Disctrict = updateCargoCustomerDto.Disctrict;
            cargoCostumer.Email = updateCargoCustomerDto.Email;
            cargoCostumer.Name = updateCargoCustomerDto.Name;
            cargoCostumer.Surname = updateCargoCustomerDto.Surname;
            cargoCostumer.City = updateCargoCustomerDto.City;

            _cargoCostumerService.TUpdate(cargoCostumer);
            return Ok("Başarılı şekilde kargo müşterisi güncellendi");
        }
    }
}
