using AutoMapper;
using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferServices : ISpecialOfferServices
    {
        private readonly IMongoCollection<SpecialOffer> SpecialOfferCollection;

        private readonly IMapper mapper;
        public SpecialOfferServices(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            SpecialOfferCollection = database.GetCollection<SpecialOffer>(databaseSettings.SpecialOfferCollectionName);
           
            this.mapper = mapper;
        }

        public async Task CreateSpecialOffer(CreateSpecialOfferDto SpecialOfferDto)
        {
            var value = mapper.Map<SpecialOffer>(SpecialOfferDto);
            await SpecialOfferCollection.InsertOneAsync(value);
        }

        public async Task DeleteSpecialOfferAsync(string id)
        {
            var value = await SpecialOfferCollection.DeleteOneAsync(x => x.SpecialOfferId == id);
            
        }

        public async Task<GetByIdSpecialOfferDto> GetAllByIdSpecialOfferAsync(string id)
        {
           var values = await SpecialOfferCollection.Find<SpecialOffer>(x=> x.SpecialOfferId == id).FirstOrDefaultAsync();
           return mapper.Map<GetByIdSpecialOfferDto>(values);
        }

        public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
        {
           var valuex = await SpecialOfferCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultSpecialOfferDto>>(valuex);
        }

       
      

        public async Task UpdateSpecialOffer(UpdateSpecialOfferDto SpecialOfferDto)
        {
            var value = mapper.Map<SpecialOffer>(SpecialOfferDto);
            await SpecialOfferCollection.FindOneAndReplaceAsync(x => x.SpecialOfferId == SpecialOfferDto.SpecialOfferId, value);
        }
    }
}
