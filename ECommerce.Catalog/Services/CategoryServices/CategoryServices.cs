using AutoMapper;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.CategoryServices
{
    public class CategoryServices : ICategoryServices
    {
        private readonly IMongoCollection<Category> mongoCollection;
        private readonly IMapper mapper;

        public CategoryServices(IMapper mapper, IDatabaseSettings _databasesettings)
        {
            var client = new MongoClient(_databasesettings.ConnectionString);
            var database = client.GetDatabase(_databasesettings.DatabaseName);
            mongoCollection = database.GetCollection<Category>(_databasesettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateCategory(CreateCategoryDto createCategoryDto)
        {
           var value = mapper.Map<Category>(createCategoryDto);
            await mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await mongoCollection.DeleteOneAsync(x => x.CategoryID == id);
        }

        public async Task<List<GetByIdCategoryDto>> GetAllByIdCategoriesAsync(string id)
        {
            var value = await mongoCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
           return mapper.Map<List<GetByIdCategoryDto>>(value);
        }

        public async Task<ResultCategoryDto> GetAllCategoryAsync()
        {
            var values = await mongoCollection.Find(x => true).ToListAsync();
            return mapper.Map<ResultCategoryDto>(values);
        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var value = mapper.Map<Category>(categoryDto);
            await mongoCollection.FindOneAndReplaceAsync(x => x.CategoryID == categoryDto.CategoryID, value);
        }
    }
}
