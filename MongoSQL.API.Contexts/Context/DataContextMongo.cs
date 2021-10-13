namespace MongoSQL.API.Contexts.Context
{
    public class DataContextMongo: IDataContextMongo
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDataContextMongo
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
