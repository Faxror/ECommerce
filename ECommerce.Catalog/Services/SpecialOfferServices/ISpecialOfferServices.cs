using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.SpecialOfferDtos;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferServices
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task CreateSpecialOffer(CreateSpecialOfferDto SpecialOfferDto);
        Task UpdateSpecialOffer(UpdateSpecialOfferDto SpecialOfferDto);
        Task DeleteSpecialOfferAsync(string id);

        Task<GetByIdSpecialOfferDto> GetAllByIdSpecialOfferAsync(string id);



    }
}
