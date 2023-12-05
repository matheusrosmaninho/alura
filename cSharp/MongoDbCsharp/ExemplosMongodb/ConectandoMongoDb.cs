using MongoDB.Driver;

namespace ExemplosMongodb;

public class ConectandoMongoDb
{
    public const string CONNECTION_STRING = "mongodb://localhost:27017";
    public const string DATABASE_NAME = "Biblioteca";
    public const string COLLECTION_NAME = "Livros";

    private static IMongoClient? _client;
    private static IMongoDatabase? _database;

    public ConectandoMongoDb()
    {
        _client = new MongoClient(CONNECTION_STRING);
        _database = _client.GetDatabase(DATABASE_NAME);
    }

    public IMongoClient? Cliente
    {
        get { return _client; }
    }

    public IMongoCollection<Livro> Livros => _database!.GetCollection<Livro>(COLLECTION_NAME);
}