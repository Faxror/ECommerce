﻿using AutoMapper;
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

        public async Task<GetByIdCategoryDto> GetAllByIdCategoriesAsync(string id)
        {
            var value = await mongoCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
           return mapper.Map<GetByIdCategoryDto>(value);
        }

        public async  Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await mongoCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task UpdateCategory(UpdateCategoryDto CategoryDto)
        {
            var value = mapper.Map<Category>(CategoryDto);
            await mongoCollection.FindOneAndReplaceAsync(x => x.CategoryID == CategoryDto.CategoryID, value);
        }

    
    }
}
