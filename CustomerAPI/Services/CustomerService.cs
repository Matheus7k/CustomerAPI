using System.Net;
using CustomerAPI.Config;
using CustomerAPI.Models;
using MongoDB.Driver;

namespace CustomerAPI.Services
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customer;

        public CustomerService(IMongoDBSettings settings)
        {
            var address = new MongoClient(settings.ConnectionString);
            var database = address.GetDatabase(settings.DatabaseName);
            _customer = database.GetCollection<Customer>(settings.CustomerCollectionName);
        }

        public List<Customer> Get() => _customer.Find(c => true).ToList();

        public Customer Get(string id) => _customer.Find(c => c.Id == id).FirstOrDefault();

        public Customer Create(Customer customer)
        {
            _customer.InsertOne(customer);

            return customer;
        }

        public void Update(string id, Customer customer) => _customer.ReplaceOne(c => c.Id == id, customer);

        public void Delete(string id) => _customer.DeleteOne(c => c.Id == id);
    }
}
