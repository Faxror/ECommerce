using AutoMapper;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IMongoCollection<Product> productCollection;
        private readonly IMongoCollection<Category> categoryproduct;
        private readonly IMapper mapper;
        public ProductServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            categoryproduct = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProduct(CreateProductDto ProductDto)
        {
            var value = mapper.Map<Product>(ProductDto);
            await productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            var value = await productCollection.DeleteOneAsync(x => x.ProductID == id);
            
        }

        public async Task<GetByIdProductDto> GetAllByIdProductAsync(string id)
        {
           var values = await productCollection.Find<Product>(x=> x.ProductID == id).FirstOrDefaultAsync();
           return mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
           var valuex = await productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(valuex);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync()
        {
            var values = await productCollection.Find(x => true).ToListAsync();
            foreach (var value in values)
            {
                var categoryDto = await categoryproduct.Find<Category>(x => x.CategoryID == value.CategoryID).FirstOrDefaultAsync();
                value.Category = categoryDto != null ? new Category { CategoryName = categoryDto.CategoryName } : null;
            }

            return mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryByCategoryIdAsync(string CategoryId)
        {
            var values = await productCollection.Find(x => x.CategoryID == CategoryId).ToListAsync();
            foreach (var value in values)
            {
                var categoryDto = await categoryproduct.Find<Category>(x => x.CategoryID == value.CategoryID).FirstOrDefaultAsync();
                value.Category = categoryDto != null ? new Category { CategoryName = categoryDto.CategoryName } : null;
            }

            return mapper.Map<List<ResultProductWithCategoryDto>>(values);
        }

        public async Task UpdateProduct(UpdateProductDto ProductDto)
        {
            var value = mapper.Map<Product>(ProductDto);
            await productCollection.FindOneAndReplaceAsync(x => x.ProductID == ProductDto.ProductID, value);
        }
    }
}
