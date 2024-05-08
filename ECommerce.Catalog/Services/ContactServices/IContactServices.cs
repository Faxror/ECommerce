using ECommerce.Catalog.Dtos.ContactDtos;

namespace ECommerce.Catalog.Services.ContactServices
{
    public interface IContactServices
    {
        Task<List<ResultContactDto>> GetAllContactAsync();
        Task CreateContact(CreateContactDto createContactDto);
        Task UpdateContact(UpdateContactDto ContactDto);
        Task DeleteContactAsync(string id);

        Task<GetByIdContactDto> GetAllByIdContactAsync(string id);

   
    }
}
