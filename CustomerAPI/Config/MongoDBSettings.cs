namespace CustomerAPI.Config
{
    public class MongoDBSettings : IMongoDBSettings
    {
        public string CityCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CustomerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
