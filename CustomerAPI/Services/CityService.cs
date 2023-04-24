using CustomerAPI.Config;
using CustomerAPI.Models;
using MongoDB.Driver;

namespace CustomerAPI.Services
{
    public class CityService
    {
        private readonly IMongoCollection<City> _city;

        public CityService(IMongoDBSettings settings)
        {
            var city = new MongoClient(settings.ConnectionString);
            var database = city.GetDatabase(settings.DatabaseName);
            _city = database.GetCollection<City>(settings.CityCollectionName);
        }

        public List<City> Get() => _city.Find(c => true).ToList();

        public City Get(string id) => _city.Find(c => c.Id == id).FirstOrDefault();

        public City Create(City city)
        {
            _city.InsertOne(city);

            return city;
        }

        public void Update(string id, City city) => _city.ReplaceOne(c => c.Id == id, city);

        public void Delete(string id) => _city.DeleteOne(c => c.Id == id);
    }
}
