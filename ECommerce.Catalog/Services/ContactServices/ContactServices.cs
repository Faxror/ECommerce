using AutoMapper;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Services.ContactServices;
using ECommerce.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerce.Catalog.Services.CategoryServices
{
    public class ContactServices : IContactServices
    {
        private readonly IMongoCollection<Contact> mongoCollection;
        private readonly IMapper mapper;

        public ContactServices(IMapper mapper, IDatabaseSettings _databasesettings)
        {
            var client = new MongoClient(_databasesettings.ConnectionString);
            var database = client.GetDatabase(_databasesettings.DatabaseName);
            mongoCollection = database.GetCollection<Contact>(_databasesettings.ContactCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
           var value = mapper.Map<Contact>(createContactDto);
            await mongoCollection.InsertOneAsync(value);
        }

        public async Task DeleteContactAsync(string id)
        {
            await mongoCollection.DeleteOneAsync(x => x.ContactId == id);
        }

        public async Task<GetByIdContactDto> GetAllByIdContactAsync(string id)
        {
            var value = await mongoCollection.Find<Contact>(x => x.ContactId == id).FirstOrDefaultAsync();
           return mapper.Map<GetByIdContactDto>(value);
        }

        public async  Task<List<ResultContactDto>> GetAllContactAsync()
        {
            var values = await mongoCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultContactDto>>(values);
        }

        public async Task UpdateContact(UpdateContactDto ContactDto)
        {
            var value = mapper.Map<Contact>(ContactDto);
            await mongoCollection.FindOneAndReplaceAsync(x => x.ContactId == ContactDto.ContactId, value);
        }

    
    }
}
