using Platform.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Platform.Services
{
    public class PlatformService
    {
        private readonly IMongoCollection<Api> _Api;

        public PlatformService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Api = database.GetCollection<Api>(settings.CollectionName);
        }

        public List<Api> Get() =>
            _Api.Find(api => true).ToList();

        public Api Get(string id) =>
            _Api.Find<Api>(api => api.Id == id).FirstOrDefault();

        public Api Create(Api api)
        {
            _Api.InsertOne(api);
            return api;
        }

        public void Update(string id, Api apiIn) =>
            _Api.ReplaceOne(api => api.Id == id, apiIn);

        public void Remove(Api apiIn) =>
            _Api.DeleteOne(api => api.Id == apiIn.Id);

        public void Remove(string id) => 
            _Api.DeleteOne(api => api.Id == id);
    }
}