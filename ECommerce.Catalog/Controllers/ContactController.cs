using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactServices _ContactServices;

        public ContactController(IContactServices ContactServices)
        {
            _ContactServices = ContactServices;
        }

        [HttpGet]
        public async Task<IActionResult> ContactGetList()
        {
            var valuese = await _ContactServices.GetAllContactAsync();
            return Ok(valuese);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ContactByIdList(string id)
        {
            var valuse = await _ContactServices.GetAllByIdContactAsync(id);
            return Ok(valuse);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategories(CreateContactDto createContactDto)
        {
            await _ContactServices.CreateContact(createContactDto);
            return Ok("Başarılı şekilde eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategories(string id)
        {
            await _ContactServices.DeleteContactAsync(id);
            return Ok("Başarılı şekilde silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategories(UpdateContactDto updateContactDto)
        {
            await _ContactServices.UpdateContact(updateContactDto);
            return Ok("Başarılı şekilde güncellendi");
        }
    }
}
