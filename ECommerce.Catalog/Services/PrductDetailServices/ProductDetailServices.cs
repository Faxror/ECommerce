using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.PrductDetailServices
{
    public class ProductDetailServices : IProductDetailServices
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductDetail> productCollection;

        public ProductDetailServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductDetail(CreateProductDetailDto ProductDto)
        {
            var value = mapper.Map<ProductDetail>(ProductDto);
            await productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            var value = await productCollection.DeleteOneAsync(x => x.ProductDetailID == id);

        }

        public async Task<GetByIdProductDetailDto> GetAllByIdProductDetailAsync(string id)
        {
            var values = await productCollection.Find<ProductDetail>(x => x.ProductDetailID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<GetByIdProductDetailDto> GetAllByProductIdProductDetailAsync(string id)
        {
            var values = await productCollection.Find<ProductDetail>(x => x.ProdcutID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var valuex = await productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(valuex);
        }

        public async Task UpdateProductDetail(UpdateProductDetailDto ProductDto)
        {
            var value = mapper.Map<ProductDetail>(ProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductDetailID == ProductDto.ProductDetailID, value);
        }
    }
}
