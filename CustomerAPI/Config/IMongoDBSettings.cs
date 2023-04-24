namespace CustomerAPI.Config
{
    public interface IMongoDBSettings
    {
        string CityCollectionName { get; set; }
        string AddressCollectionName { get; set; }
        string CustomerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
