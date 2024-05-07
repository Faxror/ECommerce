using AutoMapper;
using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.FeatureSliderServices
{
    public class FeatureSliderServices : IFeatureSliderServices
    {
        private readonly IMongoCollection<FeatureSlider> mongoCollection;
        private readonly IMapper mapper;

        public FeatureSliderServices(IMapper mapper, IDatabaseSettings _databasesettings)
        {
            var client = new MongoClient(_databasesettings.ConnectionString);
            var database = client.GetDatabase(_databasesettings.DatabaseName);
            mongoCollection = database.GetCollection<FeatureSlider>(_databasesettings.FeatureSliderCollectionName);

            this.mapper = mapper;
        }

        public async Task CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var value = mapper.Map<FeatureSlider>(createFeatureSliderDto);
            await mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteFeatureSliderAsync(string id)
        {
            await mongoCollection.DeleteOneAsync(x => x.FeatureSliderId == id);
        }

        public Task FeatureSliderChageStatusToFalse(string id)
        {
            throw new NotImplementedException();
        }

        public Task FeatureSliderChageStatusToTrue(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetByIdFeatureSliderDto> GetAllByIdCategoriesAsync(string id)
        {
            var value = await mongoCollection.Find<FeatureSlider>(x => x.FeatureSliderId == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdFeatureSliderDto>(value);
        }

        public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
        {
            var values = await mongoCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultFeatureSliderDto>>(values);
        }

        public async Task UpdateFeatureSlider(UpdateFeatureSliderDto FeatureSliderDto)
        {
            var value = mapper.Map<FeatureSlider>(FeatureSliderDto);
            await mongoCollection.FindOneAndReplaceAsync(x => x.FeatureSliderId == FeatureSliderDto.FeatureSliderId, value);
        }
    }
}
