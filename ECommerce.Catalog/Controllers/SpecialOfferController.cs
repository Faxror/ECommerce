using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOfferController : ControllerBase
    {
        private readonly ISpecialOfferServices _SpecialOfferServices;

        public SpecialOfferController(ISpecialOfferServices SpecialOfferServices)
        {
            _SpecialOfferServices = SpecialOfferServices;
        }

        [HttpGet]
        public async Task<IActionResult> SpecialOfferGetList()
        {
            var valuese = await _SpecialOfferServices.GetAllSpecialOfferAsync();
            return Ok(valuese);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SpecialOfferByIdList (string id)
        {
            var valuse = await _SpecialOfferServices.GetAllByIdSpecialOfferAsync(id);
            return Ok(valuse);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateSpecialOfferDto createSpecialOfferDto)
        {
          await  _SpecialOfferServices.CreateSpecialOffer(createSpecialOfferDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await _SpecialOfferServices.DeleteSpecialOfferAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _SpecialOfferServices.UpdateSpecialOffer(updateSpecialOfferDto);
            return Ok("Başarılı şekilde güncellendi");
        }

    }
}
