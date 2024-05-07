using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductImageServices
{
    public class ProductImageServices : IProductImageServies
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductImage> productCollection;


        public ProductImageServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            this.mapper = mapper;
        }
        public async Task CreateProductImage(CreateProductImageDto ProductDto)
        {
            var value = mapper.Map<ProductImage>(ProductDto);
            await productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            var value = await productCollection.DeleteOneAsync(x => x.ProductImageID == id);

        }

        public async Task<GetByIdProductImageDto> GetAllByIdProductImageAsync(string id)
        {
            var values = await productCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<GetByIdProductImageDto> GetAllByProductIdProductImageAsync(string id)
        {
            var values = await productCollection.Find<ProductImage>(x => x.ProductID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var valuex = await productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductImageDto>>(valuex);
        }

        public async Task UpdateProductImage(UpdateProductImageDto ProductDto)
        {
            var value = mapper.Map<ProductImage>(ProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductImageID == ProductDto.ProductImageID, value);
        }

  

       
    }
    }

